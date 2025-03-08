using AspireApp5.ApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace AspireApp5.ApiService
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConnection _connection;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        public ValuesController(IConnection connection)
        {
            _connection = connection;
        }


        [HttpGet]
        public IActionResult GetMessage()
        {
            using var channel = _connection.CreateModel();

            // Try to get a single message from the queue (non-blocking)
            var result = channel.BasicGet(queue: "myAspireRabbit", autoAck: true);

            if (result != null)
            {
                var message = Encoding.UTF8.GetString(result.Body.ToArray());
                return Ok(new { Message = message });
            }
            else
            {
                return NotFound("No messages in the queue.");
            }
        }

        [HttpPost]
        public IActionResult InsertMessage([FromBody] RequestMessage requestMessage)
        {
            try
            {
                using var channel = _connection.CreateModel();
                channel.QueueDeclare(queue: "myAspireRabbit",
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var body = System.Text.Encoding.UTF8.GetBytes(requestMessage.Message);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true; // Makes the message durable

                channel.BasicPublish(exchange: "",
                    routingKey: "myAspireRabbit",
                    basicProperties: properties,
                    body: body);

                return Ok("Message published.");
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
