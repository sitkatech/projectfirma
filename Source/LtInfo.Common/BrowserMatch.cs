using System.Text.RegularExpressions;
using System.Web;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    public class BrowserMatch
    {
        public static BrowserMatch InternetExplorerAnyVersion = new BrowserMatch("IE");
        public static BrowserMatch InternetExplorer7 = new BrowserMatch("IE", 7);
        public static BrowserMatch InternetExplorer8 = new BrowserMatch("IE", 8);
        public static BrowserMatch InternetExplorer9 = new BrowserMatch("IE", 9);
        public static BrowserMatch Firefox3 = new BrowserMatch("Firefox", 3);

        /// <summary>
        /// "Safari 3.0" Safari comes up as Version 4
        /// </summary>
        public static BrowserMatch Safari3 = new BrowserMatch("Safari", 4);

        private readonly string _browserRegexPattern;
        private readonly int? _minimumMajorVersion;

        public BrowserMatch(string browserRegexPattern)
        {
            _browserRegexPattern = browserRegexPattern;
            _minimumMajorVersion = null;
        }

        public BrowserMatch(string browserRegexPattern, int minimumMajorVersion)
        {
            _browserRegexPattern = browserRegexPattern;
            _minimumMajorVersion = minimumMajorVersion;
        }

        public bool IsMatchOnBrowserType(HttpBrowserCapabilities browserCapabilities)
        {
            return Regex.IsMatch(browserCapabilities.Browser, _browserRegexPattern, RegexOptions.IgnoreCase);
        }

        public bool IsMatchOnBrowserTypeAndVersion(HttpBrowserCapabilities browserCapabilities)
        {
            return IsMatchOnBrowserType(browserCapabilities) && browserCapabilities.MajorVersion == _minimumMajorVersion;
        }

        public bool IsAtLeastVersion(HttpBrowserCapabilities browserCapabilities)
        {
            var requestBrowserMajorVersion = browserCapabilities.MajorVersion;
            Check.RequireNotNull(_minimumMajorVersion, "You need to have requested a particular version to call this");
// ReSharper disable PossibleInvalidOperationException
            var isMatchOnVersion = requestBrowserMajorVersion >= _minimumMajorVersion.Value;
// ReSharper restore PossibleInvalidOperationException
            return isMatchOnVersion;
        }

    }
}