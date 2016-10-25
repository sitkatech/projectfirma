using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class NotFoundViewData : FirmaViewData
    {
        public NotFoundViewData(Person currentPerson)
            : base(currentPerson)
        {
            HtmlPageTitle = "Page Not Found";
            PageTitle = "Page Not Found";
        }
    }
}