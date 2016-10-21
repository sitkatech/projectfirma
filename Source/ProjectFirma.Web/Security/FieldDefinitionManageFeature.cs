using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Field Definitions")]
    public class FieldDefinitionManageFeature : LakeTahoeInfoFeatureWithContext, ILakeTahoeInfoBaseFeatureWithContext<FieldDefinition>
    {
        private readonly LakeTahoeInfoFeatureWithContextImpl<FieldDefinition> _lakeTahoeInfoFeatureWithContextImpl;

        public FieldDefinitionManageFeature()
            : base(LakeTahoeInfoBaseFeatureHelpers.AllLTInfoRolesExceptUnassigned)
        {
            _lakeTahoeInfoFeatureWithContextImpl = new LakeTahoeInfoFeatureWithContextImpl<FieldDefinition>(this);
            ActionFilter = _lakeTahoeInfoFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, FieldDefinition contextModelObject)
        {
            _lakeTahoeInfoFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, FieldDefinition contextModelObject)
        {
            return contextModelObject.PrimaryLTInfoArea.CanManageFieldDefinitionAndIntroTextForArea(person);
        }
    }
}