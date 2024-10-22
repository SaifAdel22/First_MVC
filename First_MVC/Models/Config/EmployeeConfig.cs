using First_MVC.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace First_MVC.Models.Config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
			builder.Property(x => x.salary).IsRequired();
			builder.Property(x => x.ImageURL).IsRequired();
			builder.Property(x => x.Address);
			builder.Property(x => x.JobTitle).HasColumnType("varchar(50)").IsRequired();
            builder.HasOne(x => x.Department).WithMany(x => x.Employees).HasForeignKey(x => x.DepartmentId);

            // Seeding data for Employee
            builder.HasData(
				new Employee
				{
					Id = 1,
					Name = "Alice Johnson",
					salary = 50000,
					JobTitle = "HR Manager",
					ImageURL = "1.jpg",
					Address = "123 HR Lane",
					DepartmentId = 1 // HR Department
				},
				new Employee
				{
					Id = 2,
					Name = "Bob Williams",
					salary = 60000,
					JobTitle = "Software Developer",
					ImageURL = "2.jpg",
					Address = "456 IT Street",
					DepartmentId = 2 // IT Department
				},
				new Employee
				{
					Id = 3,
					Name = "Charlie Brown",
					salary = 70000,
					JobTitle = "IT Manager",
					ImageURL = "3.jpg",
					Address = "789 IT Blvd",
					DepartmentId = 2 // IT Department
				}
			);

			builder.ToTable("Employee");
		}
	}
}
