using EventBus.Messages.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Publisher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IBus _bus;

        public MessageController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MessageEvent message)
        {
            if (message == null || string.IsNullOrEmpty(message.Text))
            {
                return BadRequest("Invalid message");
            }

            // Enviar el mensaje a la cola
            await _bus.Publish(message);

            return Ok("Message sent");
        }
    }

}
