using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyStyleCore.Models.Classes
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Model { get; set; } = string.Empty;
        public int Count { get; set; }

        public List<string> Images {
            get;
            set; 
        }

        public Category Category { get; set; }

        public ICollection<Characteristic> Characteristics { get; set; }
    }
}
