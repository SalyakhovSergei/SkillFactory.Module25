using Microsoft.EntityFrameworkCore;
using SkillFactory.Module25.Models;

namespace SkillFactory.Module25
{
    public class AppContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Database=EF.Skillfactory_Module24;Trusted_Connection=True");
        }  
        
    }
}