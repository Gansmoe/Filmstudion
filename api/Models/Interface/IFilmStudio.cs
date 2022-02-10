using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmstudion.api.Models
{

  interface IFilmStudio
  {
    public int Id { get; set; }
    public string StudioIdentifier { get; set; }
    public string FilmStudioCity { get; set; }
    public string FilmStudioName { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }

  }
}