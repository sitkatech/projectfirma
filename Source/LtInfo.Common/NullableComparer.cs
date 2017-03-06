/*-----------------------------------------------------------------------
<copyright file="NullableComparer.cs" company="Sitka Technology Group">
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
using System.Collections.Generic;

namespace LtInfo.Common
{
    public class NullableComparer<T> : IComparer<T?>
        where T : struct, IComparable<T>
    {

        public int Compare(T? x, T? y)
        {
            //Compare nulls acording MSDN specification

            //Two nulls are equal
            if (!x.HasValue && !y.HasValue)
                return 0;

            //Any object is greater than null
            if (x.HasValue && !y.HasValue)
                return 1;

            if (!x.HasValue)
                return -1;

            //Otherwise compare the two values
            return x.Value.CompareTo(y.Value);
        }
    }
}
