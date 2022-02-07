using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmstudion.api.Models
{

  interface IUser
  {
    public string UserId { get; set; }
    public string Role { get; set; }
    public string Username { get; set; }
    public string FilmStudioId { get; set; }
    public Filmstudio FilmStudio { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
  }
}