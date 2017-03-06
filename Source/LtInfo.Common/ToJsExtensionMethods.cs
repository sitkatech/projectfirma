/*-----------------------------------------------------------------------
<copyright file="ToJsExtensionMethods.cs" company="Sitka Technology Group">
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

namespace LtInfo.Common
{
    /// <summary>
    /// Handles encoding into Javascript
    /// </summary>
    public static class ToJsExtensionMethods
    {
        private const string JavascriptNullKeyword = "null";

        public static string ToJS(this IEnumerable<int> values)
        {
            if (values == null)
            {
                return JavascriptNullKeyword;
            }
            var arrayContents = String.Join(", ", values.Select(ToJS));
            return String.Format("[{0}]", arrayContents);
        }

        public static string ToJS(this int value)
        {
            return ToJS((int?) value);
        }

        public static string ToJS(this int? value)
        {
            return value.HasValue ? value.Value.ToString() : JavascriptNullKeyword;
        }

        public static string ToJS(this decimal value)
        {
            return value.ToString();
        }

        public static string ToJS(this string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value == "undefined")
            {
                return JavascriptNullKeyword;
            }
            var stringified = string.Format("'{0}'", value.ToJSON());
            return stringified;
        }

        public static string ToJS(this bool value)
        {
            return ToJS((bool?) value);
        }

        public static string ToJS(this bool? value)
        {
            return value.HasValue ? (value.Value ? "true" : "false") : JavascriptNullKeyword;
        }

        public static string ToJS(this DateTime value)
        {
            var stringified = String.Format("new Date({0},{1},{2},{3},{4},{5})"
                                               , value.Year
                                               , value.Month
                                               , value.Day
                                               , value.Hour
                                               , value.Minute
                                               , value.Second
                );
            return stringified;
        }
    }
}
