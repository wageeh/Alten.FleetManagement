using Core.BaseRepository;
using Core.ErrorHandler;
using FleetManager.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManager.Repository
{
    public static class Installer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // for init db context             
            services.AddDbContext<FleetManagerContext>(opt => opt.UseSqlServer(SQLHelper.connection));

            services.AddScoped<IBaseRepository<Client>, SQLRepository<Client>>();
            services.AddScoped<IBaseRepository<Vehicle>, SQLRepository<Vehicle>>();
            services.AddScoped<IErrorHandler, ErrorMessage>();
        }


        public static void Configure(IServiceScope serviceScope)
        {
            serviceScope.ServiceProvider.GetService<FleetManagerContext>().Database.Migrate();
            
        }
    }
}
