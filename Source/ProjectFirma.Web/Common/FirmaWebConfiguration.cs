/*-----------------------------------------------------------------------
<copyright file="FirmaWebConfiguration.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using System.IO;
using System.Linq;
using System.Web.Configuration;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Common
{
    public class FirmaWebConfiguration : SitkaWebConfiguration
    {
        public static readonly int MaximumAllowedUploadFileSize = Int32.Parse(SitkaConfiguration.GetRequiredAppSetting("MaximumAllowedUploadFileSize"));
        public static readonly int MaximumAllowedUploadImageSize = Int32.Parse(SitkaConfiguration.GetRequiredAppSetting("MaximumAllowedUploadImageSize"));
        public static readonly string RecaptchaValidatorUrl = SitkaConfiguration.GetRequiredAppSettingNotNullNotEmptyNotWhitespace("RecaptchaValidatorUrl");
        public static readonly string SitkaSupportEmail = SitkaConfiguration.GetRequiredAppSettingNotNullNotEmptyNotWhitespace("SitkaSupportEmail");
        public static readonly string DoNotReplyEmail = SitkaConfiguration.GetRequiredAppSettingNotNullNotEmptyNotWhitespace("DoNotReplyEmail");
        public static readonly string Ogr2OgrExecutable = SitkaConfiguration.GetRequiredAppSetting("Ogr2OgrExecutable");
        public static readonly string OgrInfoExecutable = SitkaConfiguration.GetRequiredAppSetting("OgrInfoExecutable");
        public static readonly int DefaultSupportPersonID = Int32.Parse(SitkaConfiguration.GetRequiredAppSetting("DefaultSupportPersonID"));

        public static readonly TimeSpan HttpRuntimeExecutionTimeout = ((HttpRuntimeSection)WebConfigurationManager.GetSection("system.web/httpRuntime")).ExecutionTimeout;

        public static readonly string PsInfoUrl = SitkaConfiguration.GetRequiredAppSetting("PsInfoUrl");
        public static readonly string PsInfoDataCenterUrl = SitkaConfiguration.GetRequiredAppSetting("PsInfoDataCenterUrl");
        public static readonly string VitalSignsUrl = SitkaConfiguration.GetRequiredAppSetting("VitalSignsUrl");
        public static readonly string NEPAtlasUrl = SitkaConfiguration.GetRequiredAppSetting("NEPAtlasUrl");
        
        public static readonly string KeystoneUserProfileUrl = SitkaConfiguration.GetRequiredAppSetting("KeystoneUserProfileUrl");
        public static readonly string KeystoneInviteUserUrl = SitkaConfiguration.GetRequiredAppSetting("KeystoneInviteUserUrl");
        public static readonly Guid KeystoneWebServiceApplicationGuid = Guid.Parse(SitkaConfiguration.GetRequiredAppSetting("KeystoneWebServiceApplicationGuid"));
        
        public static readonly string KeystoneOpenIDUrl = SitkaConfiguration.GetRequiredAppSetting("KeystoneOpenIDUrl");

        public static readonly DirectoryInfo LogFileFolder = ParseLogFileFolder();

        public static readonly FirmaEnvironment FirmaEnvironment = FirmaEnvironment.MakeFirmaEnvironment(SitkaConfiguration.GetRequiredAppSetting("FirmaEnvironment"));

        public static readonly string CanonicalHostName = CanonicalHostNames.FirstOrDefault();

        public static List<string> CanonicalHostNames => Tenant.All.OrderBy(x => x.TenantID).Select(x => FirmaEnvironment.GetCanonicalHostNameForEnvironment(x)).ToList();

        public static string GetCanonicalHost(string hostName, bool useApproximateMatch)
        {
            //First search for perfect match
            var canonicalHostNames = CanonicalHostNames;
            var result = canonicalHostNames.FirstOrDefault(h => string.Equals(h, hostName, StringComparison.InvariantCultureIgnoreCase));

            if (!string.IsNullOrWhiteSpace(result) || !useApproximateMatch)
            {
                return result;
            }

            var canonicalHost = canonicalHostNames.FirstOrDefault(h => h.EndsWith(hostName, StringComparison.InvariantCultureIgnoreCase));
            if (canonicalHost == null && FirmaEnvironment.FirmaEnvironmentType == FirmaEnvironmentType.Prod)
            {
                if (hostName.Equals("swcdemo.projectfirma.com", StringComparison.InvariantCultureIgnoreCase))
                {
                    return Tenant.IdahoAssociatonOfSoilConservationDistricts.CanonicalHostNameProd;
                }
                // Redirect to ProjectFirma home if domain is bad in Prod 
                return Tenant.SitkaTechnologyGroup.CanonicalHostNameProd;
            }

            return canonicalHost;
        }



        private static DirectoryInfo ParseLogFileFolder()
        {
            const string appSettingKeyName = "LogFileFolder";
            var logFileFolder = SitkaConfiguration.GetRequiredAppSetting(appSettingKeyName);
            Check.RequireDirectoryExists(logFileFolder, "App setting {0} must be a folder that exists, folder does not exist.");
            return new DirectoryInfo(logFileFolder);
        }
    }

}
