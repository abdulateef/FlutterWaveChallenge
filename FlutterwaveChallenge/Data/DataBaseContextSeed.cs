using FlutterwaveChallenge.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterwaveChallenge.Data
{
    public class DataBaseContextSeed
    {
        public static void SeedDataProduct(IMongoCollection<Product> productCollection)
        {
            bool productExist = productCollection.Find(p => true).Any();
            if (!productExist)
            {
                productCollection.InsertMany(GetPreConfiguredProduct());
            }
        }

        public static void SeedDataCategory(IMongoCollection<Category> categoryCollection)
        {
            bool productExist = categoryCollection.Find(p => true).Any();
            if (!productExist)
            {
                categoryCollection.InsertMany(GetPreConfigureCategory());
            }
        }

        public static void SeedDataSeller(IMongoCollection<Seller> SellerCollection)
        {
            bool productExist = SellerCollection.Find(p => true).Any();
            if (!productExist)
            {
                SellerCollection.InsertMany(GetPreConfiguredSeller());
            }
        }
        public static void SeedDataCountry(IMongoCollection<Country> countryCollection)
        {
            bool productExist = countryCollection.Find(p => true).Any();
            if (!productExist)
            {
                countryCollection.InsertMany(GetPreConfiguredCountry());
            }
        }
        public static void SeedDataRider(IMongoCollection<Rider> SellerCollection)
        {
            bool productExist = SellerCollection.Find(p => true).Any();
            if (!productExist)
            {
                SellerCollection.InsertMany(GetPreConfiguredRider());
            }
        }
        private static IEnumerable<Category> GetPreConfigureCategory()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Name = "    Drinks",
                    

                },
                 new Category()
                {
                    Name = "Wears",
                 

                }, new Category()
                {
                    Name = "Furniture",
                   

                }, new Category()
                {
                    Name = "Electronics",
                   
                }
            };
        }

        private static IEnumerable<Product> GetPreConfiguredProduct()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "Iphone x",
                    Category = "Smart Phone",
                    Description = "nice smart phone",
                    ImageFile = "product-4.png",
                    Price = 1000,

                },
                 new Product()
                {
                    Name = "Iphone x",
                    Category = "Smart Phone",
                    Description = "nice smart phone",
                    ImageFile = "product-4.png",
                    Price = 1000,

                }, new Product()
                {
                    Name = "Iphone x",
                    Category = "Smart Phone",
                    Description = "nice smart phone",
                    ImageFile = "product-4.png",
                    Price = 1000,

                }, new Product()
                {
                    Name = "Iphone x",
                    Category = "Smart Phone",
                    Description = "nice smart phone",
                    ImageFile = "product-4.png",
                    Price = 1000,

                }
            };
        }

        private static IEnumerable<Seller> GetPreConfiguredSeller()
        {
            return new List<Seller>()
            {
                new Seller()
                {
                    Address = "yaba",
                    CountryName  = "Nigeria" ,
                    DOB = DateTime.Now,
                    Email = "thpen0411@gmail.com",
                    FirstName = "Abdulateef",
                    PhoneNumber = "08182367005",
                    PostalCode = "000000",
                    ShopName = "Teminik Store"

                },
                 new Seller()
                {
                    Address = "yaba",
                    CountryName  = "Nigeria" ,
                    DOB = DateTime.Now,
                    Email = "thpen04@gmail.com",
                    FirstName = "Abdulateef",
                    PhoneNumber = "08184367005",
                    PostalCode = "000000",
                    ShopName = "Abike Store"

                }
            };
        }
        private static IEnumerable<Rider> GetPreConfiguredRider()
        {
            return new List<Rider>()
            {
                new Rider()
                {
                   CallCode =  "+234",
                   Code =  "1111",
                   CountryName = "Nigeria",
                   Email = "thepen0411@gail.com",
                   Name = "Solo Ride",
                   PhoneNumber = "08182367005"

                }
                
            };
        }
        private static IEnumerable<Country> GetPreConfiguredCountry()
        {
            return new List<Country>()
            {
                new Country()
                {
                   CallCode =  "+234",
                   Code =  "1111",
                   Currency = "NGN",
                   Name = "Nigeria",

                }

            };
        }

    }
}
