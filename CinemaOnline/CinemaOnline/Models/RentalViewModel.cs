using MessagePack;

namespace CinemaOnline.Models
{
    public class RentalViewModel
    {
        public int FilmId { get; set; } 
        public string? Email { get; set; }   
        public DateTime? Datum { get; set; }
        public string? Ime { get; set; }
        public string? Cena { get; set; }
    }
}
