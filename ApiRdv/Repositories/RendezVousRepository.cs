using ApiRdv.Data;
using ApiRdv.Models;

namespace ApiRdv.Repositories
{
    public class RendezVousRepository
    {
        private readonly RendezVousDbContext _dbcontext;

        public RendezVousRepository(RendezVousDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public IEnumerable<RendezVous> GetAll()
        {
            return _dbcontext.RendezVous.ToList();
        }
        public RendezVous GetById(int id)
        {
            return _dbcontext.RendezVous.Find(id);
        }

        public void Add(RendezVous rendezVous)
        {
            _dbcontext.RendezVous.Add(rendezVous);
            _dbcontext.SaveChanges();
        }

        public void Update(RendezVous rendezVous)
        {
            _dbcontext.RendezVous.Update(rendezVous);
            _dbcontext.SaveChanges();
        }
        public void Delete(int id)
        {
            var rendezVous = _dbcontext.RendezVous.Find(id);
            if (rendezVous != null)
            {
                _dbcontext.RendezVous.Remove(rendezVous);
                _dbcontext.SaveChanges();
            }
        }
    }
}
