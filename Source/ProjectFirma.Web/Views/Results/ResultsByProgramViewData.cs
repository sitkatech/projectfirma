using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Indicator;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Results
{
    public class ResultsByProgramViewData : FirmaViewData
    {
        public readonly List<Models.FocusArea> FocusAreas;
        public readonly Models.Program SelectedProgram;
        public readonly string ResultsByProgramUrl;
        public readonly List<IndicatorChartViewData> IndicatorChartViewDatas;

        public ResultsByProgramViewData(Person currentPerson,
            Models.FirmaPage firmaPage,
            List<Models.FocusArea> focusAreas,
            Models.Program selectedProgram) : base(currentPerson, firmaPage)
        {
            FocusAreas = focusAreas;
            PageTitle = "Results by Program";
            SelectedProgram = selectedProgram;
            ResultsByProgramUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.ResultsByProgram(UrlTemplate.Parameter1Int));

            var projectIDs = selectedProgram.Projects.Select(y => y.ProjectID).ToList();
            IndicatorChartViewDatas =
                selectedProgram.GetPerformanceMeasures()
                    .Select(x => x.Indicator)
                    .ToList()
                    .OrderBy(x => x.DisplayOrder)
                    .Select(x => new IndicatorChartViewData(x, true, ChartViewMode.Small, projectIDs))
                    .ToList();
        }
    }
}