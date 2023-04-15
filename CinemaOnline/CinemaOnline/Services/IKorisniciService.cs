using CinemaOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaOnline.Services
{
    public interface IKorisniciService
    {
        (Korisnici user, bool ShowDropdown) GetUser(HttpContext httpContext);

        void Add(Korisnici korisnik);

        Korisnici GetByEmailAndPassword(Korisnici korisnik);

    }

}
