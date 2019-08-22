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

        public void DemandPermission(Person person, ProjectUpdateBatch contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, ProjectUpdateBatch contextModelObject)
        {
            return new ProjectUpdateCreateEditSubmitFeature().HasPermission(person, contextModelObject.Project);
        }
    }
}