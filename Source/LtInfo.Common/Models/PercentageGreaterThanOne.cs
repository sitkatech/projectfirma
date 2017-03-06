/*-----------------------------------------------------------------------
<copyright file="PercentageGreaterThanOne.cs" company="Sitka Technology Group">
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
using System.Diagnostics;
using System.Globalization;
using System.Web.Mvc;

namespace LtInfo.Common.Models
{
    /// <summary>
    /// Represents a percentageGreaterThanOne between 0 and 100%
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{GetDebugView()}")]
    [ModelBinder(typeof(PercentageGreaterThanOneModelBinder))] // ModelBinder is for Action parameter parsing
    public struct PercentageGreaterThanOne : IEquatable<PercentageGreaterThanOne>,
                               IComparable<PercentageGreaterThanOne>,
                               IFormattable,
                               IConvertible,
                               IComparable
    {
        /// <summary>
        /// A zero value of percentageGreaterThanOne, regardless of currency.
        /// </summary>
        public static readonly PercentageGreaterThanOne Zero = new PercentageGreaterThanOne(0);

        /// <summary>
        /// The decimal representation of the percentageGreaterThanOne
        /// </summary>
        private readonly decimal _decimal;

        /// <summary>
        /// Initializes a new instance of the <see cref="PercentageGreaterThanOne"/> struct equal to <paramref name="value"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public PercentageGreaterThanOne(Decimal value)
        {
            CheckValue(value);
            _decimal = value;
        }

        /// <summary>
        /// Implicitly converts a <see cref="Byte"/> value to <see cref="PercentageGreaterThanOne"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="PercentageGreaterThanOne"/> value.
        /// </returns>
        public static implicit operator PercentageGreaterThanOne(Byte value)
        {
            return new PercentageGreaterThanOne(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="SByte"/> value to <see cref="PercentageGreaterThanOne"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="PercentageGreaterThanOne"/> value.
        /// </returns>
        public static implicit operator PercentageGreaterThanOne(SByte value)
        {
            return new PercentageGreaterThanOne(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Single"/> value to <see cref="PercentageGreaterThanOne"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="PercentageGreaterThanOne"/> value.
        /// </returns>
        public static implicit operator PercentageGreaterThanOne(Single value)
        {
            return new PercentageGreaterThanOne((Decimal)value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Double"/> value to <see cref="PercentageGreaterThanOne"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="PercentageGreaterThanOne"/> value.
        /// </returns>
        public static implicit operator PercentageGreaterThanOne(Double value)
        {
            return new PercentageGreaterThanOne((Decimal)value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Decimal"/> value to <see cref="PercentageGreaterThanOne"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="PercentageGreaterThanOne"/> value.
        /// </returns>
        public static implicit operator PercentageGreaterThanOne(Decimal value)
        {
            return new PercentageGreaterThanOne(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="PercentageGreaterThanOne"/> value to <see cref="Decimal"/> value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="Decimal"/> value which this <see cref="PercentageGreaterThanOne"/> value is equivalent to.
        /// </returns>
        public static implicit operator Decimal(PercentageGreaterThanOne value)
        {
            return value.ComputeValue();
        }

        /// <summary>
        /// Implicitly converts a <see cref="Int16"/> value to <see cref="PercentageGreaterThanOne"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="PercentageGreaterThanOne"/> value.
        /// </returns>
        public static implicit operator PercentageGreaterThanOne(Int16 value)
        {
            return new PercentageGreaterThanOne(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Int32"/> value to <see cref="PercentageGreaterThanOne"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="PercentageGreaterThanOne"/> value.
        /// </returns>
        public static implicit operator PercentageGreaterThanOne(Int32 value)
        {
            return new PercentageGreaterThanOne(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Int64"/> value to <see cref="PercentageGreaterThanOne"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="PercentageGreaterThanOne"/> value.
        /// </returns>
        public static implicit operator PercentageGreaterThanOne(Int64 value)
        {
            return new PercentageGreaterThanOne(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="UInt16"/> value to <see cref="PercentageGreaterThanOne"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="PercentageGreaterThanOne"/> value.
        /// </returns>
        public static implicit operator PercentageGreaterThanOne(UInt16 value)
        {
            return new PercentageGreaterThanOne(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="UInt32"/> value to <see cref="PercentageGreaterThanOne"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="PercentageGreaterThanOne"/> value.
        /// </returns>
        public static implicit operator PercentageGreaterThanOne(UInt32 value)
        {
            return new PercentageGreaterThanOne(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="UInt64"/> value to <see cref="PercentageGreaterThanOne"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="PercentageGreaterThanOne"/> value.
        /// </returns>
        public static implicit operator PercentageGreaterThanOne(UInt64 value)
        {
            return new PercentageGreaterThanOne(value);
        }

        /// <summary>
        /// A negation operator for a <see cref="PercentageGreaterThanOne"/> value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The additive inverse (negation) of the given <paramref name="value"/>.
        /// </returns>
        public static PercentageGreaterThanOne operator -(PercentageGreaterThanOne value)
        {
            return new PercentageGreaterThanOne(-value._decimal);
        }

        /// <summary>
        /// An identity operator for a <see cref="PercentageGreaterThanOne"/> value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The given <paramref name="value"/>.
        /// </returns>
        public static PercentageGreaterThanOne operator +(PercentageGreaterThanOne value)
        {
            return value;
        }

        /// <summary>
        /// An addition operator for two <see cref="PercentageGreaterThanOne"/> values.
        /// </summary>
        /// <param name="left">
        /// The left operand.
        /// </param>
        /// <param name="right">
        /// The right operand.
        /// </param>
        /// <returns>
        /// The sum of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the percentageGreaterThanOnes of <paramref name="left"/> and <paramref name="right"/> are greater than 1.
        /// </exception>
        public static PercentageGreaterThanOne operator +(PercentageGreaterThanOne left, PercentageGreaterThanOne right)
        {
            return new PercentageGreaterThanOne(left._decimal + right._decimal);
        }

        /// <summary>
        /// A subtraction operator for two <see cref="PercentageGreaterThanOne"/> values.
        /// </summary>
        /// <param name="left">
        /// The left operand.
        /// </param>
        /// <param name="right">
        /// The right operand.
        /// </param>
        /// <returns>
        /// The difference of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the currencies of <paramref name="left"/> and <paramref name="right"/> are not equal.
        /// </exception>
        public static PercentageGreaterThanOne operator -(PercentageGreaterThanOne left, PercentageGreaterThanOne right)
        {
            return new PercentageGreaterThanOne(left._decimal - right._decimal);
        }

        /// <summary>
        /// A product operator for a <see cref="PercentageGreaterThanOne"/> value and a <see cref="Decimal"/> value.
        /// </summary>
        /// <param name="left">
        /// The left operand.
        /// </param>
        /// <param name="right">
        /// The right operand.
        /// </param>
        /// <returns>
        /// The product of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static PercentageGreaterThanOne operator *(PercentageGreaterThanOne left, Decimal right)
        {
            return ((Decimal)left * right);
        }

        public static PercentageGreaterThanOne operator /(PercentageGreaterThanOne left, Decimal right)
        {
            return ((Decimal)left / right);
        }

        public static Boolean operator ==(PercentageGreaterThanOne left, PercentageGreaterThanOne right)
        {
            return left.Equals(right);
        }

        public static Boolean operator !=(PercentageGreaterThanOne left, PercentageGreaterThanOne right)
        {
            return !left.Equals(right);
        }

        public static Boolean operator >(PercentageGreaterThanOne left, PercentageGreaterThanOne right)
        {
            return left.CompareTo(right) > 0;
        }

        public static Boolean operator <(PercentageGreaterThanOne left, PercentageGreaterThanOne right)
        {
            return left.CompareTo(right) < 0;
        }

        public static Boolean operator >=(PercentageGreaterThanOne left, PercentageGreaterThanOne right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static Boolean operator <=(PercentageGreaterThanOne left, PercentageGreaterThanOne right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static Boolean TryParse(String s, out PercentageGreaterThanOne percentageGreaterThanOne)
        {
            percentageGreaterThanOne = Zero;

            if (s == null)
            {
                return false;
            }

            s = s.Trim();

            if (s == String.Empty)
            {
                return false;
            }

            Decimal value;

            if (!Decimal.TryParse(s.Replace("%", ""), out value))
            {
                return false;
            }

            percentageGreaterThanOne = new PercentageGreaterThanOne(value / 100);

            return true;
        }

        public override Int32 GetHashCode()
        {
            unchecked
            {
                return (397 * _decimal.GetHashCode());
            }
        }

        public override Boolean Equals(Object obj)
        {
            if (!(obj is PercentageGreaterThanOne))
            {
                return false;
            }

            var other = (PercentageGreaterThanOne)obj;
            return Equals(other);
        }

        public override String ToString()
        {
            return ComputeValue().ToString("0.00%", NumberFormatInfo.CurrentInfo);
        }

        public String ToString(String format)
        {
            return ComputeValue().ToString(format, NumberFormatInfo.CurrentInfo);
        }

        #region Implementation of IEquatable<PercentageGreaterThanOne>

        public Boolean Equals(PercentageGreaterThanOne other)
        {
            return _decimal == other._decimal;
        }

        #endregion

        #region Implementation of IComparable<PercentageGreaterThanOne>

        public Int32 CompareTo(PercentageGreaterThanOne other)
        {
            return _decimal.CompareTo(other._decimal);
        }

        #endregion

        #region Implementation of IFormattable

        public String ToString(String format, IFormatProvider formatProvider)
        {
            return ComputeValue().ToString(format, formatProvider);
        }

        #endregion

        #region Implementation of IComparable

        int IComparable.CompareTo(object obj)
        {
            if (obj is PercentageGreaterThanOne)
            {
                return CompareTo((PercentageGreaterThanOne)obj);
            }

            throw new InvalidOperationException("Object is not a " + GetType() + " instance.");
        }

        #endregion

        #region Implementation of IConvertible

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        public Boolean ToBoolean(IFormatProvider provider)
        {
            return _decimal == 0;
        }

        public Char ToChar(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        public SByte ToSByte(IFormatProvider provider)
        {
            return (SByte)ComputeValue();
        }

        public Byte ToByte(IFormatProvider provider)
        {
            return (Byte)ComputeValue();
        }

        public Int16 ToInt16(IFormatProvider provider)
        {
            return (Int16)ComputeValue();
        }

        public UInt16 ToUInt16(IFormatProvider provider)
        {
            return (UInt16)ComputeValue();
        }

        public Int32 ToInt32(IFormatProvider provider)
        {
            return (Int32)ComputeValue();
        }

        public UInt32 ToUInt32(IFormatProvider provider)
        {
            return (UInt32)ComputeValue();
        }

        public Int64 ToInt64(IFormatProvider provider)
        {
            return (Int64)ComputeValue();
        }

        public UInt64 ToUInt64(IFormatProvider provider)
        {
            return (UInt64)ComputeValue();
        }

        public Single ToSingle(IFormatProvider provider)
        {
            return (Single)ComputeValue();
        }

        public Double ToDouble(IFormatProvider provider)
        {
            return (Double)ComputeValue();
        }

        public Decimal ToDecimal(IFormatProvider provider)
        {
            return ComputeValue();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        public String ToString(IFormatProvider provider)
        {
            return ((Decimal)this).ToString(provider);
        }

        public Object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        #endregion

        private Decimal ComputeValue()
        {
            return _decimal;
        }

        private static void CheckValue(Decimal value)
        {
            const int minValue = 0;
            
            if (value < minValue )
            {
                throw new ArgumentOutOfRangeException("value",
                                                      value,
                                                      string.Format("PercentageGreaterThanOne value must be greater than {0}", minValue));
            }
        }

        private String GetDebugView()
        {
            return ToString() +
                   String.Format(" ({0})",
                                 ToDecimal(CultureInfo.CurrentCulture));
        }

        public class PercentageGreaterThanOneModelBinder : SitkaModelBinder
        {
            public PercentageGreaterThanOneModelBinder()
                : base(s =>
                {
                    PercentageGreaterThanOne percentageGreaterThanOne;
                    if (TryParse(s, out percentageGreaterThanOne))
                    {
                        return percentageGreaterThanOne;
                    }
                    return null;
                })
            { }
        }

    }
}
