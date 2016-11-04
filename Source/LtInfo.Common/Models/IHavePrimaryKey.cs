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