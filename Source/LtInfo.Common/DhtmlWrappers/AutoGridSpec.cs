using System;
using System.Linq;
using System.Reflection;
using LtInfo.Common.Models;

namespace LtInfo.Common.DhtmlWrappers
{
    public class AutoGridSpec<T> : GridSpec<T> where T : IStringIndexer
    {
        public AutoGridSpec()
        {
            // spin through the type T and add columns for each property/field
            var members = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (var info in members.OrderBy(m => m.Name))
            {
                var info1 = info;
                Add(info.Name,
                    m =>
                    {
                        var value = info1.GetValue(m, null);
                        return value != null ? value.ToString() : String.Empty;
                    },
                    0);
            }
        }
    }
}