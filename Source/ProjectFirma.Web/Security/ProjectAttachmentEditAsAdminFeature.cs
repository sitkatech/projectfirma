using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit Project Attachment")]
    public class ProjectAttachmentEditAsAdminFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProjectAttachment>
    {
        private readonly FirmaFeatureWithContextImpl<ProjectAttachment> _firmaFeatureWithContextImpl;

        public ProjectAttachmentEditAsAdminFeature()
            : base(new List<Role> {Role.Normal, Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProjectAttachment>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, ProjectAttachment contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, ProjectAttachment contextModelObject)
        {
            var person = firmaSession.Person;
            var isProjectAttachmentStewardButCannotStewardThisProjectAttachment = firmaSession.Role.RoleID == Role.ProjectSteward.RoleID && !person.CanStewardProject(contextModelObject.Project);
            var forbidAdmin = !HasPermissionByFirmaSession(firmaSession) || isProjectAttachmentStewardButCannotStewardThisProjectAttachment;
            if (forbidAdmin)
            {
                return new PermissionCheckResult(
                    $"You don't have permission to edit attachments for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.DisplayName}");
            }

            if (contextModelObject.Project.IsProposal() || contextModelObject.Project.IsPendingProject())
            {
                return new ProjectCreateFeature().HasPermission(firmaSession, contextModelObject.Project);
            }

            return new PermissionCheckResult();
        }
    }
}