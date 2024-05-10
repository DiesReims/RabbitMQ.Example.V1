using Consumer.Application.Features.MessageFeatures.Command.CreateMessage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Consumer.Application
{
    public static class ApplicationServiceRegistration
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Commands
            services.AddScoped<CreateMessageCommand>();
            //Queries
            return services;
        }
    }
}
