using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class DistrictZone
    {
        //public District OwningDistrict { get; set; } = null;
        public int? DistrictID { get; set; }
        [SQLIdentityID]
        public int? ID { get; set; }
        public string EnglishFullName { get; set; }
        public string ZoneCode { get; set; }
        [SQLIgnore]
        public List<ZoneArea> Areas { get; set; } = null;
    }
}
