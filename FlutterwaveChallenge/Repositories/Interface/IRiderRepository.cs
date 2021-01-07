using FlutterwaveChallenge.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterwaveChallenge.Repositories.Interface
{
    public interface IRiderRepository
    {
        Task<IEnumerable<Rider>> GetAll();
        Task<Rider> Get(string id);
        Task<IEnumerable<Rider>> GetByCountry(string countryname);
        Task<IEnumerable<Rider>> GetByName(string categoryName);
        Task<Rider> Create(Rider rider);
        Task<bool> Update(Rider rider);
        Task<bool> Delete(string id);
    }
}
