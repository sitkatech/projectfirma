using System.Diagnostics;
using System.Globalization;
using System.Web.Mvc;
using LtInfo.Common.Models;

namespace System
{
    /// <summary>
    /// Represents a whole number amount of generic currency
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{GetDebugView()}")]
    [ModelBinder(typeof(MoneyWholeNumberModelBinder))] // ModelBinder is for Action parameter parsing
    public struct MoneyWholeNumber : IEquatable<MoneyWholeNumber>,
                          IComparable<MoneyWholeNumber>,
                          IFormattable,
                          IConvertible,
                          IComparable
    {
        /// <summary>
        /// A zero value of MoneyWholeNumber, regardless of currency.
        /// </summary>
        public static readonly MoneyWholeNumber Zero = new MoneyWholeNumber(0);

        /// <summary>
        /// The whole units of currency.
        /// </summary>
        private readonly Int64 _units;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoneyWholeNumber"/> struct equal to <paramref name="value"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public MoneyWholeNumber(Decimal value)
        {
            CheckValue(value);
            _units = Convert.ToInt64(Math.Round(value));
        }




        /// <summary>
        /// Implicitly converts a <see cref="Byte"/> value to <see cref="MoneyWholeNumber"/>
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="MoneyWholeNumber"/> value
        /// </returns>
        public static implicit operator MoneyWholeNumber(Byte value)
        {
            return new MoneyWholeNumber(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="SByte"/> value to <see cref="MoneyWholeNumber"/>
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="MoneyWholeNumber"/> value
        /// </returns>
        public static implicit operator MoneyWholeNumber(SByte value)
        {
            return new MoneyWholeNumber(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Single"/> value to <see cref="MoneyWholeNumber"/>
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="MoneyWholeNumber"/> value
        /// </returns>
        public static implicit operator MoneyWholeNumber(Single value)
        {
            return new MoneyWholeNumber((Decimal)value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Double"/> value to <see cref="MoneyWholeNumber"/>
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="MoneyWholeNumber"/> value
        /// </returns>
        public static implicit operator MoneyWholeNumber(Double value)
        {
            return new MoneyWholeNumber((Decimal)value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Decimal"/> value to <see cref="MoneyWholeNumber"/>
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="MoneyWholeNumber"/> value
        /// </returns>
        public static implicit operator MoneyWholeNumber(Decimal value)
        {
            return new MoneyWholeNumber(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="MoneyWholeNumber"/> value to <see cref="Decimal"/> value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="Decimal"/> value which this <see cref="MoneyWholeNumber"/> value is equivalent to.
        /// </returns>
        public static implicit operator Decimal(MoneyWholeNumber value)
        {
            return value.ComputeValue();
        }

        /// <summary>
        /// Implicitly converts a <see cref="Int16"/> value to <see cref="MoneyWholeNumber"/>
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="MoneyWholeNumber"/> value
        /// </returns>
        public static implicit operator MoneyWholeNumber(Int16 value)
        {
            return new MoneyWholeNumber(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Int32"/> value to <see cref="MoneyWholeNumber"/>
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="MoneyWholeNumber"/> value
        /// </returns>
        public static implicit operator MoneyWholeNumber(Int32 value)
        {
            return new MoneyWholeNumber(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Int64"/> value to <see cref="MoneyWholeNumber"/>
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="MoneyWholeNumber"/> value
        /// </returns>
        public static implicit operator MoneyWholeNumber(Int64 value)
        {
            return new MoneyWholeNumber(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="UInt16"/> value to <see cref="MoneyWholeNumber"/>
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="MoneyWholeNumber"/> value
        /// </returns>
        public static implicit operator MoneyWholeNumber(UInt16 value)
        {
            return new MoneyWholeNumber(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="UInt32"/> value to <see cref="MoneyWholeNumber"/>
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="MoneyWholeNumber"/> value
        /// </returns>
        public static implicit operator MoneyWholeNumber(UInt32 value)
        {
            return new MoneyWholeNumber(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="UInt64"/> value to <see cref="MoneyWholeNumber"/>
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="MoneyWholeNumber"/> value
        /// </returns>
        public static implicit operator MoneyWholeNumber(UInt64 value)
        {
            return new MoneyWholeNumber(value);
        }

        /// <summary>
        /// A negation operator for a <see cref="MoneyWholeNumber"/> value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The additive inverse (negation) of the given <paramref name="value"/>.
        /// </returns>
        public static MoneyWholeNumber operator -(MoneyWholeNumber value)
        {
            return new MoneyWholeNumber(-value._units);
        }

        /// <summary>
        /// An identity operator for a <see cref="MoneyWholeNumber"/> value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The given <paramref name="value"/>.
        /// </returns>
        public static MoneyWholeNumber operator +(MoneyWholeNumber value)
        {
            return value;
        }

        /// <summary>
        /// An addition operator for two <see cref="MoneyWholeNumber"/> values.
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
        /// Thrown if the currencies of <paramref name="left"/> and <paramref name="right"/> are not equal.
        /// </exception>
        public static MoneyWholeNumber operator +(MoneyWholeNumber left, MoneyWholeNumber right)
        {
            var newUnits = left._units + right._units;
            return new MoneyWholeNumber(newUnits);
        }

        /// <summary>
        /// A subtraction operator for two <see cref="MoneyWholeNumber"/> values.
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
        public static MoneyWholeNumber operator -(MoneyWholeNumber left, MoneyWholeNumber right)
        {
            return left + -right;
        }

        /// <summary>
        /// A product operator for a <see cref="MoneyWholeNumber"/> value and a <see cref="Decimal"/> value.
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
        public static MoneyWholeNumber operator *(MoneyWholeNumber left, Decimal right)
        {
            return ((Decimal)left * right);
        }

        public static MoneyWholeNumber operator /(MoneyWholeNumber left, Decimal right)
        {
            return ((Decimal)left / right);
        }

        public static Boolean operator ==(MoneyWholeNumber left, MoneyWholeNumber right)
        {
            return left.Equals(right);
        }

        public static Boolean operator !=(MoneyWholeNumber left, MoneyWholeNumber right)
        {
            return !left.Equals(right);
        }

        public static Boolean operator >(MoneyWholeNumber left, MoneyWholeNumber right)
        {
            return left.CompareTo(right) > 0;
        }

        public static Boolean operator <(MoneyWholeNumber left, MoneyWholeNumber right)
        {
            return left.CompareTo(right) < 0;
        }

        public static Boolean operator >=(MoneyWholeNumber left, MoneyWholeNumber right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static Boolean operator <=(MoneyWholeNumber left, MoneyWholeNumber right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static Boolean TryParse(String s, out MoneyWholeNumber moneyWholeNumber)
        {
            Decimal value;
            if (String.IsNullOrWhiteSpace(s) || !Decimal.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out value))
            {
                moneyWholeNumber = Zero;
                return false;
            }
            moneyWholeNumber = new MoneyWholeNumber(value);
            return true;
        }


        public override Int32 GetHashCode()
        {
            unchecked
            {
                return (397 * _units.GetHashCode());
            }
        }

        public override Boolean Equals(Object obj)
        {
            if (!(obj is MoneyWholeNumber))
            {
                return false;
            }

            var other = (MoneyWholeNumber)obj;
            return Equals(other);
        }

        public override String ToString()
        {
            return ComputeValue().ToString("C0", NumberFormatInfo.CurrentInfo);
        }

        public String ToString(String format)
        {
            return ComputeValue().ToString(format, NumberFormatInfo.CurrentInfo);
        }

        #region Implementation of IEquatable<MoneyWholeNumber>

        public Boolean Equals(MoneyWholeNumber other)
        {
            return _units == other._units;
        }

        #endregion

        #region Implementation of IComparable<MoneyWholeNumber>

        public Int32 CompareTo(MoneyWholeNumber other)
        {
            var unitCompare = _units.CompareTo(other._units);

            return unitCompare;
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
            if (obj is MoneyWholeNumber)
            {
                return CompareTo((MoneyWholeNumber)obj);
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
            return _units == 0;
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
            return _units;
        }


        private static void CheckValue(Decimal value)
        {
            if (value < Int64.MinValue || value > Int64.MaxValue)
            {
                throw new ArgumentOutOfRangeException("value",
                                                      value,
                                                      "MoneyWholeNumber value must be between " +
                                                      Int64.MinValue + " and " +
                                                      Int64.MaxValue);
            }
        }

        private string GetDebugView()
        {
            return ToString() +
                   String.Format(" ({0})",
                                 ToDecimal(CultureInfo.CurrentCulture));
        }

        public class MoneyWholeNumberModelBinder : SitkaModelBinder
        {
            public MoneyWholeNumberModelBinder()
                : base(s =>
                {
                    MoneyWholeNumber moneyWholeNumber;
                    if (TryParse(s, out moneyWholeNumber))
                    {
                        return moneyWholeNumber;
                    }
                    return null;
                })
            { }
        }

        public string ToStringCurrency()
        {
            return ToString("C0");
        }
    }
}