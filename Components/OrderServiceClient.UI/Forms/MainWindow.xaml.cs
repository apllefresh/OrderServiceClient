using System.Windows;
using System.Windows.Threading;
using ClientApi;
using OrderServiceClient.MessageBroker.Contract.Services;
using OrderServiceClient.UI.Hub;

namespace OrderServiceClient.UI.Forms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMessageBrokerService _messageBrokerService;
        private readonly OrderServiceApiClient _client;
        private Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;

        public MainWindow(IMessageBrokerService messageBrokerService, OrderServiceApiClient client)
        {
            InitializeComponent();
            _messageBrokerService = messageBrokerService;
            _client = client;
            
            var model = new RouteViewModel(_client);
             
            messageBrokerService.SubscribeForNewRoutes(() =>
            {
                model.OnPropertyChanged("Routes");
                
            });
            model.PropertyChanged += ((e,o) =>
            {
                _dispatcher.Invoke(() => phonesList.Items.Refresh());
                });
            DataContext = model;
            
        }
    }
}
