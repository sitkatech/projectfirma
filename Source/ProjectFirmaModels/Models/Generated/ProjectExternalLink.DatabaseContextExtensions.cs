//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExternalLink]
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
        public static ProjectExternalLink GetProjectExternalLink(this IQueryable<ProjectExternalLink> projectExternalLinks, int projectExternalLinkID)
        {
            var projectExternalLink = projectExternalLinks.SingleOrDefault(x => x.ProjectExternalLinkID == projectExternalLinkID);
            Check.RequireNotNullThrowNotFound(projectExternalLink, "ProjectExternalLink", projectExternalLinkID);
            return projectExternalLink;
        }

    }
}