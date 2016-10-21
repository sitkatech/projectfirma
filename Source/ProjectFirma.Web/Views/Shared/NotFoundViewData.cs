using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class NotFoundViewData : SiteLayoutViewData
    {
        public NotFoundViewData(Person currentPerson)
            : base(currentPerson)
        {
            HtmlPageTitle = "Page Not Found";
            PageTitle = "Page Not Found";
        }
    }
}