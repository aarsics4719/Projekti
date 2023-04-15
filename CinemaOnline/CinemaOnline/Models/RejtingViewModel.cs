namespace CinemaOnline.Models
{
    public class RejtingViewModel
    {
        public int FilmId { get; set; }
        public string? Email { get; set; }
        public string? Ime { get; set; }
        public string? Zanr { get; set; }
        public string? Opis { get; set; }
        public int? Godina { get; set; }
        public decimal? Ocena { get; set; }
        public string? Trajanje { get; set; }

        public string? Slika { get; set; }
        public string? Cena { get; set; }
        public decimal? rejting { get; set; }
        public string? komentar { get; set; }
        public int? LikoviId { get; set; }
        public int? GlumciId { get; set; }
        public IEnumerable<Likovi>? Likovis { get; set; }
        public IEnumerable<Glumci>? Glumcis { get; set; }
    }

}
