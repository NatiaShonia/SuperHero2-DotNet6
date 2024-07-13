using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Cryptography.X509Certificates;

namespace SuperHero2Api.Data
{
    public class DateContext : DbContext
    {
        public DateContext(DbContextOptions<DateContext> builder) : base(builder)
        
        {
        
          
        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
