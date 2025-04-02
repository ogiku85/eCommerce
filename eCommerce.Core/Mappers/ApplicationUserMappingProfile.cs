using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public class ApplicationUserMappingProfile : Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dest => dest.UserID,
                option => option.MapFrom(src => src.UserID))
            .ForMember(dest => dest.Email,
                option => option.MapFrom(src => src.Email))
            .ForMember(dest => dest.PersonName,
                option => option.MapFrom(src => src.PersonName))
            .ForMember(dest => dest.Gender,
                option => option.MapFrom(src => src.Gender))
            .ForMember(dest => dest.Success,
                option => option.Ignore());
    }
}