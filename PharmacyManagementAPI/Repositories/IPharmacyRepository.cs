using System.Collections.Generic;
using System.Threading.Tasks;
using PharmacyManagementAPI.Models;

namespace PharmacyManagementAPI.Repositories
{
    public interface IPharmacyRepository
    {
        Task<IEnumerable<PharmacyModel>> GetAllPharmaciesAsync();
        Task<PharmacyModel> GetPharmacyByIdAsync(int id);
        Task<PharmacyModel> AddPharmacyAsync(PharmacyModel pharmacyModel);
        Task<PharmacyModel> UpdatePharmacyAsync(PharmacyModel pharmacyModel);
        void Save();
    }
}
