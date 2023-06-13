using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using SenWGames.Core.Domain.Entities;
using SenWGames.Web.Hubs;
using System.Threading.Tasks;

namespace SenWGames.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SignalRTestController : ControllerBase
    {
        private readonly HubConnection _hubConnection;

        public SignalRTestController(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] string groepsNaam)
        {
            await _hubConnection.StartAsync(); // Start the SignalR connection

            Group group = await _hubConnection.InvokeAsync<Group>("CreateGroup", groepsNaam);

            await _hubConnection.StopAsync(); // Stop the SignalR connection

            return Ok(group);
        }
    }
}
