using System.Collections.Generic;

namespace Filmstudion.api.Models
{
    public class Filmstudio : IFilmStudio
    {

    public int FilmStudioId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }

    }
}