using System;
using System.Linq;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectOrganizationUpdate : IAuditableEntity, IProjectOrganization
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectOrganizationUpdates =
                project.ProjectOrganizations.Select(
                    po => new ProjectOrganizationUpdate(projectUpdateBatch, po.Organization, po.RelationshipType)
                        ).ToList();
        }

        public string AuditDescriptionString
        {
            get
            {
                var projectUpdateBatch = HttpRequestStorage.DatabaseEntities.AllProjectUpdateBatches.Find(ProjectUpdateBatchID);
                var project = projectUpdateBatch?.Project;
                var organization = HttpRequestStorage.DatabaseEntities.AllOrganizations.Find(OrganizationID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var organizationName = organization != null ? organization.AuditDescriptionString : ViewUtilities.NotFoundString;
                return $"Project Update: {projectName}, Organization: {organizationName}";
            }
        }
    }
}