using EmployeeApps.Api;
using EmployeeApps.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeApps.Api.Models.Builders
{
    public class DepartmentBuilder : IEntityTypeConfiguration<Department>
    {
        private readonly SqlDBContext _context;

        public DepartmentBuilder(SqlDBContext context)
        {
            _context = context;
        }
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.IsDeleted);

            //data seed
            builder.HasData(
                new Department { Id = 1, Name = "Information Technology", CreateDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Department { Id = 2, Name = "Human Resource", CreateDate = new DateTime(2024, 1, 1), IsDeleted = false },
                new Department { Id = 3, Name = "Finance", CreateDate = new DateTime(2024, 1, 1), IsDeleted = false }
            );
        }
    }
}
