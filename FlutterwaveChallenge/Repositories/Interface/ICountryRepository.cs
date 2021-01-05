using FlutterwaveChallenge.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterwaveChallenge.Repositories.Interface
{
   public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAll();
        Task<Country> Get(string id);
        Task<IEnumerable<Country>> GetByName(string name);
        Task Create(Country country);
        Task<bool> Update(Country country);
        Task<bool> Delete(string id);
    }
}
