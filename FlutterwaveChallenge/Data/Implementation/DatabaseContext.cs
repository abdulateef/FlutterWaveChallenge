using FlutterwaveChallenge.Appsettings;
using FlutterwaveChallenge.Data.Interface;
using FlutterwaveChallenge.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterwaveChallenge.Data.Implementation
{
    public class DatabaseContext : IDatabaseContext
    {
        public DatabaseContext(IAppsetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
           
            Products = database.GetCollection<Product>(settings.ProductCollectionName);
            DataBaseContextSeed.SeedDataProduct(Products);
           
            Riders = database.GetCollection<Rider>(settings.RiderCollectionName);
            DataBaseContextSeed.SeedDataRider(Riders);

            Countries = database.GetCollection<Country>(settings.CountryCollectionName);
            DataBaseContextSeed.SeedDataCountry(Countries);

            Sellers = database.GetCollection<Seller>(settings.SellerCollectionName);
            DataBaseContextSeed.SeedDataSeller(Sellers);

            Categories = database.GetCollection<Category>(settings.CategoryCollectionName);
            DataBaseContextSeed.SeedDataCategory(Categories);
        }
        public IMongoCollection<Product> Products { get; }

        public IMongoCollection<Category> Categories { get; }

        public IMongoCollection<Seller> Sellers { get; }

        public IMongoCollection<Country> Countries { get; }

        public IMongoCollection<Rider> Riders { get; }

    }
}
