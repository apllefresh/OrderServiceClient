using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApi.Models
{
    public class Order
    {
        public int Id { get; }
        public int ExternalId { get; }
        public string Code { get; }
        public string Name { get; }
        public string Address { get; }
        public int Priority { get; }
        public int Num { get; }
        public DateTime Date { get; }
        public int Quantity { get; }
        public int Seats { get; }

        public int RouteId { get; }
        public List<Product> Products { get; }
    }
}
