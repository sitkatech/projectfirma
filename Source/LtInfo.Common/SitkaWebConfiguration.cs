/*-----------------------------------------------------------------------
<copyright file="SitkaWebConfiguration.cs" company="Sitka Technology Group">
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
using System.Collections.Generic;
using System.Reflection;

namespace LtInfo.Common
{
    public class SitkaWebConfiguration
    {
        public static readonly string ApplicationDomain = SitkaConfiguration.GetRequiredAppSettingNotNullNotEmptyNotWhitespace("ApplicationDomain");
        public static readonly string WebApplicationRootPath = String.IsNullOrWhiteSpace(SitkaConfiguration.GetOptionalAppSetting("WebApplicationRootPath")) ? String.Empty : SitkaConfiguration.GetOptionalAppSetting("WebApplicationRootPath");
        public static readonly bool UseMvcExtensionInUrl = Boolean.Parse(SitkaConfiguration.GetRequiredAppSetting("UseMvcExtensionInUrl"));
        public static string SitkaEmailRedirect = SitkaConfiguration.GetRequiredAppSetting("SitkaEmailRedirect");
        public static readonly bool IsEmailEnabled = Boolean.Parse(SitkaConfiguration.GetRequiredAppSetting("IsEmailEnabled"));
        public static readonly string MailLogBcc = SitkaConfiguration.GetRequiredAppSetting("MailLogBcc");

        public static readonly TimeSpan CacheStaticContentTimeSpan = TimeSpan.Parse(SitkaConfiguration.GetRequiredAppSetting("CacheStaticContentTimeSpan"));

        public static readonly Lazy<LtInfoVersionInfo> WebApplicationVersionInfo = new Lazy<LtInfoVersionInfo>(() => new LtInfoVersionInfo(Assembly.GetCallingAssembly()));

        public static readonly int? DebugInfoMaxLength = SitkaConfiguration.GetOptionalIntAppSetting("ErrorDebugInfoMaxLength");

        public static List<string> DefaultModalDialogButtonCssClasses
        {
            get
            {
                return new List<string>(SitkaConfiguration.GetRequiredAppSettingList("DefaultModalDialogButtonCssClasses"));
            }
        }
    }
}
