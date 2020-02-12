using System.Windows;
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
        
        public MainWindow(IMessageBrokerService messageBrokerService, OrderServiceApiClient client)
        {
            _messageBrokerService = messageBrokerService;
            _client = client;
            
            var model = new RouteViewModel(_client);
            messageBrokerService.SubscribeForNewRoutes(() => model.OnPropertyChanged() );
            DataContext = model;
            InitializeComponent();
        }
    }
}
