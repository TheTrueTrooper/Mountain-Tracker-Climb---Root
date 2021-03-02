using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class Gear
    {
        public byte? ID { get; set; }
        public string EnglishFullName { get; set; }

        [SQLIgnore]
        public List<GearSize> ClimbingWalls { get; set; } = null;
    }
}
