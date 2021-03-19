using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PartyManager.Application;
using PartyManager.Application.Main;
using PartyManager.Application.Shared.CQRS;
using PartyManager.DAL;
using PartyManager.WebUI.Data;

namespace PartyManager.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.BindCQRSPipeline();
            services.RegisterDataProviders();
            services.AddSingleton<IApplicationLayer, ApplicationLayer>();

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddSingleton<PartySummaryService>();
            services.AddSingleton<PartyAdminService>();
            services.AddSingleton<PeopleService>();
            services.AddSingleton<PersonAdminService>();
            services.AddSingleton<DrinksService>();

            services.AddMvc()
                    .AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
