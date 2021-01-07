using FlutterwaveChallenge.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterwaveChallenge.Repositories.Interface
{
   public interface ISellerRepository
    {
        Task<IEnumerable<Seller>> GetAll();
        Task<Seller> Get(string id);
        Task<IEnumerable<Seller>> GetByCountry(string countryname);
        Task<IEnumerable<Seller>> GetByName(string categoryName);
        Task<Seller> Create(Seller seller);
        Task<bool> Update(Seller seller);
        Task<bool> Delete(string id);
    }
}
