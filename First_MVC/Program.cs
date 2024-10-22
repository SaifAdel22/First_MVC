using First_MVC.Filter;
using First_MVC.Models;
using First_MVC.Models.Entity;
using First_MVC.Models.Idenity;
using First_MVC.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace First_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            //builder.Services.AddControllersWithViews(options => 
            //{
            //    options.Filters.Add(new HandleErrorattribute());
            //    });
            builder.Services.AddControllersWithViews();
           builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            builder.Services.AddScoped<IEmployeeRepository , EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository , DepartmentRepository>();
            builder.Services.AddScoped<ICourseRepository , CourseRepository>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
            }
            ).AddEntityFrameworkStores<AppDbContext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseSession();


            app.UseRouting();
            app.UseAuthentication();


            app.UseAuthorization();


            #region Custm Middleware"inline Middlewa"

            //app.Use(async (httpContext, Next) =>
            //{
            //    await httpContext.Response.WriteAsync("1)Middleware 1\n");
            //    await Next.Invoke();
            //    await httpContext.Response.WriteAsync("1)Middleware 1--\n");

            //    //
            //});
            //app.Use(async (httpContext, Next) =>
            //{
            //    await httpContext.Response.WriteAsync("2)Middleware 2\n");
            //    await Next.Invoke();
            //    await httpContext.Response.WriteAsync("2)Middleware 2-----\n");

            //});
            //app.Run(async (httpContext) =>
            //{
            //    await httpContext.Response.WriteAsync("3)Terminate\n");

            //});
            //app.Use(async (httpContext, Next) =>
            //{
            //    await httpContext.Response.WriteAsync("4)Middleware 4\n");
            //    await Next.Invoke();
            //    //
            //});
            #endregion

            //DEcalre & execute
            //naming confinatoin Route (Defain rout with name ,pattern ,default )
            //constrint
            //Optianl segment
            //app.MapControllerRoute("Route1", "R1/{name}/{age:int}/{color?}",
            //    new { controller = "Route", action = "Method1" }
            //    );
            //app.MapControllerRoute("Route2", "R2",
            //   new { controller = "Route", action = "Method2" }
            //   );



            //app.MapControllerRoute("Route1", "{controller=Route}/{action=Method1}");


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
