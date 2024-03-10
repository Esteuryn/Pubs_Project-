using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using pubs.Domain.Entities;


namespace pubs.Infrastructure.Context
{
    public class PubsContext : DbContext
    {

        public PubsContext(DbContextOptions<PubsContext> options) : base(options)
        {

        }

        public DbSet<Jobs> Jobs { get; set; }
    }
}
