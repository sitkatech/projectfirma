using System.IO;
using System.Web;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public class TestImageFile : HttpPostedFileBase
    {
        private const int Capacity = 8000;
        public FileResourceMimeType FileResourceMimeType = FileResourceMimeType.JPEG;

        public override int ContentLength
        {
            get { return Capacity; }
        }

        public override string ContentType
        {
            get { return FileResourceMimeType.FileResourceMimeTypeContentTypeName; }
        }

        public override string FileName
        {
            get { return @"TempFile.jpg"; }
        }

        /// <summary>
        /// We just need to create a stream with some bytes
        /// </summary>
        public override Stream InputStream
        {
            get
            {
                //MemoryStream memoryStream;
                //// Create the data to write to the stream. 
                //var uniEncoding = new UnicodeEncoding();
                //var firstString = uniEncoding.GetBytes("Invalid file path characters are: ");
                //var secondString = uniEncoding.GetBytes(Path.GetInvalidPathChars());
                //using (memoryStream = new MemoryStream(Capacity))
                //{
                //    // Write the first string to the stream.
                //    memoryStream.Write(firstString, 0, firstString.Length);

                //    // Write the second string to the stream, byte by byte.
                //    var count = 0;
                //    while (count < secondString.Length)
                //    {
                //        memoryStream.WriteByte(secondString[count++]);
                //    }
                //    // Set the position to the beginning of the stream.
                //    memoryStream.Seek(0, SeekOrigin.Begin);
                //}
                //return memoryStream;
                return new MemoryStream(Capacity);
            }
        }
    }
}