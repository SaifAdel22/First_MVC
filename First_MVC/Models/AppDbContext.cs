using First_MVC.Models.Entity;
using First_MVC.Models.Idenity;
using First_MVC.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace First_MVC.Models
{
	public class AppDbContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<CrsResult> CrsResults { get; set; }
		public DbSet<Trainee> Trainees { get; set; }
		//public DbSet<InstructorCourse> InstructorCourses { get; set; }

		public AppDbContext() : base() { }
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				// Hardcode the connection string here
				var connectionString = "Server=.;Database=TheMVC_Single_Instructor;Integrated Security=SSPI;TrustServerCertificate=True;MultipleActiveResultSets=True";

				optionsBuilder.UseSqlServer(connectionString);
			}
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegisterViewModel>().HasNoKey();
            modelBuilder.Entity<LoginUserViewModel>().HasNoKey();
            modelBuilder.Entity<RoleViewModel>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
	    public DbSet<First_MVC.ViewModel.RegisterViewModel> RegisterViewModel { get; set; } = default!;
	    public DbSet<First_MVC.ViewModel.LoginUserViewModel> LoginUserViewModel { get; set; } = default!;
	    public DbSet<First_MVC.ViewModel.RoleViewModel> RoleViewModel { get; set; } = default!;

    }
}
