using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit Proposed Project Note")]
    public class ProposedProjectNoteManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProposedProjectNote>
    {
        private readonly FirmaFeatureWithContextImpl<ProposedProjectNote> _firmaFeatureWithContextImpl;

        public ProposedProjectNoteManageFeature()
            : base(new List<Role> { Role.Normal, Role.SitkaAdmin, Role.Admin })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProposedProjectNote>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProposedProjectNote contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        /// <summary>
        /// TODO: This may well be simplified to be non-context sensitive
        /// </summary>
        /// <param name="person"></param>
        /// <param name="contextModelObject"></param>
        /// <returns></returns>
        public PermissionCheckResult HasPermission(Person person, ProposedProjectNote contextModelObject)
        {
            if (!HasPermissionByPerson(person))
            {
                return new PermissionCheckResult(string.Format("You don't have permission to edit this note."));
            }

            var projectNoteIsEditableByUser = contextModelObject.ProposedProject.IsEditableToThisPerson(person);
            if (!projectNoteIsEditableByUser)
            {
                return new PermissionCheckResult(string.Format("Proposed project {0} is not editable by you.", contextModelObject.ProposedProjectID));
            }

            return new PermissionCheckResult();
        }
    }
}