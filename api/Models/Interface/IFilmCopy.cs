using System;

namespace Filmstudion.api.Models
{
  public interface IFilmCopy
  {

    public int FilmCopyId { get; set; }
    public int FilmId { get; set; }
    public bool RentedOut { get; set; }
    public string FilmStudioId { get; set; }
  }
}