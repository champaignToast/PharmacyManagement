using PharmacyManagementAPI.Entities;
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

        public async Task<IEnumerable<PharmacyModel>> GetAllPharmaciesAsync()
        {
            var pharmacies = await _repository.GetAllPharmaciesAsync();
            return pharmacies;
        }

        public async Task<PharmacyModel> GetPharmacyByIdAsync(int id)
        {
            var pharmacy = await _repository.GetPharmacyByIdAsync(id);
            return pharmacy;
        }

        public async Task<PharmacyModel> AddPharmacyAsync(PharmacyModel pharmacyModel)
        {
            var pharmacy = new PharmacyModel
            {
                Name = pharmacyModel.Name,
                Address = pharmacyModel.Address,
                City = pharmacyModel.City,
                State = pharmacyModel.State,
                Zip = pharmacyModel.Zip,
                NumberOfFilledPrescriptions = pharmacyModel.NumberOfFilledPrescriptions,
                CreatedDate = pharmacyModel.CreatedDate,
                UpdatedDate = DateTime.Now,
            };

            await _repository.AddPharmacyAsync(pharmacy);
            _repository.Save();
            return pharmacy;
        }

        public async Task<PharmacyModel> UpdatePharmacyAsync(PharmacyModel pharmacyModel)
        {
            var existingPharmacy = await _repository.GetPharmacyByIdAsync(pharmacyModel.Id ?? 0);
            if (existingPharmacy == null)
            {
                return null;
            }

            existingPharmacy.Name = pharmacyModel.Name;
            existingPharmacy.Address = pharmacyModel.Address;
            existingPharmacy.City = pharmacyModel.City;
            existingPharmacy.State = pharmacyModel.State;
            existingPharmacy.Zip = pharmacyModel.Zip;
            existingPharmacy.NumberOfFilledPrescriptions = pharmacyModel.NumberOfFilledPrescriptions;
            existingPharmacy.CreatedDate = pharmacyModel.CreatedDate;
            existingPharmacy.UpdatedDate = DateTime.Now;

            await _repository.UpdatePharmacyAsync(existingPharmacy);
            _repository.Save();
            return existingPharmacy;
        }
    }
}
