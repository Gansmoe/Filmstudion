using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var filmCopy = new FilmCopy
                {
                    FilmsId = film.FilmId,
                    RentedOut = false,
                    FilmsStudioId = "",
                    FilmCopyId = rnd.Next(1, 999999)
                };
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
            List<Film> films = await _appDbContext.Films.ToListAsync();

            for (int i = 0;i < films.Count;i++)
            {
                films[i].FilmCopies = _appDbContext.FilmCopies.Where(f => f.FilmsId == films[i].FilmId).ToList();
            }

            return films;
        }

        public async Task<Film> FilmAsync(int id)
        {
            IQueryable<Film> query = _appDbContext.Films.Where(r => r.FilmId == id);

            Film film = await query.FirstOrDefaultAsync();
            film.FilmCopies = _appDbContext.FilmCopies.Where(f => f.FilmsId == film.FilmId).ToList();
            

            return film;
            
        }

        public async Task UpdateFilmAsync(Film film, JsonPatchDocument model)
        {
            model.ApplyTo(film);
            await _appDbContext.SaveChangesAsync();

        }

    }
}
