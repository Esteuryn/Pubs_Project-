using pubs.Domain;
using pubs.Domain.Repository;
using pubs.Infrastructure.Context;
using pubs.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace pubs.Infrastructure.Repositories
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly pubsContext context;

        public CountriesRepository(pubsContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<Countries, bool>> filter)
        {
            return this.context.Countries.Any(filter);
        }

        public List<Countries> GetJobs()
        {
            return context.Countries.ToList();
        }

        public Countries GetCountries(int id)
        {
            return this.context.Countries.Find(id);
        }

        public void Remove(Countries countries)
        {
            if (countries != null)
            {
                context.Countries.Remove(countries);
                context.SaveChanges();
            }
        }

        public void Save(Countries countries)
        {
            if (countries != null)
            {
                context.Countries.Add(countries);
                context.SaveChanges();
            }
        }

        public void Update(Countries countries)
        {
            if (countries != null)
            {
                context.Countries.Update(countries);
                context.SaveChanges();
            }
        }

        Countries IBaseRepository<Countries>.GetCountry(int Id)
        {
            throw new NotImplementedException();
        }

        List<Countries> IBaseRepository<Countries>.GetCountries()
        {
            throw new NotImplementedException();
        }

        List<Countries> IBaseRepository<Countries>.FindAll(Func<Countries, DateTime> filter)
        {
            throw new NotImplementedException();
        }

        int IBaseRepository<Countries>.Exist(Func<Countries, int> filter)
        {
            throw new NotImplementedException();
        }
    }
}