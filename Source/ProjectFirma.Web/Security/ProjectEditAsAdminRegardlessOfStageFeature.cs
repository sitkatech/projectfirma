using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit Project")]
    public class ProjectEditAsAdminRegardlessOfStageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public ProjectEditAsAdminRegardlessOfStageFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Project>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            var person = firmaSession.Person;
            var isProjectStewardButCannotStewardThisProject = firmaSession.Role.RoleID == Role.ProjectSteward.RoleID && !person.CanStewardProject(contextModelObject);
            var forbidAdmin = !HasPermissionByFirmaSession(firmaSession) || isProjectStewardButCannotStewardThisProject;
            if (forbidAdmin)
            {
                return new PermissionCheckResult($"You don't have permission to edit {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.GetDisplayName()}");
            }
            return new PermissionCheckResult();
        }
    }
}