using First_MVC.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class CrsResultConfig : IEntityTypeConfiguration<CrsResult>
{
    public void Configure(EntityTypeBuilder<CrsResult> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Degree).IsRequired();

        builder.HasOne(x => x.Trainee)
               .WithMany(x => x.CrsResults)
               .HasForeignKey(x => x.TraineeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.Course)
               .WithMany(o => o.CrsResults)
               .HasForeignKey(o => o.CourseId)
               .OnDelete(DeleteBehavior.Restrict);

        // Seeding more data for CrsResult
        builder.HasData(
     new CrsResult { Id = 1, Degree = 95, CourseId = 1, TraineeId = 1 },
     new CrsResult { Id = 2, Degree = 88, CourseId = 2, TraineeId = 2 },
     new CrsResult { Id = 3, Degree = 92, CourseId = 3, TraineeId = 3 }
 );


        builder.ToTable("CrsResult");
    }
}
