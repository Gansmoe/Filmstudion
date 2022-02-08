using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmstudion.api.Models
{
    public interface IFilmStudioRepository
    {
        void Add<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
    }
}