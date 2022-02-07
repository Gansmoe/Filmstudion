using System.Collections.Generic;

namespace Filmstudion.api.Models
{
    public class Filmstudio : IFilmStudio
    {
    public string FilmStudioId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public List<FilmCopy> RentedFilmCopies { get; set; }
    }
}