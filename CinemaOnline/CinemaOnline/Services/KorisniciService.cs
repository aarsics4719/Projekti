using CinemaOnline.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaOnline.Services
{
    public class KorisniciService : IKorisniciService
    {
        private readonly MovieRentalContext _context;

        public KorisniciService(MovieRentalContext context)
        {
            _context = context;
        }

        public void Add(Korisnici korisnik)
        {
            _context.Korisnicis.Add(korisnik);
            _context.SaveChanges();
        }

        public Korisnici GetByEmailAndPassword(Korisnici korisnik)
        {
            var data = _context.Korisnicis.Where(x => x.Email.Equals(korisnik.Email) && x.Password.Equals(korisnik.Password)).SingleOrDefault();
            return data;
        }

        public (Korisnici user, bool ShowDropdown) GetUser(HttpContext httpContext)
        {
            var userId = httpContext.Session.GetInt32("Sesija");
            var user = _context.Korisnicis.FirstOrDefault(x => x.KorisniciId == userId);
            bool ShowDropdown = false;
            

            if (user != null && user.Role == "Admin")
            {
                ShowDropdown = true;
            }
            

            return (user, ShowDropdown);
        }
    }
}
