using System;
using System.Text;
using Filmstudion.api.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
        private readonly IConfiguration _config;
        private readonly AppDbContext _appDbContext;
        private readonly IFilmStudioRepository _filmStudioRepository;

        public UserController(IUserRepository userRepository,
            IMapper mapper,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IConfiguration config,
            AppDbContext appDbContext, 
            IFilmStudioRepository filmStudioRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
            _appDbContext = appDbContext;
            _filmStudioRepository = filmStudioRepository;
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
                //_userRepository.Add(user);
                var result = await _userManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
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
            catch (System.Exception ex)
            {
               return this.StatusCode(500, "Database Failure");
            }
            return BadRequest();
            
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> CreateToken(UserAuthenticate model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    
                    if (user.FilmStudioId != null)
                    {
                        var filmstudio = _appDbContext.Filmstudios.Where(f => f.Username == user.UserName);

                        if (filmstudio != null)
                        {
                            user.FilmStudio = await filmstudio.FirstOrDefaultAsync();
                            user.Role = "Filmstudio";
                            await _userRepository.SaveChangesAsync();
                        }
                    }

                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                    if (result.Succeeded)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            _config["Tokens:Issuer"],
                            _config["Tokens:Audience"], 
                            claims, signingCredentials: creds,
                            expires: DateTime.UtcNow.AddMinutes(20));

                        var userDTO = _mapper.Map<UserResource>(user);

                        if (user.FilmStudioId == null)
                        {
                            return Created("", new
                            {
                                userDTO,
                                token = new JwtSecurityTokenHandler().WriteToken(token),
                                expiration = token.ValidTo
                            });
                        }
                        else
                        {
                            var filmstudioUser = _mapper.Map<FilmstudioUserResource>(user);
                            return Created("", new
                            {
                                filmstudioUser,
                                token = new JwtSecurityTokenHandler().WriteToken(token),
                                expiration = token.ValidTo
                            });
                        }
                    }
                }
            }
            return BadRequest();
        }


    }
}