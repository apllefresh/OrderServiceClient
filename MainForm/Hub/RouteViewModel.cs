using MainForm.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MainForm.Hub
{
    public class RouteViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<RouteToProcess> Routes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public RouteViewModel()
        {
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
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            foreach (var routeToProcess in GetData())
            {
                Routes.Add(routeToProcess);
            }
        }
    }
}
