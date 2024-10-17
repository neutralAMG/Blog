

using Blog.Core.Application.Features.Application.Blogs.Blogs.Interfaces;
using Blog.Infraestructure.Presistance.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infraestructure.Presistance.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfraestructurePersistanceLayer(this IServiceCollection services, IConfiguration confi)
        {

            services.AddTransient<IBlogRepository, BlogRepository>();
            return services;
        }
    }
}
