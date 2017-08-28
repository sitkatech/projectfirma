using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit {0}", FieldDefinitionEnum.FundingSource)]
    public class FundingSourceEditFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<FundingSource>
    {
        private readonly FirmaFeatureWithContextImpl<FundingSource> _firmaFeatureWithContextImpl;

        public FundingSourceEditFeature() : base(new List<Role> {Role.Admin, Role.SitkaAdmin, Role.ProjectSteward})
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<FundingSource>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public PermissionCheckResult HasPermission(Person person, FundingSource contextModelObject)
        {
            if (!HasPermissionByPerson(person))
            {
                return new PermissionCheckResult($"You don't have permission to edit or delete {FieldDefinition.FundingSource.GetFieldDefinitionLabel()} {contextModelObject.DisplayName}");
            }

            if (person.RoleID == Role.ProjectSteward.RoleID && contextModelObject.OrganizationID != person.OrganizationID)
            {
                return new PermissionCheckResult($"You don't have permission to edit or delete {FieldDefinition.FundingSource.GetFieldDefinitionLabel()} {contextModelObject.DisplayName} because it does not belong to your {FieldDefinition.Organization.GetFieldDefinitionLabel()}");
            }

            return new PermissionCheckResult();
        }

        public void DemandPermission(Person person, FundingSource contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }
    }
}
