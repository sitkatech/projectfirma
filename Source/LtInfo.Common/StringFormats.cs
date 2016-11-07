using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using LtInfo.Common.Views;

namespace LtInfo.Common
{
    public static class StringFormats
    {
        public delegate bool TryParseDelegate<T>(string str, out T value);

        public static T? TryParseOrNull<T>(TryParseDelegate<T> parse, string str) where T : struct
        {
            T value;
            return parse(str, out value) ? value : (T?)null;
        }

        public static string AddAnchorTagsToTextForSimpleUrls(this string textToUse)
        {
            return AddAnchorTagsToTextForSimpleUrlsWithExternalStyle(textToUse, null);
        }

        public static string AddAnchorTagsToTextForSimpleUrlsWithExternalStyle(this string textToUse, string externalLinkClassName)
        {
            var output = textToUse;
            if (!String.IsNullOrWhiteSpace(textToUse))
            {
                textToUse = textToUse.Replace("&gt;", " GREATERTHANTOKEN").Replace("&lt;", " LESSTHANTOKEN");
                var regex = new Regex(@"((http(s)?://)|(ftp://)|(www))([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&amp;\*_\-\=\+\\\/\?\.\:\;\'\,]*)?");
                var matches = regex.Matches(textToUse).Cast<Match>().OrderBy(c => c.Index);

                if (matches.Any())
                {
                    output = String.Empty;

                    var currIndex = 0;
                    foreach (var match in matches)
                    {
                        var valueWithProtocolPrefix = match.Value;
                        if (!valueWithProtocolPrefix.ToLower().StartsWith("http://") && !valueWithProtocolPrefix.ToLower().StartsWith("https://") && !valueWithProtocolPrefix.ToLower().StartsWith("ftp://"))
                        {
                            valueWithProtocolPrefix = "http://" + valueWithProtocolPrefix;
                        }
                        if (valueWithProtocolPrefix.EndsWith("."))
                        {
                            valueWithProtocolPrefix = valueWithProtocolPrefix.Substring(0, valueWithProtocolPrefix.Length - 1);
                        }
                        string newValue;
                        if (externalLinkClassName != null)
                        {
                            newValue = String.Format("<a {2} href=\"{0}\" target=\"_blank\">{1}</a>"
                                , valueWithProtocolPrefix
                                , match.Value
                                , (valueWithProtocolPrefix.Contains(SitkaWebConfiguration.CanonicalHostName)) ? String.Empty : "class=\"" + externalLinkClassName + "\""
                                );
                        }
                        else
                        {
                            newValue = String.Format("<a href=\"{0}\" target=\"_blank\">{1}</a>", valueWithProtocolPrefix, match.Value);
                        }
                        output += textToUse.Substring(currIndex, match.Index - currIndex) + newValue;
                        currIndex = match.Index + match.Length;
                    }

                    output += textToUse.Substring(currIndex);
                }

                output = output.Replace(" GREATERTHANTOKEN", "&gt;").Replace(" LESSTHANTOKEN", "&lt;");
            }
            return output;
        }

        public static string Left(this string thisString, int length)
        {
            if (String.IsNullOrWhiteSpace(thisString))
                return String.Empty;

            if (thisString.Length < length)
                return thisString;
            
            return thisString.Substring(0, length);
        }

        public static string ToStringPercent(this decimal? value)
        {
            return value.HasValue ? value.Value.ToStringPercent() : "";
        }
        public static string ToStringPercent(this decimal value)
        {
            return value.ToString("0.00%");
        }
        public static string ToPercentWithNoSymbolOrBlank(this decimal? d)
        {
            return d.HasValue ? (d.Value * 100).ToString("0.00") : "";
        }

        public static string ToDecimalString(this decimal? d)
        {
            return d.HasValue ? d.Value.ToString("0.00") : "";
        }

        public static string ToDecimalString(this decimal? d, bool isRounded)
        {
            return d.HasValue ?  (isRounded) ? d.Value.ToString("0.00") : d.Value.ToString(CultureInfo.InvariantCulture) : "";
        }
        
        public static string ToIntString(this decimal? d)
        {
            return d.HasValue ? d.Value.ToString("0") : "";
        }

        public static string ToGroupedNumeric(this byte value)
        {
            return value.ToString("#,###,###,##0");
        }

        public static string ToGroupedNumeric(this byte? value)
        {
            if (value.HasValue)
            {
                return ToGroupedNumeric(value.Value);
            }

            return String.Empty;
        }

        public static string ToGroupedNumeric(this int value)
        {
            return value.ToString("#,###,###,##0");
        }

        public static string ToGroupedNumeric(this int? value)
        {
            if (value.HasValue)
            {
                return ToGroupedNumeric(value.Value);
            }

            return String.Empty;
        }

        public static string ToGroupedNumeric(this decimal? value)
        {
            if (value.HasValue)
            {
                return ToGroupedNumeric(value.Value);
            }

            return String.Empty;
        }

        public static string ToGroupedNumeric(this decimal value)
        {
            return value.ToString("#,###,###,###,###,###,##0.###");
        }

        public static string ToGroupedNumeric(this double value)
        {
            return value.ToString("#,###,###,##0.###");
        }

        public static string ToGroupedNumeric(this double? value)
        {
            if (value.HasValue)
            {
                return ToGroupedNumeric(value.Value);
            }

            return String.Empty;
        }

        public static string ToStringShortPercent(this int value)
        {
            return value.ToString("0%");
        }

        public static string ToStringShortPercent(this decimal value)
        {
            return value.ToString("0%");
        }

        public static string ToNotProvidedIfNull(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Format("<span class='systemText'>{0} {1}</span>", value.ToProperCase(), ViewUtilities.NotProvidedString);
            }
            return value;
        }

        public static string ToStringCurrencyFull(this decimal value)
        {
            return value.ToString("$#,##0.00");
        }
        public static string ToStringCurrencyFull(this decimal? value)
        {
            return value.HasValue ? value.Value.ToStringCurrencyFull() : String.Empty;
        }
        public static string ToStringCurrency(this decimal? value)
        {
            return value.HasValue ? value.Value.ToStringCurrency() : String.Empty;
        }
        public static string ToStringCurrency(this int? value)
        {
            return value.HasValue ? value.Value.ToStringCurrency() : String.Empty;
        }
        public static string ToStringCurrency(this double? value)
        {
            return value.HasValue ? value.Value.ToStringCurrency() : String.Empty;
        }
        public static string ToStringCurrency(this double value)
        {
            return value.ToString("c0");
        }
        public static string ToStringCurrency(this decimal value)
        {
            return value.ToString("c0");
        }
        public static string ToStringCurrency(this int value)
        {
            return value.ToString("c0");
        }
        public static decimal? ParseNullableDecimalFromCurrencyString(string currencyString)
        {
            if (String.IsNullOrEmpty(currencyString))
            {
                return null;
            }
            decimal currencyValue;
            if (!Decimal.TryParse(currencyString, NumberStyles.Currency, CultureInfo.CurrentCulture, out currencyValue))
            {
                throw new ApplicationException(String.Format("Could not parse currency value \"{0}\"", currencyString));
            }
            return currencyValue;
        }
        public static string ToStringCdataEnclosed(this string value)
        {
            return String.Format(@"<![CDATA[{0}]]>", value);
        }
        public static string ToStringForRss(this DateTime value)
        {
            var ts = TimeZone.CurrentTimeZone.GetUtcOffset(value);
            return value.Subtract(ts).ToString("ddd, dd MMM yyyy HH':'mm':'ss 'GMT'").ToStringCdataEnclosed();
        }
        public static string ToStringCurrencyEdit(this decimal value)
        {
            return value.ToString("f00");
        }
        public static string ToStringDate(this DateTime dateTime, bool twoDigitYear)
        {
            return ToStringDate((DateTime?)dateTime, twoDigitYear);
        }

        public static string ToStringDate(this DateTime dateTime)
        {
            return dateTime.ToString("MM/dd/yyyy");
        }
        public static string ToStringDate(this DateTime? dateTime)
        {
            return ToStringDate(dateTime, false);
        }

        public static string ToStringDate(this DateTime? dateTime, bool twoDigitYear)
        {
            var formatString = twoDigitYear ? "MM/dd/yy" : "MM/dd/yyyy";
            return (dateTime.HasValue) ? dateTime.Value.ToString(formatString) : String.Empty;
        }

        public static string ToStringDateMonthYear(this DateTime dateTime)
        {
            return dateTime.ToString("M/yyyy");
        }
        public static string ToStringDateMonthYear(this DateTime? dateTime)
        {
            return (dateTime.HasValue) ? dateTime.Value.ToStringDateMonthYear() : String.Empty;
        }

        public static string ToStringDateYearMonthDay(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }
        public static string ToStringDateYearMonthDay(this DateTime? dateTime)
        {
            return (dateTime.HasValue) ? dateTime.Value.ToStringDateYearMonthDay() : String.Empty;
        }
        public static string ToStringTime(this DateTime? dateTime)
        {
            return (dateTime.HasValue) ? dateTime.Value.ToString("hh:mm tt") : String.Empty;
        }
        public static string ToStringTime(this DateTime dateTime)
        {
            return dateTime.ToString("hh:mm tt");
        }
        public static string ToStringDateTime(this DateTime dateTime)
        {
            return ((DateTime?)dateTime).ToStringDateTime();
        }
        public static string ToStringDateTime(this DateTime? dateTime)
        {
            return (dateTime.HasValue) ? dateTime.Value.ToString("MM/dd/yyyy h:mm tt") : String.Empty;
        }
        public static string ToStringDateTimeNoLeadingZeros(this DateTime dateTime)
        {
            return ((DateTime?)dateTime).ToStringDateTimeNoLeadingZeros();
        }
        public static string ToStringDateTimeNoLeadingZeros(this DateTime? dateTime)
        {
            return (dateTime.HasValue) ? dateTime.Value.ToString("M/d/yyyy h:mm tt") : String.Empty;
        }
        public static string ToStringDateTimeFull(this DateTime dateTime)
        {
            return ((DateTime?)dateTime).ToStringDateTimeFull();
        }
        public static string ToStringDateTimeFull(this DateTime? dateTime)
        {
            // note - this is set to allow maximum precision, there are no more fractions available
            return (dateTime.HasValue) ? dateTime.Value.ToString("MM/dd/yyyy HH:mm:ss.fffffff") : String.Empty;
        }

        public static bool TryParsePhoneNumber(string input, out string phoneNumber)
        {
            const int strippedPhoneLength = 10;
            phoneNumber = null;

            if (GeneralUtility.IsNullOrEmptyOrOnlyWhitespace(input))
                return false;

            var strippedPhone = CleanPhoneNumber(input);
            if (strippedPhone.Length != strippedPhoneLength)
                return false;

            phoneNumber = strippedPhone.ToPhoneNumberString();

            return true;
        }

        public static string ToPhoneNumberString(this string phoneNumber)
        {
            if (!String.IsNullOrWhiteSpace(phoneNumber))
            {
                var strippedPhone = CleanPhoneNumber(phoneNumber);
                if (strippedPhone.Length == 10)
                    return String.Format("({0}) {1}-{2}", strippedPhone.Substring(0, 3), strippedPhone.Substring(3, 3),
                                     strippedPhone.Substring(6, 4));

                if (strippedPhone.Length == 7)
                    return String.Format("{0}-{1}", strippedPhone.Substring(0, 3), strippedPhone.Substring(3, 4));
            }
            return null;
        }

        public static string ToEllipsifiedString(this string fullString, int maxLength)
        {
            if (String.IsNullOrEmpty(fullString) || fullString.Length <= maxLength)
                return fullString;

            return fullString.Substring(0, maxLength) + "...";
        }

        public static string ToEllipsifiedStringClean(this string fullString, int maxLength)
        {
            return ToEllipsifiedStringClean(fullString, maxLength, "...");
        } 
        
        public static string ToEllipsifiedStringClean(this string fullString, int maxLength, string postfix)
        {
            if (String.IsNullOrWhiteSpace(fullString) || (fullString.Length <= maxLength))
                return fullString;

            string maxString = fullString.Trim().Substring(0, maxLength);
            int lastIndexOfSpace = maxString.LastIndexOf(' ');

            if (lastIndexOfSpace == -1)
                return maxString + postfix;

            return maxString.Substring(0, lastIndexOfSpace ) + postfix;
        }

        private static string CleanPhoneNumber(string input)
        {
            return !String.IsNullOrEmpty(input) ? new Regex("[^0-9]").Replace(input, String.Empty) : String.Empty;
        }

        public static HtmlString ToHTMLFormattedString(this string text)
        {

            if (String.IsNullOrWhiteSpace(text))
            {
                return new HtmlString(String.Empty);
            }

            var result = text;
            result = result.Replace("\r\n", "\n").Replace("\n", "<br/>");

            return new HtmlString(result);
        }

        /// <summary>
        /// This will only do the first letter of the whole string to upper case and lower case everything else
        /// "HEllO WORLD" -> "Hello world"
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToUpperFirstLetter(this string text)
        {
            return String.Format("{0}{1}", Char.ToUpper(text[0]), ((text.Length > 1) ? text.Substring(1).ToLower() : String.Empty));
        }

        /// <summary>
        /// This will capitalize the first letter of every word in string
        /// "HEllO WORLD" -> "Hello World"
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        /// <summary>
        /// Formats a number representing storage space in bytes using the SI prefixes: B, KB, MB, GB, TB, PB, EB and the base 2 1024 counting style
        /// </summary>
        public static string ToHumanReadableByteSize(long sizeInBytes)
        {
            var byteSizePrefixes = new []{ "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            var order = 0;
            double size = sizeInBytes;
            while (size >= 1024 && order + 1 < byteSizePrefixes.Length)
            {
                order++;
                size = size / 1024;
            }
            var result = String.Format("{0:0.##} {1}", size, byteSizePrefixes[order]);
            return result;
        }

        // Capitalize the first character and add a space before
        // each capitalized letter (except the first character).
        public static string ToProperCase(this string text)
        {
            // If there are 0 or 1 characters, just return the string.
            if (text == null) return null;
            if (text.Length < 2) return text.ToUpper();

            // Start with the first character.
            var result = text.Substring(0, 1).ToUpper();

            // Add the remaining characters.
            for (var i = 1; i < text.Length; ++i)
            {
                if (Char.IsUpper(text[i]))
                {
                    result += " ";
                }
                result += text[i];
            }

            return result;
        }

        // Convert the string to camel case. e.g. thisIsATestString
        public static string ToCamelCase(this string text)
        {
            // If there are 0 or 1 characters, just return the string.
            if (text == null || text.Length < 2)
                return text;

            // Split the string into words.
            var words = text.Split(
                new char[] { },
                StringSplitOptions.RemoveEmptyEntries);

            // Combine the words.
            var result = words[0].ToLower();
            for (var i = 1; i < words.Length; ++i)
            {
                result += String.Format("{0}{1}", words[i].Substring(0, 1).ToUpper(), words[i].Substring(1));
            }

            return result;
        }

        // Convert the string to Pascal case. e.g. ThisIsATestString
        public static string ToPascalCase(this string text)
        {
            // If there are 0 or 1 characters, just return the string.
            if (text == null) return null;
            if (text.Length < 2) return text.ToUpper();

            // Split the string into words.
            var words = text.Split(
                new char[] { },
                StringSplitOptions.RemoveEmptyEntries);

            // Combine the words.
            return words.Aggregate("", (current, word) => current + String.Format("{0}{1}", word.Substring(0, 1).ToUpper(), word.Substring(1)));
        }

        public static readonly Regex ContainAbsoluteUrlWithApplicationDomainReferenceRegEx = new Regex(ConstructContainAbsoluteUrlWithApplicationDomainReferenceRegExForApplicationDomain(SitkaWebConfiguration.ApplicationDomain), RegexOptions.IgnoreCase | RegexOptions.Multiline);

        /// <summary>
        /// Does a given HTML string contain a non-server root relative URL pointing to the application domain? 
        /// (This is bad & undesirable, by the way.)
        /// </summary>
        /// <param name="htmlString"></param>
        /// <returns></returns>
        public static bool DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(this string htmlString)
        {
            return htmlString.DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(ContainAbsoluteUrlWithApplicationDomainReferenceRegEx);
        }

        public static HtmlString MakeAbsoluteLinksToApplicationDomainRelative(this HtmlString htmlString)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (htmlString == null || htmlString.ToString() == null)
            {
                // ReSharper disable once ExpressionIsAlwaysNull
                return htmlString;
            }
            return new HtmlString(ContainAbsoluteUrlWithApplicationDomainReferenceRegEx.Replace(htmlString.ToString(), string.Empty));
        }

        public static string ConstructContainAbsoluteUrlWithApplicationDomainReferenceRegExForApplicationDomain(string applicationDomain)
        {
            return string.Format(@"http(s?)\:\/\/[0-9a-zA-Z]*((\.?){0})", applicationDomain.Replace(@".", @"\."));
        }

        /// <summary>
        /// Only public for unit testing
        /// </summary>
        public static bool DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(this string htmlString, Regex containAbsoluteUrlWithApplicationDomainReferenceRegEx)
        {
            return htmlString != null && containAbsoluteUrlWithApplicationDomainReferenceRegEx.IsMatch(htmlString);
        }
    }
}