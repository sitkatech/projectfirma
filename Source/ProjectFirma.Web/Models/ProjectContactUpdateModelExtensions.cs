using System.Linq;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectContactUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectUpdate.PrimaryContactPersonID = project.PrimaryContactPersonID;
            projectUpdateBatch.ProjectContactUpdates =
                project.ProjectContacts.Select(
                    pc => new ProjectContactUpdate(projectUpdateBatch, pc.Contact, pc.ContactRelationshipType)
                ).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, DatabaseEntities databaseEntities)
        {
            var project = projectUpdateBatch.Project;
            var projectContactsFromProjectUpdate =
                projectUpdateBatch.ProjectContactUpdates.Select(
                    x => new ProjectContact(project.ProjectID, x.ContactID, x.ContactRelationshipTypeID)).ToList();
            project.ProjectContacts.Merge(projectContactsFromProjectUpdate,
                (x, y) => x.ContactID == y.ContactID && x.ContactRelationshipTypeID == y.ContactRelationshipTypeID,
                databaseEntities);
        }
    }
}