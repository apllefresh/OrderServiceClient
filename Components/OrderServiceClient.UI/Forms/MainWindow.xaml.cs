using System.Windows;
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
        
        public MainWindow(IMessageBrokerService messageBrokerService)
        {
            _messageBrokerService = messageBrokerService;
            var model = new RouteViewModel();
            messageBrokerService.SubscribeForNewRoutes(() => model.OnPropertyChanged() );
            DataContext = model;
            InitializeComponent();
        }
    }
}
