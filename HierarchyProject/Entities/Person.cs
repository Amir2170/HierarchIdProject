using Microsoft.EntityFrameworkCore;

namespace HierarchyProject.Entities
{
    public class Person
    {
        public Person(HierarchyId pathToPatriarch, string name, int? yearOfBirth = null) {
            PathToPatriarch = pathToPatriarch;
            Name = name;
            YearOfBirth = yearOfBirth;
            Level = pathToPatriarch.GetLevel();
        }
        public int Id { get; private set; }
        public string Name { get; set; }   
        public HierarchyId PathToPatriarch { get; set; }
        public int? YearOfBirth { get; set; }

        public int Level { get; set; }
    }
}
