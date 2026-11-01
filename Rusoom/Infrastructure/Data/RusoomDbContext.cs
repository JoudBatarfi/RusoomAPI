using Microsoft.EntityFrameworkCore;

namespace Rusoom.Infrastructure.Data
{
    public class RusoomDbContext : DbContext
    {
        public RusoomDbContext(DbContextOptions<RusoomDbContext> options)
        : base(options)
        { }
     
    }
}
