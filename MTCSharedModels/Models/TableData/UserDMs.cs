using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class UserDM
    {
		public int? UserFromID { get; set; }
		public int? UserToID { get; set; }
		[SQLIdentityID]
		public int? DirectMessageID { get; set; }
		[SQLInsertIgnore]
		public bool? Seen { get; set; }
		[SQLInsertIgnore]
		public DateTime? Time { get; set; }
		public string Message { get; set; }
	}
}
