using System.Reflection;
using Application;
using Infrastrucure.Repostories;

namespace API.Extention
{
    public static class ServiceExtension
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGRepository<>), typeof(GRepository<>));
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationLayer).Assembly);
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<GlobalExceptionHandler, GlobalExceptionHandler>();
        }
    }
}
