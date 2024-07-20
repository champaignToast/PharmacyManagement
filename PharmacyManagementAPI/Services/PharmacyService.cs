using PharmacyManagementAPI.Models;

namespace PharmacyManagementAPI.Services
{
    public class PharmacyService : IPharmacyService
    {
        private readonly IPharmacyRepository _repository;

        public PharmacyService(IPharmacyRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Pharmacy> GetAllPharmacies() => _repository.GetAllPharmacies();

        public Pharmacy GetPharmacyById(int id) => _repository.GetPharmacyById(id);

        public void AddPharmacy(Pharmacy pharmacy)
        {
            _repository.AddPharmacy(pharmacy);
            _repository.Save();
        }

        public void UpdatePharmacy(Pharmacy pharmacy)
        {
            _repository.UpdatePharmacy(pharmacy);
            _repository.Save();
        }


    }

}
