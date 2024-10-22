using First_MVC.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class CourseConfig : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x=>x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired();
        builder.HasIndex(c => c.Name).IsUnique();
        builder.Property(x => x.Degree).IsRequired();
        builder.Property(x => x.MinDegree).IsRequired();
        builder.Property(x => x.Hours).IsRequired();
        builder.HasOne(x => x.Department)
               .WithMany(x => x.Courses)
               .HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict);

        // Seeding more data for Course
        builder.HasData(
     new Course { Id = 1, Name = "Human Resource Management", Degree = 85, MinDegree = 50, Hours = 45, DepartmentId = 1 },
     new Course { Id = 2, Name = "Advanced IT Systems", Degree = 90, MinDegree = 60, Hours = 50, DepartmentId = 2 },
     new Course { Id = 3, Name = "Operating Systems", Degree = 88, MinDegree = 55, Hours = 40, DepartmentId = 3 }
 );


        builder.ToTable("Course");
    }
}
