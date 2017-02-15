using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.User
{
    public class IndexGridSpec : GridSpec<Person>
    {
        public IndexGridSpec(Person currentPerson)
        {
            var hasDeletePermission = new UserEditFeature().HasPermissionByPerson(currentPerson);
            if (hasDeletePermission)
            {
                Add(string.Empty,
                    x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), !x.HasDependentObjects(), !x.HasDependentObjects()),
                    30, DhtmlxGridColumnFilterType.None);
            }
            Add("Last Name", a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.LastName), 100, DhtmlxGridColumnFilterType.Html);
            Add("First Name", a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.FirstName), 100, DhtmlxGridColumnFilterType.Html);
            Add("Email", a => a.Email, 200);
            Add("Organization", a => a.Organization.GetDisplayNameAsUrl(), 200);
            Add("Phone", a => a.Phone.ToPhoneNumberString(), 100);
            Add("Username", a => a.LoginName.ToString(), 200);
            Add("Last Activity", a => a.LastActivityDate, 120);
            Add("Role", a => a.Role.GetDisplayNameAsUrl(), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Active?", a => a.IsActive.ToYesNo(), 75, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Receives Support Emails?", a => a.ReceiveSupportEmails.ToYesNo(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Primary Contact for Organizations", a => a.PrimaryContactOrganizations.Count, 120);
        }
    }
}