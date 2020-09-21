using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using clean_api_architecture.infrastructure.Config.Database;
using clean_api_architecture.infrastructure.Repositories.Implementations;

namespace clean_api_architecture.infrastructure.Config.Helpers
{
    public static class InfrastructureService 
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services){
            services.AddSingleton<IDatabaseSettings, DatabaseSettings>();
            services.AddSingleton<IBookRepository, BookRepository>();
            return services;
        }
    }
}