using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApi.Models
{
    public class Section
    {
        public Section(int id, string name)
        {
            Id = id;
            Name = name;
            Products = new List<Product>();
        }

        public int Id { get; }
        public string Name { get; }
        public List<Product> Products { get; }
    }
}
