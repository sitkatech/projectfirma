//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateSetting]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectUpdateSetting GetProjectUpdateSetting(this IQueryable<ProjectUpdateSetting> projectUpdateSettings, int projectUpdateSettingID)
        {
            var projectUpdateSetting = projectUpdateSettings.SingleOrDefault(x => x.ProjectUpdateSettingID == projectUpdateSettingID);
            Check.RequireNotNullThrowNotFound(projectUpdateSetting, "ProjectUpdateSetting", projectUpdateSettingID);
            return projectUpdateSetting;
        }

    }
}