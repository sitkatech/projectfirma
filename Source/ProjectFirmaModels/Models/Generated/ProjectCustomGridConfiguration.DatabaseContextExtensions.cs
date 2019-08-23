//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomGridConfiguration]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectCustomGridConfiguration GetProjectCustomGridConfiguration(this IQueryable<ProjectCustomGridConfiguration> projectCustomGridConfigurations, int projectCustomGridConfigurationID)
        {
            var projectCustomGridConfiguration = projectCustomGridConfigurations.SingleOrDefault(x => x.ProjectCustomGridConfigurationID == projectCustomGridConfigurationID);
            Check.RequireNotNullThrowNotFound(projectCustomGridConfiguration, "ProjectCustomGridConfiguration", projectCustomGridConfigurationID);
            return projectCustomGridConfiguration;
        }

    }
}