using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit Attachments for {0} Updates", FieldDefinitionEnum.Project)]
    public class ProjectAttachmentUpdateEditFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProjectAttachmentUpdate>
    {
        private readonly FirmaFeatureWithContextImpl<ProjectAttachmentUpdate> _firmaFeatureWithContextImpl;

        public ProjectAttachmentUpdateEditFeature()
            : base(new List<Role> { Role.Normal, Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProjectAttachmentUpdate>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProjectAttachmentUpdate contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, ProjectAttachmentUpdate contextModelObject)
        {
            return new ProjectUpdateCreateEditSubmitFeature().HasPermission(person, contextModelObject.ProjectUpdateBatch.Project);
        }
    }
}