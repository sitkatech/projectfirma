using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("_Admin for {0} Updates with context to a specific {0}", FieldDefinitionEnum.Project)]
    public class ProjectUpdateAdminFeatureWithProjectContext : FirmaFeatureWithContext,
        IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public ProjectUpdateAdminFeatureWithProjectContext()
            : base(new List<Role> {Role.SitkaAdmin, Role.Admin, Role.ProjectSteward})
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Project>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            if (contextModelObject.IsProposal())
            {
                return new PermissionCheckResult($"{FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabelPluralized()} cannot be updated through the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update process.");
            }

            var person = firmaSession.Person;
            var forbidAdmin = !HasPermissionByFirmaSession(firmaSession) ||
                                       firmaSession.Role.RoleID == Role.ProjectSteward.RoleID &&
                                       !person.CanStewardProject(contextModelObject);
            
            return forbidAdmin
                ? new PermissionCheckResult(
                    $"You don't have permission to make Administrative actions on {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.GetDisplayName()}")
                : new PermissionCheckResult();
        }

        public void DemandPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }
    }
}
