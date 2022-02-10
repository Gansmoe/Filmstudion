using AutoMapper;

namespace Filmstudion.api.Models
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<UserRegister, User>();
            this.CreateMap<User, UserResource>();
            this.CreateMap<User, FilmstudioUserResource>();
        }
    }
}