using Microsoft.EntityFrameworkCore;
using HierarchyProject.Entities;


namespace HierarchyProject.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options)
            : base(options) { }

        // People model context Dbset
        public DbSet<Person> People { get; set; }
    }
}
