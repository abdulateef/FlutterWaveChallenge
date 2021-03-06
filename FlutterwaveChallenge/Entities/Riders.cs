﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterwaveChallenge.Entities
{
    public class Rider
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Code { get; set; }
        public string CountryId { get; set; }
        public string CallCode { get; set; }
    }
}
