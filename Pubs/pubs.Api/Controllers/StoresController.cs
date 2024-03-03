using Microsoft.AspNetCore.Mvc;
using pubs.Api.Models;
using pubs.Infrastructure.Interfaces;
using System.Security.Cryptography.X509Certificates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            var stores = this.storesRepository.GetEntities();
            return Ok(stores);
        }


        [HttpGet("GetStoresById")]
        public IActionResult Get(string id)
        {
            var stores = this.storesRepository.GetEntity(id);
            return Ok(stores);
        }

        // POST api/<StoresController>
        [HttpPost("SaveStore")]
        public void Post([FromBody] StoreAddModel storeAddModel)
        {
            this.storesRepository.Save(new Domain.Entities.Store()
            {
                stor_name = storeAddModel.StoreName,
                stor_id = storeAddModel.storeId
            });
        }

        // PUT api/<StoresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StoresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
