using Microsoft.AspNetCore.Mvc;
using SenWGames.Core.Interfaces;

namespace SenWGames.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {

        private readonly ILogger<ValuesController> _logger;
        private readonly IValueService _valueService;

        public ValuesController(ILogger<ValuesController> logger, IValueService valueService)
        {
            _logger = logger;
            _valueService = valueService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _valueService.GetAValue(id));
        }
    }
}