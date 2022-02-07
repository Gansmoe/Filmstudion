using System;
using System.ComponentModel.DataAnnotations;

namespace Filmstudion.api.Models
{
  public interface ICreateFilmModel
  {
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Country { get; set; }
    public string Director { get; set; }
    public int NumberOfCopies { get; set; }
  }
}