
using Microsoft.Extensions.Logging;
using pubs.Domain;

using pubs.Infrastructure.Context;
using pubs.Infrastructure.Core;
using pubs.Infrastructure.Exceptions;
using pubs.Infrastructure.Interfaces;
using pubs.Infrastructure.Models;
using static System.Formats.Asn1.AsnWriter;

namespace pubs.Infrastructure.Repositories
{
    public class CountriesRepository : BaseRepository<Countries>, ICountriesRepository
    {

       
    }
}