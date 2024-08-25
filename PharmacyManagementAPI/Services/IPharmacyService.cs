using PharmacyManagementAPI.Models;
using PharmacyManagementAPI.Entities;

namespace PharmacyManagementAPI.Services
{
    public interface IPharmacyService
    {
        Task<IEnumerable<PharmacyModel>> GetAllPharmaciesAsync();
        Task<PharmacyModel> GetPharmacyByIdAsync(int id);
        Task<PharmacyModel> AddPharmacyAsync(PharmacyModel pharmacy);
        Task<PharmacyModel> UpdatePharmacyAsync(PharmacyModel pharmacy);
    }
}
