using PharmacyManagementAPI.Models;

namespace PharmacyManagementAPI.Services
{
    public interface IPharmacyService
    {
        IEnumerable<Pharmacy> GetAllPharmacies();
        Pharmacy GetPharmacyById(int id);
        void AddPharmacy(Pharmacy pharmacy);
        void UpdatePharmacy(Pharmacy pharmacy);
    }

}
