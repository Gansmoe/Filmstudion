using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmstudion.api.Models
{

  interface IFilmStudio
  {
    public string FilmStudioId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public List<FilmCopy> RentedFilmCopies { get; set; }
  }
}