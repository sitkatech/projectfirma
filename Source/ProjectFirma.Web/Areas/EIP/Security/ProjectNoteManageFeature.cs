using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    [SecurityFeatureDescription("Manage Project Note")]
    public class ProjectNoteManageFeature : EIPFeatureWithContext, ILakeTahoeInfoBaseFeatureWithContext<ProjectNote>
    {
        private readonly LakeTahoeInfoFeatureWithContextImpl<ProjectNote> _lakeTahoeInfoFeatureWithContextImpl;

        public ProjectNoteManageFeature() : base(new List<EIPRole>{ EIPRole.Admin, EIPRole.TMPOManager })
        {
            _lakeTahoeInfoFeatureWithContextImpl = new LakeTahoeInfoFeatureWithContextImpl<ProjectNote>(this);
            ActionFilter = _lakeTahoeInfoFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProjectNote contextModelObject)
        {
            _lakeTahoeInfoFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, ProjectNote contextModelObject)
        {
            if (!HasPermissionByPerson(person))
            {
                return new PermissionCheckResult("You don't have permission to edit this note.");
            }

            return new PermissionCheckResult();
        }
    }
}