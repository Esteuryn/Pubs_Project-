using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace pubs.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity GetCountry( int Id);

        List<TEntity> GetCountries();

        List<TEntity> FindAll(Func<TEntity, DateTime> filter);

        int Exist(Func<TEntity, int> filter);

        void Save(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}