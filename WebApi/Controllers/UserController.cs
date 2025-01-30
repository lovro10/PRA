using BL.Models;
using BL.Singleton;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using WebApi.DTOs;
using WebApi.Security;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PraFichteContext _context;

        public UserController(PraFichteContext context)
        {
            _context = context;
        }

        [HttpPost("[action]")]
        public ActionResult<UserRegisterDto> Register([FromBody] string jsonRegisterDto)
        {
            var registerDto = JsonSerializer.Deserialize<UserRegisterDto>(jsonRegisterDto);

            try
            {
                var trimmedUsername = registerDto.Username.Trim();
                if (_context.Users.Any(x => x.Username.Equals(trimmedUsername)))
                {
                    return BadRequest(JsonSerializer.Serialize($"Username {trimmedUsername} already exists"));
                }

                var b64salt = PasswordHashProvider.GetSalt();
                var b64hash = PasswordHashProvider.GetHash(registerDto.Password, b64salt);

                var user = new User
                {
                    Id = registerDto.Id,
                    Username = registerDto.Username,
                    PwdHash = b64hash,
                    PwdSalt = b64salt,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    Email = registerDto.Email,
                    DateOfBirth = registerDto.DateOfBirth,
                    DateJoined = DateTime.UtcNow
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                registerDto.Id = user.Id;

                return Ok(registerDto);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost("[action]")]
        public ActionResult Login([FromBody] string jsonlogInDto)
        {
            var userLoginDto = JsonSerializer.Deserialize<UserLoginDto>(jsonlogInDto);

            try
            {
                var existingUser = _context.Users
                    .Where(x => x.EmailConfirmed == true)
                    .FirstOrDefault(x => x.Username == userLoginDto.Email);
                if (existingUser == null)
                {
                    return Unauthorized("Incorect username of password");
                }

                var b64hash = PasswordHashProvider.GetHash(userLoginDto.Password, existingUser.PwdSalt);

                if (b64hash != existingUser.PwdHash)
                {
                    return Unauthorized("Incorect username of password");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/<UserController>
        [HttpGet("[action]/{username}")]
        public ActionResult<int> GetUserId(string username)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Username == username);

                return Ok(user.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("[Action]")]
        public ActionResult<UserDto> GetAllUsers()
        {
            var userDto = _context.Users
                //.Where(x => x.Id != user.Id)
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    DateJoined = x.DateJoined,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Username = x.Username,
                    DateOfBirth = x.DateOfBirth
                });

            return Ok(userDto);
        }

        [HttpGet("[action]/{username}")]
        public ActionResult<UserDto> GetUserByUsername(string username)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Username == username);

                var userDto = new UserDto
                {
                    Id = user.Id,
                    DateJoined = user.DateJoined,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Username = user.Username,
                    DateOfBirth = user.DateOfBirth
                };

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpGet("[action]/{id}")]
        public ActionResult ConfirmAccount(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            user.EmailConfirmed = true;

            _context.SaveChanges();

            return Redirect("http://localhost:5233/AccountConfirmation.html");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
