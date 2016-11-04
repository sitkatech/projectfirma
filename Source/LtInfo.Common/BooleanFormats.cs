using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using LtInfo.Common.BootstrapWrappers;

namespace LtInfo.Common
{
    public static class BooleanFormats
    {
        public static string ToYesNo(this bool? value, string nullString)
        {
            return value.HasValue ? ToYesNo(value) : nullString;
        }

        public static string ToYesNo(this bool? value)
        {
            return ToYesNo(value ?? false);
        }

        public static string ToYesNo(this bool value)
        {
            return (value) ? "Yes" : "No";
        }

        public static bool FromYesNoStringToBool(this string value)
        {
            switch (value.ToLower())
            {
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    throw new ArgumentOutOfRangeException(String.Format("Invalid boolean string of {0}", value));
            }
        }

        public static IEnumerable<SelectListItem> GetYesNoSelectList()
        {
            return new[]
                {
                    new SelectListItem {Text = "Choose one", Value = string.Empty},
                    new SelectListItem {Text = "No", Value = false.ToString()},
                    new SelectListItem {Text = "Yes", Value = true.ToString()}
                };
        }

        public static bool FromCheckedStringToBool(this string value)
        {
            switch (value.ToLower())
            {
                case "checked":
                    return true;
                case null:
                case "":
                    return false;
                default:
                    throw new ArgumentOutOfRangeException(String.Format("Invalid boolean string of {0}", value));
            }
        }

        public static string ToRequiredOptional(this bool? value)
        {
            return ToRequiredOptional(value ?? false);
        }

        public static string ToRequiredOptional(this bool value)
        {
            return (value) ? "Required" : "Optional";
        }

        public static string ToChangedNoChanges(this bool? value)
        {
            return ToChangedNoChanges(value ?? false);
        }

        public static string ToChangedNoChanges(this bool value)
        {
            return (value) ? "Changed" : "No Changes";
        }

        public static string ToActiveExpired(this bool? value)
        {
            return ToActiveExpired(value ?? false);
        }

        public static string ToActiveExpired(this bool value)
        {
            return (value) ? "Active" : "Expired";
        }

        public static string ToDisplayNoneOrEmpty(this bool? value)
        {
            return ToDisplayNoneOrEmpty(value ?? false);
        }

        public static string ToDisplayNoneOrEmpty(this bool value)
        {
            return (value) ? " style=\"display:none\" " : String.Empty;
        }

        public static string ToCheckedOrEmpty(this bool? value)
        {
            return ToCheckedOrEmpty(value ?? false);
        }

        public static string ToCheckedOrEmpty(this bool value)
        {
            return (value) ? " checked=\"checked\" " : String.Empty;
        }

        public static string ToSelectedOrEmpty(this bool? value)
        {
            return ToSelectedOrEmpty(value ?? false);
        }

        public static string ToSelectedOrEmpty(this bool value)
        {
            return (value) ? " selected=\"selected\" " : String.Empty;
        }

        public static string ToDisabledOrEmpty(this bool? value)
        {
            return ToDisabledOrEmpty(value ?? false);
        }

        public static string ToDisabledOrEmpty(this bool value)
        {
            return (value) ? " disabled=\"disabled\" " : String.Empty;
        }

        public static HtmlString ToCheckboxImageOrEmpty(this bool value)
        {
            return new HtmlString(value ? String.Format(" {0} ", BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-ok-circle", "Yes")) : String.Empty);
        }

        public static HtmlString ToCheckboxImageOrEmpty(this bool? value)
        {
            return ToCheckboxImageOrEmpty(value ?? false);
        }
    }
}
