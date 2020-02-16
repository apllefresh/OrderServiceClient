using System;
using System.Collections.Generic;

namespace ClientApi.Models
{
    public class Route
    {
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

        public List<Order> Orders { get; set; }
    }
}