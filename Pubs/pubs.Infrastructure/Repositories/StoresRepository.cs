
using Microsoft.Extensions.Logging;
using pubs.Domain.Entities;
using pubs.Infrastructure.Context;
using pubs.Infrastructure.Core;
using pubs.Infrastructure.Exceptions;
using pubs.Infrastructure.Interfaces;
using pubs.Infrastructure.Models;
using static System.Formats.Asn1.AsnWriter;

namespace pubs.Infrastructure.Repositories
{
    public class StoresRepository : BaseRepository<Store>, IStoresRepository
    {

        private readonly ICustomlogger _logger;
        private readonly Action<string> logErrorMethod;


        public StoresRepository(PubsContext context, ICustomlogger logger) : base(context)
        {
            _logger = logger;
            logErrorMethod = _logger.LogError;
        }

        public override void Update(Store entity)
        {
            try
            {
                var storeToUpdate = this.GetEntity(entity.stor_id);

                if (storeToUpdate is null)
                {
                    throw new StoresException("La tienda no existe");
                }
                else
                {
                    storeToUpdate.stor_name = entity.stor_name;
                    storeToUpdate.stor_address = entity.stor_address;
                    storeToUpdate.city = entity.city;
                    storeToUpdate.state = entity.state;
                    storeToUpdate.zip = entity.zip;
                    this.context.Stores.Update(storeToUpdate);
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logErrorMethod("Error actualizado la tienda " + ex.ToString());
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
                logErrorMethod("Error creando la categoria " + ex.ToString());
            }
        }

        public override void Remove(Store entity)
        {
            try
            {
                Store storeToRemove = this.GetEntity(entity.stor_id);
                if (storeToRemove is null)
                {
                    throw new StoresException("La tienda no existe");
                }
                else
                {
                    storeToRemove.stor_id = entity.stor_id;

                    this.context.Stores.Remove(storeToRemove);
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                logErrorMethod("Error al remover la tienda " + ex.ToString());
            }
        }
    }
}
