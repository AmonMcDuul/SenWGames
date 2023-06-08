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
        public ActionResult<Group> GetAllGroups()
        {
            List<Group> groups = _context.Groups.ToList();
            if (groups == null)
            {
                return NoContent();
            }
            return Ok(groups);
        }
    }
}
