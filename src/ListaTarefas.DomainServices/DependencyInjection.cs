using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ListaTarefas.DomainServices
{
    public static class DependencyInjection
    {
        public static void AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(scan =>
            {
                scan.FromCallingAssembly()
                    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            });
        }
    }
}
