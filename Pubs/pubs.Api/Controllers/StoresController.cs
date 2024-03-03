using Microsoft.AspNetCore.Mvc;
using pubs.Api.Dtos.Stores;
using pubs.Api.Models;
using pubs.Domain.Entities;
using pubs.Infrastructure.Exceptions;
using pubs.Infrastructure.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace pubs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoresRepository storesRepository;

        public StoresController(IStoresRepository storesRepository)
        {
            this.storesRepository = storesRepository;
        }


        [HttpGet("GetStores")]
        public IActionResult Get()
        {
            var stores = this.storesRepository.GetEntities().Select(stores => new StoreGetModel()
            {
                StoreName = stores.stor_name,
                storeId = stores.stor_id,
                State = stores.state,
                City = stores.city
            });
            return Ok(stores);
        }


        [HttpGet("GetStoresById")]
        public IActionResult Get(string id)
        {
            var store = this.storesRepository.GetEntity(id);
            StoreGetModel storeGetModel = new StoreGetModel()
            {
                storeId = store.stor_id,
                StoreName = store.stor_name,
                City = store.city,
                State = store.state
            };
            return Ok(storeGetModel);
        }

        [HttpPost("SaveStore")]
        public IActionResult Post([FromBody] StoreAddDto storeAddModel)
        {
            this.storesRepository.Save(new Domain.Entities.Store()
            {
                stor_name = storeAddModel.StoreName,
                stor_id = storeAddModel.storeId,
                state = storeAddModel.State,
                city = storeAddModel.City
            });
            return Ok("Tienda guaradada correctamente.");
        }

        [HttpPost("UpdateStore")]
        public IActionResult Put([FromBody] StoreUpdateDto storeUpdate)
        {
            this.storesRepository.Update(new Store()
            {
                stor_id = storeUpdate.storeId,
                stor_name = storeUpdate.StoreName,
                city = storeUpdate.City,
                state = storeUpdate.State
            });
            return Ok("Tienda actualizada correctamente.");
        }

        [HttpPost("RemoveStore")]
        public IActionResult Remove([FromBody] StoreRemoveDto storeRemove)
        {
            this.storesRepository.Remove(new Store()
            {
                stor_id = storeRemove.storeId
            });
            return Ok("Tienda eliminada correctamente.");
        }
    }
}
