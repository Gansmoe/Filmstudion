namespace Filmstudion.api.Models
{
    public class FilmCopy : IFilmCopy
    {
        public int FilmCopyId { get; set; }
        public int FilmsId { get; set; }
        public bool RentedOut { get; set; }
        public string FilmsStudioId { get; set; }
    }
}