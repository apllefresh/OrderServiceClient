using System.Windows;
using OrderServiceClient.UI.DI;

namespace OrderServiceClient.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            UiServiceRegistration.RegisterServices();
        }
    }
}
