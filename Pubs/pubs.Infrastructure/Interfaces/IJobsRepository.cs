using Library.Domain.Repository;
using pubs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace pubs.Infrastructure.Interfaces
{
    public interface IJobsRepository : IBaseRepository<Jobs>
    {
        // Aqui van los metodos exclusivos de la entidad 
        bool Exists(Expression<Func<Jobs, bool>> filter);
        List<Jobs> GetJobs();
        Jobs GetJob(int id);
        void Remove(Jobs jobs);
        void Save(Jobs jobs);
        void Update(Jobs jobs);
    }
}
