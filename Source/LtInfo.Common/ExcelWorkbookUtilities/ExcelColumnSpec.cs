using System;
using ClosedXML.Excel;

namespace LtInfo.Common.ExcelWorkbookUtilities
{
    public class ExcelColumnSpec<T>
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

        private readonly FuncType _funcType;

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
            NullableBool
        }

        public ExcelColumnSpec(string columnName, Func<T, string> stringValueFunc) : this(columnName)
        {
            _stringValueFunc = stringValueFunc;
            _funcType = FuncType.String;
        }

        public ExcelColumnSpec(string columnName, Func<T, int> intValueFunc)
            : this(columnName)
        {
            _intValueFunc = intValueFunc;
            _funcType = FuncType.Int;
        }

        public ExcelColumnSpec(string columnName, Func<T, int?> nullableIntValueFunc)
            : this(columnName)
        {
            _nullableIntValueFunc = nullableIntValueFunc;
            _funcType = FuncType.NullableInt;
        }

        public ExcelColumnSpec(string columnName, Func<T, short> shortValueFunc)
            : this(columnName)
        {
            _shortValueFunc = shortValueFunc;
            _funcType = FuncType.Short;
        }

        public ExcelColumnSpec(string columnName, Func<T, short?> nullableShortValueFunc)
            : this(columnName)
        {
            _nullableShortValueFunc = nullableShortValueFunc;
            _funcType = FuncType.NullableShort;
        }

        public ExcelColumnSpec(string columnName, Func<T, byte> byteValueFunc)
            : this(columnName)
        {
            _byteValueFunc = byteValueFunc;
            _funcType = FuncType.Byte;
        }

        public ExcelColumnSpec(string columnName, Func<T, byte?> nullableByteValueFunc)
            : this(columnName)
        {
            _nullableByteValueFunc = nullableByteValueFunc;
            _funcType = FuncType.NullableByte;
        }

        public ExcelColumnSpec(string columnName, Func<T, DateTime> dateTimeValueFunc)
            : this(columnName)
        {
            _dateTimeValueFunc = dateTimeValueFunc;
            _funcType = FuncType.DateTime;
        }

        public ExcelColumnSpec(string columnName, Func<T, DateTime?> nullableDateTimeValueFunc)
            : this(columnName)
        {
            _nullableDateTimeValueFunc = nullableDateTimeValueFunc;
            _funcType = FuncType.NullableDateTime;
        }

        public ExcelColumnSpec(string columnName, Func<T, decimal> valueFunc)
            : this(columnName)
        {
            _decimalValueFunc = valueFunc;
            _funcType = FuncType.Decimal;
        }

        public ExcelColumnSpec(string columnName, Func<T, decimal?> nullableDecimalValueFunc)
            : this(columnName)
        {
            _nullableDecimalValueFunc = nullableDecimalValueFunc;
            _funcType = FuncType.NullableDecimal;
        }

        public ExcelColumnSpec(string columnName, Func<T, double> valueFunc)
            : this(columnName)
        {
            _doubleValueFunc = valueFunc;
            _funcType = FuncType.Double;
        }

        public ExcelColumnSpec(string columnName, Func<T, double?> nullableDoubleValueFunc)
            : this(columnName)
        {
            _nullableDoubleValueFunc = nullableDoubleValueFunc;
            _funcType = FuncType.NullableDouble;
        }

        public ExcelColumnSpec(string columnName, Func<T, bool> valueFunc)
            : this(columnName)
        {
            _boolValueFunc = valueFunc;
            _funcType = FuncType.Bool;
        }

        public ExcelColumnSpec(string columnName, Func<T, bool?> nullableBoolValueFunc)
            : this(columnName)
        {
            _nullableBoolValueFunc = nullableBoolValueFunc;
            _funcType = FuncType.NullableBool;
        }

        private ExcelColumnSpec(string columnName)
        {
            ColumnName = columnName;
        }

        public void SetValue(IXLCell cell, T dataObject)
        {
            switch (_funcType)
            {
                case FuncType.String:
                    var stringValue = _stringValueFunc(dataObject);
                    if (stringValue != null)
                    {
                        cell.SetValue(stringValue);
                    }
                    break;
                case FuncType.Int:
                    cell.SetValue(_intValueFunc(dataObject));
                    break;
                case FuncType.NullableInt:
                    var intValue = _nullableIntValueFunc(dataObject);
                    if (intValue.HasValue)
                    {
                        cell.SetValue(intValue);
                    }
                    break;
                case FuncType.DateTime:
                    cell.SetValue(_dateTimeValueFunc(dataObject));
                    break;
                case FuncType.NullableDateTime:
                    var dateTimeValue = _nullableDateTimeValueFunc(dataObject);
                    if (dateTimeValue.HasValue)
                    {
                        cell.SetValue(dateTimeValue);
                    }
                    break;
                case FuncType.Decimal:
                    cell.SetValue(_decimalValueFunc(dataObject));
                    break;
                case FuncType.NullableDecimal:
                    var decimalValue = _nullableDecimalValueFunc(dataObject);
                    if (decimalValue.HasValue)
                    {
                        cell.SetValue(decimalValue);
                    }
                    break;
                case FuncType.Double:
                    cell.SetValue(_doubleValueFunc(dataObject));
                    break;
                case FuncType.NullableDouble:
                    var doubleValue = _nullableDoubleValueFunc(dataObject);
                    if (doubleValue.HasValue)
                    {
                        cell.SetValue(doubleValue);
                    }
                    break;
                case FuncType.Bool:
                    cell.SetValue(_boolValueFunc(dataObject));
                    break;
                case FuncType.NullableBool:
                    var boolValue = _nullableBoolValueFunc(dataObject);
                    if (boolValue.HasValue)
                    {
                        cell.SetValue(boolValue);
                    }
                    break;
                case FuncType.Short:
                    cell.SetValue(_shortValueFunc(dataObject));
                    break;
                case FuncType.NullableShort:
                    var shortValue = _nullableShortValueFunc(dataObject);
                    if (shortValue.HasValue)
                    {
                        cell.SetValue(shortValue);
                    }
                    break;
                case FuncType.Byte:
                    cell.SetValue(_byteValueFunc(dataObject));
                    break;
                case FuncType.NullableByte:
                    var byteValue = _nullableByteValueFunc(dataObject);
                    if (byteValue.HasValue)
                    {
                        cell.SetValue(byteValue);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}