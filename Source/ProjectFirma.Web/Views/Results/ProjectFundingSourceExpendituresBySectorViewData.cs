using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Results
{
    public class ProjectFundingSourceExpendituresBySectorViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly ProjectFundingSourceExpendituresBySectorGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public ProjectFundingSourceExpendituresBySectorViewData(int? sectorID, int? calendarYear)
        {
            var sectorDisplayString = "all Sectors";
            if (sectorID.HasValue)
            {
                var sector = Sector.AllLookupDictionary[sectorID.Value];
                sectorDisplayString = string.Format("selected Sector: {0}", sector.SectorDisplayName);
            }
            GridSpec = new ProjectFundingSourceExpendituresBySectorGridSpec(calendarYear)
            {
                ObjectNameSingular = string.Format("record by {0}", sectorDisplayString),
                ObjectNamePlural = string.Format("records by {0}", sectorDisplayString),
                SaveFiltersInCookie = true
            };

            GridName = "projectFundingSourceExpendituresBySectorGrid";
            GridDataUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(tc => tc.ProjectExpendituresByFundingSectorGridJsonData(sectorID, calendarYear));
        }
    }
}