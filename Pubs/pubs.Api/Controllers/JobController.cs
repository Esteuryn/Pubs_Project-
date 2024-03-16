using Microsoft.AspNetCore.Mvc;
using pubs.Api.Models;
using pubs.Domain.Entities;
using pubs.Infrastructure.Interfaces;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pubs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobsRepository JobsRepository;

        public JobsController(IJobsRepository JobsRepository)
        {
            this.JobsRepository = JobsRepository;
        }


        [HttpGet("GetJobs")]
        public IActionResult Get()
        {
            var jobs = this.JobsRepository.GetEntities();
            /*
            {
                StoreName = stores.stor_name,
                storeId = stores.stor_id,
                State = stores.state,
                City = stores.city
            });
            */
            return Ok(jobs);
        }


        [HttpGet("GetStoresById")]
        public IActionResult Get(short id)
        {
            var jobs = this.JobsRepository.GetEntity(id);
            /*
            {
                StoreName = stores.stor_name,
                storeId = stores.stor_id,
                State = stores.state,
                City = stores.city
            });
            */
            return Ok(jobs);
        }

        [HttpPost("SaveJob")]
        public void Post([FromBody] JobAddModel jobAddModel)
        {
            this.JobsRepository.Save(new Domain.Entities.Jobs()
            {
                job_id = jobAddModel.job_id,
                job_desc = jobAddModel.job_desc,
                Min_lvl = jobAddModel.Min_lvl,
                Max_lvl = jobAddModel.Max_lvl
            });

        }

        
    }
}