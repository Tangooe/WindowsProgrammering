using Exercise01.Models;

namespace Exercise01.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationDbContext : DbContext
    {
        // Your context has been configured to use a 'ApplicationDb' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Exercise01.Data.ApplicationDb' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ApplicationDb' 
        // connection string in the application configuration file.
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Language> Languages { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Applicant>().HasMany(a => a.Languages).WithMany(l => l.Applicants);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}