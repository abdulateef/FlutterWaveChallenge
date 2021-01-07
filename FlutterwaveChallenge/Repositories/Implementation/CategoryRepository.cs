using FlutterwaveChallenge.Data.Interface;
using FlutterwaveChallenge.Entities;
using FlutterwaveChallenge.Repositories.Interface;
using MongoDB.Bson;
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
        public async Task<Category> Create(Category category)
        {
            try
            {
                try
                {
                    Category doc = new Category
                    {
                        Id = ObjectId.GenerateNewId().ToString(),
                        Name = category.Name
                    };
                    await _context.Categories.InsertOneAsync(doc);
                    return category;
                }
                catch (Exception ex)
                {
                    return new Category();
                }
            }
            catch (Exception ex)
            {
                return new Category();
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                FilterDefinition<Category> filter = Builders<Category>.Filter.Eq(p => p.Id, id);
                DeleteResult deleResult = await _context.Categories.DeleteOneAsync(filter);
                return deleResult.IsAcknowledged && deleResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
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
            FilterDefinition<Category> filter = Builders<Category>.Filter.Eq(p => p.Name, name);
            return await _context.Categories.Find(filter).ToListAsync();
        }

        public async Task<bool> Update(Category category)
        {
            try
            {
                var updaterResult = await _context
                                              .Categories
                                              .ReplaceOneAsync(filter: g => g.Id == category.Id, replacement: category);
                return updaterResult.IsAcknowledged && updaterResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
