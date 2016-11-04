using System;

namespace LtInfo.Common.Email
{
    /// <summary>
    /// For testing purposes, allows a using() block to start and end a mock situation
    /// </summary>
    public class MockModeContext : IDisposable
    {
        private readonly Action _endMockModeFunction;
        private readonly Action _startMockModeFunction;

        public MockModeContext(Action startMockModeFunction, Action endMockModeFunction)
        {
            _startMockModeFunction = startMockModeFunction;
            _endMockModeFunction = endMockModeFunction;
            _startMockModeFunction();
        }

        public void Dispose()
        {
            _endMockModeFunction();
        }
    }
}