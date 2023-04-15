using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaOnline.Models;

public partial class Rentum
{
    [Key]
    public int RentaId { get; set; }

    public int? FilmId { get; set; }

    public int? KorisniciId { get; set; }

    public DateTime? Datum { get; set; }


    public virtual Filmovi? Film { get; set; }

    public virtual Korisnici? Korisnici { get; set; }

}
