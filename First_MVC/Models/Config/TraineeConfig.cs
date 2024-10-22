using First_MVC.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class TraineeConfig : IEntityTypeConfiguration<Trainee>
{
    public void Configure(EntityTypeBuilder<Trainee> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.ImageURL).IsRequired();
        builder.Property(x => x.Grade).HasColumnType("int").IsRequired();
        builder.Property(x => x.Address).IsRequired();
       
        builder.HasOne(x => x.Department)
               .WithMany(x => x.Trainees)
               .HasForeignKey(x => x.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);

        //Seeding more data for Trainee

       builder.HasData(
            new Trainee { Id = 4, Name = "Michael Johnson", Grade = 30, ImageURL = "4.jpg", Address = "101 Trainee Ln", DepartmentId = 1 },
            new Trainee { Id = 5, Name = "Sophia Williams", Grade = 60, ImageURL = "5.jpg", Address = "202 Learning Rd", DepartmentId = 2 }
       );

       builder.ToTable("Trainee");
    }
}
