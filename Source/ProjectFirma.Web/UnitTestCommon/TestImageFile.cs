/*-----------------------------------------------------------------------
<copyright file="TestImageFile.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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
