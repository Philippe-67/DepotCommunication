using ApiRdv.Models;
using ApiRdv.Repositories;

namespace ApiRdv.Services
{
    public class RendezVousService
    {

        private readonly RendezVousRepository _repository;

public RendezVousService(RendezVousRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<RendezVous> GetAllRendezvous()
        {
            return _repository.GetAll();
        }
        public RendezVous GetRendezVousById(int id) 
        {
         return _repository.GetById(id);
        }
        public void CreateRendezVous(RendezVous rendezVous) 
        {
            // Ajouter des logiques de validation si nécessaire
            rendezVous.Date = DateTime.Now;// Exemple : assigner la date actuelle lors de la création
            _repository.Add(rendezVous);
        }
        public void UpdateRendezVous(int id, RendezVous updateDRendezVous)
        {
            var existingRendezVous= _repository.GetById(id);

            if (existingRendezVous != null)
            {
                existingRendezVous.NomPatient = updateDRendezVous.NomPatient;
                existingRendezVous.Date = updateDRendezVous.Date;

                _repository.Update(existingRendezVous);
            }
        }

        public void DeleteRendezVous(int Id)
        { _repository.Delete(Id); }

    }
}
