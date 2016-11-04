using System;

namespace LtInfo.Common
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CrossAreaRouteAttribute : Attribute
    {
    }
}