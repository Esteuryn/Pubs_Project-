using pubs.Domain.Entities;
using pubs.Infrastructure.Context;
using pubs.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace pubs.Infrastructure.Repositories
{
    public class JobsRepository : IJobsRepository
    {
        private readonly PubsContext context;

        public JobsRepository(PubsContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<Jobs , bool>> filter)
        {
            return this.context.Jobs.Any(filter);
        }

        public List<Jobs> GetJobs()
        {
            return context.Jobs.ToList();
        }

        public Jobs GetJob(int id)
        {
            return this.context.Jobs.Find(id);
        }

        public void Remove(Jobs jobs )
        {
            if (jobs != null)
            {
                context.Jobs.Remove(jobs);
                context.SaveChanges();
            }
        }

        public void Save(Jobs jobs)
        {
            if (jobs != null)
            {
                context.Jobs.Add(jobs);
                context.SaveChanges();
            }
        }

        public void Update(Jobs jobs)
        {
            if (jobs != null)
            {
                context.Jobs.Update(jobs);
                context.SaveChanges();
            }
        }
    }
}
