using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Field Definitions")]
    public class FieldDefinitionManageFeature : EIPFeatureWithContext, ILakeTahoeInfoBaseFeatureWithContext<FieldDefinition>
    {
        private readonly LakeTahoeInfoFeatureWithContextImpl<FieldDefinition> _lakeTahoeInfoFeatureWithContextImpl;

        public FieldDefinitionManageFeature()
            : base(LakeTahoeInfoBaseFeatureHelpers.AllEIPRolesExceptUnassigned)
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
            if (HasPermissionByPerson(person))
            {
                return new PermissionCheckResult();
            }
            return new PermissionCheckResult("Does not have administration privileges");
        }
    }
}