using CinemaOnline.Models;

namespace CinemaOnline.Services
{
    public interface IRentalService
    {
        IEnumerable<Rentum> GetAll();

        Rentum GetById(int id);

        void Add(Rentum rentum);

        void Delete(int id);
    }
}
