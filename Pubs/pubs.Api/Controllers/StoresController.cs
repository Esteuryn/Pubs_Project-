using Microsoft.AspNetCore.Mvc;
using pubs.Api.Dtos.Stores;
using pubs.Api.Models;
using pubs.Application.Contracts;
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
        private readonly IStoresService storeService;

        public StoresController(IStoresService storeService)
        {
            this.storeService = storeService;
        }


        [HttpGet("GetStores")]
        public IActionResult Get()
        {
            var result = this.storeService.GetStores();

            if (!result.Success) 
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpGet("GetStoresById")]
        public IActionResult Get(string id)
        {
            var result = this.storeService.GetStore(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("SaveStore")]
        public IActionResult Post([FromBody] Application.Dtos.Store.StoreAddDto storeAddModel)
        {
            var result = this.storeService.SaveStore(storeAddModel);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("UpdateStore")]
        public IActionResult Put([FromBody] Application.Dtos.Store.StoreUpdateDto storeUpdate)
        {
            var result = this.storeService.UpdateStore(storeUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("RemoveStore")]
        public IActionResult Remove([FromBody] Application.Dtos.Store.StoreRemoveDto storeRemove)
        {
            var result = this.storeService.RemoveStore(storeRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
