using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using OrderServiceClient.UI.Models;

namespace OrderServiceClient.UI.Hub
{
    public class RouteViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<RouteToProcess> Routes { get; set; }
        private Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;

        public event PropertyChangedEventHandler PropertyChanged;

        public RouteViewModel()
        {
            Routes = new ObservableCollection<RouteToProcess>();
            foreach (var routeToProcess in GetData())
            {
                Routes.Add(routeToProcess);
            }
        }

        private IReadOnlyCollection<RouteToProcess> GetData()
        {
            return new[]
            {
                new RouteToProcess()
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Num = 1,
                    Priority = 1,
                    Quantity = 1,
                    Seats = 1,
                    ExternalId = 1,
                    OrdersCount = 1
                }
            };
        }
        
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            foreach (var routeToProcess in GetData())
            {
                _dispatcher.Invoke(()=> Routes.Add(routeToProcess));
            }
        }
    }
}
