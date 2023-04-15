using CinemaOnline.Models;

namespace CinemaOnline.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly MovieRentalContext _context;
        public CharacterService(MovieRentalContext context)
        {
            _context = context;
        }
        public void Add(Likovi likovi)
        {
            _context.Likovis.Add(likovi);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var delete = _context.Likovis.FirstOrDefault(x => x.LikoviId == id);
            _context.Likovis.Remove(delete);
            _context.SaveChanges();
        }

        public IEnumerable<Likovi> GetAll()
        {
            var sviLikovi = _context.Likovis.ToList();
            return sviLikovi;
        }

        public Likovi getById(int id)
        {
            var data = _context.Likovis.FirstOrDefault(x => x.LikoviId == id);
            return data;
        }

        public Likovi Update(int id, Likovi editLikovi)
        {
            _context.Likovis.Update(editLikovi);
            _context.SaveChanges();
            return editLikovi;
        }
    }
}
