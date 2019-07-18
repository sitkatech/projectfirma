using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirmaModels.Models
{
    public static class ProjectOrganizationUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectUpdate.PrimaryContactPersonID = project.PrimaryContactPersonID;
            projectUpdateBatch.ProjectOrganizationUpdates =
                project.ProjectOrganizations.Select(
                    po => new ProjectOrganizationUpdate(projectUpdateBatch, po.Organization, po.OrganizationRelationshipType)
                ).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectOrganization> allProjectOrganizations)
        {
            var project = projectUpdateBatch.Project;
            var projectOrganizationsFromProjectUpdate =
                projectUpdateBatch.ProjectOrganizationUpdates.Select(
                    x => new ProjectOrganization(project.ProjectID, x.OrganizationID, x.OrganizationRelationshipTypeID)).ToList();
            project.ProjectOrganizations.Merge(projectOrganizationsFromProjectUpdate, allProjectOrganizations,
                (x, y) => x.OrganizationID == y.OrganizationID && x.OrganizationRelationshipTypeID == y.OrganizationRelationshipTypeID, HttpRequestStorage.DatabaseEntities);
        }
    }
}