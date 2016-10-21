using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Page Content")]
    public class ProjectFirmaPageManageFeature : LakeTahoeInfoFeatureWithContext, ILakeTahoeInfoBaseFeatureWithContext<ProjectFirmaPage>
    {
        private readonly LakeTahoeInfoFeatureWithContextImpl<ProjectFirmaPage> _lakeTahoeInfoFeatureWithContextImpl;

        public ProjectFirmaPageManageFeature()
            : base(LakeTahoeInfoBaseFeatureHelpers.AllLTInfoRolesExceptUnassigned)
        {
            _lakeTahoeInfoFeatureWithContextImpl = new LakeTahoeInfoFeatureWithContextImpl<ProjectFirmaPage>(this);
            ActionFilter = _lakeTahoeInfoFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProjectFirmaPage contextModelObject)
        {
            _lakeTahoeInfoFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, ProjectFirmaPage contextModelObject)
        {
            return contextModelObject.ProjectFirmaPageType.PrimaryLTInfoArea.CanManageFieldDefinitionAndIntroTextForArea(person);
        }
    }
}