using System.IO;
using DocumentFormat.OpenXml.Packaging;

namespace SharpDocx
{
    public class SharpDocxImage
    {
        public Stream ImageStream { get; set; }
        public ImagePartType ImagePartType { get; set; }

        public SharpDocxImage(Stream imageStream, ImagePartType imagePartType)
        {
            ImageStream = imageStream;
            ImagePartType = imagePartType;
        }
    }
}