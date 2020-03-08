using System;
using System.Collections.Generic;

namespace ClientApi.Models
{
    public class Route
    {
        public Route(
            int id,
            int externalId,
            int priority,
            int num,
            DateTime date,
            int numberOfOrders,
            int quantity,
            int seats,
            int statusId,
            DateTime? timeStart,
            DateTime? timeFinish)
        {
            Id = id;
            ExternalId = externalId;
            Priority = priority;
            Num = num;
            Date = date;
            NumberOfOrders = numberOfOrders;
            Quantity = quantity;
            Seats = seats;
            StatusId = statusId;
            TimeStart = timeStart;
            TimeFinish = timeFinish;
            Orders = new List<Order>();
        }

        public int Id { get; }
        public int ExternalId { get; }
        public int Priority { get; }
        public int Num { get; }
        public DateTime Date { get; }
        public int NumberOfOrders { get; }
        public int Quantity { get; }
        public int Seats { get; }
        public int StatusId { get; }

        public DateTime? TimeStart { get; }
        public DateTime? TimeFinish { get; }

        public List<Order> Orders { get; }
    }
}