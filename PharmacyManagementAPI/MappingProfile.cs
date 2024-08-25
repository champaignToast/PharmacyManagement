using AutoMapper;
using PharmacyManagementAPI.Entities;
using PharmacyManagementAPI.Models;

namespace PharmacyManagementAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pharmacy, PharmacyModel>().ReverseMap();
        }
    }
}
