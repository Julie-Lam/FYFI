using Fyfi.Application;
using Fyfi.Application.Services;
using FyFi.Domain.Interfaces;
using FyFi.Infrastructure;
using FyFi.Infrastructure.DatabaseLayer;
using FyFi.WebUI.Components;

namespace FyFi.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            //Register dependencies
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();


            builder.Services.AddSingleton<IRepository, Repository>();
            builder.Services.AddSingleton<IMonthlyCaptureService, MonthlyCaptureService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
     