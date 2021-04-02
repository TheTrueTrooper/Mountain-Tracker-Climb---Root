using MTCSharedModels.Models.Interfaces;
using System.IO;

namespace MTCSharedModels.Models
{
    public class UserBannerPicture : IPictureBytes
    {
        public byte[] BannerPictureBytes { get; set; }
        [SQLIgnore]
        public MemoryStream ImageStream { get => new MemoryStream(BannerPictureBytes); set => BannerPictureBytes = value.ToArray(); }
        [SQLIgnore]
        public byte[] PictureRawBytes { get => BannerPictureBytes; set => PictureRawBytes = value; }
    }
}
