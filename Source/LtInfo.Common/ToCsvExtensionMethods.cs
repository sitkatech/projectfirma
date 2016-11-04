using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;

namespace LtInfo.Common
{
    public static class ToCsvExtensionMethods
    {
        public const string CsvDelimiter = ",";
        private const string DoubleQuote = "\"";
        private const string EscapedDoubleQuote = "\"\"";
        private const string ErrorMessageForEmptyModelList = "Unable to convert null object to Csv. Verify collection has been instantiated.";

        /// <summary>
        /// Similar to <see cref="String.Join(string, string[])"/>, but takes a function to use and always puts the prefix in place
        /// </summary>
        public static string JoinCsv<T>(this IEnumerable<T> things, string prefixDelimiter, Func<T, string> toStringMethod)
        {
            return string.Join("", things.Select(s => string.Format("{0}{1}", prefixDelimiter, toStringMethod(s))).ToList());
        }

        /// <summary>
        /// Similar to <see cref="String.Join(string, string[])"/>, takes a function and only puts the suffix in place in between elements
        /// </summary>
        public static string JoinCsv<T>(this IEnumerable<T> things, Func<T, string> toStringMethod, string suffixDelimiter)
        {
            return string.Join(suffixDelimiter, things.Select(toStringMethod).ToList());
        }

        /// <summary>
        /// Converts a <param name="list"></param> of objects into a CSV based on public properties
        /// </summary>
        public static string ToCsv(this IEnumerable list)
        {
            Check.RequireNotNull(list);
            return ToCsvImpl(list, null);
        }

        /// <summary>
        /// Converts a <param name="list"></param> of objects into a CSV based on a given list of public property names
        /// </summary>
        public static string ToCsv(this IEnumerable list, string[] propertyNames)
        {
            Check.RequireNotNull(list);
            Check.RequireNotNull(propertyNames);
            return ToCsvImpl(list, propertyNames);
        }

        private static void ToCsvRow<T>(this T thingToRead, StringBuilder output, IEnumerable<ColumnSpec<T>> gridSpec)
        {
            var row = string.Join(CsvDelimiter, gridSpec.Select(columnSpec => CsvEscape(columnSpec.CalculateStringValue(thingToRead))).ToList());
            output.AppendLine(row);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string ToCsv<T>(this IEnumerable<T> modelList, GridSpec<T> spec)
        {
            Check.RequireNotNull(modelList, ErrorMessageForEmptyModelList);

            var output = new StringBuilder();
            output.AppendLine(EnumerableStringToCsvRow(spec.ColumnNames));
            foreach (var viewModel in modelList)
            {
                viewModel.ToCsvRow(output, spec);
            }

            return output.ToString();
        }

        private static string ToCsvImpl(IEnumerable list, string[] propertyNames)
        {
            var csvDataOutput = new StringBuilder();
            var headerDone = false;
            var ourNewLine = String.Empty;
            foreach (var obj in list)
            {
                if (!headerDone)
                {
                    if (propertyNames == null)
                    {
                        var names = obj.PublicInstancePropertyNames();
                        names.Sort();
                        propertyNames = names.ToArray();
                    }
                    if (propertyNames.Length == 0)
                    {
                        return String.Empty;
                    }

                    AddCsvRow(propertyNames, csvDataOutput);
                    csvDataOutput.AppendLine();
                    headerDone = true;
                }

                csvDataOutput.Append(ourNewLine);
                ourNewLine = Environment.NewLine;
                AddCsvRow(propertyNames.Select(p => GetPropertyValueAsString(obj, p)).ToList(), csvDataOutput);
            }
            return csvDataOutput.ToString();
        }

        public static string EnumerableStringToCsvRow(IEnumerable<string> values)
        {
            var output = new StringBuilder();
            AddCsvRow(values, output);
            return output.ToString();
        }

        private static void AddCsvRow(IEnumerable<string> values, StringBuilder output)
        {
            output.Append(string.Join(CsvDelimiter, values.Select(CsvEscape).ToList()));
        }

        /// <summary>
        ///     Fully encodes a value for CSV output. Surrounds with double quotes if not blank.
        /// </summary>
        internal static string CsvEscape(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }
            var csvEscape = value.Replace(DoubleQuote, EscapedDoubleQuote);
            csvEscape = string.Format("{0}{1}{0}", DoubleQuote, csvEscape);
            return csvEscape;
        }

        private static string GetPropertyValueAsString(object obj, string propertyName)
        {
            var pi = obj.GetType().GetProperty(propertyName);
            Check.RequireNotNull(pi, String.Format("Could not find requested property \"{0}\" on object of type \"{1}\"", propertyName, obj.GetType()));
            var valueAsObject = pi.GetValue(obj, null);

            return valueAsObject == null ? String.Empty : valueAsObject.ToString();
        }
    }
}