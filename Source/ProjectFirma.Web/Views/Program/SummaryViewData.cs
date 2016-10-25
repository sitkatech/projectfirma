using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Indicator;
using LtInfo.Common;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Program
{
    public class SummaryViewData : FirmaViewData
    {
        public readonly Models.Program Program;
        public readonly List<Models.EIPPerformanceMeasure> EIPPerformanceMeasures;
        public readonly int EIPPerformanceMeasuresEndOfFirstHalf;

        public readonly bool UserHasProgramManagePermissions;
        public readonly string EditProgramUrl;

        public readonly string BackUrl;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string FiveYearListProjectGridName;
        public readonly string FiveYearListProjectGridDataUrl;
        public readonly string EditDescriptionUrl;

        public readonly ProjectTaxonomyViewData ProjectTaxonomyViewData;

        public readonly List<Models.EIPPerformanceMeasure> ProgramEIPPerformanceMeasures;

        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;
        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly string EipProjectMapFilteredUrl;

        public readonly List<IndicatorChartViewData> IndicatorChartViewDatas;

        public SummaryViewData(Person currentPerson,
            Models.Program program,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData) : base(currentPerson)
        {
            Program = program;
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            PageTitle = program.DisplayName;
            EntityName = "Program";
            new ProgramEIPPerformanceMeasureManageFeature().HasPermissionByPerson(currentPerson);
            EIPPerformanceMeasures = program.ProgramEIPPerformanceMeasures.Select(x => x.EIPPerformanceMeasure).OrderBy(x => x.Indicator.DisplayOrder).ToList();
            EIPPerformanceMeasuresEndOfFirstHalf = GeneralUtility.CalculateIndexOfEndOfFirstHalf(EIPPerformanceMeasures.Count);

            EipProjectMapFilteredUrl = ProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();

            var projectIDs = Program.Projects.Select(y => y.ProjectID).ToList();
            IndicatorChartViewDatas =
                Program.GetEIPPerformanceMeasures()
                    .Select(x => x.Indicator)
                    .ToList()
                    .OrderBy(x => x.DisplayOrder)
                    .Select(x => new IndicatorChartViewData(x, true, ChartViewMode.Small, projectIDs))
                    .ToList();

            UserHasProgramManagePermissions = new ProgramManageFeature().HasPermissionByPerson(CurrentPerson);
            EditProgramUrl = SitkaRoute<ProgramController>.BuildUrlFromExpression(c => c.Edit(program.ProgramID));

            BackUrl = SitkaRoute<ProgramController>.BuildUrlFromExpression(c => c.Index());

            FiveYearListProjectGridName = "programProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                ObjectNameSingular = "Project with this Program",
                ObjectNamePlural = "Projects with this Program",
                SaveFiltersInCookie = true
            };
            FiveYearListProjectGridDataUrl = SitkaRoute<ProgramController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(program));
            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(program);
            EditDescriptionUrl = SitkaRoute<ProgramController>.BuildUrlFromExpression(tc => tc.EditDescription(program));

            ProgramEIPPerformanceMeasures = program.GetEIPPerformanceMeasures().OrderBy(x => x.EIPPerformanceMeasureID).ToList();
        }
    }
}