using CinemaOnline.Models;

namespace CinemaOnline.Services
{
    public interface IMoviesService
    {
        IEnumerable<Filmovi> GetAll();

        Filmovi GetById(int id);

        void Add(Filmovi filmovi);

        Filmovi Update(int id, Filmovi editFilmovi);

        void Delete(int id);
    }
}
