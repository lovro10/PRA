using BL.Models;
using BL.Singleton;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApi.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly PraFichteContext _context;

        public FriendController(PraFichteContext context)
        {
            _context = context;
        }

        // GET: api/<FriendController>
        [HttpGet("[action]")]
        public ActionResult<FriendDto> GetAllFriendRequests()
        {

            var friendDto = _context.Friends
                .Include(x => x.Sender)
                .Include(x => x.Reciever)
                .Select(x => new FriendDto
                {
                    Id = x.Id,
                    SenderId = x.SenderId,
                    UserSender = x.Sender,
                    ReceiverId = x.RecieverId,
                    UserReceiver = x.Reciever,
                    DateSent = x.DateSent,
                    IsAccepted = x.IsAccepted
                });

            return Ok(friendDto);
        }

        // GET api/<FriendController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FriendController>
        [HttpPost("[action]")]
        public ActionResult CreateFriendRequest([FromBody] string jsonFriendDto)
        {
            var friendDto = JsonSerializer.Deserialize<FriendDto>(jsonFriendDto);

            try
            {
                var friend = new Friend
                {
                    SenderId = friendDto.SenderId,
                    RecieverId = friendDto.ReceiverId,
                    DateSent = DateTime.UtcNow,
                    IsAccepted = false
                };

                _context.Friends.Add(friend);
                _context.SaveChanges();

                return Ok(friendDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("[action]")]
        public ActionResult AcceptFriendRequest([FromBody] string jsonFriendDto)
        {
            var friendDto = JsonSerializer.Deserialize<FriendDto>(jsonFriendDto);

            var friend = _context.Friends.FirstOrDefault(x => x.Id == friendDto.Id);

            friend.IsAccepted = true;

            _context.SaveChanges();

            return Ok(friendDto);
        }

        // PUT api/<FriendController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<FriendController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
