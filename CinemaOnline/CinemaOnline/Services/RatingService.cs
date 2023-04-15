using CinemaOnline.Models;

namespace CinemaOnline.Services
{
    public class RatingService : IRatingService
    {
        private readonly MovieRentalContext _context;

        public RatingService(MovieRentalContext context)
        {
            _context = context;
        }
        public void Add(Rejting rejting)
        {
            _context.Rejtings.Add(rejting);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var delete = _context.Rejtings.FirstOrDefault(r => r.RejtingId == id);
            _context.Rejtings.Remove(delete);
            _context.SaveChanges();
        }

        public IEnumerable<Rejting> GetAll()
        {
            var savRejting = _context.Rejtings.ToList();
            return savRejting;
        }

        public Rejting GetByFilmAndUser(int FilmId, int KorisniciId)
        {
            var FilmAndUser = _context.Rejtings.FirstOrDefault(r => r.FilmId == FilmId && r.KorisniciId == KorisniciId);
            return FilmAndUser;
        }

        public Rejting GetById(int id)
        {
            var rejting = _context.Rejtings.FirstOrDefault(r => r.RejtingId == id);
            return rejting;
        }

        public Rejting Update(int id, Rejting editRejting)
        {
            _context.Rejtings.Update(editRejting);
            _context.SaveChanges();
            return editRejting;
        }
    }
}
