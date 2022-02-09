using System;
using Filmstudion.api.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;

namespace Filmstudion.api.Controllers
{
    [Route("/api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserController(IUserRepository userRepository, IMapper mapper, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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

        [HttpPost]
        public async Task<IActionResult> CreateToken(UserAuthenticate model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);

                if (user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                    if (result.Succeeded)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                        };
                        
                    }
                }
            }
            return BadRequest();
        }


    }
}