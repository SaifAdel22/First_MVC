﻿// <auto-generated />
using First_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace First_MVC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241015000201_degINnum")]
    partial class degINnum
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("First_MVC.Models.Entity.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<int>("MinDegree")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Course", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Degree = 85,
                            DepartmentId = 1,
                            Hours = 45,
                            MinDegree = 50,
                            Name = "Human Resource Management"
                        },
                        new
                        {
                            Id = 2,
                            Degree = 90,
                            DepartmentId = 2,
                            Hours = 50,
                            MinDegree = 60,
                            Name = "Advanced IT Systems"
                        },
                        new
                        {
                            Id = 3,
                            Degree = 88,
                            DepartmentId = 3,
                            Hours = 40,
                            MinDegree = 55,
                            Name = "Operating Systems"
                        });
                });

            modelBuilder.Entity("First_MVC.Models.Entity.CrsResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("TraineeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TraineeId");

                    b.ToTable("CrsResult", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Degree = 95,
                            TraineeId = 1
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 2,
                            Degree = 88,
                            TraineeId = 2
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 3,
                            Degree = 92,
                            TraineeId = 3
                        });
                });

            modelBuilder.Entity("First_MVC.Models.Entity.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ManagerName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ManagerName = "John Doe",
                            Name = "Human Resources"
                        },
                        new
                        {
                            Id = 2,
                            ManagerName = "Jane Smith",
                            Name = "IT"
                        },
                        new
                        {
                            Id = 3,
                            ManagerName = "Ahmed Salah",
                            Name = "OS"
                        });
                });

            modelBuilder.Entity("First_MVC.Models.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 HR Lane",
                            DepartmentId = 1,
                            ImageURL = "1.jpg",
                            JobTitle = "HR Manager",
                            Name = "Alice Johnson",
                            salary = 50000
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 IT Street",
                            DepartmentId = 2,
                            ImageURL = "2.jpg",
                            JobTitle = "Software Developer",
                            Name = "Bob Williams",
                            salary = 60000
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 IT Blvd",
                            DepartmentId = 2,
                            ImageURL = "3.jpg",
                            JobTitle = "IT Manager",
                            Name = "Charlie Brown",
                            salary = 70000
                        });
                });

            modelBuilder.Entity("First_MVC.Models.Entity.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Instructor", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            CourseId = 1,
                            DepartmentId = 1,
                            ImageURL = "1.jpg",
                            Name = "Alice Johnson",
                            Salary = 60000m
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 University Ave",
                            CourseId = 2,
                            DepartmentId = 2,
                            ImageURL = "2.jpg",
                            Name = "Bob Williams",
                            Salary = 65000m
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 College Rd",
                            CourseId = 3,
                            DepartmentId = 3,
                            ImageURL = "3.jpg",
                            Name = "Charlie Davis",
                            Salary = 70000m
                        });
                });

            modelBuilder.Entity("First_MVC.Models.Entity.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Trainee", (string)null);
                });

            modelBuilder.Entity("First_MVC.Models.Entity.Course", b =>
                {
                    b.HasOne("First_MVC.Models.Entity.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("First_MVC.Models.Entity.CrsResult", b =>
                {
                    b.HasOne("First_MVC.Models.Entity.Course", "Course")
                        .WithMany("CrsResults")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("First_MVC.Models.Entity.Trainee", "Trainee")
                        .WithMany("CrsResults")
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("First_MVC.Models.Entity.Employee", b =>
                {
                    b.HasOne("First_MVC.Models.Entity.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("First_MVC.Models.Entity.Instructor", b =>
                {
                    b.HasOne("First_MVC.Models.Entity.Course", "Course")
                        .WithMany("instructors")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("First_MVC.Models.Entity.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("First_MVC.Models.Entity.Trainee", b =>
                {
                    b.HasOne("First_MVC.Models.Entity.Department", "Department")
                        .WithMany("Trainees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("First_MVC.Models.Entity.Course", b =>
                {
                    b.Navigation("CrsResults");

                    b.Navigation("instructors");
                });

            modelBuilder.Entity("First_MVC.Models.Entity.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Employees");

                    b.Navigation("Instructors");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("First_MVC.Models.Entity.Trainee", b =>
                {
                    b.Navigation("CrsResults");
                });
#pragma warning restore 612, 618
        }
    }
}
