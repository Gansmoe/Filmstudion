using Filmstudion.api.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;

namespace Filmstudion.api.Controllers
{
    [Route("/api/filmstudios")]
    [ApiController]
    public class FilmstudioController : Controller
    {
        private readonly IFilmStudioRepository _filmstudioRepository;
        private readonly IMapper _mapper;

        public FilmstudioController(IFilmStudioRepository filmStudioRepository, IMapper mapper)
        {
            _filmstudioRepository = filmStudioRepository;
            _mapper = mapper;
        }

        
        [HttpPost("register")]
        public async Task<ActionResult<Filmstudio>> Register(RegisterFilmStudio model)
        {
            try
            {
                var filmstudio = _mapper.Map<Filmstudio>(model);
                _filmstudioRepository.Add(filmstudio);
                if (await _filmstudioRepository.SaveChangesAsync())
                {
                    return Ok(filmstudio);
                }
                
            }
            catch (System.Exception)
            {
                return this.StatusCode(500, "Database Failure");
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filmstudio>>> GetAllAsync()
        {
            var filmstudios = await _filmstudioRepository.ListAsync();
            var filmstudiosDTO = _mapper.Map<IEnumerable<Filmstudio>, IEnumerable<FilmStudioReturn>>(filmstudios);
            return Ok(filmstudiosDTO);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Filmstudio>> GetFilmstudio (int id)
        {
            var model = await _filmstudioRepository.FilmstudioAsync(id);
            var filmstudio = _mapper.Map<FilmStudioReturn>(model);
            if(filmstudio == null)
            {
                return NotFound();
            }

            return Ok(filmstudio);
        }
    }
}