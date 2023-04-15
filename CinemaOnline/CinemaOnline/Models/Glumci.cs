using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaOnline.Models;

public partial class Glumci
{
    [Key]
    public int GlumciId { get; set; }

    public string? Ime { get; set; }

    public DateTime? DatumRodjenja { get; set; }

    public string? ZemljaPorekla { get; set; }

    public string? Nagrade { get; set; }

    public virtual ICollection<Filmovi> Filmovis { get; } = new List<Filmovi>();
}
