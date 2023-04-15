using CinemaOnline.Models;

namespace CinemaOnline.Services
{
    public interface IActorsService
    {
        IEnumerable<Glumci> GetAll();

        Glumci GetById(int id);

        void Add(Glumci glumci);

        Glumci Update(int id, Glumci editGlumci);

        void Delete(int id);
    }
}
