﻿using Core.BaseRepository;
using Core.Entites;
using Core.ErrorHandler;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleTracker.DTO;

namespace VehicleTracker.Repository
{
    public static class Installer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // for init db context             
            services.AddDbContext<SQLContext>(opt => opt.UseSqlServer(SQLHelper.connection));
            
            services.AddScoped<IBaseRepository<VehicleStatus>, SQLRepository<VehicleStatus>>();
            services.AddScoped<IBaseRepository<Vehicle>, SQLRepository<Vehicle>>();
            services.AddScoped<IErrorHandler, ErrorMessage>();
        }
    }
}
