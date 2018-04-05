using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit Project Document")]
    public class ProjectDocumentEditAsAdminFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProjectDocument>
    {
        private readonly FirmaFeatureWithContextImpl<ProjectDocument> _firmaFeatureWithContextImpl;

        public ProjectDocumentEditAsAdminFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProjectDocument>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProjectDocument contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, ProjectDocument contextModelObject)
        {
            var isProjectDocumentStewardButCannotStewardThisProjectDocument = person.Role.RoleID == Role.ProjectSteward.RoleID && !person.CanStewardProjectByOrganizationRelationship(contextModelObject.Project);
            var forbidAdmin = !HasPermissionByPerson(person) || isProjectDocumentStewardButCannotStewardThisProjectDocument;
            if (forbidAdmin)
            {
                return new PermissionCheckResult(
                    $"You don't have permission to edit documents for {FieldDefinition.Project.GetFieldDefinitionLabel()} {contextModelObject.DisplayName}");
            }
            return new PermissionCheckResult();
        }
    }
}
