using CinemaOnline.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CinemaOnline.Services
{
    public class ActorsService : IActorsService
    {
        private readonly MovieRentalContext _context;
        
        public ActorsService(MovieRentalContext context)
        {
            _context = context;
        }
        public void Add(Glumci glumci)
        {
            _context.Glumcis.Add(glumci);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var delete = _context.Glumcis.FirstOrDefault(x => x.GlumciId == id);
            if (delete != null)
            {
                _context.Glumcis.Remove(delete);
                _context.SaveChanges();
            }
        }
        public Glumci GetById(int id)
        {
            var data = _context.Glumcis.FirstOrDefault(x => x.GlumciId == id);
            return data;
        }

        public IEnumerable<Glumci> GetAll()
        {
            var sviGlumci = _context.Glumcis.ToList();
            return sviGlumci;
        }
        public Glumci Update(int id, Glumci editGlumci)
        {
            _context.Glumcis.Update(editGlumci);
            _context.SaveChanges();
            return editGlumci;
        }
    }
}
