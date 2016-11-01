using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit/Delete Proposed Project Image")]
    public class ProposedProjectImageEditOrDeleteFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProposedProjectImage>
    {
        private readonly FirmaFeatureWithContextImpl<ProposedProjectImage> _firmaFeatureWithContextImpl;

        public ProposedProjectImageEditOrDeleteFeature()
            : base(new List<Role> { Role.Normal, Role.SitkaAdmin, Role.Admin })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProposedProjectImage>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProposedProjectImage contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
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