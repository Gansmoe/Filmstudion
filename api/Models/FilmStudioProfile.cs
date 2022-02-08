using AutoMapper;

namespace Filmstudion.api.Models
{
    public class FilmStudioProfile : Profile
    {
        public FilmStudioProfile()
        {
            this.CreateMap<Filmstudio, FilmStudioResource>();
        }
    }
}