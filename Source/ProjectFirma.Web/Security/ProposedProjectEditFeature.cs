using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit Proposed Project")]
    public class ProposedProjectEditFeature : EIPFeatureWithContext, ILakeTahoeInfoBaseFeatureWithContext<ProposedProject>
    {
        private readonly LakeTahoeInfoFeatureWithContextImpl<ProposedProject> _lakeTahoeInfoFeatureWithContextImpl;

        public ProposedProjectEditFeature() : base(new List<Role> {Role.Normal, Role.Approver, Role.Admin, Role.TMPOManager})
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
                return new PermissionCheckResult(string.Format("You don't have permission to edit {0}", contextModelObject.DisplayName));
            }

            var projectIsEditableByUser = contextModelObject.IsEditableToThisPerson(person);
            if (!projectIsEditableByUser)
            {
                return new PermissionCheckResult(string.Format("Proposed Project {0} is not editable by you.", contextModelObject.ProposedProjectID));
            }

            return new PermissionCheckResult();
        }
    }
}