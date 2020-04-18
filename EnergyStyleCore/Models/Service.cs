using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyStyleCore.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public List<string> Image { get; set; }
        public string Info { get; set; }

    }
}
