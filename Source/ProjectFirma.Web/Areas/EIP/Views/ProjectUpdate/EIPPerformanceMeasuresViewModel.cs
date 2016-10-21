using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectUpdate
{
    public class EIPPerformanceMeasuresViewModel : FormViewModel, IValidatableObject
    {
        public string Explanation { get; set; }
        public List<ProjectExemptReportingYearUpdateSimple> ProjectExemptReportingYearUpdates { get; set; }
        public List<EIPPerformanceMeasureActualUpdateSimple> EIPPerformanceMeasureActualUpdates { get; set; }
        [DisplayName("Show Validation Warnings?")]
        public bool ShowValidationWarnings { get; set; }

        [DisplayName("Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.EIPPerformanceMeasuresComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EIPPerformanceMeasuresViewModel()
        {
        }

        public EIPPerformanceMeasuresViewModel(List<EIPPerformanceMeasureActualUpdateSimple> eipPerformanceMeasureActualUpdates,
            string explanation,
            List<ProjectExemptReportingYearUpdateSimple> projectExemptReportingYearUpdates,
            bool showValidationWarnings,
            string comments)
        {
            EIPPerformanceMeasureActualUpdates = eipPerformanceMeasureActualUpdates;
            Explanation = explanation;
            ProjectExemptReportingYearUpdates = projectExemptReportingYearUpdates;
            ShowValidationWarnings = showValidationWarnings;
            Comments = comments;
        }

        public void UpdateModel(List<EIPPerformanceMeasureActualUpdate> currentEIPPerformanceMeasureActualUpdates,
            IList<EIPPerformanceMeasureActualUpdate> allEIPPerformanceMeasureActualUpdates,
            IList<EIPPerformanceMeasureActualSubcategoryOptionUpdate> allEIPPerformanceMeasureActualSubcategoryOptionUpdates,
            ProjectUpdateBatch projectUpdateBatch)
        {
            var currentEIPPerformanceMeasureActualSubcategoryOptionUpdates =
                currentEIPPerformanceMeasureActualUpdates.SelectMany(x => x.EIPPerformanceMeasureActualSubcategoryOptionUpdates).ToList();
            var eipPerformanceMeasureActualUpdatesUpdated = new List<EIPPerformanceMeasureActualUpdate>();

            if (EIPPerformanceMeasureActualUpdates != null)
            {
                // Completely rebuild the list
                eipPerformanceMeasureActualUpdatesUpdated = EIPPerformanceMeasureActualUpdates.Select(x =>
                {
                    var eipPerformanceMeasureActual = new EIPPerformanceMeasureActualUpdate(x.EIPPerformanceMeasureActualUpdateID,
                        x.ProjectUpdateBatchID,
                        x.EIPPerformanceMeasureID,
                        x.CalendarYear.Value,
                        x.ActualValue);
                    if (x.EIPPerformanceMeasureActualSubcategoryOptionUpdates != null)
                    {
                        eipPerformanceMeasureActual.EIPPerformanceMeasureActualSubcategoryOptionUpdates =
                            x.EIPPerformanceMeasureActualSubcategoryOptionUpdates.Where(pmavsou => ModelObjectHelpers.IsRealPrimaryKeyValue(pmavsou.IndicatorSubcategoryOptionID))
                                .Select(
                                    y =>
                                        new EIPPerformanceMeasureActualSubcategoryOptionUpdate(eipPerformanceMeasureActual.EIPPerformanceMeasureActualUpdateID,
                                            y.IndicatorSubcategoryOptionID.Value,
                                            y.EIPPerformanceMeasureID,
                                            y.IndicatorSubcategoryID))
                                .ToList();
                    }
                    return eipPerformanceMeasureActual;
                }).ToList();
            }
            currentEIPPerformanceMeasureActualUpdates.Merge(eipPerformanceMeasureActualUpdatesUpdated,
                allEIPPerformanceMeasureActualUpdates,
                (x, y) => x.EIPPerformanceMeasureActualUpdateID == y.EIPPerformanceMeasureActualUpdateID,
                (x, y) =>
                {
                    x.CalendarYear = y.CalendarYear;
                    x.ActualValue = y.ActualValue;
                });

            currentEIPPerformanceMeasureActualSubcategoryOptionUpdates.Merge(
                eipPerformanceMeasureActualUpdatesUpdated.SelectMany(x => x.EIPPerformanceMeasureActualSubcategoryOptionUpdates).ToList(),
                allEIPPerformanceMeasureActualSubcategoryOptionUpdates,
                (x, y) => x.EIPPerformanceMeasureActualUpdateID == y.EIPPerformanceMeasureActualUpdateID && x.IndicatorSubcategoryID == y.IndicatorSubcategoryID && x.EIPPerformanceMeasureID == y.EIPPerformanceMeasureID,
                (x, y) => x.IndicatorSubcategoryOptionID = y.IndicatorSubcategoryOptionID);

            var currentProjectExemptYearUpdates = projectUpdateBatch.ProjectExemptReportingYearUpdates.ToList();
            HttpRequestStorage.DatabaseEntities.ProjectExemptReportingYearUpdates.Load();
            var allProjectExemptYearUpdates = HttpRequestStorage.DatabaseEntities.ProjectExemptReportingYearUpdates.Local;
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
            projectUpdateBatch.EIPPerformanceMeasureActualYearsExemptionExplanation = Explanation;
            projectUpdateBatch.ShowEIPPerformanceMeasuresValidationWarnings = ShowValidationWarnings;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (ProjectExemptReportingYearUpdates != null && ProjectExemptReportingYearUpdates.Any(x => x.IsExempt) && string.IsNullOrWhiteSpace(Explanation))
            {
                errors.Add(new SitkaValidationResult<EIPPerformanceMeasuresViewModel, string>(ProjectFirmaValidationMessages.ExplanationNecessaryForProjectExemptYears, x => x.Explanation));
            }

            if ((ProjectExemptReportingYearUpdates == null || !ProjectExemptReportingYearUpdates.Any(x => x.IsExempt)) && !string.IsNullOrWhiteSpace(Explanation))
            {
                errors.Add(new SitkaValidationResult<EIPPerformanceMeasuresViewModel, string>(ProjectFirmaValidationMessages.ExplanationNotNecessaryForProjectExemptYears, x => x.Explanation));
            }

            return errors;
        }
    }
}