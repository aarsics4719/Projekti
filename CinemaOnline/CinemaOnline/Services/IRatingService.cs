using CinemaOnline.Models;

namespace CinemaOnline.Services
{
    public interface IRatingService
    {
        IEnumerable<Rejting> GetAll();
        void Add(Rejting rejting);

        Rejting Update(int id, Rejting editRejting);

        Rejting GetByFilmAndUser(int FilmId, int KorisniciId);

        void Delete(int id);

        Rejting GetById(int id);
    }
}
