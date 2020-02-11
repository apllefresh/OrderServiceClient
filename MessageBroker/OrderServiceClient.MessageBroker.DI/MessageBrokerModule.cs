using Autofac;
using OrderServiceClient.MessageBroker.Contract.Services;
using OrderServiceClient.MessageBroker.RabbitMq.Services;

namespace OrderServiceClient.MessageBroker.DI
{
    public class MessageBrokerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RabbitMqMessageBrokerService>()
                .As<IMessageBrokerService>()
                .SingleInstance();
        }
    }
}