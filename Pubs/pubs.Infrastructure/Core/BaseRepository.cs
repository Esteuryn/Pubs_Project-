using Microsoft.EntityFrameworkCore;
using pubs.Domain.Repository;
using pubs.Infrastructure.Context;
namespace pubs.Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        public readonly pubsContext context;
        public readonly DbSet<TEntity> DBentity;

        protected BaseRepository(pubsContext context)
        {
            this.context = context;
            this.DBentity = context.Set<TEntity>();
        }

        public virtual bool Exist(Func<TEntity, bool> filter)
        {
            return DBentity.Any(filter);
        }

        public virtual List<TEntity> FindAll(Func<TEntity, bool> filter)
        {
            return DBentity.Where(filter).ToList();
        }

        public List<TEntity> GetEntities()
        {
            return DBentity.ToList();
        }


        public virtual void Save(TEntity entity)
        {
            try
            {
                DBentity.Add(entity);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                DBentity.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Remove(TEntity entity)
        {
            try
            {
                DBentity.Update(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TEntity GetEntity(string id)
        {
            throw new NotImplementedException();
        }
    }
}