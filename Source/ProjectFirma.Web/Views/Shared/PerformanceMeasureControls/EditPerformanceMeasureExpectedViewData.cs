using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.PerformanceMeasureControls
{
    public class EditPerformanceMeasureExpectedViewData : FirmaUserControlViewData
    {
        public readonly List<PerformanceMeasureSimple> AllPerformanceMeasures;
        public readonly List<PerformanceMeasureSubcategorySimple> AllPerformanceMeasureSubcategories;
        public readonly List<PerformanceMeasureSubcategoryOptionSimple> AllPerformanceMeasureSubcategoryOptions;
        public readonly List<ProjectSimple> AllProjects;
        public readonly int? ProjectID;

        private EditPerformanceMeasureExpectedViewData(List<ProjectSimple> allProjects, List<Models.PerformanceMeasure> allPerformanceMeasures, int projectID)
        {
            ProjectID = projectID;
            AllPerformanceMeasures = allPerformanceMeasures.Select(x => new PerformanceMeasureSimple(x)).OrderBy(p => p.PerformanceMeasureID).ToList();
            var performanceMeasureSubcategories =
                allPerformanceMeasures.SelectMany(x => x.PerformanceMeasureSubcategories).Distinct(new HavePrimaryKeyComparer<PerformanceMeasureSubcategory>()).ToList();
            AllPerformanceMeasureSubcategories = performanceMeasureSubcategories.Select(x => new PerformanceMeasureSubcategorySimple(x)).ToList();
            AllPerformanceMeasureSubcategoryOptions = performanceMeasureSubcategories.SelectMany(y => y.PerformanceMeasureSubcategoryOptions.Select(z => new PerformanceMeasureSubcategoryOptionSimple(z))).ToList();
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