using System;
using System.IO;
using System.Linq;
using System.Web.Configuration;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Common
{
    public class ProjectFirmaWebConfiguration : LtInfoWebConfiguration
    {
        public static readonly int MaximumAllowedUploadFileSize = Int32.Parse(SitkaConfiguration.GetRequiredAppSetting("MaximumAllowedUploadFileSize"));
        public static readonly string DatabaseConnectionString = SitkaConfiguration.GetRequiredAppSetting("DatabaseConnectionString");
        public static readonly string RecaptchaPublicKey = SitkaConfiguration.GetRequiredAppSettingNotNullNotEmptyNotWhitespace("RecaptchaPublicKey");
        public static readonly string RecaptchaPrivateKey = SitkaConfiguration.GetRequiredAppSettingNotNullNotEmptyNotWhitespace("RecaptchaPrivateKey");
        public static readonly string RecaptchaValidatorUrl = SitkaConfiguration.GetRequiredAppSettingNotNullNotEmptyNotWhitespace("RecaptchaValidatorUrl");
        public static readonly string SitkaSupportEmail = SitkaConfiguration.GetRequiredAppSettingNotNullNotEmptyNotWhitespace("SitkaSupportEmail");
        public static readonly string DoNotReplyEmail = SitkaConfiguration.GetRequiredAppSettingNotNullNotEmptyNotWhitespace("DoNotReplyEmail");
        public static readonly int Pre2007ProjectCount = Int32.Parse(SitkaConfiguration.GetRequiredAppSetting("Pre2007ProjectCount"));
        public static readonly Lazy<int> LatestDatabaseMigration = new Lazy<int>(() => HttpRequestStorage.DatabaseEntities.DatabaseMigrations.Max(x => x.DatabaseMigrationNumber));
        public static readonly string Ogr2OgrExecutable = SitkaConfiguration.GetRequiredAppSetting("Ogr2OgrExecutable");
        public static readonly string OgrInfoExecutable = SitkaConfiguration.GetRequiredAppSetting("OgrInfoExecutable");
        public static readonly int ReportingPeriodStartMonth = Int32.Parse(SitkaConfiguration.GetRequiredAppSetting("ReportingPeriodStartMonth"));
        public static readonly int ReportingPeriodStartDay = Int32.Parse(SitkaConfiguration.GetRequiredAppSetting("ReportingPeriodStartDay"));
        public static readonly int DefaultSupportPersonID = Int32.Parse(SitkaConfiguration.GetRequiredAppSetting("DefaultSupportPersonID"));
        public static readonly int AnnualReportingContactPersonID = Int32.Parse(SitkaConfiguration.GetRequiredAppSetting("AnnualReportingContactPersonID"));
        public static readonly int MinimumYearForReportingExpenditures = Int32.Parse(SitkaConfiguration.GetRequiredAppSetting("MinimumYearForReportingExpenditures"));

        public static readonly TimeSpan HttpRuntimeExecutionTimeout = ((HttpRuntimeSection)WebConfigurationManager.GetSection("system.web/httpRuntime")).ExecutionTimeout;
        public static readonly string CanonicalHostNameRoot = SitkaConfiguration.GetRequiredAppSetting("CanonicalHostNameRoot");
        public static readonly string CanonicalHostNameEIP = SitkaConfiguration.GetRequiredAppSetting("CanonicalHostNameEIP");
        public static readonly string CanonicalHostNameSustainability = SitkaConfiguration.GetRequiredAppSetting("CanonicalHostNameSustainability");
        public static readonly string CanonicalHostNameParcelTracker = SitkaConfiguration.GetRequiredAppSetting("CanonicalHostNameParcelTracker");
        public static readonly string CanonicalHostNameThresholds = SitkaConfiguration.GetRequiredAppSetting("CanonicalHostNameThresholds");
       
        public static readonly string AccelaAgency = SitkaConfiguration.GetRequiredAppSetting("AccelaAgency");
        public static readonly string AccelaUsername = SitkaConfiguration.GetRequiredAppSetting("AccelaUsername");
        public static readonly string AccelaPassword = SitkaConfiguration.GetRequiredAppSetting("AccelaPassword");
        public static readonly string AccelaEnvironment = SitkaConfiguration.GetRequiredAppSetting("AccelaEnvironment");
        public static readonly string AccelaConstructAPIAppID = SitkaConfiguration.GetRequiredAppSetting("AccelaConstructAPIAppID");
        public static readonly string AccelaConstructAPIAppSecret = SitkaConfiguration.GetRequiredAppSetting("AccelaConstructAPIAppSecret");
        public static readonly Uri AccelaGovXmlWebServiceUrl = new Uri(SitkaConfiguration.GetRequiredAppSetting("AccelaGovXmlWebServiceUrl"));
        public static readonly string AccelaParcelSearchByApnUrl = SitkaConfiguration.GetRequiredAppSetting("AccelaParcelSearchByApnUrl");
        public static readonly string AccelaCapRecordDetailUrl = SitkaConfiguration.GetRequiredAppSetting("AccelaCapRecordDetailUrl");

        public static readonly string KeystoneUrl = SitkaConfiguration.GetRequiredAppSetting("KeystoneUrl");
        public static readonly string KeystoneRegisterUserUrl = SitkaConfiguration.GetRequiredAppSetting("KeystoneRegisterUserUrl");
        public static readonly string KeystoneUserProfileUrl = SitkaConfiguration.GetRequiredAppSetting("KeystoneUserProfileUrl");
        public static readonly string KeystoneOrganizationEditUrl = SitkaConfiguration.GetRequiredAppSetting("KeystoneOrganizationEditUrl");

        public static readonly string TrpaArcGisServer = SitkaConfiguration.GetRequiredAppSetting("TrpaArcGisServer");
        public static readonly string LakeTahoeInfoMapServiceUrl = SitkaConfiguration.GetRequiredAppSetting("LakeTahoeInfoMapServiceUrl");
        
        public static readonly DirectoryInfo LogFileFolder = ParseLogFileFolder();

        public static readonly LakeTahoeInfoEnvironment LakeTahoeInfoEnvironment = LakeTahoeInfoEnvironment.MakeLakeTahoeInfoEnvironment(SitkaConfiguration.GetRequiredAppSetting("LakeTahoeInfoEnvironment"));

        private static DirectoryInfo ParseLogFileFolder()
        {
            const string appSettingKeyName = "LogFileFolder";
            var logFileFolder = SitkaConfiguration.GetRequiredAppSetting(appSettingKeyName);
            Check.RequireDirectoryExists(logFileFolder, "App setting {0} must be a folder that exists, folder does not exist.");
            return new DirectoryInfo(logFileFolder);
        }
    }

}