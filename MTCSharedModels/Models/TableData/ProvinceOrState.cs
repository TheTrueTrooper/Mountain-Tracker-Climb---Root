using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class ProvinceOrState
    {
        public Country OwningCountry { get; set; }
        public byte CountryID { get; set; }
        public ushort ID { get; set; }
        public string EnglishFullName { get; set; }
        public string CountryCode { get; set; }
        public List<Region> Regions { get; set; }
    }
}
