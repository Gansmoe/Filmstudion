using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.api.Models
{
    public class FilmStudioRepository : IFilmStudioRepository
    {
        private readonly AppDbContext _appDbContext;

        public FilmStudioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //Lägger till det som ska sparas
        public void Add<T>(T entity) where T : class
        {
            _appDbContext.Add(entity);
        }

        //Sparar till databasen
        public async Task<bool> SaveChangesAsync()
        {
            return (await _appDbContext.SaveChangesAsync()) > 0;
        }

        public async Task<IEnumerable<Filmstudio>> ListAsync()
        {
            return await _appDbContext.Filmstudios.ToListAsync();
        }

        public async Task<Filmstudio> FilmstudioAsync(int id)
        {
            IQueryable<Filmstudio> query = _appDbContext.Filmstudios.Where(r => r.FilmStudioId == id);
            return await query.FirstOrDefaultAsync();
        }

    }
}