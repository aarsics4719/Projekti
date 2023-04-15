using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaOnline.Models;

public partial class Likovi
{

    [Key]
    public int LikoviId { get; set; }

    public string? Ime { get; set; }

    public virtual ICollection<Filmovi> Filmovis { get; } = new List<Filmovi>();

}
