using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit an Organization's Background Information")]
    public class OrganizationBackgroundEditFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Organization>
    {
        private readonly FirmaFeatureWithContextImpl<Organization> _firmaFeatureWithContextImpl;

        public OrganizationBackgroundEditFeature()
            : base(new List<Role> { Role.Normal, Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Organization>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, Organization contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Organization contextModelObject)
        {
            var hasPermissionByFirmaSession = HasPermissionByFirmaSession(firmaSession);
            if (!hasPermissionByFirmaSession)
            {
                return new PermissionCheckResult($"You don't have permission to Edit {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} {contextModelObject.GetDisplayName()}");
            }

            var organizationIsEditableByUser = new FirmaAdminFeature().HasPermission(firmaSession).HasPermission || contextModelObject.PrimaryContactPerson != null && firmaSession.PersonID == contextModelObject.PrimaryContactPerson.PersonID;
            if (!organizationIsEditableByUser)
            {
                return new PermissionCheckResult($"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} {contextModelObject.OrganizationID} is not editable by you.");
            }

            return new PermissionCheckResult();
        }
    }
}