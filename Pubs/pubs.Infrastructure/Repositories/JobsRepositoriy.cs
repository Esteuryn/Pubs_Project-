using Microsoft.Extensions.Logging;
using pubs.Domain.Entities;
using pubs.Infrastructure.Context;
using pubs.Infrastructure.Core;
using pubs.Infrastructure.Exceptions;
using pubs.Infrastructure.Interfaces;

namespace pubs.Infrastructure.Repositories
{
    public class JobsRepository : BaseRepository<Jobs>, IJobsRepository
    {

        private readonly ILogger<JobsRepository> logger;


        public JobsRepository(PubsContext context, ILogger<JobsRepository> logger) : base(context)
        {
            this.logger = logger;
        }

        public override void Update(Jobs entity)
        {
            try
            {
                var JobToUpdate = this.GetEntity(entity.job_id);

                if (JobToUpdate is null)
                {
                    throw new JobsException("La tienda no existe");
                }
                else
                {
                    JobToUpdate.job_id = entity.job_id;
                    JobToUpdate.job_desc = entity.job_desc;
                    JobToUpdate.Min_lvl = entity.Min_lvl; 
                    JobToUpdate.Max_lvl = entity.Max_lvl; 
                    this.context.Jobs.Update(JobToUpdate);
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actualizado la tienda", ex.ToString());
            }
        }


        public override void Save(Jobs entity)
        {
            try
            {
                this.context.Jobs.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error creando la categoria", ex.ToString());
            }
        }

        public override void Remove(Jobs entity)
        {
            try
            {
                Jobs JobsToRemove = this.GetEntity(entity.job_id);
                if (JobsToRemove is null)
                {
                    throw new JobsException("La tienda no existe");
                }
                else
                {
                    JobsToRemove.job_id = entity.job_id;

                    this.context.Jobs.Remove(JobsToRemove);
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al remover la tienda", ex.ToString());
            }
        }
    }
}