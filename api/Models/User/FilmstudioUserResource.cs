

namespace Filmstudion.api.Models
{
    public class FilmstudioUserResource
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Filmstudio Filmstudio {get; set;}
        public string FilmStudioId { get; set; }
    }
}
