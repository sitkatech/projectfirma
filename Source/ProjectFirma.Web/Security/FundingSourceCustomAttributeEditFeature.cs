using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit {0}", FieldDefinitionEnum.FundingSourceCustomAttribute)]
    public class FundingSourceCustomAttributeEditFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<FundingSource>
    {
        private readonly FirmaFeatureWithContextImpl<FundingSource> _firmaFeatureWithContextImpl;

        public FundingSourceCustomAttributeEditFeature() : base(new List<Role> {Role.Admin, Role.SitkaAdmin, Role.ProjectSteward})
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<FundingSource>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, FundingSource contextModelObject)
        {
            if (!HasPermissionByFirmaSession(firmaSession))
            {
                return new PermissionCheckResult($"You don't have permission to edit {FieldDefinitionEnum.FundingSourceCustomAttribute.ToType().GetFieldDefinitionLabel()} {contextModelObject.GetDisplayName()}");
            }

            if (firmaSession.Person.RoleID == Role.ProjectSteward.RoleID && contextModelObject.OrganizationID != firmaSession.Person.OrganizationID)
            {
                return new PermissionCheckResult($"You don't have permission to edit {FieldDefinitionEnum.FundingSourceCustomAttribute.ToType().GetFieldDefinitionLabel()} {contextModelObject.GetDisplayName()} because it does not belong to your {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}");
            }

            return new PermissionCheckResult();
        }

        public void DemandPermission(FirmaSession firmaSession, FundingSource contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }
    }
}
