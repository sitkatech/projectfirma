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
            var tempPath = Path.GetTempFileName() + fileEnding;
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