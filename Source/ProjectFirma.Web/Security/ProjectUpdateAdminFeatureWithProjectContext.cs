using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("_Admin for {0} Updates with context to a specific {0}", FieldDefinitionEnum.Project)]
    public class ProjectUpdateAdminFeatureWithProjectContext : FirmaFeatureWithContext,
        IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public ProjectUpdateAdminFeatureWithProjectContext()
            : base(new List<Role> {Role.SitkaAdmin, Role.Admin, Role.ProjectApprover})
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Project>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public PermissionCheckResult HasPermission(Person person, Project contextModelObject)
        {
            var forbidAdmin = !HasPermissionByPerson(person) ||
                                       person.Role.RoleID == Role.ProjectApprover.RoleID &&
                                       !person.CanApproveProjectByOrganizationRelationship(contextModelObject);
            return forbidAdmin
                ? new PermissionCheckResult(
                    $"You don't have permission to make Administrative actions on {FieldDefinition.Project.GetFieldDefinitionLabel()} {contextModelObject.DisplayName}")
                : new PermissionCheckResult();
        }

        public void DemandPermission(Person person, Project contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }
    }
}
