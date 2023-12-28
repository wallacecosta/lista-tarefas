using ListaTarefas.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ListaTarefas.Repositories
{
    public static class DepedencyInjection
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(x =>
            {
                var connectionString = configuration.GetConnectionString("AppConnection");
                x.UseSqlServer(connectionString);
            });
        }
    }
}
