using CompanyEmployees.Configuration;
using CompanyEmployees.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.Repository {
    public class RepositoryContext : DbContext {
        public RepositoryContext(DbContextOptions options) : base(options) {}

        //seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

        public DbSet<Company> companies {get; set;}
        public DbSet<Employee> Employees {get; set;}
    }
}
