using FlutterwaveChallenge.Data.Interface;
using FlutterwaveChallenge.Entities;
using FlutterwaveChallenge.Repositories.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterwaveChallenge.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDatabaseContext _context;
        public CategoryRepository(IDatabaseContext databaseContext)
        {
            _context = databaseContext;
        }
        public async Task Create(Category category)
        {
            await _context.Categories.InsertOneAsync(category);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Category> filter = Builders<Category>.Filter.Eq(p => p.Id, id);
            DeleteResult deleResult = await _context.Categories.DeleteOneAsync(filter);
            return deleResult.IsAcknowledged && deleResult.DeletedCount > 0;
        }

        public async Task<Category> Get(string id)
        {
            return await _context.Categories.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetByName(string name)
        {
            FilterDefinition<Category> filter = Builders<Category>.Filter.ElemMatch(p => p.Name, name);
            return await _context.Categories.Find(filter).ToListAsync();
        }

        public async Task<bool> Update(Category category)
        {
            var updaterResult = await _context
                                                .Categories
                                                .ReplaceOneAsync(filter: g => g.Id == category.Id, replacement: category);
            return updaterResult.IsAcknowledged && updaterResult.ModifiedCount > 0;
        }
    }
}
