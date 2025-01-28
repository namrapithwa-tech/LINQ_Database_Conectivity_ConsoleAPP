using Microsoft.EntityFrameworkCore;

namespace LINQ_Database_Conectivity_ConsoleAPP
{
    //DbContext class – it is responsible to communicate with database
    //DbSet - Represents the collection of all entities in the context, or that can be queried from the database, of a given type.
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=AKSHAT\SQLEXPRESS;Database=LINQ_DB_EX; Trusted_Connection=true;TrustServerCertificate=True;");
        }
    }
}
