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

        public void DemandPermission(Person person, ProjectAttachment contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, ProjectAttachment contextModelObject)
        {
            var isProjectAttachmentStewardButCannotStewardThisProjectAttachment = person.Role.RoleID == Role.ProjectSteward.RoleID && !person.CanStewardProject(contextModelObject.Project);
            var forbidAdmin = !HasPermissionByPerson(person) || isProjectAttachmentStewardButCannotStewardThisProjectAttachment;
            if (forbidAdmin)
            {
                return new PermissionCheckResult(
                    $"You don't have permission to edit attachments for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.DisplayName}");
            }

            if (contextModelObject.Project.IsProposal() || contextModelObject.Project.IsPendingProject())
            {
                return new ProjectCreateFeature().HasPermission(person, contextModelObject.Project);
            }

            return new PermissionCheckResult();
        }
    }
}