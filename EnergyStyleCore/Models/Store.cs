namespace EnergyStyleCore.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string PlaceName { get; set; } // название места
        public string Address { get; set; } // Адрес места
        public string LocalPhone { get; set; } // телефон именно этого магаза
        public string Email { get; set; } // e-mail именно этого магаза
        public string WorkTime { get; set; } // часы работы
        public double GeoLong { get; set; } // долгота - для карт google
        public double GeoLat { get; set; } // широта - для карт google
    }
}
