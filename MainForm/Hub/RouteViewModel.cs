using MainForm.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MainForm.Hub
{
    public class RouteViewModel : INotifyPropertyChanged
    {
        HubConnection hubConnection;

        public string UserName { get; set; }
        public string Message { get; set; }
        // список всех полученных сообщений
        public ObservableCollection<RouteToProcess> Messages { get; }

        // идет ли отправка сообщений
        bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    OnPropertyChanged("IsBusy");
                }
            }
        }
        // осуществлено ли подключение
        bool isConnected;
        public bool IsConnected
        {
            get => isConnected;
            set
            {
                if (isConnected != value)
                {
                    isConnected = value;
                    OnPropertyChanged("IsConnected");
                }
            }
        }
        // команда отправки сообщений
        //public Command SendMessageCommand { get; }

        public RouteViewModel()
        {
            // создание подключения
            hubConnection = new HubConnectionBuilder()
                .WithUrl("http://192.168.0.103:3000/chat")
                .Build();

            Messages = new ObservableCollection<RouteToProcess>();

            IsConnected = false;    // по умолчанию не подключены
            IsBusy = false;         // отправка сообщения не идет

            //SendMessageCommand = new Command(async () => await SendMessage(), () => IsConnected);

            hubConnection.Closed += async (error) =>
            {
                SendLocalMessage(String.Empty, "Подключение закрыто...");
                IsConnected = false;
                await Task.Delay(5000);
                await Connect();
            };

            hubConnection.On<string, string>("Receive", (user, message) =>
            {
                SendLocalMessage(user, message);
            });
        }
        // подключение к чату
        public async Task Connect()
        {
            if (IsConnected)
                return;
            try
            {
                await hubConnection.StartAsync();
                SendLocalMessage(String.Empty, "Вы вошли в чат...");

                IsConnected = true;
            }
            catch (Exception ex)
            {
                SendLocalMessage(String.Empty, $"Ошибка подключения: {ex.Message}");
            }
        }

        // Отключение от чата
        public async Task Disconnect()
        {
            if (!IsConnected)
                return;

            await hubConnection.StopAsync();
            IsConnected = false;
            SendLocalMessage(String.Empty, "Вы покинули чат...");
        }

        // Отправка сообщения
        async Task SendMessage()
        {
            try
            {
                IsBusy = true;
                await hubConnection.InvokeAsync("Send", UserName, Message);
            }
            catch (Exception ex)
            {
                SendLocalMessage(String.Empty, $"Ошибка отправки: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
        // Добавление сообщения
        private void SendLocalMessage(string user, string message)
        {
            Messages.Insert(0, new RouteToProcess
            { 
                Id = 1,
                Date = DateTime.Now,
                ExternalId = 1,
                Num = 1,
                OrdersCount = 1,
                Priority = 1,
                Quantity = 1,
                Seats = 1
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
