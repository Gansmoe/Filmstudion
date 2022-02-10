namespace Filmstudion.api.Models
{

    public class RegisterFilmStudio : IRegisterFilmStudio
    {
        public string StudioIdentifier { get; set; }
        public string FilmStudioCity { get; set; }
        public string FilmStudioName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}