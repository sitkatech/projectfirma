using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class NotFoundViewData : EIPViewData
    {
        public NotFoundViewData(Person currentPerson)
            : base(currentPerson)
        {
            HtmlPageTitle = "Page Not Found";
            PageTitle = "Page Not Found";
        }
    }
}