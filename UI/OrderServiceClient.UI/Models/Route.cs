using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OrderServiceClient.UI.Models
{
    public class Route : INotifyPropertyChanged
    {
        private int _id;
        private int _externalId;
        private int _priority;
        private int _num;
        private int _ordersCount;
        private int _quantity;
        private int _seats;
        private IReadOnlyCollection<BoxingOrder> _orders;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public int ExternalId {
            get => _externalId;
            set
            {
                _externalId = value;
                OnPropertyChanged("ExternalId");
            }
        }
        public int Priority {
            get => _priority;
            set
            {
                _priority = value;
                OnPropertyChanged("Priority");
            }
        }
        public int Num {
            get => _num;
            set
            {
                _num = value;
                OnPropertyChanged("Num");
            }
        }
        public DateTime Date { get; set; }
        public int OrdersCount {
            get => _ordersCount;
            set
            {
                _ordersCount = value;
                OnPropertyChanged("OrdersCount");
            }
        }
        public int Quantity {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
        public int Seats 
        {
            get => _seats;
            set
            {
                _seats = value;
                OnPropertyChanged("Seats");
            }
        }

        public IReadOnlyCollection<BoxingOrder> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged("Orders");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
