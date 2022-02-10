using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmstudion.api.Models
{

    public class UserAuthenticate
    {
      public bool IsAdmin { get; set; }
      public string UserName { get; set; }
      public string Password { get; set; }
    }
}