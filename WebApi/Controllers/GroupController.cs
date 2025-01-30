using BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApi.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly PraFichteContext _context;

        public GroupController(PraFichteContext context)
        {
            _context = context;
        }

        // GET: api/<GroupController>
        [HttpGet("[action]")]
        public ActionResult<GroupDto> GetAllGroups()
        {
            var groupDto = _context.Groups.Select(x => new GroupDto
            {
                Id = x.Id,
                Name = x.Name,
            });

            return Ok(groupDto);
        }

        // GET api/<GroupController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GroupController>
        [HttpPost("[action]")]
        public ActionResult<GroupDto> CreateGroup([FromBody] string jsonGroup)
        {
            var groupDto = JsonSerializer.Deserialize<GroupDto>(jsonGroup);

            try
            {
                var trimmerGroupName = groupDto.Name.Trim();
                if (_context.Groups.Any(x => x.Name.Equals(trimmerGroupName)))
                {
                    return BadRequest(JsonSerializer.Serialize($"Group with name {trimmerGroupName} already exists"));
                }

                var group = new Group 
                {
                    Id = groupDto.Id,
                    Name = groupDto.Name,
                    DateCreated = DateTime.UtcNow,
                };

                _context.Groups.Add(group);
                _context.SaveChanges();

                return Ok(groupDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<GroupController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            return BadRequest();
        }

        // DELETE api/<GroupController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
