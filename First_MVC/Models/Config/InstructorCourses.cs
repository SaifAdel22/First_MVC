//using First_MVC.Models.Entity;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;

//namespace First_MVC.Models.Config
//{
//    public class InstructorCourses : IEntityTypeConfiguration<InstructorCourse>
//    {
//        public void Configure(EntityTypeBuilder<InstructorCourse> builder)
//        {
//            builder.HasKey(ci => new { ci.CourseId, ci.InstructorId });

//            builder.HasOne(ci => ci.Course)
//                 .WithMany(c => c.InstructorCourses)
//                 .HasForeignKey(ci => ci.CourseId)
//                 .OnDelete(DeleteBehavior.Restrict);


//            builder.HasOne(ci => ci.Instructor)
//                .WithMany(i => i.InstructorCourses)
//                .HasForeignKey(ci => ci.InstructorId)
//                .OnDelete(DeleteBehavior.Restrict);

//            builder.HasData(
//    new InstructorCourse { CourseId = 1, InstructorId = 1 },
//    new InstructorCourse { CourseId = 2, InstructorId = 2 },
//    new InstructorCourse { CourseId = 3, InstructorId = 3 }
//);




//            builder.ToTable("InstructorCourses");
//        }
    
//    }
//}
