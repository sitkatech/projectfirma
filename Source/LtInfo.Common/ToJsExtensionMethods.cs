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