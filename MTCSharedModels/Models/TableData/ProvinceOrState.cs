using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class ProvinceOrState
    {
        //public Country OwningCountry { get; set; } = null;
        public byte CountryID { get; set; }
        public short ID { get; set; }
        public string EnglishFullName { get; set; }
        public string RegionCode { get; set; }
        public List<Region> Regions { get; set; } = null;
    }
}
