//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectImage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectImage GetProjectImage(this IQueryable<ProjectImage> projectImages, int projectImageID)
        {
            var projectImage = projectImages.SingleOrDefault(x => x.ProjectImageID == projectImageID);
            Check.RequireNotNullThrowNotFound(projectImage, "ProjectImage", projectImageID);
            return projectImage;
        }

    }
}