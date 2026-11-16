
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioRags.API.Data;

namespace StudioRags.API.Controllers
{
    [ApiController]
    [Route("api/database-test")]
    public class DatabaseTestController : ControllerBase
    {
        private readonly StudioRagsDbContext _context;

        public DatabaseTestController(StudioRagsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> TestConnection()
        {
            bool connected = await _context.Database.CanConnectAsync();

            if (connected)
            {
                return Ok(new
                {
                    message = "Studio Rags database connected successfully!"
                });
            }

            return StatusCode(503, new
            {
                message = "Database connection failed."
            });
        }
    }
}
