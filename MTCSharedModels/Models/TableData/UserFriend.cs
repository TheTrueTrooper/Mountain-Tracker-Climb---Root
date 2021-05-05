using System;

namespace MTCSharedModels.Models
{
    public class UserFriend
    {
		public int UserFromID { get; set; }
		public int UserToID { get; set; }
		[SQLInsertIgnore]
		public bool? Accepted { get; set; }
		[SQLInsertIgnore]
		public DateTime? RequestCreationDate { get; set; }
		[SQLInsertIgnore]
		public DateTime? RequestAcceptDate { get; set; }
	}
}
