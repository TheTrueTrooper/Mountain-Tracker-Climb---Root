using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class DistrictZone
    {
        //public District OwningDistrict { get; set; } = null;
        public uint DistrictID { get; set; }
        public uint ID { get; set; }
        public string EnglishFullName { get; set; }
        public string CountryCode { get; set; }
        public List<ZoneArea> Districts { get; set; } = null;
    }
}
