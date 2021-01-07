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
    public class SellerRepository : ISellerRepository
    {
        private readonly IDatabaseContext _context;
        private readonly ICountryRepository _countryRepository;
        public SellerRepository(IDatabaseContext databaseContext, ICountryRepository countryRepository)
        {
            _context = databaseContext;
            _countryRepository = countryRepository;
        }
        public async Task<Seller> Create(Seller seller)
        {
            try
            {
                var country = await _countryRepository.Get(seller.CountryId);
                if (country != null)
                {
                    Seller doc = new Seller
                    {
                        Id = ObjectId.GenerateNewId().ToString(),
                        Address = seller.Address,
                        CountryId = seller.CountryId,
                        DOB = seller.DOB,
                        Email = seller.Email,
                        FirstName = seller.FirstName,
                        PhoneNumber = seller.PhoneNumber,
                        PostalCode = seller.PostalCode,
                        ShopName = seller.ShopName


                    };
                    await _context.Sellers.InsertOneAsync(doc);
                }

                return seller;
            }
            catch (Exception ex)
            {
                return new Seller();
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                FilterDefinition<Seller> filter = Builders<Seller>.Filter.Eq(p => p.Id, id);
                DeleteResult deleResult = await _context.Sellers.DeleteOneAsync(filter);
                return deleResult.IsAcknowledged && deleResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Seller> Get(string id)
        {
            return await _context.Sellers.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Seller>> GetAll()
        {
            return await _context.Sellers.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<Seller>> GetByCountry(string countryid)
        {
            FilterDefinition<Seller> filter = Builders<Seller>.Filter.Eq(p => p.CountryId, countryid);
            return await _context.Sellers.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Seller>> GetByName(string name)
        {
            FilterDefinition<Seller> filter = Builders<Seller>.Filter.Eq(p => p.ShopName, name);
            return await _context.Sellers.Find(filter).ToListAsync();
        }

        public async Task<bool> Update(Seller seller)
        {
            try
            {
                var updaterResult = await _context
                           .Sellers
                           .ReplaceOneAsync(filter: g => g.Id == seller.Id, replacement: seller);
                return updaterResult.IsAcknowledged && updaterResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
