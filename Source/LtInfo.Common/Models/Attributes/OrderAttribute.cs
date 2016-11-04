using System;

namespace LtInfo.Common.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class OrderAttribute : Attribute
    {
        private readonly int _order;

        public OrderAttribute(int order)
        {
            _order = order;
        }

        public int Order
        {
            get { return _order; }
        }
    }
}