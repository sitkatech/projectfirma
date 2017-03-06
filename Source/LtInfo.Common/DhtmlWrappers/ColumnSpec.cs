/*-----------------------------------------------------------------------
<copyright file="ColumnSpec.cs" company="Sitka Technology Group">
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
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;
using LtInfo.Common.Views;

namespace LtInfo.Common.DhtmlWrappers
{
    public class ColumnSpec<T>
    {
        public readonly string ColumnName;
        private readonly Func<T, int> _intValueFunc;
        private readonly Func<T, int?> _nullableIntValueFunc;
        private readonly Func<T, short> _shortValueFunc;
        private readonly Func<T, short?> _nullableShortValueFunc;
        private readonly Func<T, byte> _byteValueFunc;
        private readonly Func<T, byte?> _nullableByteValueFunc;
        private readonly Func<T, string> _stringValueFunc;
        private readonly Func<T, DateTime> _dateTimeValueFunc;
        private readonly Func<T, DateTime?> _nullableDateTimeValueFunc;
        private readonly Func<T, decimal> _decimalValueFunc;
        private readonly Func<T, decimal?> _nullableDecimalValueFunc;
        private readonly Func<T, double> _doubleValueFunc;
        private readonly Func<T, double?> _nullableDoubleValueFunc;
        private readonly Func<T, bool> _boolValueFunc;
        private readonly Func<T, bool?> _nullableBoolValueFunc;
        private readonly Func<T, HtmlString> _htmlStringValueFunc;

        private readonly FuncType _funcType;
        private readonly Func<T, string> _cssClassFunction;
        private readonly Func<T, string> _titleFunction;
        public readonly int GridWidth;
        public readonly DhtmlxGridColumnSortType DhtmlxGridColumnSortType;
        public readonly DhtmlxGridColumnAlignType DhtmlxGridColumnAlignType;
        public readonly DhtmlxGridColumnDataType DhtmlxGridColumnDataType;
        public readonly DhtmlxGridColumnFilterType DhtmlxGridColumnFilterType;
        public readonly DhtmlxGridColumnFormatType DhtmlxGridColumnFormatType;
        public readonly DhtmlxGridColumnAggregationType GridColumnAggregationType;

        /// <summary>
        ///     This is the text that would appear to a user when viewing the column through a web browser - so all HTML tags are stripped out
        /// </summary>
        public string ColumnNameInnerText
        {
            get
            {
                var noXmlTags = Regex.Replace(ColumnName, "<.*?>", string.Empty);
                return noXmlTags;
            }
        }

        /// <summary>
        ///     A version of <see cref="ColumnName" /> that works for use as a javascript name
        /// </summary>
        public string ColumnNameForJavascript
        {
            get
            {
                var noSpecialChars = Regex.Replace(ColumnNameInnerText, @"[\-\(\)/]", string.Empty);
                var acceptableColumnName = noSpecialChars.Replace(" ", "").Replace("#", "Num").Replace("...", "");

                // Move digits to the end.
                if (Regex.IsMatch(acceptableColumnName, @"^\d+"))
                {
                    var match = Regex.Match(acceptableColumnName, @"\d+");

                    acceptableColumnName = acceptableColumnName.Replace(match.ToString(), "") + "_" + match;
                }

                return acceptableColumnName;
            }
        }

        public string GetAlignmentForFooterRow()
        {
            string alignment;
            switch (DhtmlxGridColumnAlignType)
            {
                case DhtmlxGridColumnAlignType.Left:
                    alignment = "left";
                    break;
                case DhtmlxGridColumnAlignType.Right:
                    alignment = "right";
                    break;
                case DhtmlxGridColumnAlignType.Center:
                    alignment = "center";
                    break;
                case DhtmlxGridColumnAlignType.Justify:
                    alignment = "justify";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return string.Format("\"text-align:{0}\"", alignment);
        }

        private enum FuncType
        {
            Int,
            NullableInt,
            Short,
            NullableShort,
            Byte,
            NullableByte,
            String,
            DateTime,
            NullableDateTime,
            Decimal,
            NullableDecimal,
            Double,
            NullableDouble,
            Bool,
            NullableBool,
            HtmlString
        }

        private ColumnSpec(string columnName, int gridWidth, DhtmlxGridColumnDataType dhtmlxGridColumnDataType,
            DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType, DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType,
            DhtmlxGridColumnSortType dhtmlxGridColumnSortType, DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
        {
            ColumnName = columnName;
            DhtmlxGridColumnDataType = dhtmlxGridColumnDataType;
            GridWidth = gridWidth;
            DhtmlxGridColumnSortType = dhtmlxGridColumnSortType;
            DhtmlxGridColumnFilterType = dhtmlxGridColumnFilterType;
            GridColumnAggregationType = dhtmlxGridColumnAggregationType;
            DhtmlxGridColumnFormatType = dhtmlxGridColumnFormatType ?? DhtmlxGridColumnFormatType.None;
            DhtmlxGridColumnAlignType = dhtmlxGridColumnAlignType;
            _cssClassFunction = cssClassFunction;
            _titleFunction = titleFunction;
        }

        public ColumnSpec(string columnName, Func<T, string> stringValueFunc, int gridWidth,
            DhtmlxGridColumnDataType dhtmlxGridColumnDataType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, dhtmlxGridColumnDataType, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType,
                dhtmlxGridColumnSortType, dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _stringValueFunc = stringValueFunc;
            _funcType = FuncType.String;
        }

        public ColumnSpec(string columnName, Func<T, int> intValueFunc, int gridWidth,
            DhtmlxGridColumnDataType dhtmlxGridColumnDataType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, dhtmlxGridColumnDataType, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType,
                dhtmlxGridColumnSortType, dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _intValueFunc = intValueFunc;
            _funcType = FuncType.Int;
        }

        public ColumnSpec(string columnName, Func<T, int?> nullableIntValueFunc, int gridWidth,
            DhtmlxGridColumnDataType dhtmlxGridColumnDataType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, dhtmlxGridColumnDataType, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType,
                dhtmlxGridColumnSortType, dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _nullableIntValueFunc = nullableIntValueFunc;
            _funcType = FuncType.NullableInt;
        }

        public ColumnSpec(string columnName, Func<T, short> shortValueFunc, int gridWidth,
            DhtmlxGridColumnDataType dhtmlxGridColumnDataType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, dhtmlxGridColumnDataType, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType,
                dhtmlxGridColumnSortType, dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _shortValueFunc = shortValueFunc;
            _funcType = FuncType.Short;
        }

        public ColumnSpec(string columnName, Func<T, short?> nullableShortValueFunc, int gridWidth,
            DhtmlxGridColumnDataType dhtmlxGridColumnDataType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, dhtmlxGridColumnDataType, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType,
                dhtmlxGridColumnSortType, dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _nullableShortValueFunc = nullableShortValueFunc;
            _funcType = FuncType.NullableShort;
        }

        public ColumnSpec(string columnName, Func<T, byte> byteValueFunc, int gridWidth,
            DhtmlxGridColumnDataType dhtmlxGridColumnDataType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, dhtmlxGridColumnDataType, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType,
                dhtmlxGridColumnSortType, dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _byteValueFunc = byteValueFunc;
            _funcType = FuncType.Byte;
        }

        public ColumnSpec(string columnName, Func<T, byte?> nullableByteValueFunc, int gridWidth,
            DhtmlxGridColumnDataType dhtmlxGridColumnDataType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, dhtmlxGridColumnDataType, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType,
                dhtmlxGridColumnSortType, dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _nullableByteValueFunc = nullableByteValueFunc;
            _funcType = FuncType.NullableByte;
        }

        public ColumnSpec(string columnName, Func<T, DateTime> dateTimeValueFunc, int gridWidth,
            DhtmlxGridColumnDataType dhtmlxGridColumnDataType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, dhtmlxGridColumnDataType, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType,
                dhtmlxGridColumnSortType, dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _dateTimeValueFunc = dateTimeValueFunc;
            _funcType = FuncType.DateTime;
        }

        public ColumnSpec(string columnName, Func<T, DateTime?> nullableDateTimeValueFunc, int gridWidth,
            DhtmlxGridColumnDataType dhtmlxGridColumnDataType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, dhtmlxGridColumnDataType, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType,
                dhtmlxGridColumnSortType, dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _nullableDateTimeValueFunc = nullableDateTimeValueFunc;
            _funcType = FuncType.NullableDateTime;
        }

        public ColumnSpec(string columnName, Func<T, double> doubleValueFunc, int gridWidth,
            DhtmlxGridColumnDataType dhtmlxGridColumnDataType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, dhtmlxGridColumnDataType, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType,
                dhtmlxGridColumnSortType, dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _doubleValueFunc = doubleValueFunc;
            _funcType = FuncType.Double;
        }

        public ColumnSpec(string columnName, Func<T, double?> nullableDoubleValueFunc, int gridWidth,
            DhtmlxGridColumnDataType dhtmlxGridColumnDataType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, dhtmlxGridColumnDataType, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType,
                dhtmlxGridColumnSortType, dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _nullableDoubleValueFunc = nullableDoubleValueFunc;
            _funcType = FuncType.NullableDouble;
        }

        public ColumnSpec(string columnName, Func<T, decimal> decimalValueFunc, int gridWidth,
            DhtmlxGridColumnDataType dhtmlxGridColumnDataType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, dhtmlxGridColumnDataType, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType,
                dhtmlxGridColumnSortType, dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _decimalValueFunc = decimalValueFunc;
            _funcType = FuncType.Decimal;
        }

        public ColumnSpec(string columnName, Func<T, decimal?> nullableDecimalValueFunc, int gridWidth,
            DhtmlxGridColumnDataType dhtmlxGridColumnDataType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, dhtmlxGridColumnDataType, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType,
                dhtmlxGridColumnSortType, dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _nullableDecimalValueFunc = nullableDecimalValueFunc;
            _funcType = FuncType.NullableDecimal;
        }

        public ColumnSpec(string columnName, Func<T, HtmlString> htmlStringValueFunc, int gridWidth,
            DhtmlxGridColumnDataType dhtmlxGridColumnDataType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, dhtmlxGridColumnDataType, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType,
                dhtmlxGridColumnSortType, dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _htmlStringValueFunc = htmlStringValueFunc;
            _funcType = FuncType.HtmlString;
        }

        public ColumnSpec(string columnName, Func<T, bool> boolValueFunc, int gridWidth,
            DhtmlxGridColumnDataType dhtmlxGridColumnDataType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, dhtmlxGridColumnDataType, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType,
                dhtmlxGridColumnSortType, dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _boolValueFunc = boolValueFunc;
            _funcType = FuncType.Bool;
        }

        public ColumnSpec(string columnName, Func<T, bool?> nullableBoolValueFunc, int gridWidth,
            DhtmlxGridColumnDataType dhtmlxGridColumnDataType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, dhtmlxGridColumnDataType, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType,
                dhtmlxGridColumnSortType, dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _nullableBoolValueFunc = nullableBoolValueFunc;
            _funcType = FuncType.NullableBool;
        }

        public string CalculateCellCssClass(T dataObject)
        {
            return _cssClassFunction != null ? _cssClassFunction(dataObject) : null;
        }

        public string CalculateTitle(T dataObject)
        {
            return _titleFunction != null ? _titleFunction(dataObject) : null;
        }

        public string CalculateStringValue(T dataObject)
        {
            switch (_funcType)
            {
                case FuncType.String:
                    var stringValue = _stringValueFunc(dataObject);
                    return stringValue ?? string.Empty;
                case FuncType.Int:
                    return _intValueFunc(dataObject).ToString(CultureInfo.InvariantCulture);
                case FuncType.NullableInt:
                    var intValue = _nullableIntValueFunc(dataObject);
                    return intValue.HasValue ? intValue.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
                case FuncType.DateTime:
                    return DhtmlxGridColumnFormatType == DhtmlxGridColumnFormatType.Date ? _dateTimeValueFunc(dataObject).ToStringDate() : _dateTimeValueFunc(dataObject).ToStringDateTime();
                case FuncType.NullableDateTime:
                    var dateTimeValue = _nullableDateTimeValueFunc(dataObject);
                    return dateTimeValue.HasValue
                        ? DhtmlxGridColumnFormatType == DhtmlxGridColumnFormatType.Date
                            ? dateTimeValue.Value.ToStringDate()
                            : dateTimeValue.Value.ToStringDateTime()
                        : string.Empty;
                case FuncType.Decimal:
                    return _decimalValueFunc(dataObject).ToString(CultureInfo.InvariantCulture);
                case FuncType.NullableDecimal:
                    var decimalValue = _nullableDecimalValueFunc(dataObject);
                    return decimalValue.HasValue ? decimalValue.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
                case FuncType.Double:
                    return _doubleValueFunc(dataObject).ToString(CultureInfo.InvariantCulture);
                case FuncType.NullableDouble:
                    var doubleValue = _nullableDoubleValueFunc(dataObject);
                    return doubleValue.HasValue ? doubleValue.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
                case FuncType.Bool:
                    return _boolValueFunc(dataObject).ToYesNo();
                case FuncType.NullableBool:
                    var boolValue = _nullableBoolValueFunc(dataObject);
                    return boolValue.HasValue ? boolValue.ToYesNo() : string.Empty;
                case FuncType.HtmlString:
                    var htmlStringValue = _htmlStringValueFunc(dataObject);
                    return htmlStringValue.ToString();
                case FuncType.Short:
                    return _shortValueFunc(dataObject).ToString(CultureInfo.InvariantCulture);
                case FuncType.NullableShort:
                    var shortValue = _nullableShortValueFunc(dataObject);
                    return shortValue.HasValue ? shortValue.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
                case FuncType.Byte:
                    return _byteValueFunc(dataObject).ToString(CultureInfo.InvariantCulture);
                case FuncType.NullableByte:
                    var byteValue = _nullableByteValueFunc(dataObject);
                    return byteValue.HasValue ? byteValue.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
