
using pubs.Domain.Entities;
using pubs.Domain.Repository;

namespace pubs.Infrastructure.Interfaces
{
    public interface IStoresRepository : IBaseRepository<Store>
    {
        void Create(Store store);
        void Remove(Store store);
        void Update(Store store);
        List<Store> GetStores();
        Store GetStore(int storeId);
    }
}
