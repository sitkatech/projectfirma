using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit Proposed Project")]
    public class ProposedProjectEditFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProposedProject>
    {
        private readonly FirmaFeatureWithContextImpl<ProposedProject> _firmaFeatureWithContextImpl;

        public ProposedProjectEditFeature()
            : base(new List<Role> { Role.Normal, Role.Approver, Role.SitkaAdmin, Role.Admin, Role.TMPOManager })
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