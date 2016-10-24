//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationAreaJurisdiction]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectLocationAreaJurisdiction GetProjectLocationAreaJurisdiction(this IQueryable<ProjectLocationAreaJurisdiction> projectLocationAreaJurisdictions, int projectLocationAreaJurisdictionID)
        {
            var projectLocationAreaJurisdiction = projectLocationAreaJurisdictions.SingleOrDefault(x => x.ProjectLocationAreaJurisdictionID == projectLocationAreaJurisdictionID);
            Check.RequireNotNullThrowNotFound(projectLocationAreaJurisdiction, "ProjectLocationAreaJurisdiction", projectLocationAreaJurisdictionID);
            return projectLocationAreaJurisdiction;
        }

        public static void DeleteProjectLocationAreaJurisdiction(this IQueryable<ProjectLocationAreaJurisdiction> projectLocationAreaJurisdictions, List<int> projectLocationAreaJurisdictionIDList)
        {
            if(projectLocationAreaJurisdictionIDList.Any())
            {
                projectLocationAreaJurisdictions.Where(x => projectLocationAreaJurisdictionIDList.Contains(x.ProjectLocationAreaJurisdictionID)).Delete();
            }
        }

        public static void DeleteProjectLocationAreaJurisdiction(this IQueryable<ProjectLocationAreaJurisdiction> projectLocationAreaJurisdictions, ICollection<ProjectLocationAreaJurisdiction> projectLocationAreaJurisdictionsToDelete)
        {
            if(projectLocationAreaJurisdictionsToDelete.Any())
            {
                var projectLocationAreaJurisdictionIDList = projectLocationAreaJurisdictionsToDelete.Select(x => x.ProjectLocationAreaJurisdictionID).ToList();
                projectLocationAreaJurisdictions.Where(x => projectLocationAreaJurisdictionIDList.Contains(x.ProjectLocationAreaJurisdictionID)).Delete();
            }
        }

        public static void DeleteProjectLocationAreaJurisdiction(this IQueryable<ProjectLocationAreaJurisdiction> projectLocationAreaJurisdictions, int projectLocationAreaJurisdictionID)
        {
            DeleteProjectLocationAreaJurisdiction(projectLocationAreaJurisdictions, new List<int> { projectLocationAreaJurisdictionID });
        }

        public static void DeleteProjectLocationAreaJurisdiction(this IQueryable<ProjectLocationAreaJurisdiction> projectLocationAreaJurisdictions, ProjectLocationAreaJurisdiction projectLocationAreaJurisdictionToDelete)
        {
            DeleteProjectLocationAreaJurisdiction(projectLocationAreaJurisdictions, new List<ProjectLocationAreaJurisdiction> { projectLocationAreaJurisdictionToDelete });
        }
    }
}