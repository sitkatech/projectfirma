//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectTag]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectTag GetProjectTag(this IQueryable<ProjectTag> projectTags, int projectTagID)
        {
            var projectTag = projectTags.SingleOrDefault(x => x.ProjectTagID == projectTagID);
            Check.RequireNotNullThrowNotFound(projectTag, "ProjectTag", projectTagID);
            return projectTag;
        }

    }
}