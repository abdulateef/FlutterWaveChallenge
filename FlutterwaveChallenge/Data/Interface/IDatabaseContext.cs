using FlutterwaveChallenge.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterwaveChallenge.Data.Interface
{
    public interface IDatabaseContext
    {
        IMongoCollection<Product> Products { get; }
        IMongoCollection<Category> Categories { get; }
        IMongoCollection<Seller> Sellers { get; }
        IMongoCollection<Rider> Riders { get; }
        IMongoCollection<Country> Countries { get; }



    }
}
