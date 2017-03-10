/*-----------------------------------------------------------------------
<copyright file="DisposableTempFile.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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
using System;
using System.IO;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    public class DisposableTempFile : IDisposable
    {
        private FileInfo _fileInfo;

        private bool _isDisposed;

        public DisposableTempFile()
            : this(Path.GetTempFileName())
        {
        }

        public DisposableTempFile(string tempFileName)
        {
            _fileInfo = new FileInfo(tempFileName);
        }

        public static DisposableTempFile MakeDisposableTempFileEndingIn(string fileEnding)
        {
            var tempFileName = Path.GetTempFileName();
            File.Delete(tempFileName); // we need to delete this right away once we get the path; Path.GetTempFileName() creates a zero byte file on disk
            var tempPath = tempFileName + fileEnding;
            return new DisposableTempFile(tempPath);
        }

        public FileInfo FileInfo
        {
            get
            {
                Check.Require(!_isDisposed, "Object is already disposed");
                return _fileInfo;
            }
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                if (_fileInfo != null)
                {
                    var fileFullName = _fileInfo.FullName;
                    if (File.Exists(fileFullName))
                    {
                        File.Delete(fileFullName);
                    }
                    _fileInfo = null;
                }
                _isDisposed = true;
            }
        }

        ~DisposableTempFile()
        {
            Dispose();
        }
    }
}
