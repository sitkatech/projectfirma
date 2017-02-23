/*-----------------------------------------------------------------------
<copyright file="ExtensionMethods.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Collections.Generic;
using System.Text;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    public static class ExtensionMethods
    {
        // an override of the standard Contains() method that allows you to specify case sensitivity (e.g. "SUBLIME".Contains("lime", StringComparison.OrdinalIgnoreCase) )
        public static bool Contains(this string source, string toCheck, StringComparison sc)
        {
            return source.IndexOf(toCheck, sc) >= 0;
        }

        // splits "StringsLikeThis" into "Strings Like This".  Useful for "englishization" of enumeration members
        public static string CamelSplit(this string s, string seperator)
        {
            if (String.IsNullOrEmpty(s))
                return s;

            var words = new List<string>();
            byte[] bytes = Encoding.ASCII.GetBytes(s);

            // determine the case of the first character
            bool firstCase = IsLowerCase(bytes[0]);
            bool priorCase = firstCase;
            int b = 0, e = 1;

            for (; e < s.Length; e++)
            {
                bool currentCase = IsLowerCase(bytes[e]);

                if (currentCase != priorCase && currentCase == firstCase)
                {
                    words.Add(s.Substring(b, e - b));
                    b = e;
                }

                priorCase = currentCase;
            }

            if (b <= s.Length - 1)
                words.Add(s.Substring(b, s.Length - b));

            return String.Join(" ", words);
        }

        /// <summary>
        /// This will truncate parts of string that exceed the max length
        /// </summary>
        public static string Truncate(this string s, int maximumLengthAllowed, string truncationMarker)
        {
            Check.Require(maximumLengthAllowed >= 0, String.Format("Need a positive maximum length, got {0}", maximumLengthAllowed) );
            truncationMarker = truncationMarker ?? String.Empty;
            Check.Require(maximumLengthAllowed > truncationMarker.Length, String.Format("Truncation marker \"{0}\" is too long for maximum length {1}.", truncationMarker, maximumLengthAllowed));

            if (String.IsNullOrEmpty(s))
            {
                return s;
            }

            if (s.Length <= maximumLengthAllowed)
            {
                return s;
            }

            return s.Substring(0, maximumLengthAllowed - truncationMarker.Length) + truncationMarker;
        }

        private static bool IsLowerCase(byte b)
        {
            return (b >= 97 && b <= 122);
        }

        public static string WordTranslate(this string s, string from, string to)
        {
            var fromArray = @from.Split(' ');
            var toArray = to.Split(' ');

            if (fromArray.Length != toArray.Length)
                throw new ArgumentException("Number of elements in \"from\" and \"to\" strings are not equal.");

            for (int i = 0; i < fromArray.Length; i++)
                if (fromArray[i] == s)
                    return toArray[i];

            return "";
        }

        // removes "n" characters from the left side of the string
        public static string Pop(this string s, int n)
        {
            if (s == null)
                return null;

            if (n >= s.Length)
                return String.Empty;

            return s.Substring(0, s.Length - n);
        }

        // removes "n" characters from the right side of the string
        public static string Shift(this string s, int n)
        {
            if (s == null)
                return null;

            if (n >= s.Length)
                return String.Empty;

            return s.Substring(n, s.Length - n);
        }

        // make a scalar object safe for javascript

        // make a string safe for JSON
        public static string ToJSON(this string s)
        {
            var json = new StringBuilder(s.Length);

            foreach (char ch in s)
            {
                if (Char.IsControl(ch) || ch == '\'')
                {
                    var ich = (int) ch;
                    json.Append(@"\u" + ich.ToString("x4"));
                    continue;
                }
                if (ch == '\"' || ch == '\\' || ch == '/')
                {
                    json.Append('\\');
                }

                json.Append(ch);
            }

            return json.ToString();
        }
        /// <summary>
        /// DHTMLXGrid does not like having a loose comma within a grid cell that's a header or footer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>String with the commas replaced by the HTML entity</returns>
        public static string HtmlEncodeCommasForDhtmlxGrid(this string value)
        {
            if(String.IsNullOrEmpty(value))
            {
                return value;
            }
            return value.Replace(",", "&#44;");
        }


        /// <summary>
        /// Casts string into an Enum
        /// </summary>
        /// <typeparam name="T">Type of the Enum</typeparam>
        /// <param name="value">String to cast, must be non-null and non-empty</param>
        /// <returns></returns>
        public static T ParseAsEnum<T>(this string value) // where T : enum
        {
            var enumType = typeof(T);
            Check.Require(enumType.IsEnum, new InvalidOperationException("Expected T to be an Enum type but was not."));
            return (T) Enum.Parse(enumType, value, true);
        }

        /// <summary>
        /// Casts int into an Enum
        /// </summary>
        /// <typeparam name="T">Type of the Enum</typeparam>
        /// <param name="value">String to cast, must be non-null and non-empty</param>
        /// <returns></returns>
        public static T ParseAsEnum<T>(this int value) // where T : enum
        {
            var enumType = typeof(T);
            Check.Require(enumType.IsEnum, new InvalidOperationException("Expected T to be an Enum type but was not."));
            var enumValue = (T) Enum.ToObject(typeof(T), value);
            Check.Require(Enum.IsDefined(typeof(T), enumValue), String.Format("Enum does not have a corresponding value for integer. Enum type: {0}, integer value: {1}.", typeof(T).FullName, value));
            return enumValue;
        }

        /// <summary>
        /// Returns a list of the names of the public instance properties. Only includes Instance, Public, and non-inherited properties
        /// </summary>
        public static List<string> PublicInstancePropertyNames(this object thingToInspect)
        {
            var properties =
                new List<PropertyInfo>(
                    thingToInspect.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public |
                                                           BindingFlags.DeclaredOnly));

            return (properties.Where(pi => pi.CanRead).Select(pi => pi.Name)).ToList();
        }

        public static decimal FormatPercentage(this decimal p)
        {
            return p == 0 ? 0.0M : Decimal.Parse((p * 100M).ToString("N1"));
        }

        public static TRet DefaultIfNull<TSrc, TRet>(this TSrc value, Func<TSrc, TRet> property) where TSrc : class
        {
            return value.DefaultIfNull(property, default(TRet));
        }

        public static TRet DefaultIfNull<TSrc, TRet>(this TSrc value, Func<TSrc, TRet> property, TRet deflt) where TSrc : class
        {
            return value == null ? deflt : property(value);
        }

        public static TRet DefaultIfNull<TSrc, TRet>(this TSrc? value, Func<TSrc, TRet> property, TRet deflt) where TSrc : struct
        {
            return value == null ? deflt : property(value.Value);
        }

        public static TRet DefaultIfNull<TSrc, TRet>(this TSrc? value, Func<TSrc, TRet> property) where TSrc : struct
        {
            return value.DefaultIfNull(property, default(TRet));
        }

        public static decimal? SumNullWhenEmpty<T>(this IList<T> enumerable, Func<T, decimal?> func)
        {
            if (enumerable.Any())
            {
                return enumerable.Sum(func);
            }
            return null;
        }

        public static double? SumNullWhenEmpty<T>(this IList<T> enumerable, Func<T, double?> func)
        {
            if (enumerable.Any())
            {
                return enumerable.Sum(func);
            }
            return null;
        }

        /// <summary>
        /// Instead of returning zero when summing an empty list or a list of all nulls, this method returns null
        /// </summary>
        public static decimal? SumNullWhenEmptyOrAllNull<T>(this IEnumerable<T> enumerable, Func<T, decimal?> func)
        {
            var values = enumerable.Select(func).ToList();
            if (!values.Any(x => x.HasValue))
            {
                return null;
            }
            return values.Sum();
        }

        /// <summary>
        /// Creates a way to iterate through all exceptions to treat an exception tree as if it were a list starting with the most current to the most inner
        /// </summary>
        public static IEnumerable<Exception> AllExceptions(this Exception exception)
        {
            var ex = exception;
            while (ex != null)
            {
                yield return ex;
                ex = ex.InnerException;
            }
        }
    }
}
