
using pubs.Domain.Entities;
using pubs.Infrastructure.Context;
using pubs.Infrastructure.Interfaces;

namespace pubs.Infrastructure.Repositories
{
    public class StoresRepository : IStoresRepository
    {
        private readonly PubsContext context;

        public StoresRepository(PubsContext context)
        {
            this.context = context;
        }

        public void Create(Store store)
        {
            try 
            {
                this.context.stores.Add(store);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Store GetStore(int storeId)
        {
            return this.context.stores.Find(storeId);
        }

        public List<Store> GetStores()
        {
            return this.context.stores.ToList();
        }

        public void Remove(Store store)
        {
            try
            {
                var storeToRemove = this.GetStore(store.stor_id);
                this.context.stores.Update(storeToRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Store store)
        {
            try
            {
                var storeToUpdate = this.GetStore(store.stor_id);
                storeToUpdate.stor_name = store.stor_name;
                storeToUpdate.stor_address = store.stor_address;
                storeToUpdate.city = store.city;
                storeToUpdate.state = store.state;
                storeToUpdate.zip = store.zip;
                this.context.stores.Update(storeToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
