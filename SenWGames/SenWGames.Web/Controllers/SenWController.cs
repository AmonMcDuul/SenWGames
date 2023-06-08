using Microsoft.AspNetCore.Mvc;
using SenWGames.Core.Domain.Entities;
using SenWGames.Infrastructure;

namespace SenWGames.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SenWController : ControllerBase
    {
        private readonly SenWDbContext _context;
        private readonly IConfiguration _configuration;

        public SenWController(SenWDbContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }

        [HttpGet("")]
        public ActionResult<List<Group>> GetAllGroups()
        {
            List<Group> groups = _context.Groups.ToList();
            if (groups == null)
            {
                return NoContent();
            }
            return groups;
        }

        [HttpPost("")]
        public ActionResult<Group> PostGroup(string groepsNaam)
        {
            Group newGroup = new Group(groepsNaam, null, null, null, null);
            _context.Groups.Add(newGroup);
            _context.SaveChanges();
            return newGroup;
        }

        [HttpDelete("{id}")]
        public ActionResult<Group> DeleteGroup(long id)
        {
            Group? groupToDelete = _context.Groups.FirstOrDefault(g => g.Id == id);
            if (groupToDelete == null)
            {
                return NotFound();
            }
            _context.Groups.Remove(groupToDelete);
            _context.SaveChanges();
            return Ok();
        }
    }
}
