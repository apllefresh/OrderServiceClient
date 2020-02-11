using Microsoft.Extensions.DependencyInjection;
using OrderServiceClient.MessageBroker.Contract.Services;
using OrderServiceClient.MessageBroker.RabbitMq.Services;

namespace OrderServiceClient.MessageBroker.DI
{
    public static class MessageBrokerServiceRegistration
    {
        public static IServiceCollection AddMessageBrokerServices(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBrokerService, RabbitMqMessageBrokerService>();

            return services;
        }
    }
}