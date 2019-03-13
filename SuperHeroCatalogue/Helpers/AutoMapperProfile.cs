using AutoMapper;
using SuperHeroCatalogue.Dto;
using SuperHeroCatalogue.Models;

namespace SuperHeroCatalogue.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
