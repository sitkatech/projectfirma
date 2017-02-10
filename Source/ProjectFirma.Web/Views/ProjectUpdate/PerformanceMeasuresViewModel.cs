using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class PerformanceMeasuresViewModel : FormViewModel, IValidatableObject
    {
        public string Explanation { get; set; }
        public List<ProjectExemptReportingYearUpdateSimple> ProjectExemptReportingYearUpdates { get; set; }
        public List<PerformanceMeasureActualUpdateSimple> PerformanceMeasureActualUpdates { get; set; }
        [DisplayName("Show Validation Warnings?")]
        public bool ShowValidationWarnings { get; set; }

        [DisplayName("Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.PerformanceMeasuresComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public PerformanceMeasuresViewModel()
        {
        }

        public PerformanceMeasuresViewModel(List<PerformanceMeasureActualUpdateSimple> performanceMeasureActualUpdates,
            string explanation,
            List<ProjectExemptReportingYearUpdateSimple> projectExemptReportingYearUpdates,
            bool showValidationWarnings,
            string comments)
        {
            PerformanceMeasureActualUpdates = performanceMeasureActualUpdates;
            Explanation = explanation;
            ProjectExemptReportingYearUpdates = projectExemptReportingYearUpdates;
            ShowValidationWarnings = showValidationWarnings;
            Comments = comments;
        }

        public void UpdateModel(List<PerformanceMeasureActualUpdate> currentPerformanceMeasureActualUpdates,
            IList<PerformanceMeasureActualUpdate> allPerformanceMeasureActualUpdates,
            IList<PerformanceMeasureActualSubcategoryOptionUpdate> allPerformanceMeasureActualSubcategoryOptionUpdates,
            ProjectUpdateBatch projectUpdateBatch)
        {
            var currentPerformanceMeasureActualSubcategoryOptionUpdates =
                currentPerformanceMeasureActualUpdates.SelectMany(x => x.PerformanceMeasureActualSubcategoryOptionUpdates).ToList();
            var performanceMeasureActualUpdatesUpdated = new List<PerformanceMeasureActualUpdate>();

            if (PerformanceMeasureActualUpdates != null)
            {
                // Completely rebuild the list
                performanceMeasureActualUpdatesUpdated = PerformanceMeasureActualUpdates.Select(x =>
                {
                    var performanceMeasureActual = new PerformanceMeasureActualUpdate(x.PerformanceMeasureActualUpdateID,
                        x.ProjectUpdateBatchID,
                        x.PerformanceMeasureID,
                        x.CalendarYear.Value,
                        x.ActualValue);
                    if (x.PerformanceMeasureActualSubcategoryOptionUpdates != null)
                    {
                        performanceMeasureActual.PerformanceMeasureActualSubcategoryOptionUpdates =
                            x.PerformanceMeasureActualSubcategoryOptionUpdates.Where(pmavsou => ModelObjectHelpers.IsRealPrimaryKeyValue(pmavsou.PerformanceMeasureSubcategoryOptionID))
                                .Select(
                                    y =>
                                        new PerformanceMeasureActualSubcategoryOptionUpdate(performanceMeasureActual.PerformanceMeasureActualUpdateID,
                                            y.PerformanceMeasureSubcategoryOptionID.Value,
                                            y.PerformanceMeasureID,
                                            y.PerformanceMeasureSubcategoryID))
                                .ToList();
                    }
                    return performanceMeasureActual;
                }).ToList();
            }
            currentPerformanceMeasureActualUpdates.Merge(performanceMeasureActualUpdatesUpdated,
                allPerformanceMeasureActualUpdates,
                (x, y) => x.PerformanceMeasureActualUpdateID == y.PerformanceMeasureActualUpdateID,
                (x, y) =>
                {
                    x.CalendarYear = y.CalendarYear;
                    x.ActualValue = y.ActualValue;
                });

            currentPerformanceMeasureActualSubcategoryOptionUpdates.Merge(
                performanceMeasureActualUpdatesUpdated.SelectMany(x => x.PerformanceMeasureActualSubcategoryOptionUpdates).ToList(),
                allPerformanceMeasureActualSubcategoryOptionUpdates,
                (x, y) => x.PerformanceMeasureActualUpdateID == y.PerformanceMeasureActualUpdateID && x.PerformanceMeasureSubcategoryID == y.PerformanceMeasureSubcategoryID && x.PerformanceMeasureID == y.PerformanceMeasureID,
                (x, y) => x.PerformanceMeasureSubcategoryOptionID = y.PerformanceMeasureSubcategoryOptionID);

            var currentProjectExemptYearUpdates = projectUpdateBatch.ProjectExemptReportingYearUpdates.ToList();
            HttpRequestStorage.DatabaseEntities.ProjectExemptReportingYearUpdates.Load();
            var allProjectExemptYearUpdates = HttpRequestStorage.DatabaseEntities.AllProjectExemptReportingYearUpdates.Local;
            var projectExemptReportingYears = new List<ProjectExemptReportingYearUpdate>();
            if (ProjectExemptReportingYearUpdates != null)
            {
                // Completely rebuild the list
                projectExemptReportingYears =
                    ProjectExemptReportingYearUpdates.Where(x => x.IsExempt)
                        .Select(x => new ProjectExemptReportingYearUpdate(x.ProjectExemptReportingYearUpdateID, x.ProjectUpdateBatchID, x.CalendarYear))
                        .ToList();
            }
            currentProjectExemptYearUpdates.Merge(projectExemptReportingYears,
                allProjectExemptYearUpdates,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.CalendarYear == y.CalendarYear);
            projectUpdateBatch.PerformanceMeasureActualYearsExemptionExplanation = Explanation;
            projectUpdateBatch.ShowPerformanceMeasuresValidationWarnings = ShowValidationWarnings;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (ProjectExemptReportingYearUpdates != null && ProjectExemptReportingYearUpdates.Any(x => x.IsExempt) && string.IsNullOrWhiteSpace(Explanation))
            {
                errors.Add(new SitkaValidationResult<PerformanceMeasuresViewModel, string>(FirmaValidationMessages.ExplanationNecessaryForProjectExemptYears, x => x.Explanation));
            }

            if ((ProjectExemptReportingYearUpdates == null || !ProjectExemptReportingYearUpdates.Any(x => x.IsExempt)) && !string.IsNullOrWhiteSpace(Explanation))
            {
                errors.Add(new SitkaValidationResult<PerformanceMeasuresViewModel, string>(FirmaValidationMessages.ExplanationNotNecessaryForProjectExemptYears, x => x.Explanation));
            }

            return errors;
        }
    }
}