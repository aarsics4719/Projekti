using CinemaOnline.Controllers;
using CinemaOnline.Models;

namespace CinemaOnline.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly MovieRentalContext _context;

        public MoviesService(MovieRentalContext context)
        {
            _context = context;
        }

        public void Add(Filmovi filmovi)
        {
            _context.Filmovis.Add(filmovi);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var delete = _context.Filmovis.FirstOrDefault(x => x.FilmId == id);
            if(delete != null)
            {
                _context.Filmovis.Remove(delete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Filmovi> GetAll()
        {
            var sviFilmovi = _context.Filmovis.ToList();
            return sviFilmovi;
        }

        public Filmovi GetById(int id)
        {
            var data = _context.Filmovis.FirstOrDefault(x => x.FilmId == id);
            return data;
        }

        public Filmovi Update(int id, Filmovi editFilmovi)
        {
            _context.Filmovis.Update(editFilmovi);
            _context.SaveChanges();
            return editFilmovi;
        }
    }
}
