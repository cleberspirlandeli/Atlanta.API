using Atlanta.Domain;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Atlanta.API.Controllers
{
    // MassTransit Send
    [Route("api/[controller]")]
    [ApiController]
    public class AtenaController : ControllerBase
    {
        private readonly IBus _bus;

        public AtenaController(IBus bus)
        {
            this._bus = bus;
        }

        // GET: api/<AtenaController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = new string[] { "Atlanta API", "Atena Response" };
            return Ok(result);
        }
     
        // POST api/<AtenaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Atena atena)
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:atena-queue"));

            await endpoint.Send(atena);

            return Ok();
        }

    }
}
