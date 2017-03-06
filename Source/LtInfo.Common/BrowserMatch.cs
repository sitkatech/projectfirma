/*-----------------------------------------------------------------------
<copyright file="BrowserMatch.cs" company="Sitka Technology Group">
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
