
using Microsoft.AspNetCore.Mvc;

namespace StudioRags.API.Controllers
{
    [ApiController]
    [Route("api/hello")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                message = "Hello from Studio Rags Backend!"
            });
        }
    }
}
