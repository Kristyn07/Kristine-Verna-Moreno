//new
using KristineVernaMorenoV1._2.Models;

namespace KristineVernaMorenoV1._2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            var builder = WebApplication.CreateBuilder(args);
            // Add configuration to the container
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                 .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

            // Bind SMTP configuration section to SMTPSettings
            builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SMTP"));

            builder.Services.AddControllersWithViews(); 

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            
        }

       
    }
}