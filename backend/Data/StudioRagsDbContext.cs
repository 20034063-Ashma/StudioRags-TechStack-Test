

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudioRags.API.Data
{
    public class StudioRagsDbContext
        : IdentityDbContext<IdentityUser>
    {
        public StudioRagsDbContext(
            DbContextOptions<StudioRagsDbContext> options)
            : base(options)
        {
        }
    }
}

