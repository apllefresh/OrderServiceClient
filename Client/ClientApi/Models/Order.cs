using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApi.Models
{
    public class Order
    {
        public Order(
                  int id,
                  string code,
                  string name,
                  string address,
                  int priority,
                  int num,
                  DateTime date,
                  int quantity,
                  int seats,
                  int routeId,
                  int externalId)
        {
            Id = id;
            Code = code;
            Name = name;
            Address = address;
            Priority = priority;
            Num = num;
            Date = date;
            Quantity = quantity;
            Seats = seats;
            RouteId = routeId;
            ExternalId = externalId;
            Products = new List<Product>();
            Sections = new List<Section>();
        }

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
        public List<Section> Sections { get; }
    }
}
