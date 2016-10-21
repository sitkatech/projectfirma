using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.EIPPerformanceMeasureActual
{
    public class EditEIPPerformanceMeasureActualsViewModel : FormViewModel, IValidatableObject
    {
        public string Explanation { get; set; }
        public List<ProjectExemptReportingYearSimple> ProjectExemptReportingYears { get; set; }
        public List<EIPPerformanceMeasureActualSimple> EIPPerformanceMeasureActuals { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditEIPPerformanceMeasureActualsViewModel()
        {
        }

        public EditEIPPerformanceMeasureActualsViewModel(List<EIPPerformanceMeasureActualSimple> eipPerformanceMeasureActuals) : this(eipPerformanceMeasureActuals, null, null)
        {
        }

        public EditEIPPerformanceMeasureActualsViewModel(List<EIPPerformanceMeasureActualSimple> eipPerformanceMeasureActuals,
            string explanation,
            List<ProjectExemptReportingYearSimple> projectExemptReportingYears)
        {
            EIPPerformanceMeasureActuals = eipPerformanceMeasureActuals;
            Explanation = explanation;
            ProjectExemptReportingYears = projectExemptReportingYears;
        }

        public void UpdateModel(List<Models.EIPPerformanceMeasureActual> currentEIPPerformanceMeasureActuals,
            IList<Models.EIPPerformanceMeasureActual> allEIPPerformanceMeasureActuals,
            IList<EIPPerformanceMeasureActualSubcategoryOption> allEIPPerformanceMeasureActualSubcategoryOptions,
            Models.Project project)
        {
            UpdateModelImpl(currentEIPPerformanceMeasureActuals, allEIPPerformanceMeasureActuals, allEIPPerformanceMeasureActualSubcategoryOptions);
            var currentProjectExemptYears = project.ProjectExemptReportingYears.ToList();
            HttpRequestStorage.DatabaseEntities.ProjectExemptReportingYears.Load();
            var allProjectExemptYears = HttpRequestStorage.DatabaseEntities.ProjectExemptReportingYears.Local;
            var projectExemptReportingYears = new List<ProjectExemptReportingYear>();
            if (ProjectExemptReportingYears != null)
            {
                // Completely rebuild the list
                projectExemptReportingYears =
                    ProjectExemptReportingYears.Where(x => x.IsExempt).Select(x => new ProjectExemptReportingYear(x.ProjectExemptReportingYearID, x.ProjectID, x.CalendarYear)).ToList();
            }
            currentProjectExemptYears.Merge(projectExemptReportingYears, allProjectExemptYears, (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear);
            project.EIPPerformanceMeasureActualYearsExemptionExplanation = Explanation;
        }

        private void UpdateModelImpl(List<Models.EIPPerformanceMeasureActual> currentEIPPerformanceMeasureActuals,
            IList<Models.EIPPerformanceMeasureActual> allEIPPerformanceMeasureActuals,
            IList<EIPPerformanceMeasureActualSubcategoryOption> allEIPPerformanceMeasureActualSubcategoryOptions)
        {
            // Remove all existing associations
            currentEIPPerformanceMeasureActuals.ForEach(pmav =>
            {
                pmav.EIPPerformanceMeasureActualSubcategoryOptions.ToList().ForEach(pmavso => allEIPPerformanceMeasureActualSubcategoryOptions.Remove(pmavso));
                allEIPPerformanceMeasureActuals.Remove(pmav);
            });
            currentEIPPerformanceMeasureActuals.Clear();

            if (EIPPerformanceMeasureActuals != null)
            {
                // Completely rebuild the list
                foreach (var x in EIPPerformanceMeasureActuals)
                {
                    var eipPerformanceMeasureActual = new Models.EIPPerformanceMeasureActual(x.ProjectID.Value, x.EIPPerformanceMeasureID.Value, x.CalendarYear.Value, x.ActualValue.Value);
                    allEIPPerformanceMeasureActuals.Add(eipPerformanceMeasureActual);
                    if (x.EIPPerformanceMeasureActualSubcategoryOptions != null)
                    {
                        x.EIPPerformanceMeasureActualSubcategoryOptions.ForEach(
                            y =>
                                allEIPPerformanceMeasureActualSubcategoryOptions.Add(new EIPPerformanceMeasureActualSubcategoryOption(
                                    eipPerformanceMeasureActual.EIPPerformanceMeasureActualID,
                                    y.IndicatorSubcategoryOptionID.Value,
                                    y.EIPPerformanceMeasureID,
                                    y.IndicatorSubcategoryID)));
                    }
                }
            }
        }
        /*
         * JHB & LC 10/10/16: We fixed issues around validating when Subcategory Options are not selected, but this ViewModel still has a bug. To reproduce:
         * 1. Open "Reported Performance Measures" dialog
         * 2. Click "What is my project has no accomplishments to report..."
         * 3. Select a year, but do not enter any explanation text
         * 4. Save
         * 5. Select a Performance Measure and hit "Add". 
         * 6. Angular pukes.            
         */
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (ProjectExemptReportingYears != null && ProjectExemptReportingYears.Any(x => x.IsExempt) && string.IsNullOrWhiteSpace(Explanation))
            {
                errors.Add(new ValidationResult(ProjectFirmaValidationMessages.ExplanationNecessaryForProjectExemptYears));
            }

            if ((ProjectExemptReportingYears == null || !ProjectExemptReportingYears.Any(x => x.IsExempt)) && !string.IsNullOrWhiteSpace(Explanation))
            {
                errors.Add(new ValidationResult(ProjectFirmaValidationMessages.ExplanationNotNecessaryForProjectExemptYears));
            }

            

            return errors;
        }
    }
}