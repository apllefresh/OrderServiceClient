using System;

namespace OrderServiceClient.MessageBroker.Contract.Services
{
    public interface IMessageBrokerService
    {
        void SubscribeForNewRoutes(Action action);
    }
}