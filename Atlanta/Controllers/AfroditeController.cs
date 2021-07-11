using Atlanta.Domain;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Atlanta.API.Controllers
{
    // Publish
    [Route("api/[controller]")]
    [ApiController]
    public class AfroditeController : ControllerBase
    {
        private readonly IPublishEndpoint _bus;

        public AfroditeController(IPublishEndpoint publishEndpoint)
        {
            this._bus = publishEndpoint;
        }

        // GET: api/<AfroditeController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = new string[] { "Atlanta API", "Afrodite Response" };
            return Ok(result);
        }

        // POST api/<AfroditeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Gods afrodite)
        {
            await _bus.Publish<Gods>(afrodite);
            return Ok();
        }

    }
}
