/*-----------------------------------------------------------------------
<copyright file="SitkaConfiguration.cs" company="Sitka Technology Group">
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
using System.Configuration;
using System.Linq;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    public class SitkaConfiguration
    {
        /// <summary>
        /// Normal app setting lookup
        /// </summary>
        public static string GetRequiredAppSetting(string appSettingKeyName)
        {
            var appSettingValue = GetOptionalAppSetting(appSettingKeyName);
            
            const string exceptionMessage = "Could not find the required appSetting {0} in the configuration file.";
            Check.RequireNotNull(appSettingValue, String.Format(exceptionMessage, appSettingKeyName));

            return appSettingValue;
        }
        /// <summary>
        /// Normal app setting lookup
        /// </summary>
        public static string GetRequiredAppSettingNotNullNotEmptyNotWhitespace(string appSettingKeyName)
        {
            var appSettingValue = GetRequiredAppSetting(appSettingKeyName);
            Check.RequireNotNullNotEmptyNotWhitespace(appSettingValue, "Found required appSetting {0} in the configuration file, but the value was empty or only whitespace.");
            return appSettingValue;
        }

        /// <summary>
        /// Splits a single config setting value into multiple strings.
        /// </summary>
        public static List<string> GetRequiredAppSettingList(string appSettingKeyName, string delimiter = ",")
        {
            var settingValue = GetRequiredAppSetting(appSettingKeyName);
            var result = settingValue.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            return result;
        }

        public static string GetOptionalAppSetting(string appSettingKeyName)
        {
            return ConfigurationManager.AppSettings.Get(appSettingKeyName);
        }

        public static int? GetOptionalIntAppSetting(string appSettingKeyName)
        {
            var val = ConfigurationManager.AppSettings.Get(appSettingKeyName);
            return val != null ? (int?) int.Parse(val) : null;
        }
    }
}
