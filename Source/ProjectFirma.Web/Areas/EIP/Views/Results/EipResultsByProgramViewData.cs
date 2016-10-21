using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Indicator;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.Results
{
    public class EipResultsByProgramViewData : EIPViewData
    {
        public readonly List<Models.FocusArea> FocusAreas;
        public readonly Models.Program SelectedProgram;
        public readonly string EipResultsByProgramUrl;
        public readonly List<IndicatorChartViewData> IndicatorChartViewDatas;

        public EipResultsByProgramViewData(Person currentPerson,
            ProjectFirmaPage projectFirmaPage,
            List<Models.FocusArea> focusAreas,
            Models.Program selectedProgram) : base(currentPerson, projectFirmaPage)
        {
            FocusAreas = focusAreas;
            PageTitle = "EIP Results by Program";
            SelectedProgram = selectedProgram;
            EipResultsByProgramUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.EipResultsByProgram(UrlTemplate.Parameter1Int));

            var projectIDs = selectedProgram.Projects.Select(y => y.ProjectID).ToList();
            IndicatorChartViewDatas =
                selectedProgram.GetEIPPerformanceMeasures()
                    .Select(x => x.Indicator)
                    .ToList()
                    .OrderBy(x => x.DisplayOrder)
                    .Select(x => new IndicatorChartViewData(x, true, ChartViewMode.Small, projectIDs))
                    .ToList();
        }
    }
}