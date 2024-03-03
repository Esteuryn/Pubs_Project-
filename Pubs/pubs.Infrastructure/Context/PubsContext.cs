using Microsoft.EntityFrameworkCore;
using pubs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
