
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using static System.Formats.Asn1.AsnWriter;
using pubs.Domain;

namespace pubs.Infrastructure.Context
{
    public class PubsContext : DbContext
    {
        public PubsContext(DbContextOptions<PubsContext> options) : base(options)
        {
        }

        public DbSet<Countries> Countries { get; set; }
    }
}