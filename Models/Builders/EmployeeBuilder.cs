using EmployeeApps.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeApps.Api.Models.Builders
{
    public class EmployeeBuilder : IEntityTypeConfiguration<Employee>
    {
        private readonly SqlDBContext _context;

        public EmployeeBuilder(SqlDBContext context)
        {
            _context = context;
        }
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.IsDeleted);

            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            //data seed
            builder.HasData(
                new Employee { Id = 1, Name = "Adi", CreateDate = new DateTime(2024, 1, 1), IsDeleted = false, DepartmentId = 1 },
                new Employee { Id = 2, Name = "Abi", CreateDate = new DateTime(2024, 1, 1), IsDeleted = false, DepartmentId = 2 },
                new Employee { Id = 3, Name = "Aji", CreateDate = new DateTime(2024, 1, 1), IsDeleted = false, DepartmentId = 3 }
            );
        }
    }
}
