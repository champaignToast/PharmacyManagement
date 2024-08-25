using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyManagementAPI.Entities;
using PharmacyManagementAPI.Models;
using AutoMapper;

namespace PharmacyManagementAPI.Repositories
{
    public class PharmacyRepository : IPharmacyRepository
    {
        private readonly PharmacyContext _context;
        private readonly IMapper _mapper;

        public PharmacyRepository(PharmacyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PharmacyModel>> GetAllPharmaciesAsync()
        {
            var entities = await _context.Pharmacies.ToListAsync();
            return _mapper.Map<IEnumerable<PharmacyModel>>(entities);
        }

        public async Task<PharmacyModel> GetPharmacyByIdAsync(int id)
        {
            var entity = await _context.Pharmacies.FindAsync(id);
            return _mapper.Map<PharmacyModel>(entity);
        }

        public async Task<PharmacyModel> AddPharmacyAsync(PharmacyModel pharmacyModel)
        {
            var entity = _mapper.Map<Pharmacy>(pharmacyModel);
            _context.Pharmacies.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PharmacyModel>(entity);
        }

        public async Task<PharmacyModel> UpdatePharmacyAsync(PharmacyModel pharmacyModel)
        {
            var entity = await _context.Pharmacies.FindAsync(pharmacyModel.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Pharmacy with ID {pharmacyModel.Id} not found.");
            }
            _mapper.Map(pharmacyModel, entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<PharmacyModel>(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
