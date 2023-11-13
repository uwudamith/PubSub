using Dapr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Subscriber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        ILogger<SubscriberController> logger;

        public SubscriberController(ILogger<SubscriberController> logger)
        {
            this.logger = logger;
        }

        [Topic("myapp-pubsub", "test-dapr-topic")]
        [HttpPost("subscriber")]
        public IActionResult Post([FromBody] string value)
        {
            logger.LogInformation(value);
            return Ok(value);
        }
    }
}
