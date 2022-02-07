using System.Collections.Generic;

namespace Filmstudion.Models
{
    public class FilmStudion
    {
        public int StudioId {get; set;}
        public string Name {get; set;}
        public string City {get; set;}
        public string Email {get; set;}
        public string ContactPerson {get; set;}
        public IEnumerable<Film> Films {get; set;}
    }
}