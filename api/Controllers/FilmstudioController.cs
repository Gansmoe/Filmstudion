using Filmstudion.api.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Filmstudion.api.Controllers
{
    [Route("/api/filmstudios")]
    [ApiController]
    public class FilmstudioController : Controller
    {
        private readonly IFilmStudioRepository _filmstudioRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public FilmstudioController(IFilmStudioRepository filmStudioRepository, IMapper mapper, UserManager<User> userManager)
        {
            _filmstudioRepository = filmStudioRepository;
            _mapper = mapper;
            _userManager = userManager;
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
        public async Task<ActionResult<IEnumerable<Filmstudio>>> GetAllAsync(UserAuthenticate model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if(user == null || user.Role == "Filmstudio")
            {
                var filmstudios = await _filmstudioRepository.ListAsync();
                var filmstudiosDTO = _mapper.Map<IEnumerable<Filmstudio>, IEnumerable<FilmStudioReturn>>(filmstudios);
                return Ok(filmstudiosDTO);
            }
            else if (user.Role == "Admin")
            {
                var filmstudios = await _filmstudioRepository.ListAsync();
                return Ok(filmstudios);
            }
            
            return this.StatusCode(500, "Database Failure");
            
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Filmstudio>> GetFilmstudio (int id, UserAuthenticate userModel)
        {
            var model = await _filmstudioRepository.FilmstudioAsync(id);
            User user = null;

            if (userModel.UserName != null)
            {
                user = await _userManager.FindByNameAsync(userModel.UserName);
            }

            if (user == null || user.Role == "Filmstudio")
            {
                var filmstudio = _mapper.Map<FilmStudioReturn>(model);
                if(filmstudio == null)
                {
                    return NotFound();
                }

                return Ok(filmstudio);
            }
            
            else if (user.Role == "Admin")
            {
                return Ok(model);
            }

            return this.StatusCode(500, "Database Failure");
        }
    }
}