using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DbEntites.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VehicleTracker.API.Repository;

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
            // for init db context 
            services.AddDbContext<StatusContext>(opt => opt.UseSqlServer(Helper.connection));
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
