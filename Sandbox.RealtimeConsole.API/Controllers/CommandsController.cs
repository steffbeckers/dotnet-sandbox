using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Sandbox.RealtimeConsole.API.Hubs;

namespace Sandbox.RealtimeConsole.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IHubContext<RealtimeHub> _realtimeHub;

        public CommandsController(IHubContext<RealtimeHub> realtimeHub)
        {
            _realtimeHub = realtimeHub;
        }

        [HttpGet]
        [Route("{command}")]
        public async Task<IActionResult> SendCommand([FromRoute] string command, CancellationToken cancellationToken)
        {
            await _realtimeHub.Clients.All.SendAsync(command, cancellationToken);

            return Ok();
        }

        [HttpGet]
        [Route("open-file")]
        public async Task<IActionResult> OpenFileCommand([FromQuery] string path, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(path))
            {
                return BadRequest("path is a required query param");
            }

            await _realtimeHub.Clients.All.SendAsync("open-file", path, cancellationToken);

            return Ok();
        }
    }
}
