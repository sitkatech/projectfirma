using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Role
{
    public class PersonWithRoleGridSpec : GridSpec<Person>
    {
        public PersonWithRoleGridSpec()
        {
            Add("Last Name", a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.LastName), 200, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("First Name", a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.FirstName), 200, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Organization", a => a.Organization.DisplayName, 200, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Last Activity", a => a.LastActivityDate.ToString(), 200, DhtmlxGridColumnFilterType.SelectFilterStrict);            
        }
    }
}