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