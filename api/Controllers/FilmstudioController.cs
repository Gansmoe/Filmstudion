using Filmstudion.api.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Filmstudion.api.Controllers
{
    [Route("/api/filmstudio")]
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
    }
}