using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmstudion.api.Models
{

  interface IUser
    {
      //public int UserId { get; set; }
      public bool IsAdmin { get; set; }
      public string Role { get; set; }
      //public string Username { get; set; }
      //public string Password { get; set; }
    }
}