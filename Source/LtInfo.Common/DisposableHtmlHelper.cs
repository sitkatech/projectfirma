using System;

namespace LtInfo.Common
{
    public class DisposableHtmlHelper : IDisposable
    {
        private readonly Action _end;
        
        public DisposableHtmlHelper(Action begin, Action end)
        {
            _end = end;
            begin();
        }
        public void Dispose()
        {
            _end();
        }
    }
}