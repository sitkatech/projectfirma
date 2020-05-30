//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectGeospatialArea]
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
        public static ProjectGeospatialArea GetProjectGeospatialArea(this IQueryable<ProjectGeospatialArea> projectGeospatialAreas, int projectGeospatialAreaID)
        {
            var projectGeospatialArea = projectGeospatialAreas.SingleOrDefault(x => x.ProjectGeospatialAreaID == projectGeospatialAreaID);
            Check.RequireNotNullThrowNotFound(projectGeospatialArea, "ProjectGeospatialArea", projectGeospatialAreaID);
            return projectGeospatialArea;
        }

    }
}