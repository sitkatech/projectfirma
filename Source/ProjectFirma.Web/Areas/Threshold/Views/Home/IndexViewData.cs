using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Areas.Threshold.Views.Home
{
    public class IndexViewData : ThresholdViewData
    {
        public readonly List<Models.ThresholdCategory> ThresholdCategories;

        public IndexViewData(Person currentPerson, ProjectFirmaPage projectFirmaPage, List<Models.ThresholdCategory> thresholdCategories) : base(currentPerson, projectFirmaPage)
        {
            ThresholdCategories = thresholdCategories;
            PageTitle = "Threshold Dashboard";
        }
    }
}