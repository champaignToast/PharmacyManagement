using Microsoft.EntityFrameworkCore;
using PharmacyManagementAPI.Models;

namespace PharmacyManagementAPI.Repositories
{
    public class PharmacyRepository : IPharmacyRepository
    {
        private readonly PharmacyContext _context;

        public PharmacyRepository(PharmacyContext context)
        {
            _context = context;
        }

        public IEnumerable<Pharmacy> GetAllPharmacies() => _context.Pharmacies.ToList();

        public Pharmacy GetPharmacyById(int id) => _context.Pharmacies.Find(id);

        public void AddPharmacy(Pharmacy pharmacy)
        {
            _context.Pharmacies.Add(pharmacy);
        }

        public void UpdatePharmacy(Pharmacy pharmacy)
        {
            
            var entity = _context.Pharmacies.Attach(pharmacy);
            _context.Entry(pharmacy).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
//test changes