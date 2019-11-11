using System;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class FundingSourceCustomAttributeTypeModelExtensions
    {
        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<FundingSourceCustomAttributeTypeController>.BuildUrlFromExpression(c => c.DeleteFundingSourceCustomAttributeType(UrlTemplate.Parameter1Int)));

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<FundingSourceCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Edit(UrlTemplate.Parameter1Int)));

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<FundingSourceCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Detail(UrlTemplate.Parameter1Int)));

        public static readonly UrlTemplate<int> DescriptionUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<FundingSourceCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Description(UrlTemplate.Parameter1Int)));

        public static string GetDeleteUrl(this FundingSourceCustomAttributeType fundingSourceCustomAttributeType) => DeleteUrlTemplate.ParameterReplace(fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID);
        public static string GetEditUrl(this FundingSourceCustomAttributeType fundingSourceCustomAttributeType) => EditUrlTemplate.ParameterReplace(fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID);
        public static string GetDetailUrl(this FundingSourceCustomAttributeType fundingSourceCustomAttributeType) => DetailUrlTemplate.ParameterReplace(fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID);
        public static string GetDescriptionUrl(this FundingSourceCustomAttributeType fundingSourceCustomAttributeType) => DescriptionUrlTemplate.ParameterReplace(fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID);

        public static HtmlString GetEditableRoles(this FundingSourceCustomAttributeType fundingSourceCustomAttributeType)
        {
            var customAttributeTypeEditableRoles = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeTypeRoles.Where(x => x.FundingSourceCustomAttributeTypeID == fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID).ToList();
            return new HtmlString(customAttributeTypeEditableRoles.Any()
                ? String.Join(", ", customAttributeTypeEditableRoles.OrderBy(x => x.RoleID).Where(x => x.FundingSourceCustomAttributeTypeRolePermissionType == FundingSourceCustomAttributeTypeRolePermissionType.Edit).Select(x => x.Role.GetRoleDisplayName()).ToList())
                : ViewUtilities.NoAnswerProvided);
        }

        public static HtmlString GetViewableRoles(this FundingSourceCustomAttributeType fundingSourceCustomAttributeType)
        {
            var customAttributeTypViewableRoles = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeTypeRoles.Where(x => x.FundingSourceCustomAttributeTypeID == fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID).ToList();
            return new HtmlString(customAttributeTypViewableRoles.Any()
                ? String.Join(", ", customAttributeTypViewableRoles.OrderBy(x => x.RoleID).Where(x => x.FundingSourceCustomAttributeTypeRolePermissionType == FundingSourceCustomAttributeTypeRolePermissionType.View).Select(x => x.Role.GetRoleDisplayName()).ToList())
                : ViewUtilities.NoAnswerProvided);
        }

        public static bool HasEditPermission(this FundingSourceCustomAttributeType fundingSourceCustomAttributeType, FirmaSession currentFirmaSession)
        {
            return fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeRoles
                       .Where(x => !currentFirmaSession.IsAnonymousUser() && x.FundingSourceCustomAttributeTypeRolePermissionType ==
                                   FundingSourceCustomAttributeTypeRolePermissionType.Edit).Select(x => x.Role)
                       .Contains(currentFirmaSession.Role) ||
                   new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
        }

        public static bool HasViewPermission(this FundingSourceCustomAttributeType fundingSourceCustomAttributeType, FirmaSession currentFirmaSession)
        {
            return fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeRoles
                       .Where(x => x.FundingSourceCustomAttributeTypeRolePermissionType ==
                                   FundingSourceCustomAttributeTypeRolePermissionType.View).Select(x => x.Role)
                                   .Contains(currentFirmaSession.Role) ||
                   new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
        }
    }
}