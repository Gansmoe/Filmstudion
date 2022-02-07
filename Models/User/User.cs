namespace Filmstudion.Models
{
    public class User
    {
        public int UserId {get; set;}
        public string UserName {get; set;}
        public string Role {get; set;}
        public bool IsAdmin {get; set;} = false;
        public string Password {get; set;}
    }
}