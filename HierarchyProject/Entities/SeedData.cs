using HierarchyProject.Data;
using Microsoft.EntityFrameworkCore;

namespace HierarchyProject.Entities
{
    public static class SeedData
    {
        public static void initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyAppContext(
                serviceProvider.GetRequiredService
                <DbContextOptions<MyAppContext>>()))
            {
                // Look for any people instance in db
                if(context.People.Any())
                {
                    return; // do not initialize again
                }

                context.People.AddRange(
                    new Person(HierarchyId.Parse("/"), "Balbo", 1167),
                    new Person(HierarchyId.Parse("/1/"), "Mungo", 1207),
                    new Person(HierarchyId.Parse("/2/"), "Pansy", 1212),
                    new Person(HierarchyId.Parse("/3/"), "Ponto", 1216),
                    new Person(HierarchyId.Parse("/4/"), "Largo", 1220),
                    new Person(HierarchyId.Parse("/5/"), "Lily", 1222),
                    new Person(HierarchyId.Parse("/1/1/"), "Bungo", 1246),
                    new Person(HierarchyId.Parse("/1/2/"), "Belba", 1256),
                    new Person(HierarchyId.Parse("/1/3/"), "Longo", 1260),
                    new Person(HierarchyId.Parse("/1/4/"), "Linda", 1262),
                    new Person(HierarchyId.Parse("/1/5/"), "Bingo", 1264),
                    new Person(HierarchyId.Parse("/3/1/"), "Rosa", 1256),
                    new Person(HierarchyId.Parse("/3/2/"), "Polo"),
                    new Person(HierarchyId.Parse("/4/1/"), "Fosco", 1264),
                    new Person(HierarchyId.Parse("/1/1/1/"), "Bilbo", 1290),
                    new Person(HierarchyId.Parse("/1/3/1/"), "Otho", 1310),
                    new Person(HierarchyId.Parse("/1/5/1/"), "Falco", 1303),
                    new Person(HierarchyId.Parse("/3/2/1/"), "Posco", 1302),
                    new Person(HierarchyId.Parse("/3/2/2/"), "Prisca", 1306),
                    new Person(HierarchyId.Parse("/4/1/1/"), "Dora", 1302),
                    new Person(HierarchyId.Parse("/4/1/2/"), "Drogo", 1308),
                    new Person(HierarchyId.Parse("/4/1/3/"), "Dudo", 1311),
                    new Person(HierarchyId.Parse("/1/3/1/1/"), "Lotho", 1310),
                    new Person(HierarchyId.Parse("/1/5/1/1/"), "Poppy", 1344),
                    new Person(HierarchyId.Parse("/3/2/1/1/"), "Ponto", 1346),
                    new Person(HierarchyId.Parse("/3/2/1/2/"), "Porto", 1348),
                    new Person(HierarchyId.Parse("/3/2/1/3/"), "Peony", 1350),
                    new Person(HierarchyId.Parse("/4/1/2/1/"), "Frodo", 1368),
                    new Person(HierarchyId.Parse("/4/1/3/1/"), "Daisy", 1350),
                    new Person(HierarchyId.Parse("/3/2/1/1/1/"), "Angelica", 1381));

                context.SaveChanges();

            }
        }
    }
}
