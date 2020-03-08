using Autofac;
using ClientApi;
using OrderServiceClient.MessageBroker.Contract.Services;
using OrderServiceClient.MessageBroker.DI;
using OrderServiceClient.UI.Forms;

namespace OrderServiceClient.UI.DI
{
    public static class UiServiceRegistration
    {
        public static void RegisterServices()
        {
            var url = @"http://localhost:37770/api/route/";
            
            var builder = new ContainerBuilder();

            builder.RegisterModule<MessageBrokerModule>();
            builder.RegisterType<OrderServiceApiClient>()
                .AsSelf()
                .WithParameter("url", url)
                .SingleInstance();
                
            var container = builder.Build();
            var messageBrokerService = container.Resolve<IMessageBrokerService>();
            var client = container.Resolve<OrderServiceApiClient>();

            var view = new MainWindow(messageBrokerService, client);
            view.Show();
        }
    }
}