using System.Data.Entity;
using TestProject.Models;

namespace TestTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<MyEntity> MyEntities { get; set; }
    }
}
