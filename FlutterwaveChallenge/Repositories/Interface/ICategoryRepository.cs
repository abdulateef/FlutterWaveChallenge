using FlutterwaveChallenge.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterwaveChallenge.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> Get(string id);
        Task<IEnumerable<Category>> GetByName(string name);
        Task Create(Category category);
        Task<bool> Update(Category category);
        Task<bool> Delete(string id);
    }
}
