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
    public class CountryRepository : ICountryRepository
    {
        private readonly IDatabaseContext _context;
        public CountryRepository(IDatabaseContext databaseContext)
        {
            _context = databaseContext;
        }
        public async Task<Country> Create(Country country)
        {
            try
            {
                Country doc = new Country
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = country.Name,
                     CallCode = country.CallCode,
                      Code = country.Code,
                       Currency = country.Currency
                };
                await _context.Countries.InsertOneAsync(doc);
                return country; 
            }
            catch (Exception ex)
            {
                return new Country();
            }
        }
         
        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Country> filter = Builders<Country>.Filter.Eq(p => p.Id, id);
            DeleteResult deleResult = await _context.Countries.DeleteOneAsync(filter);
            return deleResult.IsAcknowledged && deleResult.DeletedCount > 0;
        }

        public async Task<Country> Get(string id)
        {
            return await _context.Countries.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _context.Countries.Find(p => true).ToListAsync();
        }

        public async Task<Country> GetByName(string Name)
        {
            FilterDefinition<Country> filter = Builders<Country>.Filter.Eq(p => p.Name, Name);
            return await _context.Countries.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Country country)
        {
            var updaterResult = await _context
                                    .Countries
                                    .ReplaceOneAsync(filter: g => g.Id == country.Id, replacement: country);
            return   updaterResult.IsAcknowledged && updaterResult.ModifiedCount > 0;
        }
    }
}
