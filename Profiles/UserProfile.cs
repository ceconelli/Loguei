using Loguei.Dtos;
using Loguei.Models;
using AutoMapper;

namespace Logue.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
        }
    }
}