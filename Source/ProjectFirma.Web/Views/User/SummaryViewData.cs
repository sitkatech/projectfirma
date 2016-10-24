using System.Web;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Views.User
{
    public class SummaryViewData : SiteLayoutViewData
    {
        public readonly Person Person;
        public readonly string EditPersonOrganizationPrimaryContactUrl;
        public readonly string Index;

        public readonly bool UserHasPersonViewPermissions;
        public readonly bool UserHasPersonManagePermissions;
        public readonly bool UserHasViewEverythingPermissions;
        public readonly bool IsViewingSelf;
        public readonly Project.BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoGridName;
        public readonly string BasicProjectInfoGridDataUrl;
        public readonly UserNotificationGridSpec UserNotificationGridSpec;
        public readonly string UserNotificationGridName;
        public readonly string UserNotificationGridDataUrl;
        public readonly string ActivateInactivateUrl;

        public SummaryViewData(Person currentPerson,
            Person personToView,
            Project.BasicProjectInfoGridSpec basicProjectInfoGridSpec,
            string basicProjectInfoGridName,
            string basicProjectInfoGridDataUrl,
            UserNotificationGridSpec userNotificationGridSpec,
            string userNotificationGridName,
            string userNotificationGridDataUrl,
            string activateInactivateUrl)
            : base(currentPerson, false)
        {
            Person = personToView;
            PageTitle = personToView.FullNameFirstLast + (!personToView.IsActive ? " (inactive)" : string.Empty);
            EntityName = "User";
            //TODO: This gets pulled up to root
            EditPersonOrganizationPrimaryContactUrl = SitkaRoute<PersonOrganizationController>.BuildUrlFromExpression(c => c.EditPersonOrganizationPrimaryContacts(personToView));
            Index = SitkaRoute<UserController>.BuildUrlFromExpression(x => x.Index());

            UserHasPersonViewPermissions = new UserViewFeature().HasPermissionByPerson(currentPerson);
            UserHasPersonManagePermissions = new UserEditFeature().HasPermissionByPerson(currentPerson);
            UserHasViewEverythingPermissions = new AdminReadOnlyViewEverythingFeature().HasPermissionByPerson(currentPerson);
            IsViewingSelf = currentPerson != null && currentPerson.PersonID == personToView.PersonID;
            EditRolesLink = UserHasPersonManagePermissions
                ? ModalDialogFormHelper.MakeEditIconLink(SitkaRoute<UserController>.BuildUrlFromExpression(c => c.EditRoles(personToView)),
                    string.Format("Edit Roles for User - {0}", personToView.FullNameFirstLast),
                    true)
                : new HtmlString(string.Empty);

            BasicProjectInfoGridSpec = basicProjectInfoGridSpec;
            BasicProjectInfoGridName = basicProjectInfoGridName;
            BasicProjectInfoGridDataUrl = basicProjectInfoGridDataUrl;

            UserNotificationGridSpec = userNotificationGridSpec;
            UserNotificationGridName = userNotificationGridName;
            UserNotificationGridDataUrl = userNotificationGridDataUrl;
            ActivateInactivateUrl = activateInactivateUrl;
        }

        public readonly HtmlString EditRolesLink;
    }
}