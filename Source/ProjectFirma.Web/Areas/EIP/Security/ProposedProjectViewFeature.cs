using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    [SecurityFeatureDescription("View Proposed Project")]
    public class ProposedProjectViewFeature : EIPFeatureWithContext, ILakeTahoeInfoBaseFeatureWithContext<ProposedProject>
    {
        private readonly LakeTahoeInfoFeatureWithContextImpl<ProposedProject> _lakeTahoeInfoFeatureWithContextImpl;

        public ProposedProjectViewFeature() : base(new List<EIPRole>())
        {
            _lakeTahoeInfoFeatureWithContextImpl = new LakeTahoeInfoFeatureWithContextImpl<ProposedProject>(this);
            ActionFilter = _lakeTahoeInfoFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProposedProject contextModelObject)
        {
            _lakeTahoeInfoFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, ProposedProject contextModelObject)
        {
            if (!HasPermissionByPerson(person))
            {
                return new PermissionCheckResult(string.Format("You don't have permission to view {0}", contextModelObject.DisplayName));
            }

            if (!contextModelObject.IsVisibleToThisPerson(person))
            {
                return new PermissionCheckResult(string.Format("ProposedProject {0} is not visible to you.", contextModelObject.ProposedProjectID));
            }

            // Allowed
            return new PermissionCheckResult();
        }
    }
}