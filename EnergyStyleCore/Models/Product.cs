using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyStyleCore.Models
{
    public class Product
    {
        public Product(Category category) {
            Category = category;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Model { get; set; }
        public int Count { get; set; }
        public List<string> Images { get; private set; } = new List<string>();

        public Category Category { get;private  set; }

        public ICharasteristic Charasteristic { get; set; }
    }
}
