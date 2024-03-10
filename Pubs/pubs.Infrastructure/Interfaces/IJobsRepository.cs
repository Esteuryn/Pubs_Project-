using pubs.Domain.Repository;
using pubs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace pubs.Infrastructure.Interfaces
{
    public interface IJobsRepository : IBaseRepository<Jobs>
    {
    }
}
