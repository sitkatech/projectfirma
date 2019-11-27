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

        public void DemandPermission(FirmaSession firmaSession, ProjectAttachmentUpdate contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, ProjectAttachmentUpdate contextModelObject)
        {
            return new ProjectUpdateCreateEditSubmitFeature().HasPermission(firmaSession, contextModelObject.ProjectUpdateBatch.Project);
        }
    }
}