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
    public static class ProjectCustomAttributeTypeModelExtensions
    {
        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.DeleteProjectCustomAttributeType(UrlTemplate.Parameter1Int)));

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Edit(UrlTemplate.Parameter1Int)));

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Detail(UrlTemplate.Parameter1Int)));

        public static readonly UrlTemplate<int> DescriptionUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Description(UrlTemplate.Parameter1Int)));

        public static string GetDeleteUrl(this ProjectCustomAttributeType projectCustomAttributeType) => DeleteUrlTemplate.ParameterReplace(projectCustomAttributeType.ProjectCustomAttributeTypeID);
        public static string GetEditUrl(this ProjectCustomAttributeType projectCustomAttributeType) => EditUrlTemplate.ParameterReplace(projectCustomAttributeType.ProjectCustomAttributeTypeID);
        public static string GetDetailUrl(this ProjectCustomAttributeType projectCustomAttributeType) => DetailUrlTemplate.ParameterReplace(projectCustomAttributeType.ProjectCustomAttributeTypeID);
        public static string GetDescriptionUrl(this ProjectCustomAttributeType projectCustomAttributeType) => DescriptionUrlTemplate.ParameterReplace(projectCustomAttributeType.ProjectCustomAttributeTypeID);

        public static HtmlString GetEditableRoles(this ProjectCustomAttributeType projectCustomAttributeType)
        {
            var customAttributeTypeEditableRoles = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypeRoles.Where(x => x.ProjectCustomAttributeTypeID == projectCustomAttributeType.ProjectCustomAttributeTypeID).ToList();
            return new HtmlString(customAttributeTypeEditableRoles.Any() 
                ? String.Join(", ", customAttributeTypeEditableRoles.OrderBy(x => x.RoleID).Where(x => x.ProjectCustomAttributeTypeRolePermissionType == ProjectCustomAttributeTypeRolePermissionType.Edit).Select(x => x.Role.GetRoleDisplayName()).ToList()) 
                : ViewUtilities.NoAnswerProvided);
        }

        public static HtmlString GetViewableRoles(this ProjectCustomAttributeType projectCustomAttributeType)
        {
            var customAttributeTypViewableRoles = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypeRoles.Where(x => x.ProjectCustomAttributeTypeID == projectCustomAttributeType.ProjectCustomAttributeTypeID).ToList();
            return new HtmlString(customAttributeTypViewableRoles.Any()
                ? String.Join(", ", customAttributeTypViewableRoles.OrderBy(x => x.RoleID).Where(x => x.ProjectCustomAttributeTypeRolePermissionType == ProjectCustomAttributeTypeRolePermissionType.View).Select(x => x.Role == null ? "Anonymous (Public)" : x.Role.GetRoleDisplayName()).ToList())
                : ViewUtilities.NoAnswerProvided);
        }

        public static bool HasEditPermission(this ProjectCustomAttributeType projectCustomAttributeType, FirmaSession currentFirmaSession)
        {
            var editTypeRoles = projectCustomAttributeType.ProjectCustomAttributeTypeRoles.Where(x => x.ProjectCustomAttributeTypeRolePermissionType == ProjectCustomAttributeTypeRolePermissionType.Edit);
            return (currentFirmaSession.Person != null && editTypeRoles.Select(x => x.Role).Contains(currentFirmaSession.Role)) || new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
        }

        public static bool HasViewPermission(this ProjectCustomAttributeType projectCustomAttributeType, FirmaSession currentFirmaSession)
        {
            var viewTypeRoles = projectCustomAttributeType.ProjectCustomAttributeTypeRoles.Where(x => x.ProjectCustomAttributeTypeRolePermissionType == ProjectCustomAttributeTypeRolePermissionType.View);
            return (currentFirmaSession.Person != null && viewTypeRoles.Select(x => x.Role).Contains(currentFirmaSession.Role)) || new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession) || (currentFirmaSession.Person == null && viewTypeRoles.Any(x => x.Role == null));
        }
    }
}