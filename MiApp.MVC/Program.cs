using Api.Consummer;
using MiAPI.UTN.Modelos;

namespace MiApp.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Crud<Cargo>.Endpoint = "https://localhost:7133/api/Cargos";
            Crud<Persona>.Endpoint = "https://localhost:7133/api/Personas";
            Crud<Empleado>.Endpoint = "https://localhost:7133/api/Empleados";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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