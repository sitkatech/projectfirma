using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.PerformanceMeasure;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Program
{
    public class SummaryViewData : FirmaViewData
    {
        public readonly Models.Program Program;
        public readonly List<Models.PerformanceMeasure> PerformanceMeasures;
        public readonly int PerformanceMeasuresEndOfFirstHalf;

        public readonly bool UserHasProgramManagePermissions;
        public readonly string EditProgramUrl;

        public readonly string BackUrl;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string FiveYearListProjectGridName;
        public readonly string FiveYearListProjectGridDataUrl;
        public readonly string EditDescriptionUrl;

        public readonly ProjectTaxonomyViewData ProjectTaxonomyViewData;

        public readonly List<Models.PerformanceMeasure> ProgramPerformanceMeasures;

        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;
        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly string ProjectMapFilteredUrl;

        public readonly List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas;

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
            new ProgramPerformanceMeasureManageFeature().HasPermissionByPerson(currentPerson);
            PerformanceMeasures = program.ProgramPerformanceMeasures.Select(x => x.PerformanceMeasure).OrderBy(x => x.DisplayOrder).ToList();
            PerformanceMeasuresEndOfFirstHalf = GeneralUtility.CalculateIndexOfEndOfFirstHalf(PerformanceMeasures.Count);

            ProjectMapFilteredUrl = ProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();

            var projectIDs = Program.Projects.Select(y => y.ProjectID).ToList();
            PerformanceMeasureChartViewDatas =
                Program.GetPerformanceMeasures()
                    .ToList()
                    .OrderBy(x => x.DisplayOrder)
                    .Select(x => new PerformanceMeasureChartViewData(x, true, ChartViewMode.Small, projectIDs))
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

            ProgramPerformanceMeasures = program.GetPerformanceMeasures().OrderBy(x => x.PerformanceMeasureID).ToList();
        }
    }
}