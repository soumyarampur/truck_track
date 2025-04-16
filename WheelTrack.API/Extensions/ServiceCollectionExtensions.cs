using WheelTrack.Core.Factories;
using WheelTrack.Core.Repositories;
using WheelTrack.Core.Services;
using WheelTrack.DAL.Factories;
using WheelTrack.DAL.Repositories;
using WheelTrack.Service.Services;

namespace WheelTrack.API.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IDbConnectionFactory, DbConnectionFactory>();
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<IOrganizationRepository, OrganizationRepository>();
            services.AddTransient<IDriverService, DriverService>();
            return services;
        }

    }
}
