using System.IO;

namespace MTCSharedModels.Models.Interfaces
{
    public interface IPictureBytes
    {
        MemoryStream ImageStream { get; set; }
        byte[] PictureRawBytes { get; set; }
    }
}
