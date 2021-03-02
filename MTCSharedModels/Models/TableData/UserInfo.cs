using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models.TableData
{
    public class UserInfo
    {
        public int? ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PicturePath { get; set; }
        public string Bio { get; set; }
        public string ProfileURL { get; set; }
        public bool? KeepPrivate { get; set; }
    }
}
