using Microsoft.EntityFrameworkCore;
using RunForLive.Entities;
using RunForLive.Services;

namespace RunForLive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //add service cloudinary
            builder.Services.AddSingleton<CloudinaryService>();


            //add connect db
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<RunforliveContext>(ops =>
            {
                ops.UseSqlServer(connectionString);
            });
            using (var scope = builder.Services.BuildServiceProvider().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<RunforliveContext>();

                // Chạy truy vấn SQL
                var userCount = context.Accounts.Count();
                Console.WriteLine($"Số lượng tài khoản trong hệ thống: {userCount}");
            }
            //turn on MVC (Controller + View)
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //add static file(wwwroot)
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Event}/{action=Index}/{id?}");

            app.MapControllers();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            app.MapRazorPages();

            app.Run();
        }
    }
}
