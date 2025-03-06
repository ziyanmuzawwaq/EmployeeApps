using EmployeeApps.Api.Models.Builders;
using EmployeeApps.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApps.Api
{
    public class SqlDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public SqlDBContext(DbContextOptions<SqlDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new EmployeeBuilder(this).Configure(modelBuilder.Entity<Employee>());
            new DepartmentBuilder(this).Configure(modelBuilder.Entity<Department>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ZIYAN\\SQLEXPRESS;Database=DbEmployee;Integrated Security=SSPI;TrustServerCertificate=True")
                              .EnableSensitiveDataLogging();
            }
        }
    }
}
