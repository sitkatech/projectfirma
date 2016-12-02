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
        public readonly List<PerformanceMeasureSubcategorySimple> AllPerformanceMeasureSubcategories;
        public readonly List<PerformanceMeasureSubcategoryOptionSimple> AllPerformanceMeasureSubcategoryOptions;
        public readonly List<ProjectSimple> AllProjects;
        public readonly int? ProjectID;
        public readonly List<int> CalendarYears;
        public readonly bool ShowExemptYears;

        private EditPerformanceMeasureActualsViewData(List<ProjectSimple> allProjects, List<Models.PerformanceMeasure> allPerformanceMeasures, Models.Project project, bool showExemptYears)
        {
            ShowExemptYears = showExemptYears;
            ProjectID = project.ProjectID;
            AllPerformanceMeasures = allPerformanceMeasures.Select(x => new PerformanceMeasureSimple(x)).OrderBy(p => p.PerformanceMeasureID).ToList();
            var performanceMeasureSubcategories =
                allPerformanceMeasures.SelectMany(x => x.PerformanceMeasureSubcategories).Distinct(new HavePrimaryKeyComparer<PerformanceMeasureSubcategory>()).ToList();
            AllPerformanceMeasureSubcategories = performanceMeasureSubcategories.Select(x => new PerformanceMeasureSubcategorySimple(x)).ToList();
            AllPerformanceMeasureSubcategoryOptions = performanceMeasureSubcategories.SelectMany(y => y.PerformanceMeasureSubcategoryOptions.Select(z => new PerformanceMeasureSubcategoryOptionSimple(z))).ToList();
            AllProjects = allProjects;
            CalendarYears = FirmaDateUtilities.ReportingYearsForUserInput().OrderByDescending(x => x).ToList();
        }

        public EditPerformanceMeasureActualsViewData(Models.Project project, List<Models.PerformanceMeasure> allPerformanceMeasures, bool showExemptYears)
            : this(new List<ProjectSimple> {new ProjectSimple(project)}, allPerformanceMeasures, project, showExemptYears)
        {
        }
    }
}