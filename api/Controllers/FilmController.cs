using AutoMapper;
using Filmstudion.api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;

namespace Filmstudion.Controllers
{
    [Route("api/films")]
    [ApiController]
    
    public class FilmController : Controller
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public FilmController(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddNewFilm(CreateFilm model)
        {
            if(ModelState.IsValid)
                try
                {
                    var film = _mapper.Map<Film>(model);
                    film.FilmCopies = new List<FilmCopy>();
                    var films = _filmRepository.AllFilms;
                    int count = films.Count();
                    film.FilmId = count + 1;
                    var test = _filmRepository.AddCopiesList(model.NumberOfCopies, film);
                    _filmRepository.Add(test);
                    if (await _filmRepository.SaveChangesAsync())
                    {
                        return Ok(test);
                    }
                }
                catch (System.Exception ex)
                {
                    return this.StatusCode(500, "Database Failure");
                }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Film>>> GetAllAsync()
        {
            var films = await _filmRepository.ListAsync();
            return Ok(films);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Film>> GetFilm(int id)
        {
            var film = await _filmRepository.FilmAsync(id);
            //var filmstudio = _mapper.Map<FilmStudioReturn>(model);
            if (film == null)
            {
                return NotFound();
            }

            return Ok(film);
        }

        [HttpPatch("{Id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> PatchFilm(int id, JsonPatchDocument model)
        {
            var film = await _filmRepository.FilmAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            await _filmRepository.UpdateFilmAsync(film, model);
            var updatedFilm = await _filmRepository.FilmAsync(id);
            return Ok(updatedFilm);

        }
    }
}
