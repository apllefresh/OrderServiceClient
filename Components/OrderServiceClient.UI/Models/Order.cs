using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OrderServiceClient.UI.Models
{
    public class Order : INotifyPropertyChanged
    {
        private int _id;
        private int _externalId;
        private string _code;
        private string _name;
        private string _address;
        private int _priority;
        private int _num;
        private int _quantity;
        private int _seats;
        

        public int OrderId
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("OrderId");
            }
        }
        public int OrderExternalId
        {
            get => _externalId;
            set
            {
                _externalId = value;
                OnPropertyChanged("OrderExternalId");
            }
        }
        public string OrderCode
        {
            get => _code;
            set
            {
                _code = value;
                OnPropertyChanged("OrderCode");
            }
        }
        public string OrderName
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("OrderName");
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }
        public int OrderPriority
        {
            get => _priority;
            set
            {
                _priority = value;
                OnPropertyChanged("OrderPriority");
            }
        }
        public int OrderNum
        {
            get => _num;
            set
            {
                _num = value;
                OnPropertyChanged("OrderNum");
            }
        }
        public DateTime OrderDate { get; }
        public int OrderQuantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged("OrderQuantity");
            }
        }
        public int OrderSeats
        {
            get => _seats;
            set
            {
                _seats = value;
                OnPropertyChanged("OrderSeats");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
