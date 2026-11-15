
using Microsoft.EntityFrameworkCore;

namespace StudioRags.API.Data
{
    public class StudioRagsDbContext : DbContext
    {
        public StudioRagsDbContext(
            DbContextOptions<StudioRagsDbContext> options)
            : base(options)
        {
        }
    }
}
