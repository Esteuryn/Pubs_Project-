using pubs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Library.Domain.Repository
{
     public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Update (TEntity entity);
        void Remove(TEntity entity);

        List<TEntity> GetJobs();
        TEntity GetJob(int id);
        bool Exists(Expression<Func<Jobs, bool>> filter);
    }
}
