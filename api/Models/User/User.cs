using Microsoft.AspNetCore.Identity;

namespace Filmstudion.api.Models

{
    
    public class User : IdentityUser, IUser
    {
      public bool IsAdmin { get; set; }
      public string Role { get; set; }
      public string FilmStudioId { get; set; }
      public Filmstudio FilmStudio { get; set; }
    }
}