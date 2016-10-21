using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class ErrorViewData : SiteLayoutViewData
    {
        public ErrorViewData(Person currentPerson)
            : base(currentPerson)
        {
            HtmlPageTitle = "Error Page";
            PageTitle = "Error Page";
        }
    }
}