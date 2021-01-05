using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterwaveChallenge.Entities
{
    public class Seller
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string FirstName { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string CountryName { get; set; }
        public DateTime? DOB { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
