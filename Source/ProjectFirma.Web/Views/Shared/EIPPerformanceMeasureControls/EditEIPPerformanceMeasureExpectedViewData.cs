using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Shared.EIPPerformanceMeasureControls
{
    public class EditEIPPerformanceMeasureExpectedViewData : FirmaUserControlViewData
    {
        public readonly List<EIPPerformanceMeasureSimple> AllEIPPerformanceMeasures;
        public readonly List<IndicatorSubcategorySimple> AllIndicatorSubcategories;
        public readonly List<IndicatorSubcategoryOptionSimple> AllIndicatorSubcategoryOptions;
        public readonly List<ProjectSimple> AllProjects;
        public readonly int? ProjectID;

        private EditEIPPerformanceMeasureExpectedViewData(List<ProjectSimple> allProjects, List<Models.EIPPerformanceMeasure> allEIPPerformanceMeasures, int projectID)
        {
            ProjectID = projectID;
            AllEIPPerformanceMeasures = allEIPPerformanceMeasures.Select(x => new EIPPerformanceMeasureSimple(x)).OrderBy(p => p.EIPPerformanceMeasureID).ToList();
            var eipPerformanceMeasureSubcategories = allEIPPerformanceMeasures.SelectMany(x => x.IndicatorSubcategories).ToList();
            var indicatorSubcategories = eipPerformanceMeasureSubcategories.Distinct(new HavePrimaryKeyComparer<IndicatorSubcategory>()).ToList();
            AllIndicatorSubcategories = indicatorSubcategories.Select(x => new IndicatorSubcategorySimple(x)).ToList();
            AllIndicatorSubcategoryOptions = indicatorSubcategories.SelectMany(y => y.IndicatorSubcategoryOptions.Select(z => new IndicatorSubcategoryOptionSimple(z))).ToList();
            AllProjects = allProjects;
        }

        public EditEIPPerformanceMeasureExpectedViewData(Models.Project project, List<Models.EIPPerformanceMeasure> allEIPPerformanceMeasures)
            : this(new List<ProjectSimple> { new ProjectSimple(project)}, allEIPPerformanceMeasures, project.ProjectID)
        {
        }

        public EditEIPPerformanceMeasureExpectedViewData(Models.ProposedProject proposedProject, List<Models.EIPPerformanceMeasure> allEIPPerformanceMeasures)
            : this(new List<ProjectSimple> { new ProjectSimple(proposedProject) }, allEIPPerformanceMeasures, proposedProject.ProposedProjectID)
        {
        }
    }
}