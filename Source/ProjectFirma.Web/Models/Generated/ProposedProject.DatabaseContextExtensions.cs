//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProject]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProposedProject GetProposedProject(this IQueryable<ProposedProject> proposedProjects, int proposedProjectID)
        {
            var proposedProject = proposedProjects.SingleOrDefault(x => x.ProposedProjectID == proposedProjectID);
            Check.RequireNotNullThrowNotFound(proposedProject, "ProposedProject", proposedProjectID);
            return proposedProject;
        }

        public static void DeleteProposedProject(this List<int> proposedProjectIDList)
        {
            if(proposedProjectIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjects.RemoveRange(HttpRequestStorage.DatabaseEntities.ProposedProjects.Where(x => proposedProjectIDList.Contains(x.ProposedProjectID)));
            }
        }

        public static void DeleteProposedProject(this ICollection<ProposedProject> proposedProjectsToDelete)
        {
            if(proposedProjectsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjects.RemoveRange(proposedProjectsToDelete);
            }
        }

        public static void DeleteProposedProject(this int proposedProjectID)
        {
            DeleteProposedProject(new List<int> { proposedProjectID });
        }

        public static void DeleteProposedProject(this ProposedProject proposedProjectToDelete)
        {
            DeleteProposedProject(new List<ProposedProject> { proposedProjectToDelete });
        }
    }
}