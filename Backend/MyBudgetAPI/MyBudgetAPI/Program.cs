
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBudget.BLL.Interface;
using MyBudget.BLL.Repository;
using MyBudgetAPI.Context;
using MyBudgetAPI.Models;
using MyBudgetSystem.Data.Repositories;

namespace MyBudgetAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IIncomeRpository, IncomeRepository>();



            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
               options =>
               {
                   options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1); // 1 hr
                   options.Lockout.MaxFailedAccessAttempts = 5; // 5 tries 
                   options.Lockout.AllowedForNewUsers = true;  // lock it if 5 times wrong password 

                   // password setting )
                   options.Password.RequireDigit = true;
                   options.Password.RequiredLength = 8;
                   options.Password.RequireNonAlphanumeric = true;
                   options.Password.RequireUppercase = true;
                   options.Password.RequireLowercase = true;
                   // User settings
                   options.User.RequireUniqueEmail = true;
               }
               )
               .AddEntityFrameworkStores<ApplicationDbContext>();


            builder.Services.AddAuthentication();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

                
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
