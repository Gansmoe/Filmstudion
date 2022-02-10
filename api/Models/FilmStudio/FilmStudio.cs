using System.Collections.Generic;

namespace Filmstudion.api.Models
{
    public class Filmstudio : IFilmStudio
    {

        public int FilmStudioId { get; set; }
        public string FilmStudioCity { get; set; }
        public string FilmStudioName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public List<FilmCopy> RentedFilmCopies { get; set; }

    }
}