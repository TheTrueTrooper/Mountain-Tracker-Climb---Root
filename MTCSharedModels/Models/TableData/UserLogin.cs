using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class UserLogin
    {
        [APIAlwaysRequired(nameof(UserName))]
        public string UserName { get; set; }
        [APIAlwaysRequired(nameof(Password))]
        public string Password { get; set; }
    }
}
