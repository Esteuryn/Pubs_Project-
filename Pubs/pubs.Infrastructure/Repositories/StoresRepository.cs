
using Microsoft.Extensions.Logging;
using pubs.Domain.Entities;
using pubs.Infrastructure.Context;
using pubs.Infrastructure.Core;
using pubs.Infrastructure.Interfaces;
using pubs.Infrastructure.Models;
using static System.Formats.Asn1.AsnWriter;

namespace pubs.Infrastructure.Repositories
{
    public class StoresRepository : BaseRepository<Store>, IStoresRepository
    {

        private readonly ILogger<StoresRepository> logger;

        public StoresRepository(PubsContext context, ILogger<StoresRepository> logger) : base(context)
        {
            this.logger = logger;
        }

        public override void Update(Store entity)
        {
            try
            {
                var storeToUpdate = this.GetEntity(entity.stor_id);
                storeToUpdate.stor_name = entity.stor_name;
                storeToUpdate.stor_address = entity.stor_address;
                storeToUpdate.city = entity.city;
                storeToUpdate.state = entity.state;
                storeToUpdate.zip = entity.zip;
                this.context.Stores.Update(storeToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actualizado la tienda", ex.ToString());
            }
        }

        public override void Save(Store entity)
        {
            try
            {
                this.context.Stores.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error creando la categoria", ex.ToString());
            }
        }

        public List<StoresModel> GetStoresById(int storeId)
        {
            throw new NotImplementedException();
        }
    }
}
