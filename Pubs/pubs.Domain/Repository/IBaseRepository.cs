namespace pubs.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity GetEntity(string id);

        List<TEntity> GetEntities();

        List<TEntity> FindAll(Func<TEntity, bool> filter);

        bool Exist(Func<TEntity, bool> filter);

        void Save(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
