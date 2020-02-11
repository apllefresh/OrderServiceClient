using System.Windows;
using OrderServiceClient.MessageBroker.Contract.Services;

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
            InitializeComponent();
        }
    }
}
