

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infraestructure.Presistance.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfraestructurePersistanceLayer(this IServiceCollection services, IConfiguration confi)
        {
            return services;
        }
    }
}
