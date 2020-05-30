//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocation]
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
        public static ProjectLocation GetProjectLocation(this IQueryable<ProjectLocation> projectLocations, int projectLocationID)
        {
            var projectLocation = projectLocations.SingleOrDefault(x => x.ProjectLocationID == projectLocationID);
            Check.RequireNotNullThrowNotFound(projectLocation, "ProjectLocation", projectLocationID);
            return projectLocation;
        }

    }
}