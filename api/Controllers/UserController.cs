using Filmstudion.api.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Filmstudion.api.Controllers
{
    [Route("/api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // För att registrera en användare
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegister model)
        {
            try
            {
                var user = _mapper.Map<User>(model);
                if (model.IsAdmin == true)
                {
                    user.Role ="Admin";
                }
                else
                {
                    user.Role ="User";
                }
                _userRepository.Add(user);
                if (await _userRepository.SaveChangesAsync())
                {

                    var userDTO = _mapper.Map<UserResource>(user);
                    if (user.IsAdmin == true)
                    {
                        userDTO.Role = "Admin";
                    }
                    else
                    {
                        userDTO.Role ="User";
                    }
                    return Ok(userDTO);
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