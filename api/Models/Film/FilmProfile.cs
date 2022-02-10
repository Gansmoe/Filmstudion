using AutoMapper;

namespace Filmstudion.api.Models
{
    public class FilmProfile : Profile
    {
        public FilmProfile()
        {
            this.CreateMap<CreateFilm, Film>();
        }
    }
}
