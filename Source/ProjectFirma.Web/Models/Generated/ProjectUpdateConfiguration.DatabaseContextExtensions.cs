//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateConfiguration]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectUpdateConfiguration GetProjectUpdateConfiguration(this IQueryable<ProjectUpdateConfiguration> projectUpdateConfigurations, int projectUpdateConfigurationID)
        {
            var projectUpdateConfiguration = projectUpdateConfigurations.SingleOrDefault(x => x.ProjectUpdateConfigurationID == projectUpdateConfigurationID);
            Check.RequireNotNullThrowNotFound(projectUpdateConfiguration, "ProjectUpdateConfiguration", projectUpdateConfigurationID);
            return projectUpdateConfiguration;
        }

        public static void DeleteProjectUpdateConfiguration(this List<int> projectUpdateConfigurationIDList)
        {
            if(projectUpdateConfigurationIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectUpdateConfigurations.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectUpdateConfigurations.Where(x => projectUpdateConfigurationIDList.Contains(x.ProjectUpdateConfigurationID)));
            }
        }

        public static void DeleteProjectUpdateConfiguration(this ICollection<ProjectUpdateConfiguration> projectUpdateConfigurationsToDelete)
        {
            if(projectUpdateConfigurationsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectUpdateConfigurations.RemoveRange(projectUpdateConfigurationsToDelete);
            }
        }

        public static void DeleteProjectUpdateConfiguration(this int projectUpdateConfigurationID)
        {
            DeleteProjectUpdateConfiguration(new List<int> { projectUpdateConfigurationID });
        }

        public static void DeleteProjectUpdateConfiguration(this ProjectUpdateConfiguration projectUpdateConfigurationToDelete)
        {
            DeleteProjectUpdateConfiguration(new List<ProjectUpdateConfiguration> { projectUpdateConfigurationToDelete });
        }
    }
}