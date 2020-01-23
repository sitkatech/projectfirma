using System.Linq;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
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

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, DatabaseEntities databaseEntities)
        {
            var project = projectUpdateBatch.Project;
            var projectOrganizationsFromProjectUpdate =
                projectUpdateBatch.ProjectOrganizationUpdates.Select(
                    x => new ProjectOrganization(project.ProjectID, x.OrganizationID, x.OrganizationRelationshipTypeID)).ToList();
            project.ProjectOrganizations.Merge(projectOrganizationsFromProjectUpdate,
                (x, y) => x.OrganizationID == y.OrganizationID &&
                          x.OrganizationRelationshipTypeID == y.OrganizationRelationshipTypeID, databaseEntities);
        }
    }
}