using PharmacyManagementAPI.Models;

public interface IPharmacyRepository
{
    Task<IEnumerable<PharmacyModel>> GetAllPharmaciesAsync();
    Task<PharmacyModel> GetPharmacyByIdAsync(int id);
    Task<PharmacyModel> AddPharmacyAsync(PharmacyModel pharmacy);
    Task<PharmacyModel> UpdatePharmacyAsync(PharmacyModel pharmacy);
    void Save();
}
