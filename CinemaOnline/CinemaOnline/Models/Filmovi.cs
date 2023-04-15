using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaOnline.Models;

public partial class Filmovi
{

    [Key]
    public int FilmId { get; set; }

    public string? Ime { get; set; }

    public string? Zanr { get; set; }

    public string? Opis { get; set; }

    public int? Godina { get; set; }

    public decimal? Ocena { get; set; }

    public string? Trajanje { get; set; }

    public string? Slika { get; set; }

    public string? Cena { get; set; }

    public int? GlumciId { get; set; }

    public int? LikoviId { get; set; }

    public virtual Likovi? Likovi { get; set; }

    public virtual Glumci? Glumci { get; set; }

    public virtual ICollection<Rentum> Renta { get; } = new List<Rentum>();

    public virtual ICollection<Rejting> Rejtings { get; } = new List<Rejting>();

}
