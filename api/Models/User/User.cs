namespace Filmstudion.api.Models
{
    
    public class User : IUser
    {
      public int UserId { get; set; }
      public bool IsAdmin { get; set; }
      public string Role { get; set; }
      public string Username { get; set; }
      public string Password { get; set; }
    }
}