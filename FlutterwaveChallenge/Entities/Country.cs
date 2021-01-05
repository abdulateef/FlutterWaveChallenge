using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterwaveChallenge.Entities
{
    public class Country
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Currency { get; set; }
        public string CallCode { get; set; }

    }
}
