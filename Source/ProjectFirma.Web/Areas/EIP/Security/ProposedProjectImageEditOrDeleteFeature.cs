using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    [SecurityFeatureDescription("Edit/Delete Proposed Project Image")]
    public class ProposedProjectImageEditOrDeleteFeature : EIPFeatureWithContext, ILakeTahoeInfoBaseFeatureWithContext<ProposedProjectImage>
    {
        private readonly LakeTahoeInfoFeatureWithContextImpl<ProposedProjectImage> _lakeTahoeInfoFeatureWithContextImpl;

        public ProposedProjectImageEditOrDeleteFeature(): base(new List<EIPRole>{ EIPRole.Normal, EIPRole.Approver, EIPRole.Admin, EIPRole.TMPOManager })
        {
            _lakeTahoeInfoFeatureWithContextImpl = new LakeTahoeInfoFeatureWithContextImpl<ProposedProjectImage>(this);
            ActionFilter = _lakeTahoeInfoFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProposedProjectImage contextModelObject)
        {
            _lakeTahoeInfoFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, ProposedProjectImage contextModelObject)
        {
            if (!HasPermissionByPerson(person))
            {
                return new PermissionCheckResult(string.Format("You don't have permission to edit {0}", contextModelObject.ProposedProject.DisplayName));
            }

            var projectIsEditableByUser = contextModelObject.ProposedProject.IsEditableToThisPerson(person);
            if (!projectIsEditableByUser)
            {
                return new PermissionCheckResult(string.Format("Proposed Project {0} is not editable by you.", contextModelObject.ProposedProjectImageID));
            }

            return new PermissionCheckResult();
        }
    }
}