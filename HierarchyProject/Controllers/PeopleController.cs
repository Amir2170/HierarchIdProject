using HierarchyProject.Data;
using HierarchyProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace HierarchyProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly MyAppContext _myAppContext; 

        public PeopleController(MyAppContext context)
        {
            _myAppContext = context;
        }

        [HttpGet("getDepthFirst")]
        //GET: /people/getDepthFirst
        // get all people in tree depth first traversal
        public IEnumerable<Person> GetDepthFirst()
        {
           return ReturnDepthFirst();
        }

        [HttpGet("getBreathFirst")]
        //GET: /people/getBreadthFirst
        // get all people in tree breadth first traversal
        public IEnumerable<Person> GetBreadthFirst()
        {
            return ReturnBreadthFirst();
        }

        [HttpPost]
        //POST: /people
        // add a new child to the end of given parent children
        public IActionResult AddChild(int parentId, string name, int yearOfBirth)
        {
            // find parent according to id
            var parent = _myAppContext.People.Find(parentId);

            // return bad request if parent doesn't exists
            if(parent == null)
            {
                return BadRequest(error: "parent doesn't exists");
            }

            // find last child of the given parent
            var lastChild = _myAppContext.People.Where(
                people => people.PathToPatriarch.GetAncestor(1) == parent.PathToPatriarch)
                .Max(people => people.PathToPatriarch);

            // add child to the given parent 
            _myAppContext.People.Add(
                new Person(
                    parent.PathToPatriarch.GetDescendant(lastChild, null),
                    name,
                    yearOfBirth
                )
            );

            // save changes
            _myAppContext.SaveChanges();

            // return ok when successfull adding
            return Ok();
        }

        //DELETE : people/{id}
        // deletes person with given id if unsuccessfull return bad request
        [HttpDelete("id")]
        public IActionResult Delete(int personId)
        {
            var person = _myAppContext.People.Find(personId);

            if (person == null)
            {
                return BadRequest(error: "person with given id does not exists");
            }

            var descendants = _myAppContext.People.Where(
                people => people.PathToPatriarch.IsDescendantOf(person.PathToPatriarch));

            _myAppContext.People.RemoveRange(descendants);

            _myAppContext.SaveChanges();

            return Ok();
        }

        //GET: people/findDepthFirst/{name}
        [HttpGet("findDepthFirst/{name}")]
        public IActionResult FindDepthFirst(string name) {
            
            var people = ReturnDepthFirst();

            foreach(Person person in people)
            {
                if (person.Name.ToLower() == name.ToLower()) return Ok(person);
            }

            return BadRequest(error: "person with given id not found");
        }

        //GET: people/findBreadthFirst/{name}
        [HttpGet("findBreadthFirst/{name}")]
        public IActionResult FindBreadthFirst(string name)
        {
            var people = ReturnBreadthFirst();

            foreach (Person person in people)
            {
                if (person.Name.ToLower() == name.ToLower()) return Ok(person);
            }

            return BadRequest(error: "person with given id not found");
        }

        // return people in depth first order
        private IEnumerable<Person> ReturnDepthFirst()
        {
            return _myAppContext.People
                .OrderBy(people => people.PathToPatriarch)
                .ToList();
        }

        // return people in breadth first order
        private IEnumerable<Person> ReturnBreadthFirst()
        {
            return _myAppContext.People
                .OrderBy(people => people.Level)
                .ToList();
        }
    }
}
