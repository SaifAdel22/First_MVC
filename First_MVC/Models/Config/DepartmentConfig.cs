using First_MVC.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace First_MVC.Models.Config
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired();
			builder.Property(x => x.ManagerName).HasColumnType("varchar(50)").IsRequired();

			// Seeding data for Department
			builder.HasData(
				new Department { Id = 1, Name = "Human Resources", ManagerName = "John Doe" },
				new Department { Id = 2, Name = "IT", ManagerName = "Jane Smith" },
				new Department { Id = 3, Name = "OS", ManagerName = "Ahmed Salah" }
			);

			builder.HasMany(x => x.Employees)
				.WithOne(x => x.Department)
				.HasForeignKey(x => x.DepartmentId);

			builder.ToTable("Department");
		}
	}
}
