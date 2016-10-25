using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Page Content")]
    public class ProjectFirmaPageManageFeature : EIPFeatureWithContext, IFirmaBaseFeatureWithContext<ProjectFirmaPage>
    {
        private readonly FirmaFeatureWithContextImpl<ProjectFirmaPage> _firmaFeatureWithContextImpl;

        public ProjectFirmaPageManageFeature()
            : base(FirmaBaseFeatureHelpers.AllEIPRolesExceptUnassigned)
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProjectFirmaPage>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProjectFirmaPage contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, ProjectFirmaPage contextModelObject)
        {
            if (HasPermissionByPerson(person))
            {
                return new PermissionCheckResult();
            }
            return new PermissionCheckResult("Does not have administration privileges");
        }
    }
}