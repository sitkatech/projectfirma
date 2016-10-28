using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.PerformanceMeasureControls
{
    public class EditPerformanceMeasureExpectedViewData : FirmaUserControlViewData
    {
        public readonly List<PerformanceMeasureSimple> AllPerformanceMeasures;
        public readonly List<IndicatorSubcategorySimple> AllIndicatorSubcategories;
        public readonly List<IndicatorSubcategoryOptionSimple> AllIndicatorSubcategoryOptions;
        public readonly List<ProjectSimple> AllProjects;
        public readonly int? ProjectID;

        private EditPerformanceMeasureExpectedViewData(List<ProjectSimple> allProjects, List<Models.PerformanceMeasure> allPerformanceMeasures, int projectID)
        {
            ProjectID = projectID;
            AllPerformanceMeasures = allPerformanceMeasures.Select(x => new PerformanceMeasureSimple(x)).OrderBy(p => p.PerformanceMeasureID).ToList();
            var performanceMeasureSubcategories = allPerformanceMeasures.SelectMany(x => x.IndicatorSubcategories).ToList();
            var indicatorSubcategories = performanceMeasureSubcategories.Distinct(new HavePrimaryKeyComparer<IndicatorSubcategory>()).ToList();
            AllIndicatorSubcategories = indicatorSubcategories.Select(x => new IndicatorSubcategorySimple(x)).ToList();
            AllIndicatorSubcategoryOptions = indicatorSubcategories.SelectMany(y => y.IndicatorSubcategoryOptions.Select(z => new IndicatorSubcategoryOptionSimple(z))).ToList();
            AllProjects = allProjects;
        }

        public EditPerformanceMeasureExpectedViewData(Models.Project project, List<Models.PerformanceMeasure> allPerformanceMeasures)
            : this(new List<ProjectSimple> { new ProjectSimple(project)}, allPerformanceMeasures, project.ProjectID)
        {
        }

        public EditPerformanceMeasureExpectedViewData(Models.ProposedProject proposedProject, List<Models.PerformanceMeasure> allPerformanceMeasures)
            : this(new List<ProjectSimple> { new ProjectSimple(proposedProject) }, allPerformanceMeasures, proposedProject.ProposedProjectID)
        {
        }
    }
}