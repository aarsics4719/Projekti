using CinemaOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace CinemaOnline.Services
{
    public class RentalService : IRentalService
    {
        private readonly MovieRentalContext _context;

        public RentalService(MovieRentalContext context)
        {
            _context = context;
        }

        public void Add(Rentum rentum)
        {
            _context.Renta.Add(rentum);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var delete = _context.Renta.FirstOrDefault(x => x.RentaId == id);
            if (delete != null)
            {
                _context.Renta.Remove(delete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Rentum> GetAll()
        {
            var svePorudzbine = _context.Renta.ToList();
            return svePorudzbine;
        }

        public Rentum GetById(int id)
        {
            var data = _context.Renta.Include(r => r.Korisnici).Include(r => r.Film).FirstOrDefault(x => x.RentaId == id);
            return data;
        }
    }
}
