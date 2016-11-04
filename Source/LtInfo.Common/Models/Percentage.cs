using System;
using System.Diagnostics;
using System.Globalization;
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common.Models
{
    /// <summary>
    /// Represents a percentage between 0 and 100%
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{GetDebugView()}")]
    [ModelBinder(typeof(PercentageModelBinder))] // ModelBinder is for Action parameter parsing
    public struct Percentage : IEquatable<Percentage>,
                               IComparable<Percentage>,
                               IFormattable,
                               IConvertible,
                               IComparable
    {
        private const int MinValue = 0;
        private const int MaxValue = 1;

        /// <summary>
        /// A zero value of percentage, regardless of currency.
        /// </summary>
        public static readonly Percentage Zero = new Percentage(0);

        /// <summary>
        /// The decimal representation of the percentage
        /// </summary>
        private readonly decimal _decimal;

        /// <summary>
        /// Initializes a new instance of the <see cref="Percentage"/> struct equal to <paramref name="value"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public Percentage(Decimal value)
        {
            CheckValue(value);
            _decimal = value;
        }

        /// <summary>
        /// Implicitly converts a <see cref="Byte"/> value to <see cref="Percentage"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="Percentage"/> value.
        /// </returns>
        public static implicit operator Percentage(Byte value)
        {
            return new Percentage(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="SByte"/> value to <see cref="Percentage"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="Percentage"/> value.
        /// </returns>
        public static implicit operator Percentage(SByte value)
        {
            return new Percentage(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Single"/> value to <see cref="Percentage"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="Percentage"/> value.
        /// </returns>
        public static implicit operator Percentage(Single value)
        {
            return new Percentage((Decimal)value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Double"/> value to <see cref="Percentage"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="Percentage"/> value.
        /// </returns>
        public static implicit operator Percentage(Double value)
        {
            return new Percentage((Decimal)value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Decimal"/> value to <see cref="Percentage"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="Percentage"/> value.
        /// </returns>
        public static implicit operator Percentage(Decimal value)
        {
            return new Percentage(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Percentage"/> value to <see cref="Decimal"/> value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="Decimal"/> value which this <see cref="Percentage"/> value is equivalent to.
        /// </returns>
        public static implicit operator Decimal(Percentage value)
        {
            return value.ComputeValue();
        }

        /// <summary>
        /// Implicitly converts a <see cref="Int16"/> value to <see cref="Percentage"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="Percentage"/> value.
        /// </returns>
        public static implicit operator Percentage(Int16 value)
        {
            return new Percentage(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Int32"/> value to <see cref="Percentage"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="Percentage"/> value.
        /// </returns>
        public static implicit operator Percentage(Int32 value)
        {
            return new Percentage(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="Int64"/> value to <see cref="Percentage"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="Percentage"/> value.
        /// </returns>
        public static implicit operator Percentage(Int64 value)
        {
            return new Percentage(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="UInt16"/> value to <see cref="Percentage"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="Percentage"/> value.
        /// </returns>
        public static implicit operator Percentage(UInt16 value)
        {
            return new Percentage(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="UInt32"/> value to <see cref="Percentage"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="Percentage"/> value.
        /// </returns>
        public static implicit operator Percentage(UInt32 value)
        {
            return new Percentage(value);
        }

        /// <summary>
        /// Implicitly converts a <see cref="UInt64"/> value to <see cref="Percentage"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A <see cref="Percentage"/> value.
        /// </returns>
        public static implicit operator Percentage(UInt64 value)
        {
            return new Percentage(value);
        }

        /// <summary>
        /// A negation operator for a <see cref="Percentage"/> value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The additive inverse (negation) of the given <paramref name="value"/>.
        /// </returns>
        public static Percentage operator -(Percentage value)
        {
            return new Percentage(-value._decimal);
        }

        /// <summary>
        /// An identity operator for a <see cref="Percentage"/> value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The given <paramref name="value"/>.
        /// </returns>
        public static Percentage operator +(Percentage value)
        {
            return value;
        }

        /// <summary>
        /// An addition operator for two <see cref="Percentage"/> values.
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
        /// Thrown if the percentages of <paramref name="left"/> and <paramref name="right"/> are greater than 1.
        /// </exception>
        public static Percentage operator +(Percentage left, Percentage right)
        {
            return new Percentage(left._decimal + right._decimal);
        }

        /// <summary>
        /// A subtraction operator for two <see cref="Percentage"/> values.
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
        public static Percentage operator -(Percentage left, Percentage right)
        {
            return new Percentage(left._decimal - right._decimal);
        }

        /// <summary>
        /// A product operator for a <see cref="Percentage"/> value and a <see cref="Decimal"/> value.
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
        public static Percentage operator *(Percentage left, Decimal right)
        {
            return ((Decimal)left * right);
        }

        public static Percentage operator /(Percentage left, Decimal right)
        {
            return ((Decimal)left / right);
        }

        public static Boolean operator ==(Percentage left, Percentage right)
        {
            return left.Equals(right);
        }

        public static Boolean operator !=(Percentage left, Percentage right)
        {
            return !left.Equals(right);
        }

        public static Boolean operator >(Percentage left, Percentage right)
        {
            return left.CompareTo(right) > 0;
        }

        public static Boolean operator <(Percentage left, Percentage right)
        {
            return left.CompareTo(right) < 0;
        }

        public static Boolean operator >=(Percentage left, Percentage right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static Boolean operator <=(Percentage left, Percentage right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static Boolean TryParse(String s, out Percentage percentage)
        {
            decimal value;
            if (TryParseImpl(s, out value))
            {
                percentage = new Percentage(value/100);
                return true;
            }

            percentage = Zero;
            return false;
        }

        private static bool TryParseImpl(string s, out decimal value)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                value = 0;
                return false;
            }

            return decimal.TryParse(s.Replace("%", ""), out value);
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
            if (!(obj is Percentage))
            {
                return false;
            }

            var other = (Percentage)obj;
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

        #region Implementation of IEquatable<Percentage>

        public Boolean Equals(Percentage other)
        {
            return _decimal == other._decimal;
        }

        #endregion

        #region Implementation of IComparable<Percentage>

        public Int32 CompareTo(Percentage other)
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
            if (obj is Percentage)
            {
                return CompareTo((Percentage)obj);
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
            var isValidPercentage = IsValidPercentage(value);
            if (!isValidPercentage)
            {
                throw new ArgumentOutOfRangeException("value", value, string.Format("Percentage value must be between {0} and {1}", MinValue, MaxValue));
            }
        }

        private static bool IsValidPercentage(decimal value)
        {
            return value >= MinValue && value <= MaxValue;
        }

        private string GetDebugView()
        {
            return ToString() +
                   string.Format(" ({0})",
                                 ToDecimal(CultureInfo.CurrentCulture));
        }

        public class PercentageModelBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

                Check.RequireType<string>(valueProviderResult.AttemptedValue, string.Format("Parameter {0} {1} but wrong primitive type.", typeof(object).Name, bindingContext.ModelName));

                decimal percentageAsDecimal;
                if (TryParseImpl(valueProviderResult.AttemptedValue, out percentageAsDecimal))
                {
                    percentageAsDecimal = percentageAsDecimal/100;
                    if (IsValidPercentage(percentageAsDecimal))
                    {
                        return new Percentage(percentageAsDecimal);
                    }
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, string.Format("Percentage must be between {0} and {1}", MinValue.ToString("0%"), MaxValue.ToString("0%")));
                    bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
                    return percentageAsDecimal;
                }
                return null;
            }
        }
    }
}