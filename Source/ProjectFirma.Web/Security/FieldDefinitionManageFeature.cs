using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Field Definitions")]
    public class FieldDefinitionManageFeature : EIPFeatureWithContext, IFirmaBaseFeatureWithContext<FieldDefinition>
    {
        private readonly FirmaFeatureWithContextImpl<FieldDefinition> _firmaFeatureWithContextImpl;

        public FieldDefinitionManageFeature()
            : base(FirmaBaseFeatureHelpers.AllEIPRolesExceptUnassigned)
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<FieldDefinition>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, FieldDefinition contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
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