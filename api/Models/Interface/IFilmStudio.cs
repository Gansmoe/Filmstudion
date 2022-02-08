using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmstudion.api.Models
{

  interface IFilmStudio
  {
    public int FilmStudioId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }

  }
}