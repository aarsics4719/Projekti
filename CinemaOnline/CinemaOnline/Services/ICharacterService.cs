using CinemaOnline.Models;

namespace CinemaOnline.Services
{
    public interface ICharacterService
    {
        IEnumerable<Likovi> GetAll();

        Likovi getById(int id);

        void Add(Likovi likovi);

        Likovi Update(int id, Likovi editLikovi);

        void Delete(int id);

    }
}
