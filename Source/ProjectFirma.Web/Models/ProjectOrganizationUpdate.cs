using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LtInfo.Common;
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

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectOrganization> allProjectOrganizations)
        {
            var project = projectUpdateBatch.Project;
            var projectOrganizationsFromProjectUpdate =
                projectUpdateBatch.ProjectOrganizationUpdates.Select(
                    x => new ProjectOrganization(project.ProjectID, x.OrganizationID, x.RelationshipTypeID)).ToList();
            project.ProjectOrganizations.Merge(projectOrganizationsFromProjectUpdate, allProjectOrganizations,
                (x, y) => x.OrganizationID == y.OrganizationID && x.RelationshipTypeID == y.RelationshipTypeID);
        }
    }
}