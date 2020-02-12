using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Threading;
using ClientApi;
using OrderServiceClient.UI.Models;

namespace OrderServiceClient.UI.Hub
{
    public class RouteViewModel : INotifyPropertyChanged
    {
        private readonly OrderServiceApiClient _client;
        public ObservableCollection<RouteToProcess> Routes { get; set; }
        private Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;

        public event PropertyChangedEventHandler PropertyChanged;

        public RouteViewModel(OrderServiceApiClient client)
        {
            _client = client;
            Routes = new ObservableCollection<RouteToProcess>();
            GetData();
        }

        private void GetData()
        {
            _dispatcher.Invoke(() =>
            {

                var result = Task.Run(async () =>
                        await _client.GetRoutesToProcess(1, 200)
                            .ConfigureAwait(false))
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                var data = result.Select(r => new RouteToProcess
                {
                    Id = r.Id,
                    ExternalId = r.ExternalId,
                    Date = r.Date,
                    Num = r.Num,
                    Priority = r.Priority,
                    Quantity = r.Quantity,
                    Seats = r.Seats,
                    OrdersCount = r.OrdersCount
                }).ToList();


               
                    var t = Routes.ToList<RouteToProcess>();
                    data.AddRange(t);
                
                Routes = new ObservableCollection<RouteToProcess>(data);
            });
        }

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //_dispatcher.Invoke(() => GetData());
            GetData();
        }
    }
}