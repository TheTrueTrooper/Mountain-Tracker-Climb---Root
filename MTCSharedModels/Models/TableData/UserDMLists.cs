using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class UserDMLists
    {
        public Dictionary<int, UserDMList> MessagesBetweenUser { get; set; } = new Dictionary<int, UserDMList>();
    }
}
