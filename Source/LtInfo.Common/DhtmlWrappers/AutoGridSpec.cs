/*-----------------------------------------------------------------------
<copyright file="AutoGridSpec.cs" company="Sitka Technology Group">
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
