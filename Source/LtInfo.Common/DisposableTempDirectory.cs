/*-----------------------------------------------------------------------
<copyright file="DisposableTempDirectory.cs" company="Sitka Technology Group">
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
using System;
using System.IO;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    public class DisposableTempDirectory : IDisposable
    {
        private DirectoryInfo _directoryInfo;

        private bool _isDisposed;

        public DisposableTempDirectory()
        {
            var newTempDirectoryName = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            _directoryInfo = new DirectoryInfo(newTempDirectoryName);
            Check.Assert(!_directoryInfo.Exists, string.Format("Directory {0} already exists", newTempDirectoryName));
            _directoryInfo.Create();
        }

        public DirectoryInfo DirectoryInfo
        {
            get
            {
                Check.Require(!_isDisposed, "Object is already disposed");
                return _directoryInfo;
            }
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                if (_directoryInfo != null)
                {
                    var directoryFullName = _directoryInfo.FullName;
                    if (Directory.Exists(directoryFullName))
                    {
                        Directory.Delete(directoryFullName, true);
                    }
                    _directoryInfo = null;
                }
                _isDisposed = true;
            }
        }

        ~DisposableTempDirectory()
        {
            Dispose();
        }
    }
}
