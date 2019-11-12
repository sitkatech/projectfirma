using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Add Attachments for {0} Updates", FieldDefinitionEnum.Project)]
    public class ProjectAttachmentUpdateNewFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProjectUpdateBatch>
    {
        private readonly FirmaFeatureWithContextImpl<ProjectUpdateBatch> _firmaFeatureWithContextImpl;

        public ProjectAttachmentUpdateNewFeature()
            : base(new List<Role> { Role.Normal, Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProjectUpdateBatch>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, ProjectUpdateBatch contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, ProjectUpdateBatch contextModelObject)
        {
            return new ProjectUpdateCreateEditSubmitFeature().HasPermission(firmaSession, contextModelObject.Project);
        }
    }
}