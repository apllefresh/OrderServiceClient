using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OrderServiceClient.UI.Models
{
    public class Section : INotifyPropertyChanged
    {
        private int _id;
        private string _name;


        public int SectionId
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("SectionId");
            }
        }

        public string SectionName
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("SectionName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}