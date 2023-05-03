using AutoMapper;
using Qualisha.iCommunity.Data.Models;
using Qualisha.iCommunity.Data.Models.Dtos;
using Qualisha.iCommunity.RegistrationAPI.Model;

namespace Qualisha.iCommunity.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressDto, Address>();
            CreateMap<UserRegistraionDto, User>()
                .ForMember(dest => dest.Address, act => act.MapFrom(src => src.AddressDto));

            CreateMap<Address, AddressDto>();
            CreateMap<User, UserRegistraionDto>()
                .ForMember(dest => dest.AddressDto, act => act.MapFrom(src => src.Address));
        }
    }
}