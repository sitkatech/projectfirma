using System;
using System.IO;
using System.Linq;
using System.Web.Configuration;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Common
{
    public class FirmaWebConfiguration : LtInfo.Common.FirmaWebConfiguration
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
        public static readonly string KeystoneUrl = SitkaConfiguration.GetRequiredAppSetting("KeystoneUrl");
        public static readonly string KeystoneRegisterUserUrl = SitkaConfiguration.GetRequiredAppSetting("KeystoneRegisterUserUrl");
        public static readonly string KeystoneUserProfileUrl = SitkaConfiguration.GetRequiredAppSetting("KeystoneUserProfileUrl");
        public static readonly string KeystoneOrganizationEditUrl = SitkaConfiguration.GetRequiredAppSetting("KeystoneOrganizationEditUrl");

        public static readonly string TrpaArcGisServer = SitkaConfiguration.GetRequiredAppSetting("TrpaArcGisServer");
        
        public static readonly DirectoryInfo LogFileFolder = ParseLogFileFolder();

        public static readonly FirmaEnvironment FirmaEnvironment = FirmaEnvironment.MakeFirmaEnvironment(SitkaConfiguration.GetRequiredAppSetting("FirmaEnvironment"));

        private static DirectoryInfo ParseLogFileFolder()
        {
            const string appSettingKeyName = "LogFileFolder";
            var logFileFolder = SitkaConfiguration.GetRequiredAppSetting(appSettingKeyName);
            Check.RequireDirectoryExists(logFileFolder, "App setting {0} must be a folder that exists, folder does not exist.");
            return new DirectoryInfo(logFileFolder);
        }
    }

}