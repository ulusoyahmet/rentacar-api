using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RentACarAPI.Application.Services
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services,
            IConfiguration configurations)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof
                (ServiceRegistration).Assembly));
            
        }
    }
}
