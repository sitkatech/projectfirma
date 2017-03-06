/*-----------------------------------------------------------------------
<copyright file="IHavePrimaryKey.cs" company="Sitka Technology Group">
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
using System.Linq;

namespace LtInfo.Common.Models
{
    public interface IHavePrimaryKey
    {
        int PrimaryKey { get; }
    }

    /// <summary>
    /// Useful in <see cref="System.Linq"/> expressions such as <see cref="Enumerable.Distinct{TSource}(System.Collections.Generic.IEnumerable{TSource})"/>
    /// </summary>
    public class HavePrimaryKeyComparer<T> : EqualityComparerByProperty<T> where T : IHavePrimaryKey
    {
        public HavePrimaryKeyComparer() : base(obj => obj.PrimaryKey) { }
    }

    /// <summary>
    /// This is a "safe" comparer in that it handles "null" situations properly automatically for derived classes. Give it a comparer function and it will do the rest.
    /// </summary>
    public abstract class EqualityComparerByProperty<T> : IEqualityComparer<T>
    {
        private readonly Func<T, object> _f;
        protected EqualityComparerByProperty(Func<T, object> f)
        {
            _f = f;
        }
        public bool Equals(T lhs, T rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
            {
                return false;
            }
            var oLhs = _f(lhs);
            var oRhs = _f(rhs);
            return oLhs.Equals(oRhs);
        }
        public int GetHashCode(T obj)
        {
            return ReferenceEquals(obj, null) ? 0 : _f(obj).GetHashCode();
        }
    }
}
