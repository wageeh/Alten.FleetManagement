﻿
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VehicleTracker.Repository;

namespace VehicleTracker.API
{
    public class Startup
    {
        public static string botURL;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            botURL = Configuration.GetSection("VechicleBotAPI").Value;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            Installer.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
                {
                    Installer.Configure(serviceScope);
                    //serviceScope.ServiceProvider.GetService<ISeedService>().SeedDatabase().Wait();
                }
            }
            catch (System.Exception ex)
            {
                // I'm using Serilog here, but use the logging solution of your choice.
                throw ex;

            }


        }
    }
}
