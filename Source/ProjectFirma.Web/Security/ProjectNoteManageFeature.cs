using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Project Note")]
    public class ProjectNoteManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProjectNote>
    {
        private readonly FirmaFeatureWithContextImpl<ProjectNote> _firmaFeatureWithContextImpl;

        public ProjectNoteManageFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.TMPOManager })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProjectNote>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProjectNote contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
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