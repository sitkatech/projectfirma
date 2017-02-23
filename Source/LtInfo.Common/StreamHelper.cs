/*-----------------------------------------------------------------------
<copyright file="StreamHelper.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    public static class StreamHelper
    {
        public static MemoryStream StreamToMemoryStream(Stream sourceStream)
        {
            Check.RequireNotNull(sourceStream);
            Check.Require(sourceStream.CanRead, "Can't read stream which is required to convert stream to another type.");

            long originalPosition = 0;

            if (sourceStream.CanSeek)
            {
                originalPosition = sourceStream.Position;
                sourceStream.Position = 0;
            }

            var mem = new MemoryStream();
            try
            {
                var temporaryBuffer = new byte[8192];
                int count;
                do
                {
                    count = sourceStream.Read(temporaryBuffer, 0, temporaryBuffer.Length);

                    if (count != 0)
                        mem.Write(temporaryBuffer, 0, count);
                } while (count > 0); // any more data to read?

                mem.Flush();
                mem.Position = 0;

                if (sourceStream.CanSeek)
                    sourceStream.Position = originalPosition;
            }
            catch
            {
                mem.Dispose();
                throw;
            }

            return mem;
        }

        public static byte[] ReadFully(this Stream input)
        {
            using (var ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

    }
}
