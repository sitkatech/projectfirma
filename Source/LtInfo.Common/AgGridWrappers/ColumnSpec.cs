/*-----------------------------------------------------------------------
<copyright file="ColumnSpec.cs" company="Environmental Science Associates">
Copyright (c) Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

namespace LtInfo.Common.AgGridWrappers
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
        public readonly AgGridColumnAlignType AgGridColumnAlignType;
        public readonly AgGridColumnDataType AgGridColumnDataType;
        public readonly AgGridColumnFilterType AgGridColumnFilterType;
        public readonly AgGridColumnFormatType AgGridColumnFormatType;
        public readonly AgGridColumnAggregationType GridColumnAggregationType;

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
            switch (AgGridColumnAlignType)
            {
                case AgGridColumnAlignType.Left:
                    alignment = "left";
                    break;
                case AgGridColumnAlignType.Right:
                    alignment = "right";
                    break;
                case AgGridColumnAlignType.Center:
                    alignment = "center";
                    break;
                case AgGridColumnAlignType.Justify:
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

        private ColumnSpec(string columnName, int gridWidth, AgGridColumnDataType agGridColumnDataType,
            AgGridColumnFormatType agGridColumnFormatType, AgGridColumnAlignType agGridColumnAlignType,
            DhtmlxGridColumnSortType dhtmlxGridColumnSortType, AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
        {
            ColumnName = columnName;
            AgGridColumnDataType = agGridColumnDataType;
            GridWidth = gridWidth;
            DhtmlxGridColumnSortType = dhtmlxGridColumnSortType;
            AgGridColumnFilterType = agGridColumnFilterType;
            GridColumnAggregationType = agGridColumnAggregationType;
            AgGridColumnFormatType = agGridColumnFormatType;// ?? DhtmlxGridColumnFormatType.None;
            AgGridColumnAlignType = agGridColumnAlignType;
            _cssClassFunction = cssClassFunction;
            _titleFunction = titleFunction;
        }

        public ColumnSpec(string columnName, Func<T, string> stringValueFunc, int gridWidth,
            AgGridColumnDataType agGridColumnDataType, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAlignType agGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, agGridColumnDataType, agGridColumnFormatType, agGridColumnAlignType,
                dhtmlxGridColumnSortType, agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _stringValueFunc = stringValueFunc;
            _funcType = FuncType.String;
        }

        public ColumnSpec(string columnName, Func<T, int> intValueFunc, int gridWidth,
            AgGridColumnDataType agGridColumnDataType, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAlignType agGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, agGridColumnDataType, agGridColumnFormatType, agGridColumnAlignType,
                dhtmlxGridColumnSortType, agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _intValueFunc = intValueFunc;
            _funcType = FuncType.Int;
        }

        public ColumnSpec(string columnName, Func<T, int?> nullableIntValueFunc, int gridWidth,
            AgGridColumnDataType agGridColumnDataType, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAlignType agGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, agGridColumnDataType, agGridColumnFormatType, agGridColumnAlignType,
                dhtmlxGridColumnSortType, agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _nullableIntValueFunc = nullableIntValueFunc;
            _funcType = FuncType.NullableInt;
        }

        public ColumnSpec(string columnName, Func<T, short> shortValueFunc, int gridWidth,
            AgGridColumnDataType agGridColumnDataType, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAlignType agGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, agGridColumnDataType, agGridColumnFormatType, agGridColumnAlignType,
                dhtmlxGridColumnSortType, agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _shortValueFunc = shortValueFunc;
            _funcType = FuncType.Short;
        }

        public ColumnSpec(string columnName, Func<T, short?> nullableShortValueFunc, int gridWidth,
            AgGridColumnDataType agGridColumnDataType, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAlignType agGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, agGridColumnDataType, agGridColumnFormatType, agGridColumnAlignType,
                dhtmlxGridColumnSortType, agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _nullableShortValueFunc = nullableShortValueFunc;
            _funcType = FuncType.NullableShort;
        }

        public ColumnSpec(string columnName, Func<T, byte> byteValueFunc, int gridWidth,
            AgGridColumnDataType agGridColumnDataType, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAlignType agGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, agGridColumnDataType, agGridColumnFormatType, agGridColumnAlignType,
                dhtmlxGridColumnSortType, agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _byteValueFunc = byteValueFunc;
            _funcType = FuncType.Byte;
        }

        public ColumnSpec(string columnName, Func<T, byte?> nullableByteValueFunc, int gridWidth,
            AgGridColumnDataType agGridColumnDataType, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAlignType agGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, agGridColumnDataType, agGridColumnFormatType, agGridColumnAlignType,
                dhtmlxGridColumnSortType, agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _nullableByteValueFunc = nullableByteValueFunc;
            _funcType = FuncType.NullableByte;
        }

        public ColumnSpec(string columnName, Func<T, DateTime> dateTimeValueFunc, int gridWidth,
            AgGridColumnDataType agGridColumnDataType, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAlignType agGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, agGridColumnDataType, agGridColumnFormatType, agGridColumnAlignType,
                dhtmlxGridColumnSortType, agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _dateTimeValueFunc = dateTimeValueFunc;
            _funcType = FuncType.DateTime;
        }

        public ColumnSpec(string columnName, Func<T, DateTime?> nullableDateTimeValueFunc, int gridWidth,
            AgGridColumnDataType agGridColumnDataType, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAlignType agGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, agGridColumnDataType, agGridColumnFormatType, agGridColumnAlignType,
                dhtmlxGridColumnSortType, agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _nullableDateTimeValueFunc = nullableDateTimeValueFunc;
            _funcType = FuncType.NullableDateTime;
        }

        public ColumnSpec(string columnName, Func<T, double> doubleValueFunc, int gridWidth,
            AgGridColumnDataType agGridColumnDataType, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAlignType agGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, agGridColumnDataType, agGridColumnFormatType, agGridColumnAlignType,
                dhtmlxGridColumnSortType, agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _doubleValueFunc = doubleValueFunc;
            _funcType = FuncType.Double;
        }

        public ColumnSpec(string columnName, Func<T, double?> nullableDoubleValueFunc, int gridWidth,
            AgGridColumnDataType agGridColumnDataType, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAlignType agGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, agGridColumnDataType, agGridColumnFormatType, agGridColumnAlignType,
                dhtmlxGridColumnSortType, agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _nullableDoubleValueFunc = nullableDoubleValueFunc;
            _funcType = FuncType.NullableDouble;
        }

        public ColumnSpec(string columnName, Func<T, decimal> decimalValueFunc, int gridWidth,
            AgGridColumnDataType agGridColumnDataType, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAlignType agGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, agGridColumnDataType, agGridColumnFormatType, agGridColumnAlignType,
                dhtmlxGridColumnSortType, agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _decimalValueFunc = decimalValueFunc;
            _funcType = FuncType.Decimal;
        }

        public ColumnSpec(string columnName, Func<T, decimal?> nullableDecimalValueFunc, int gridWidth,
            AgGridColumnDataType agGridColumnDataType, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAlignType agGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, agGridColumnDataType, agGridColumnFormatType, agGridColumnAlignType,
                dhtmlxGridColumnSortType, agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _nullableDecimalValueFunc = nullableDecimalValueFunc;
            _funcType = FuncType.NullableDecimal;
        }

        public ColumnSpec(string columnName, Func<T, HtmlString> htmlStringValueFunc, int gridWidth,
            AgGridColumnDataType agGridColumnDataType, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAlignType agGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, agGridColumnDataType, agGridColumnFormatType, agGridColumnAlignType,
                dhtmlxGridColumnSortType, agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _htmlStringValueFunc = htmlStringValueFunc;
            _funcType = FuncType.HtmlString;
        }

        public ColumnSpec(string columnName, Func<T, bool> boolValueFunc, int gridWidth,
            AgGridColumnDataType agGridColumnDataType, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAlignType agGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, agGridColumnDataType, agGridColumnFormatType, agGridColumnAlignType,
                dhtmlxGridColumnSortType, agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction,
                titleFunction)
        {
            _boolValueFunc = boolValueFunc;
            _funcType = FuncType.Bool;
        }

        public ColumnSpec(string columnName, Func<T, bool?> nullableBoolValueFunc, int gridWidth,
            AgGridColumnDataType agGridColumnDataType, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAlignType agGridColumnAlignType, DhtmlxGridColumnSortType dhtmlxGridColumnSortType,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType, Func<T, string> cssClassFunction,
            Func<T, string> titleFunction)
            : this(
                columnName, gridWidth, agGridColumnDataType, agGridColumnFormatType, agGridColumnAlignType,
                dhtmlxGridColumnSortType, agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction,
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
                    return AgGridColumnFormatType == AgGridColumnFormatType.Date ? _dateTimeValueFunc(dataObject).ToStringDate() : _dateTimeValueFunc(dataObject).ToStringDateTime();
                case FuncType.NullableDateTime:
                    var dateTimeValue = _nullableDateTimeValueFunc(dataObject);
                    return dateTimeValue.HasValue
                        ? AgGridColumnFormatType == AgGridColumnFormatType.Date
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
                    var calculateStringValue = htmlStringValue.ToString();
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse RL 1/11/19 Not true!
                    return calculateStringValue ?? string.Empty;
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

        public object CalculateNumericOrStringValue(T dataObject)
        {
            switch (_funcType)
            {

                case FuncType.Int:
                    return _intValueFunc(dataObject);
                case FuncType.NullableInt:
                    return _nullableIntValueFunc(dataObject);
                case FuncType.Decimal:
                    return _decimalValueFunc(dataObject);
                case FuncType.NullableDecimal:
                    return _nullableDecimalValueFunc(dataObject);
                case FuncType.Double:
                    return _doubleValueFunc(dataObject);
                case FuncType.NullableDouble:
                    return _nullableDoubleValueFunc(dataObject);
                case FuncType.Short:
                    return _shortValueFunc(dataObject);
                case FuncType.NullableShort:
                    return _nullableShortValueFunc(dataObject);
                case FuncType.Byte:
                    return _byteValueFunc(dataObject);
                case FuncType.NullableByte:
                    return _nullableByteValueFunc(dataObject);
                default:
                    return CalculateStringValue(dataObject);
            }
        }
    }
}
