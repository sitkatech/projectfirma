using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasureActual
{
    public class EditPerformanceMeasureActualsViewData : FirmaUserControlViewData
    {
        public readonly List<PerformanceMeasureSimple> AllPerformanceMeasures;
        public readonly List<IndicatorSubcategorySimple> AllIndicatorSubcategories;
        public readonly List<IndicatorSubcategoryOptionSimple> AllIndicatorSubcategoryOptions;
        public readonly List<ProjectSimple> AllProjects;
        public readonly int? ProjectID;
        public readonly List<int> CalendarYears;
        public readonly bool ShowExemptYears;

        private EditPerformanceMeasureActualsViewData(List<ProjectSimple> allProjects, List<Models.PerformanceMeasure> allPerformanceMeasures, Models.Project project, bool showExemptYears)
        {
            ShowExemptYears = showExemptYears;
            ProjectID = project.ProjectID;
            AllPerformanceMeasures = allPerformanceMeasures.Select(x => new PerformanceMeasureSimple(x)).OrderBy(p => p.PerformanceMeasureID).ToList();
            var performanceMeasureSubcategories = allPerformanceMeasures.SelectMany(x => x.IndicatorSubcategories).ToList();
            var indicatorSubcategories = performanceMeasureSubcategories.Distinct(new HavePrimaryKeyComparer<IndicatorSubcategory>()).ToList();
            AllIndicatorSubcategories = indicatorSubcategories.Select(x => new IndicatorSubcategorySimple(x)).ToList();
            AllIndicatorSubcategoryOptions = indicatorSubcategories.SelectMany(y => y.IndicatorSubcategoryOptions.Select(z => new IndicatorSubcategoryOptionSimple(z))).ToList();
            AllProjects = allProjects;
            CalendarYears = FirmaDateUtilities.ReportingYearsForUserInput().OrderByDescending(x => x).ToList();
        }

        public EditPerformanceMeasureActualsViewData(Models.Project project, List<Models.PerformanceMeasure> allPerformanceMeasures, bool showExemptYears)
            : this(new List<ProjectSimple> {new ProjectSimple(project)}, allPerformanceMeasures, project, showExemptYears)
        {
        }
    }
}