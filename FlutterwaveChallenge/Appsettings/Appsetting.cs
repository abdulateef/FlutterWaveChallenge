using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterwaveChallenge.Appsettings
{
    public class Appsetting : IAppsetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ProductCollectionName { get; set; }
        public string SellerCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string RiderCollectionName { get; set; }
        public string CountryCollectionName { get; set; }
    }
}
