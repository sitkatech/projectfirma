using ProjectFirma.Web.Views;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ThresholdCategory
{
    public class IndexViewData : FirmaViewData
    {
        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = "Threshold Categories, Reporting Categories, and Indicators";
        }
    }
}