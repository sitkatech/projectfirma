using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit Project")]
    public class ProjectEditFeature : EIPFeatureWithContext, ILakeTahoeInfoBaseFeatureWithContext<Project>
    {
        private readonly LakeTahoeInfoFeatureWithContextImpl<Project> _lakeTahoeInfoFeatureWithContextImpl;

        public ProjectEditFeature() : base(new List<Role> {Role.Admin, Role.TMPOManager})
        {
            _lakeTahoeInfoFeatureWithContextImpl = new LakeTahoeInfoFeatureWithContextImpl<Project>(this);
            ActionFilter = _lakeTahoeInfoFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, Project contextModelObject)
        {
            _lakeTahoeInfoFeatureWithContextImpl.DemandPermission(person, contextModelObject);
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