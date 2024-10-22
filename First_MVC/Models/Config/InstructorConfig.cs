using First_MVC.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

public class InstructorConfig : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.ImageURL).IsRequired();
        builder.Property(x => x.Salary).IsRequired();
        builder.Property(x => x.Address).IsRequired();

        
       

        builder.HasOne(x => x.Department)
                    .WithMany(x => x.Instructors)
                    .HasForeignKey(x => x.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict); // Change cascade delete to NoAction

        builder.HasOne(x => x.Course).WithMany(x => x.instructors).HasForeignKey(x => x.CourseId).OnDelete(DeleteBehavior.Restrict);

        // Configure foreign key to Course with NO ACTION on delete


        // Seeding more data for Instructor
        builder.HasData(
    new Instructor { Id = 1, Name = "Alice Johnson", ImageURL = "1.jpg", Salary = 60000, Address = "123 Main St", DepartmentId = 1 ,CourseId =1 },
    new Instructor { Id = 2, Name = "Bob Williams", ImageURL = "2.jpg", Salary = 65000, Address = "456 University Ave", DepartmentId = 2 , CourseId =2 },
    new Instructor { Id = 3, Name = "Charlie Davis", ImageURL = "3.jpg", Salary = 70000, Address = "789 College Rd", DepartmentId = 3 , CourseId = 3 }
);



        builder.ToTable("Instructor");
    }
}
