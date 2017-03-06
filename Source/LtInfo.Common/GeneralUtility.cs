/*-----------------------------------------------------------------------
<copyright file="GeneralUtility.cs" company="Sitka Technology Group">
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
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    public static class GeneralUtility
    {
        public const BindingFlags AllMethodsBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy;
        public const BindingFlags AllInstanceMethodsBindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy;

        public static int Reverse(int n)
        {
            var left = n;
            var rev = 0;
            while (left > 0)
            {
                var r = left % 10;
                rev = rev * 10 + r;
                left = left / 10;  //left = Math.floor(left / 10); 
            }
            return rev;
        }

        public static DirectoryInfo GetExecutingAssemblyDirectory()
        {
            return GetExecutingAssemblyFile().Directory;
        }

        public static FileInfo GetExecutingAssemblyFile()
        {
            var localAssemblyPathString = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            return new FileInfo(localAssemblyPathString);
        }

        public static string Coalesce(string first, string second)
        {
            if (String.IsNullOrEmpty(first))
                return second;

            return first;
        }

        /// <summary>
        /// Returns all the values of an enumerated class
        /// </summary>
        public static List<T> EnumGetValues<T>() where T : struct
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        public static string Coalesce(decimal? first, string second)
        {
            if (!first.HasValue)
                return second;

            return first.ToString();
        }

        public static Dictionary<string, object> ToDictionary(this object data)
        {
            const BindingFlags attr = BindingFlags.Public | BindingFlags.Instance;
            var dict = new Dictionary<string, object>();
            foreach (var property in data.GetType().GetProperties(attr))
            {
                if (property.CanRead)
                {
                    dict.Add(property.Name, property.GetValue(data, null));
                }
            }

            return dict;
        }

        /// <summary>
        /// Helper method to get member name with compile time verification to avoid typo.
        /// </summary>
        /// <param name="expr">The lambda expression usually in the form of () => o.member</param>
        /// <returns>The name of the member.</returns>
        public static string GetMemberFunctionNameFromExpression<T>(Expression<T> expr)
        {
            var body = expr.Body;
            var memberExpression = body as MemberExpression != null ? ((MemberExpression) body).Member.Name : ((MethodCallExpression) body).Method.Name;
            return memberExpression;
        }

        /// <summary>
        /// Helper method to get member function name at compile time verification to avoid typo.
        /// </summary>
        public static ParsedExpressionParts ParseExpressionParts<T>(Expression<Action<T>> expr)
        {
            return new ParsedExpressionParts((MethodCallExpression)expr.Body);
        }

        /// <summary>
        /// Helper method to get member function name at compile time verification to avoid typo.
        /// </summary>
        public static ParsedExpressionParts ParseExpressionParts<T, TProp>(Expression<Func<T, TProp>> expr)
        {
            return new ParsedExpressionParts((MemberExpression)expr.Body);
        }

        /// <summary>
        /// Result of parsing an expression
        /// </summary>
        public class ParsedExpressionParts
        {
            public string DeclaringTypeName
            {
                get { return _declaringType.Name; }
            }

            public string MethodOrMemberName
            {
                get { return _methodOrMemberName; }
            }

            public Type DeclaringType
            {
                get { return _declaringType; }
            }

            private readonly string _methodOrMemberName;
            private readonly Type _declaringType;

            public ParsedExpressionParts(MethodCallExpression methodCallExpression)
            {
                var methodInfo = methodCallExpression.Method;
                _declaringType = methodInfo.DeclaringType;
                _methodOrMemberName = methodInfo.Name;
                CheckInvariantAllFieldsNotNull();
            }

            public ParsedExpressionParts(MemberExpression methodCallExpression)
            {
                var memberInfo = methodCallExpression.Member;
                _declaringType = memberInfo.DeclaringType;
                _methodOrMemberName = memberInfo.Name;
                CheckInvariantAllFieldsNotNull();
            }

            private void CheckInvariantAllFieldsNotNull()
            {
                Check.RequireNotNull(_methodOrMemberName, "Got null method name");
                Check.RequireNotNull(_declaringType, "Got null type");
            }
        }

        public static string HtmlizeEncodeLineBreaks(string stringToEncode)
        {
            if (String.IsNullOrEmpty(stringToEncode))
                return String.Empty;
            return stringToEncode.Replace("\n", "<br/>");
        }

        public static string TrimWhitespaceEvenIfNull(string possiblyNullableThingToTrim)
        {
            return possiblyNullableThingToTrim == null ? null : possiblyNullableThingToTrim.Trim();
        }

        /// <summary>
        /// This will take a possibly null string and return either an empty string (if null) or the trimmed version of the string
        /// </summary>
        public static string TrimWhitespaceMapNullToEmptyString(string possiblyNullableThingToTrim)
        {
            return possiblyNullableThingToTrim == null ? String.Empty : possiblyNullableThingToTrim.Trim();
        }

        /// <summary>
        /// Indicates whether the string is null or empty similar to <see cref="string.IsNullOrEmpty"/>, but runs a <see cref="string.Trim()"/> beforehand AND handles null strings.
        /// </summary>
        public static bool IsNullOrEmptyOrOnlyWhitespace(string stringToCheck)
        {
            return stringToCheck == null || String.IsNullOrEmpty(stringToCheck.Trim());
        }

        public static bool IsNullableType(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static string AsciiToHex(string ascii)
        {
            var hex = new StringBuilder();

            for (int i = 0; i < ascii.Length; i++)
            {
                char c = ascii[i];
                if ((c >= 32 && c < 127) && (c != '+' && c != '='))
                {
                    hex.Append(c);
                }
                else
                {
                    hex.Append("+" + ConvertToHex(ascii[i].ToString()));
                }
            }

            return hex.ToString();
        }

        public static string ConvertToHex(string asciiString)
        {
            string hex = "";
            foreach (char c in asciiString)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", Convert.ToUInt32(tmp.ToString()));
            }
            return hex;
        }

        public static decimal CelsiusToFahrenheit(string temperatureCelsius)
        {
            decimal celsius = Decimal.Parse(temperatureCelsius);
            return (celsius * 9 / 5) + 32;
        }

        public static decimal FahrenheitToCelsius(string temperatureFahrenheit)
        {
            decimal fahrenheit = Decimal.Parse(temperatureFahrenheit);
            return (fahrenheit - 32) * 5 / 9;
        }

        public static bool HasDuplicates<T>(this IEnumerable<T> items)
        {
            var fullCount = items.Count();
            var distinctCount = items.Distinct().Count();
            return fullCount > distinctCount;
        }

        public static bool ContainsCaseInsensitive(this string source, string value)
        {
            if(source == null || value == null)
                return false;

            var results = source.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
            return results == -1 ? false : true;
        }

        public static bool ByteArrayCompare(this byte[] a1, byte[] a2)
        {
            if (a1 == null || a2 == null)
                return a1 == a2;

            if (a1.Length != a2.Length)
                return false;

            return !a1.Where((t, i) => t != a2[i]).Any();
        }

        public static string CompressPhoneNumber(string uncompressed)
        {
            if (String.IsNullOrEmpty(uncompressed))
                return uncompressed;

            return RemoveNoise(uncompressed.Trim(), new[] { '(', ')', '-', '.', ' ' });            
        }

        // "compresses" a string by removing any of the "noise" characters
        public static string RemoveNoise(string p, char[] noise)
        {
            if (String.IsNullOrEmpty(p))
                return "";

            int j = 0;
            string v = p;

            foreach (char c in noise)
                v = v.Replace(c, '\xff');

            // build a new char array string, copying all non \xff characters to the output
            var noiseless = new char[v.Length];

            for (int i = 0; i < v.Length; i++)
                if (v[i] != '\xff')
                    noiseless[j++] = v[i];

            if (j == 0)
                return "";

            return new string(noiseless, 0, j);
        }

        /// <summary>
        /// Ellipsisify a string if it exceeds maxLength
        /// </summary>
        public static string EllipsisString(string stringToElipisis, int maxLength)
        {
            const string ellipsisString = "...";
            string stringToReturn = stringToElipisis;

            if (stringToElipisis.Length > maxLength)
            {
                stringToReturn = stringToReturn.Substring(0, maxLength - ellipsisString.Length) + ellipsisString;
            }

            return stringToReturn;
        }

        public static string UrlToAbsolutePath(string relativeOrAbsoluteUrl)
        {
            var uri = new Uri(relativeOrAbsoluteUrl, UriKind.RelativeOrAbsolute);
            UriBuilder uriBuilder;
            if (uri.IsAbsoluteUri)
            {
                uriBuilder = new UriBuilder(uri);
            }
            else
            {
                uriBuilder = new UriBuilder("http", "www.example.com", 80, relativeOrAbsoluteUrl);
            }
            return uriBuilder.Uri.AbsolutePath;
        }

        /// <summary>
        /// Calculates the *index* for a zero-indexed list for a given number of items
        /// </summary>
        public static int CalculateIndexOfEndOfFirstHalf(int numberOfItems)
        {
            // For up to 2 items in a list, index 0 is the end of the first half
            if (numberOfItems <= 2)
                return 0;

            // after that it is a formula
            return (numberOfItems - 1) / 2;
        }

        /// <summary>
        /// Indicates if a TCP port is in use on the <see cref="IPAddress.Loopback"/> address
        /// </summary>
        public static bool IsTcpPortInUse(int tcpPortToCheck)
        {
            using (var c = new TcpClient())
            {
                try
                {
                    c.Connect(new IPEndPoint(IPAddress.Loopback, tcpPortToCheck));
                }
                catch (SocketException)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Finds the first free TCP port given the port numbers in question
        /// </summary>
        public static int FindFirstFreeTcpPort(IEnumerable<int> portsToChooseFrom)
        {
            var firstFreePort = portsToChooseFrom.First(port => !IsTcpPortInUse(port));
            return firstFreePort;
        }

        /// <summary>
        /// Finds a free tcp port that could be used to setup a listener on the <see cref="IPAddress.Loopback"/> address, from 49152 to 65535 based on the concept of "Ephemeral Port" http://en.wikipedia.org/wiki/Ephemeral_port 
        /// </summary>
        public static int FindFirstFreeTcpPort()
        {
            return FindFirstFreeTcpPort(Enumerable.Range(49152,65535));
        }

        /// <summary>
        /// Takes a string and *fully* escapes it for use safely within a .NET Regex expression including ] and }.
        /// <see cref="Regex.Escape"/> escapes \, *, +, ?, |, {, [, (, ), ^, $, ., #, and white space.
        /// This function escapes \, *, +, ?, |, {, }, [, ], (, ), ^, $, ., #, and white space.
        /// This can be used to combine user input with an existing regex expression.
        /// </summary>
        /// <param name="stringToEscape"></param>
        /// <returns></returns>
        public static string RegexEscape(string stringToEscape)
        {
            var escaped = Regex.Escape(stringToEscape);
            escaped = escaped.Replace("]", @"\]");
            escaped = escaped.Replace("}", @"\}");
            return escaped;
        }

        private const string HexDigits = "0123456789ABCDEF";

        /// <summary>
        /// Convert a byte array to hex string.
        /// </summary>
        /// <param name="bytes">An array of bytes</param>
        /// <returns>Hex string</returns>
        public static string BytesToHexString(byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                sb.AppendFormat("{0:X2}", b);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Convert a hex string to byte array.
        /// </summary>
        /// <param name="str">hex string. For example, "FF00EE11"</param>
        /// <returns>An array of bytes</returns>
        public static byte[] HexStringToBytes(string str)
        {
            // Determine how many bytes there are.     
            var bytes = new byte[str.Length >> 1];
            for (var i = 0; i < str.Length; i += 2)
            {
                var highDigit = HexDigits.IndexOf(Char.ToUpperInvariant(str[i]));
                var lowDigit = HexDigits.IndexOf(Char.ToUpperInvariant(str[i + 1]));
                if (highDigit == -1 || lowDigit == -1)
                {
                    throw new ArgumentException("The string contains an invalid digit.", "s");
                }
                bytes[i >> 1] = (byte)((highDigit << 4) | lowDigit);
            }
            return bytes;
        }

        public static string NameOf<T>(Expression<Func<T>> expr)
        {
            return ((MemberExpression)expr.Body).Member.Name;
        }

        public static string EscapeStringLiteralForSql(string value)
        {
            return value.Replace("'", "''");
        }
    }
}
