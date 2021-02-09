using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class Region
    {
        //public ProvinceOrState OwningProvinceOrState { get; set; }
        public uint ProvinceOrStateID { get; set; }
        public uint ID { get; set; }
        public string EnglishFullName { get; set; }
        public string CountryCode { get; set; }
        public List<District> Districts { get; set; } = null;
    }
}
