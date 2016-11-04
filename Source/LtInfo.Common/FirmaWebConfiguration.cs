using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LtInfo.Common
{
    public class FirmaWebConfiguration
    {
        public static readonly string ApplicationDomain = SitkaConfiguration.GetRequiredAppSettingNotNullNotEmptyNotWhitespace("ApplicationDomain");
        public static readonly string WebApplicationRootPath = String.IsNullOrWhiteSpace(SitkaConfiguration.GetOptionalAppSetting("WebApplicationRootPath")) ? String.Empty : SitkaConfiguration.GetOptionalAppSetting("WebApplicationRootPath");
        public static readonly bool UseMvcExtensionInUrl = Boolean.Parse(SitkaConfiguration.GetRequiredAppSetting("UseMvcExtensionInUrl"));
        public static string SitkaEmailRedirect = SitkaConfiguration.GetRequiredAppSetting("SitkaEmailRedirect");
        public static readonly bool IsEmailEnabled = Boolean.Parse(SitkaConfiguration.GetRequiredAppSetting("IsEmailEnabled"));
        public static readonly string MailLogBcc = SitkaConfiguration.GetRequiredAppSetting("MailLogBcc");

        public static readonly TimeSpan CacheStaticContentTimeSpan = TimeSpan.Parse(SitkaConfiguration.GetRequiredAppSetting("CacheStaticContentTimeSpan"));

        public static readonly Lazy<LtInfoVersionInfo> WebApplicationVersionInfo = new Lazy<LtInfoVersionInfo>(() => new LtInfoVersionInfo(Assembly.GetCallingAssembly()));

        public static readonly List<Uri> SitkaReverseProxyWhitelist = SitkaReverseProxy.LoadWhiteList();
        public static readonly int? DebugInfoMaxLength = SitkaConfiguration.GetOptionalIntAppSetting("ErrorDebugInfoMaxLength");

        public static List<string> CanonicalHostNames
        {
            get
            {
                return new List<string>(SitkaConfiguration.GetRequiredAppSettingList("CanonicalHostName"));
            }
        }

        public static List<string> DefaultModalDialogButtonCssClasses
        {
            get
            {
                return new List<string>(SitkaConfiguration.GetRequiredAppSettingList("DefaultModalDialogButtonCssClasses"));
            }
        }

        public static readonly string CanonicalHostName = CanonicalHostNames.FirstOrDefault();

        public static string GetCanonicalHost(string hostName, bool useApproximateMatch)
        {
            //First search for perfect match
            var result = CanonicalHostNames.FirstOrDefault(h => string.Equals(h, hostName, StringComparison.InvariantCultureIgnoreCase));

            if (!string.IsNullOrWhiteSpace(result) || !useApproximateMatch)
            {
                return result;
            }

            //Use the domain name  (laketahoeinfo.org -->  should use www.laketahoeinfo.org for the match)
            return CanonicalHostNames.FirstOrDefault(h => h.EndsWith(hostName, StringComparison.InvariantCultureIgnoreCase)) ?? CanonicalHostName;
        }

    }
}
