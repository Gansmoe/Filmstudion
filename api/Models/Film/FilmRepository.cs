using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmstudion.api.Models
{
    public class FilmRepository : IFilmRepository
    {
        private readonly AppDbContext _appDbContext;

        public FilmRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _appDbContext.Add(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _appDbContext.SaveChangesAsync()) > 0;
        }

        public Film AddCopiesList(int number, Film film)
        {
            for(int i = 0; i < number; i++)
            {
                Random rnd = new Random();
                var filmCopy = new FilmCopy();
                filmCopy.FilmId = film.FilmId;
                filmCopy.RentedOut = false;
                filmCopy.FilmStudioId = "";
                filmCopy.FilmCopyId = rnd.Next(1, 999999);
                film.FilmCopies.Add(filmCopy);
            }
            return film;
        }

        public IEnumerable<Film> AllFilms
        {
            get
            {
                return _appDbContext.Films;
            }
        }

        public async Task<IEnumerable<Film>> ListAsync()
        {
            return await _appDbContext.Films.ToListAsync();
        }

    }
}
