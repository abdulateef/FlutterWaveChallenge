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
    public class RiderRepository : IRiderRepository
    {
        private readonly IDatabaseContext _context;
        public RiderRepository(IDatabaseContext databaseContext)
        {
            _context = databaseContext;
        }
        public async Task Create(Rider rider)
        {
            await _context.Riders.InsertOneAsync(rider);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Rider> filter = Builders<Rider>.Filter.Eq(p => p.Id, id);
            DeleteResult deleResult = await _context.Riders.DeleteOneAsync(filter);
            return deleResult.IsAcknowledged && deleResult.DeletedCount > 0;
        }

        public async Task<Rider> Get(string id)
        {
            return await _context.Riders.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Rider>> GetAll()
        {
            return await _context.Riders.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<Rider>> GetByCountry(string countryname)
        {
            FilterDefinition<Rider> filter = Builders<Rider>.Filter.ElemMatch(p => p.CountryName, countryname);
            return await _context.Riders.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Rider>> GetByName(string name)
        {
            FilterDefinition<Rider> filter = Builders<Rider>.Filter.ElemMatch(p => p.Name, name);
            return await _context.Riders.Find(filter).ToListAsync();
        }

        public async Task<bool> Update(Rider rider)
        {
            var updaterResult = await _context
                            .Riders
                            .ReplaceOneAsync(filter: g => g.Id == rider.Id, replacement: rider);
            return updaterResult.IsAcknowledged && updaterResult.ModifiedCount > 0;
        }
    }
}
