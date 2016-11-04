using System;

namespace LtInfo.Common.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class IsComplexOverrideAttribute : Attribute
    {
    }
}