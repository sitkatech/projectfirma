using System;
using System.Globalization;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectCustomAttributeDataType
    {
        public abstract bool ValueIsCorrectDataType(string customAttributeValue);
        public abstract string ValueParsedForDataType(string customAttributeValue);
        public abstract bool HasOptions();
        public abstract bool HasMeasurementUnit();
    }

    public partial class ProjectCustomAttributeDataTypeString
    {
        public override bool ValueIsCorrectDataType(string customAttributeValue) => true;
        public override string ValueParsedForDataType(string customAttributeValue) => customAttributeValue;
        public override bool HasOptions() => false;
        public override bool HasMeasurementUnit() => false;
    }

    public partial class ProjectCustomAttributeDataTypeInteger
    {
        public override bool ValueIsCorrectDataType(string customAttributeValue) => int.TryParse(customAttributeValue, out var _);

        public override string ValueParsedForDataType(string customAttributeValue)
        {
            if (string.IsNullOrWhiteSpace(customAttributeValue))
            {
                return customAttributeValue;
            }

            if (int.TryParse(customAttributeValue, out var n))
            {
                return n.ToString();
            }

            throw new ArgumentOutOfRangeException($"Attribute value {customAttributeValue} does not appear to be a {this.GetType().Name} data type");
        }

        public override bool HasOptions() => false;
        public override bool HasMeasurementUnit() => true;
    }

    public partial class ProjectCustomAttributeDataTypeDecimal
    {
        public override bool ValueIsCorrectDataType(string customAttributeValue)
        {
            return decimal.TryParse(customAttributeValue, out var _);
        }

        public override string ValueParsedForDataType(string customAttributeValue)
        {
            if (string.IsNullOrWhiteSpace(customAttributeValue))
            {
                return customAttributeValue;
            }

            if (decimal.TryParse(customAttributeValue, out var n))
            {
                return n.ToString(CultureInfo.InvariantCulture);
            }

            throw new ArgumentOutOfRangeException($"Attribute value {customAttributeValue} does not appear to be a {this.GetType().Name} data type");
        }

        public override bool HasOptions() => false;
        public override bool HasMeasurementUnit() => true;
    }

    public partial class ProjectCustomAttributeDataTypeDateTime
    {
        public override bool ValueIsCorrectDataType(string customAttributeValue) => System.DateTime.TryParse(customAttributeValue, out var _);

        public override string ValueParsedForDataType(string customAttributeValue)
        {
            if (string.IsNullOrWhiteSpace(customAttributeValue))
            {
                return customAttributeValue;
            }

            if (System.DateTime.TryParse(customAttributeValue, out var dateTime))
            {
                return dateTime.ToString(CultureInfo.InvariantCulture);
            }

            throw new ArgumentOutOfRangeException($"Attribute value {customAttributeValue} does not appear to be a {this.GetType().Name} data type");
        }

        public override bool HasOptions() => false;
        public override bool HasMeasurementUnit() => false;
    }

    public partial class ProjectCustomAttributeDataTypePickFromList
    {
        public override bool ValueIsCorrectDataType(string customAttributeValue) => true;
        public override string ValueParsedForDataType(string customAttributeValue) => customAttributeValue;
        public override bool HasOptions() => true;
        public override bool HasMeasurementUnit() => false;
    }

    public partial class ProjectCustomAttributeDataTypeMultiSelect
    {
        public override bool ValueIsCorrectDataType(string customAttributeValue) => true;
        public override string ValueParsedForDataType(string customAttributeValue) => customAttributeValue;
        public override bool HasOptions() => true;
        public override bool HasMeasurementUnit() => false;
    }

    public partial class ProjectCustomAttributeDataTypeBoolean
    {
        public override bool ValueIsCorrectDataType(string customAttributeValue) => System.Boolean.TryParse(customAttributeValue, out var _);

        public override string ValueParsedForDataType(string customAttributeValue)
        {
            if (bool.TryParse(customAttributeValue, out var n))
            {
                return n.ToString(CultureInfo.InvariantCulture);
            }

            throw new ArgumentOutOfRangeException($"Attribute value {customAttributeValue} does not appear to be a {this.GetType().Name} data type");
        }

        public override bool HasOptions() => false;
        public override bool HasMeasurementUnit() => false;
    }


}
