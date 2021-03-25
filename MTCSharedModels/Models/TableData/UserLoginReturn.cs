using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class UserLoginReturn
    {
        public int? UserID { get; set; }
        public string BearersToken { get; set; }
    }
}
