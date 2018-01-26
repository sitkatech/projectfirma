using System;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectOrganizationUpdate
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectOrganizationUpdates =
                project.ProjectOrganizations.Select(
                    po => new ProjectOrganizationUpdate(projectUpdateBatch, po.Organization, po.RelationshipType)
                        ).ToList();
        }
    }
}