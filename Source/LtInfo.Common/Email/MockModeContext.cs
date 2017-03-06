/*-----------------------------------------------------------------------
<copyright file="MockModeContext.cs" company="Sitka Technology Group">
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
