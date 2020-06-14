using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyStyleCore.Models.Classes
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }

        public List<string> Images
        {
            get;
            set;
        }
        public string Info { get; set; }
    }
}
