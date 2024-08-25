using System.Collections.Generic;
using System.Threading.Tasks;
using PharmacyManagementAPI.Models;
using PharmacyManagementAPI.Repositories;
using AutoMapper;

namespace PharmacyManagementAPI.Services
{
    public class PharmacyService : IPharmacyService
    {
        private readonly IPharmacyRepository _repository;
        private readonly IMapper _mapper;

        public PharmacyService(IPharmacyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PharmacyModel>> GetAllPharmaciesAsync()
        {
            return await _repository.GetAllPharmaciesAsync();
        }

        public async Task<PharmacyModel> GetPharmacyByIdAsync(int id)
        {
            return await _repository.GetPharmacyByIdAsync(id);
        }

        public async Task<PharmacyModel> AddPharmacyAsync(PharmacyModel pharmacyModel)
        {
            return await _repository.AddPharmacyAsync(pharmacyModel);
        }

        public async Task<PharmacyModel> UpdatePharmacyAsync(PharmacyModel pharmacyModel)
        {
            return await _repository.UpdatePharmacyAsync(pharmacyModel);
        }
    }
}
