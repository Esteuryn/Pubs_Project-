using pubs.Domain.Repository;

namespace pubs.Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
    }
}
