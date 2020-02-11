using Autofac;
using OrderServiceClient.MessageBroker.Contract.Services;
using OrderServiceClient.MessageBroker.DI;
using OrderServiceClient.UI.Forms;

namespace OrderServiceClient.UI.DI
{
    public static class UiServiceRegistration
    {
        public static void RegisterServices()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<MessageBrokerModule>();
            var container = builder.Build();
            var messageBrokerService = container.Resolve<IMessageBrokerService>();

            var view = new MainWindow(messageBrokerService);
            view.Show();
        }
    }
}