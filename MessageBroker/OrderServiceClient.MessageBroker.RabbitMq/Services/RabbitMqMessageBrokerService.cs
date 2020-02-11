using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using OrderServiceClient.MessageBroker.Contract.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace OrderServiceClient.MessageBroker.RabbitMq.Services
{
    public class RabbitMqMessageBrokerService : IMessageBrokerService, IDisposable
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IConnection _connection;
        private readonly Dictionary<ChanelType, IModel> _channels;

        public RabbitMqMessageBrokerService()
        {
            _connectionFactory = new ConnectionFactory() { HostName = "localhost" };
            _connection = _connectionFactory.CreateConnection();
            _channels = new Dictionary<ChanelType, IModel>
            {
                {ChanelType.GetNewRoutes, _connection.CreateModel()}
            };
        }

        public void SubscribeForNewRoutes(Action action)
        {
            //_logger.LogDebug("Open connection");
            try
            {
                var channel = _channels[ChanelType.GetNewRoutes];

                channel.QueueDeclare(queue: "RefreshRouteTable",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                consumer.Received += (sender, args) => action.Invoke();
                
                channel.BasicConsume(queue: "RefreshRouteTable",
                    autoAck: true,
                    consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
            catch (RabbitMQ.Client.Exceptions.BrokerUnreachableException ex)
            {
                //_logger.LogError($"Failed connect to RabbitMQ server");
                //_logger.LogError(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Failed to send notification");
                //_logger.LogError(ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            foreach (var chanel in _channels)
            {
                chanel.Value.Dispose();
            }
            _connection?.Dispose();
        }
    }
}