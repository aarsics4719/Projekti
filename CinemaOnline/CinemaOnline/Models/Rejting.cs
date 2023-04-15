using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaOnline.Models;

public partial class Rejting
{
    
    [Key]
    public int RejtingId { get; set; }

    public int FilmId { get; set; }

    public int KorisniciId { get; set; }

    public string? Email { get; set; }

    public int rejting { get; set; }

    public string? komentar { get; set; }

    public virtual Filmovi? Filmovi { get; set; }

    public virtual Korisnici? Korisnici { get; set; }




}

