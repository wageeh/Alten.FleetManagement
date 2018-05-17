using Core.BaseRepository;
using Core.ErrorHandler;
using Microsoft.Extensions.DependencyInjection;

namespace Core.SQLRepository
{
    public static class SQLHelper
    {
        public static string connection = @"Server=.;Database=AltenVehicleDB;Trusted_Connection=True;ConnectRetryCount=4";
    }
}
