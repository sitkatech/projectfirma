using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

namespace LtInfo.Common.ExcelWorkbookUtilities
{
    /// <summary>
    /// A few parts in the ExcelWorkbookUtilities namespace used portions of code from the SimpleOOXML library: https://www.nuget.org/packages/SimpleOOXML/
    ///
    /// This library had a dependency on an older version of DocumentFormat.OpenXml that we do not want to support. The parts from the SimpleOOXML library that we used have been
    /// added to this project directly. This is all related to work done on PF #2056, #2058, and #2061.
    /// </summary>
    public static class OpenXmlExtensionMethods
    {
        public static T CloneElement<T>(this OpenXmlElement value) where T : OpenXmlElement
        {
            return value.CloneNode(true) as T;
        }

        public static bool Compare(this BooleanPropertyType thisValue, BooleanPropertyType value)
        {
            if (ExclusiveNull(thisValue, value)) return false;
            return true;
        }

        public static bool Compare(this BooleanValue thisValue, BooleanValue value)
        {
            if (ExclusiveNull(thisValue, value)) return false;
            if (AreNull(thisValue, value)) return true;

            if (AreNullValue(thisValue, value)) return true;
            if (ExclusiveHasValue(thisValue, value)) return false;

            return thisValue.Value.Equals(value.Value);
        }

        public static bool Compare(this StringValue thisValue, StringValue value)
        {
            if (ExclusiveNull(thisValue, value)) return false;
            if (AreNullValue(thisValue, value)) return true;

            return thisValue.Value.Equals(value.Value);
        }

        public static bool Compare<T>(this EnumValue<T> thisValue, EnumValue<T> value) where T : struct
        {
            if (ExclusiveNull(thisValue, value)) return false;
            if (AreNull(thisValue, value)) return true;

            if (AreNullValue<T>(thisValue, value)) return true;
            if (ExclusiveHasValue<T>(thisValue, value)) return false;

            //Now comapre the actual values
            return thisValue.Value.Equals(value.Value);
        }

        public static bool Compare(this ColorType thisValue, ColorType color)
        {
            if (ExclusiveNull(thisValue, color)) return false;
            if (AreNull(thisValue, color)) return true;

            if (ExclusiveNull(thisValue.Rgb, color.Rgb) || ExclusiveNull(thisValue.Theme, color.Theme)) return false;
            if (ExclusiveHasValue(thisValue.Rgb, color.Rgb) || ExclusiveHasValue(thisValue.Theme, color.Theme)) return false;

            if (!AreNullValue(thisValue.Rgb, color.Rgb)) return thisValue.Rgb.Value == color.Rgb.Value;
            if (!AreNullValue(thisValue.Theme, color.Theme)) return thisValue.Theme.Value == color.Theme.Value;

            return true;
            //both null value
        }

        public static bool Compare(this FontSize thisValue, FontSize fontSize)
        {
            if (ExclusiveNull(thisValue, fontSize)) return false;
            if (AreNull(thisValue, fontSize)) return true;

            if (ExclusiveHasValue(thisValue.Val, fontSize.Val)) return false;
            if (AreNullValue(thisValue.Val, fontSize.Val)) return true;

            return thisValue.Val.Value == fontSize.Val.Value;
        }

        public static bool Compare(this FontName thisValue, FontName fontName)
        {
            if (ExclusiveNull(thisValue, fontName)) return false;
            if (AreNull(thisValue, fontName)) return true;

            if (ExclusiveHasValue(thisValue.Val, fontName.Val)) return false;
            if (AreNullValue(thisValue.Val, fontName.Val)) return true;

            return thisValue.Val.Value == fontName.Val.Value;
        }

        public static bool Compare(this FontFamily thisValue, FontFamily fontFamily)
        {
            if (ExclusiveNull(thisValue, fontFamily)) return false;
            if (AreNull(thisValue, fontFamily)) return true;

            if (ExclusiveHasValue(thisValue.Val, fontFamily.Val)) return false;
            if (AreNullValue(thisValue.Val, fontFamily.Val)) return true;

            return thisValue.Val.Value == fontFamily.Val.Value;
        }

        public static bool Compare(this FontScheme thisValue, FontScheme fontScheme)
        {
            if (ExclusiveNull(thisValue, fontScheme)) return false;
            if (AreNull(thisValue, fontScheme)) return true;

            if (ExclusiveHasValue(thisValue.Val, fontScheme.Val)) return false;
            if (AreNullValue(thisValue.Val, fontScheme.Val)) return true;

            return thisValue.Val.Value == fontScheme.Val.Value;
        }

        public static bool Compare(this Underline thisValue, Underline underline)
        {
            if (ExclusiveNull(thisValue, underline)) return false;
            if (AreNull(thisValue, underline)) return true;

            if (ExclusiveHasValue(thisValue.Val, underline.Val)) return false;
            if (AreNullValue(thisValue.Val, underline.Val)) return true;

            return thisValue.Val.Value == underline.Val.Value;
        }

        public static bool Compare(this BorderPropertiesType thisValue, BorderPropertiesType border)
        {
            if (!Compare(thisValue.Style, border.Style)) return false;
            if (!Compare(thisValue.Color, border.Color)) return false;

            return true;
            //both null value
        }

        //Helper functions
        private static bool ExclusiveNull(object x, object y)
        {
            return (x == null && y != null) || (x != null && y == null);
        }

        private static bool ExclusiveHasValue<T>(OpenXmlSimpleValue<T> x, OpenXmlSimpleValue<T> y) where T : struct
        {
            if ((AreNull(x, y))) return false;
            return (x.HasValue && !y.HasValue) || (!x.HasValue && y.HasValue);
        }

        private static bool ExclusiveHasValue<T>(EnumValue<T> x, EnumValue<T> y) where T : struct
        {
            if ((AreNull(x, y))) return false;
            return (x.HasValue && !y.HasValue) || (!x.HasValue && y.HasValue);
        }

        private static bool ExclusiveHasValue(OpenXmlSimpleType x, OpenXmlSimpleType y)
        {
            if ((AreNull(x, y))) return false;
            return (x.HasValue && !y.HasValue) || (!x.HasValue && y.HasValue);
        }

        private static bool AreNull(object x, object y)
        {
            return x == null && y == null;
        }

        private static bool AreNullValue<T>(OpenXmlSimpleValue<T> x, OpenXmlSimpleValue<T> y) where T : struct
        {
            if (x == null || y == null) return true;
            return !x.HasValue && !y.HasValue;
        }

        private static bool AreNullValue<T>(EnumValue<T> x, EnumValue<T> y) where T : struct
        {
            if (x == null || y == null) return true;
            return !x.HasValue && !y.HasValue;
        }

        private static bool AreNullValue(OpenXmlSimpleType x, OpenXmlSimpleType y)
        {
            if (x == null || y == null) return true;
            return !x.HasValue && !y.HasValue;
        }
    }
}
