using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmstudion.api.Models
{
    public interface IFilmRepository
    {
        void Add<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
        Film AddCopiesList(int number, Film film);

        IEnumerable<Film> AllFilms { get; }

        Task<IEnumerable<Film>> ListAsync();
        Task<Film> FilmAsync(int id);
        Task UpdateFilmAsync(Film film, JsonPatchDocument model);
    }
}
