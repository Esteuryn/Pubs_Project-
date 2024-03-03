

using Library.Domain.Repository;
using pubs.Domain.Entities;
using System.Linq.Expressions;

namespace pubs.Infrastructure.Core

   
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public bool Exists(Expression<Func<Jobs, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public TEntity GetJob(int id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetJobs()
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
 