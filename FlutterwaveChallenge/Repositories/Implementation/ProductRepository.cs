using FlutterwaveChallenge.Data.Implementation;
using FlutterwaveChallenge.Data.Interface;
using FlutterwaveChallenge.Entities;
using FlutterwaveChallenge.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
        public async Task<Product> Create(Product product)
        {
            try
            {
                Product doc = new Product
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = product.Name,
                    Category = product.Category,
                    Description = product.Description,
                    ImageFile = product.ImageFile,
                    Price = product.Price,
                    Summary = product.Summary

                };
                await _context.Products.InsertOneAsync(doc);
                return product;
            }
            catch (Exception ex)
            {
                return new Product();
            }

        }
        public async Task<bool> Delete(string id)
        {
            try
            {
                FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);
                DeleteResult deleResult = await _context.Products.DeleteOneAsync(filter);
                return deleResult.IsAcknowledged && deleResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }

        public async Task<bool> Update(Product product)
        {
            try
            {
                var updaterResult = await _context
                .Products
                .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
                return updaterResult.IsAcknowledged && updaterResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
