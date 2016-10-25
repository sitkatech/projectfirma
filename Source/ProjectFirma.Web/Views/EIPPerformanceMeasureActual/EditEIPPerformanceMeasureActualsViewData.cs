using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.EIPPerformanceMeasureActual
{
    public class EditEIPPerformanceMeasureActualsViewData : FirmaUserControlViewData
    {
        public readonly List<EIPPerformanceMeasureSimple> AllEIPPerformanceMeasures;
        public readonly List<IndicatorSubcategorySimple> AllIndicatorSubcategories;
        public readonly List<IndicatorSubcategoryOptionSimple> AllIndicatorSubcategoryOptions;
        public readonly List<ProjectSimple> AllProjects;
        public readonly int? ProjectID;
        public readonly List<int> CalendarYears;
        public readonly bool ShowExemptYears;

        private EditEIPPerformanceMeasureActualsViewData(List<ProjectSimple> allProjects, List<Models.EIPPerformanceMeasure> allEIPPerformanceMeasures, Models.Project project, bool showExemptYears)
        {
            ShowExemptYears = showExemptYears;
            ProjectID = project.ProjectID;
            AllEIPPerformanceMeasures = allEIPPerformanceMeasures.Select(x => new EIPPerformanceMeasureSimple(x)).OrderBy(p => p.EIPPerformanceMeasureID).ToList();
            var eipPerformanceMeasureSubcategories = allEIPPerformanceMeasures.SelectMany(x => x.IndicatorSubcategories).ToList();
            var indicatorSubcategories = eipPerformanceMeasureSubcategories.Distinct(new HavePrimaryKeyComparer<IndicatorSubcategory>()).ToList();
            AllIndicatorSubcategories = indicatorSubcategories.Select(x => new IndicatorSubcategorySimple(x)).ToList();
            AllIndicatorSubcategoryOptions = indicatorSubcategories.SelectMany(y => y.IndicatorSubcategoryOptions.Select(z => new IndicatorSubcategoryOptionSimple(z))).ToList();
            AllProjects = allProjects;
            CalendarYears = ProjectFirmaDateUtilities.ReportingYearsForUserInput().OrderByDescending(x => x).ToList();
        }

        public EditEIPPerformanceMeasureActualsViewData(Models.Project project, List<Models.EIPPerformanceMeasure> allEIPPerformanceMeasures, bool showExemptYears)
            : this(new List<ProjectSimple> {new ProjectSimple(project)}, allEIPPerformanceMeasures, project, showExemptYears)
        {
        }
    }
}