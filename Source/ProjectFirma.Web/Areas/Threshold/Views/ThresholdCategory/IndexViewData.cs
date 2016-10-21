using ProjectFirma.Web.Areas.Threshold.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory
{
    public class IndexViewData : ThresholdViewData
    {
        public readonly ThresholdTaxonomyViewData ThresholdTaxonomyViewData;

        public IndexViewData(Person currentPerson, ProjectFirmaPage projectFirmaPage, ThresholdTaxonomyViewData thresholdTaxonomyViewData) : base(currentPerson, projectFirmaPage)
        {
            ThresholdTaxonomyViewData = thresholdTaxonomyViewData;
            PageTitle = "Threshold Categories, Reporting Categories, and Indicators";
        }
    }
}