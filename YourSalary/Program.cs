using YourSalary.Services;
using Microsoft.EntityFrameworkCore;
using YourSalary.Data;

namespace YourSalary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();


            // Register our custom service
            builder.Services.AddScoped<SalaryComparisonService>();
            builder.Services.AddScoped<AthleteService>();


            var dbConnectionString = builder.Configuration.GetConnectionString("SalaryDbConnectionString");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(dbConnectionString));


            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();
                DbInitializer.Initialize(context);
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();



            app.UseSession(); // ???? ??????????? ?????????? ?? ?????????????



            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
