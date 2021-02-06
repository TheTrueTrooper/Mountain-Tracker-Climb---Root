using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class Country
    {
        public byte ID { get; set; }
        public string EnglishFullName { get; set; }
        public string CountryCode{ get; set; }
        public List<ProvinceOrState> ProvincesOrStates { get; set; }

    }
}
