/*-----------------------------------------------------------------------
<copyright file="NullableRange.cs" company="Sitka Technology Group">
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
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    public class NullableRange<T> where T : struct, IComparable<T>
    {
        private readonly T? _minimum;
        private readonly T? _maximum;
        private readonly NullableComparer<T> _comparer = new NullableComparer<T>();

        /// <summary>
        /// Minimum value of the range
        /// </summary>
        public T? Minimum
        {
            get { return _minimum; }
        }

        /// <summary>
        /// Maximum value of the range
        /// </summary>
        public T? Maximum
        {
            get { return _maximum; }
        }

        public NullableRange(T? minimum, T? maximum)
        {
            _minimum = minimum;
            _maximum = maximum;
            Check.Require(IsValid(), "Range should be valid");
        }

        /// <summary>
        /// Presents the Range in readable format
        /// </summary>
        /// <returns>String representation of the Range</returns>
        public override string ToString() { return String.Format("[{0} - {1}]", Minimum, Maximum); }

        /// <summary>
        /// Determines if the range is valid
        /// </summary>
        /// <returns>True if range is valid, else false</returns>
        private Boolean IsValid()
        {
            // ReSharper disable CompareNonConstrainedGenericWithNull
            return _minimum == null || _maximum == null || _comparer.Compare(Minimum, Maximum) <= 0;
            // ReSharper restore CompareNonConstrainedGenericWithNull
        }

        /// <summary>
        /// Determines if the provided value is inside the range
        /// </summary>
        /// <param name="value">The value to test</param>
        /// <returns>True if the value is inside Range, else false</returns>
        public Boolean IsValueInRange(T? value)
        {
            // ReSharper disable CompareNonConstrainedGenericWithNull
            var isWithinLowerBound = _minimum == null || _comparer.Compare(Minimum, value) <= 0;
            var isWithinUpperBound = _maximum == null || _comparer.Compare(value, Maximum) <= 0;
            // ReSharper restore CompareNonConstrainedGenericWithNull
            return isWithinLowerBound && isWithinUpperBound;
        }

        public bool OverlapsWithOtherRange(NullableRange<T> rhs)
        {
            return (rhs.IsValueInRange(_maximum) || IsValueInRange(rhs._maximum) || rhs.IsValueInRange(_minimum) || IsValueInRange(rhs._minimum));
        }
    }
}
