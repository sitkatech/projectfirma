using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View Proposed Project")]
    public class ProposedProjectViewFeature : EIPFeatureWithContext, IFirmaBaseFeatureWithContext<ProposedProject>
    {
        private readonly FirmaFeatureWithContextImpl<ProposedProject> _firmaFeatureWithContextImpl;

        public ProposedProjectViewFeature() : base(new List<Role>())
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProposedProject>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProposedProject contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
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