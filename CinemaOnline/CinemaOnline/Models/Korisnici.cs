using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaOnline.Models;

public partial class Korisnici
{

    [Key]
    public int KorisniciId { get; set; }

    [Required]
    [DataType(DataType.Text, ErrorMessage ="Can't be empty!")]
    public string? Email { get; set; }
    
    [Required]
    [DataType(DataType.Password, ErrorMessage = "Can't be empty!")]
    public string? Password { get; set; }

    public string? Role { get; set; }
    public virtual ICollection<Rentum> Renta { get; } = new List<Rentum>();

    public virtual ICollection<Rejting> Rejtings { get; } = new List<Rejting>();

}
