using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit Project")]
    public class ProjectEditFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public ProjectEditFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.TMPOManager })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Project>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, Project contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, Project contextModelObject)
        {
            var hasPermissionByPerson = HasPermissionByPerson(person);
            if (!hasPermissionByPerson)
            {
                return new PermissionCheckResult(string.Format("You don't have permission to edit {0}", contextModelObject.DisplayName));
            }

            return new PermissionCheckResult();
        }
    }
}