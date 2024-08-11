using Microsoft.EntityFrameworkCore;
using PharmacyManagementAPI.Entities;
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

        public async Task<IEnumerable<PharmacyModel>> GetAllPharmaciesAsync()
        {
            var pharmacies = await _context.Pharmacies.ToListAsync();
            var pharmacyModels = pharmacies.Select(p => new PharmacyModel
            {
                Id = p.Id,
                Name = p.Name,
                Address = p.Address,
                City = p.City,
                State = p.State,
                Zip = p.Zip,
                NumberOfFilledPrescriptions = p.NumberOfFilledPrescriptions,
                CreatedDate = p.CreatedDate,
                UpdatedDate = p.UpdatedDate
            });

            return pharmacyModels;
        }


        public async Task<PharmacyModel> GetPharmacyByIdAsync(int id)
        {
            var pharmacy = await _context.Pharmacies.FindAsync(id);
            if (pharmacy == null)
            {
                throw new KeyNotFoundException($"Pharmacy with ID {id} not found.");
            }

            var pharmacyModel = new PharmacyModel
            {
                Id = pharmacy.Id,
                Name = pharmacy.Name,
                Address = pharmacy.Address,
                City = pharmacy.City,
                State = pharmacy.State,
                Zip = pharmacy.Zip,
                NumberOfFilledPrescriptions = pharmacy.NumberOfFilledPrescriptions,
                CreatedDate = pharmacy.CreatedDate,
                UpdatedDate = pharmacy.UpdatedDate
            };

            return pharmacyModel;
        }




        public async Task<PharmacyModel> AddPharmacyAsync(PharmacyModel pharmacy)
        {
            var entity = new Pharmacy
            {
                Name = pharmacy.Name,
                Address = pharmacy.Address,
                City = pharmacy.City,
                State = pharmacy.State,
                Zip = pharmacy.Zip,
                NumberOfFilledPrescriptions = pharmacy.NumberOfFilledPrescriptions ?? 0,
                CreatedDate = pharmacy.CreatedDate,
                UpdatedDate = DateTime.Now
            };

            _context.Pharmacies.Add(entity);
            await _context.SaveChangesAsync();

            
            pharmacy.Id = entity.Id;

            return pharmacy;
        }



        public async Task<PharmacyModel> UpdatePharmacyAsync(PharmacyModel pharmacy)
        {
            var entity = await _context.Pharmacies.FindAsync(pharmacy.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Pharmacy with ID {pharmacy.Id} not found.");
            }

            entity.Name = pharmacy.Name;
            entity.Address = pharmacy.Address;
            entity.City = pharmacy.City;
            entity.State = pharmacy.State;
            entity.Zip = pharmacy.Zip;
            entity.NumberOfFilledPrescriptions = pharmacy.NumberOfFilledPrescriptions ?? 0;
            entity.CreatedDate = pharmacy.CreatedDate;
            entity.UpdatedDate = DateTime.Now;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return pharmacy;
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
