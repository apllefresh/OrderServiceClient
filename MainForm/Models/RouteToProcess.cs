using System;
using System.Collections.Generic;
using System.Text;

namespace MainForm.Models
{
    public class RouteToProcess
    {
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public int Priority { get; set; }
        public int Num { get; set; }
        public DateTime Date { get; set; }
        public int OrdersCount { get; set; }
        public int Quantity { get; set; }
        public int Seats { get; set; }
    }
}
