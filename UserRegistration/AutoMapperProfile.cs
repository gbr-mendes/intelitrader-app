using AutoMapper;
using UserRegistration.Models;
using UserRegistration.Dtos.User;

namespace UserRegistration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
        }
    }
}