using FlutterwaveChallenge.Data.Implementation;
using FlutterwaveChallenge.Data.Interface;
using FlutterwaveChallenge.Entities;
using FlutterwaveChallenge.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterwaveChallenge.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDatabaseContext _context;

        public ProductRepository(IDatabaseContext catalogContext)
        {
            _context = catalogContext;
        }
        public async Task Create(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            DeleteResult deleResult = await _context.Products.DeleteOneAsync(filter);
            return deleResult.IsAcknowledged && deleResult.DeletedCount > 0;
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Category, categoryName);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }

        public async Task<bool> Update(Product product)
        {
            var updaterResult = await _context
                .Products
                .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
            return updaterResult.IsAcknowledged && updaterResult.ModifiedCount > 0;
        }
    }

}
