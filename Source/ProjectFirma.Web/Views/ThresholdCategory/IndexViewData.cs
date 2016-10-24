using ProjectFirma.Web.Areas.EIP.Views;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ThresholdCategory
{
    public class IndexViewData : EIPViewData
    {
        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Threshold Categories, Reporting Categories, and Indicators";
        }
    }
}