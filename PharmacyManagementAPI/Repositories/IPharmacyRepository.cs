using PharmacyManagementAPI.Models;

public interface IPharmacyRepository
{
    IEnumerable<Pharmacy> GetAllPharmacies();
    Pharmacy GetPharmacyById(int id);
    void AddPharmacy(Pharmacy pharmacy);
    void UpdatePharmacy(Pharmacy pharmacy);
    void Save();
}
