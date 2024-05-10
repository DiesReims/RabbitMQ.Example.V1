using Consumer.Infraestructure.Entities;
using Consumer.Infraestructure.Persistence;
using Consumer.Infraestructure.Persistence.Interfaces;
using Consumer.Infraestructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Consumer.Infraestructure
{
    public static class InfraestructureServiceRegistration
    {
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MongoDBConnection>();
            //Repositories
            services.AddSingleton<IAsyncRepository<Message>, BaseRepository<Message>>();
            services.AddSingleton<MessageRepository>();
            return services;
        }
    }
}
