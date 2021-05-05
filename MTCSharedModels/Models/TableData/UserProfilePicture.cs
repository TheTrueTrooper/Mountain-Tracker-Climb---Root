using MTCSharedModels.Models.Interfaces;
using System.IO;

namespace MTCSharedModels.Models
{
    public class UserProfilePicture : IPictureBytes
    {
        public byte[] ProfilePictureBytes { get; set; }
        [SQLIgnore]
        public MemoryStream ImageStream { get => new MemoryStream(ProfilePictureBytes); set => ProfilePictureBytes = value.ToArray(); }
        [SQLIgnore]
        public byte[] PictureRawBytes { get => ProfilePictureBytes; set => ProfilePictureBytes = value; }
    }
}
