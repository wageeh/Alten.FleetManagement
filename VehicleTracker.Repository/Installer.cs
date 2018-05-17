using Core.BaseRepository;
using Core.Entites;
using Core.ErrorHandler;
using Core.SQLRepository;
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
            services.AddDbContext<BaseContext>(opt => opt.UseSqlServer(SQLHelper.connection));

            services.AddTransient<IBaseRepository<VehicleStatus>, SQLRepository<VehicleStatus>>();
            services.AddTransient<IBaseRepository<Vehicle>, SQLRepository<Vehicle>>();
            services.AddTransient<IErrorHandler, ErrorMessage>();
        }
    }
}
