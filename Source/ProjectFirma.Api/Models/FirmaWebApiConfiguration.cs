using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Api.Models
{
    public class FirmaWebApiConfiguration
    {
        public static readonly string PsInfoApiKey = SitkaConfiguration.GetRequiredAppSetting("PsInfoApiKey");

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
            return val != null ? (int?)int.Parse(val) : null;
        }
    }
}