using System.Web;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class OrganizationModelExtensions
    {
        public readonly static UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<OrganizationController>.BuildUrlFromExpression(t => t.DeleteOrganization(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this Organization organization)
        {
            return DeleteUrlTemplate.ParameterReplace(organization.OrganizationID);
        }

        public static HtmlString GetDisplayNameAsUrl(this Organization organization)
        {          
            return UrlTemplate.MakeHrefString(organization.GetSummaryUrl(), organization.DisplayName);
        }

        public readonly static UrlTemplate<int> SummaryUrlTemplate = new UrlTemplate<int>(SitkaRoute<OrganizationController>.BuildUrlFromExpression(t => t.Summary(UrlTemplate.Parameter1Int)));
        public static string GetSummaryUrl(this Organization organization)
        {
            if (organization == null) {return "";}
            return SummaryUrlTemplate.ParameterReplace(organization.OrganizationID);
        }
    }
}