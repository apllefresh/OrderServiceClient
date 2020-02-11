using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OrderServiceClient.UI.Models
{
    public class RouteToProcess: INotifyPropertyChanged
    {
        public int Id
        {
            get => Id;
            set
            {
                Id = value;
                OnPropertyChanged("Id");
            }
        }
        public int ExternalId { get; set; }
        public int Priority { get; set; }
        public int Num { get; set; }
        public DateTime Date { get; set; }
        public int OrdersCount { get; set; }
        public int Quantity { get; set; }
        public int Seats { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
