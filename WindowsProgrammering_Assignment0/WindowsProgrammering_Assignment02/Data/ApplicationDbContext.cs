using WindowsProgrammering_Assignment02.Models;

namespace WindowsProgrammering_Assignment02.Data
{
    using System.Data.Entity;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}