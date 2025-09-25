using Shoping_Card_DB_Connection.DataAccess;
using Shoping_Card_DB_Connection.Databases;

namespace MVC_Shoping_Card
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register your data access dependency
            builder.Services.AddScoped<ISqlData, SqlData>();
            builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();

            builder.Services.AddAuthentication("Cookies")
                            .AddCookie("Cookies", options =>
                            {
                                options.LoginPath = "/Account/Login";
                                options.AccessDeniedPath = "/Account/AccessDenied";
                            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
