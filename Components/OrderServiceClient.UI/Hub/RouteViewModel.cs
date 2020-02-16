using System.Collections.Generic;
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
        public ObservableCollection<Route> Routes { get; set; }
        private Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;

        public event PropertyChangedEventHandler PropertyChanged;

        public RouteViewModel(OrderServiceApiClient client)
        {
            _client = client;
            Routes = new ObservableCollection<Route>();
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

                var data = result.Select(r => new Route
                {
                    Id = Routes.Count,
                    ExternalId = r.ExternalId,
                    Date = r.Date,
                    Num = r.Num,
                    Priority = r.Priority,
                    Quantity = r.Quantity,
                    Seats = r.Seats,
                    OrdersCount = r.Orders.Count
                }).ToList();
                var t = Routes.ToList();
                data.AddRange(t);

                Routes = new ObservableCollection<Route>(data);
        });
        }

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            GetData();
            
        }
    }
}