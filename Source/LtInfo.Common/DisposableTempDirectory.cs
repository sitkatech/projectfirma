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