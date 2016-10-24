//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProject]
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
        public static ProposedProject GetProposedProject(this IQueryable<ProposedProject> proposedProjects, int proposedProjectID)
        {
            var proposedProject = proposedProjects.SingleOrDefault(x => x.ProposedProjectID == proposedProjectID);
            Check.RequireNotNullThrowNotFound(proposedProject, "ProposedProject", proposedProjectID);
            return proposedProject;
        }

        public static void DeleteProposedProject(this IQueryable<ProposedProject> proposedProjects, List<int> proposedProjectIDList)
        {
            if(proposedProjectIDList.Any())
            {
                proposedProjects.Where(x => proposedProjectIDList.Contains(x.ProposedProjectID)).Delete();
            }
        }

        public static void DeleteProposedProject(this IQueryable<ProposedProject> proposedProjects, ICollection<ProposedProject> proposedProjectsToDelete)
        {
            if(proposedProjectsToDelete.Any())
            {
                var proposedProjectIDList = proposedProjectsToDelete.Select(x => x.ProposedProjectID).ToList();
                proposedProjects.Where(x => proposedProjectIDList.Contains(x.ProposedProjectID)).Delete();
            }
        }

        public static void DeleteProposedProject(this IQueryable<ProposedProject> proposedProjects, int proposedProjectID)
        {
            DeleteProposedProject(proposedProjects, new List<int> { proposedProjectID });
        }

        public static void DeleteProposedProject(this IQueryable<ProposedProject> proposedProjects, ProposedProject proposedProjectToDelete)
        {
            DeleteProposedProject(proposedProjects, new List<ProposedProject> { proposedProjectToDelete });
        }
    }
}