using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmstudion.api.Models
{

    interface IUserAuthenticate
    {
        public bool IsAdmin { get; set; }
        public string Username { get; set; }
        public string FilmStudioId { get; set; }
        public string Password { get; set; }
    }
}