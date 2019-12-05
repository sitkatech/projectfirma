/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasuresViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ReportedPerformanceMeasuresViewModel : FormViewModel, IValidatableObject
    {
        public string Explanation { get; set; }
        public List<ProjectExemptReportingYearUpdateSimple> ProjectExemptReportingYearUpdates { get; set; }
        public List<PerformanceMeasureActualUpdateSimple> PerformanceMeasureActualUpdates { get; set; }

        [DisplayName("Review Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.ReportedPerformanceMeasuresComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ReportedPerformanceMeasuresViewModel()
        {
        }

        public ReportedPerformanceMeasuresViewModel(List<PerformanceMeasureActualUpdateSimple> performanceMeasureActualUpdates,
            string explanation,
            List<ProjectExemptReportingYearUpdateSimple> projectExemptReportingYearUpdates,
            string comments)
        {
            PerformanceMeasureActualUpdates = performanceMeasureActualUpdates;
            Explanation = explanation;
            ProjectExemptReportingYearUpdates = projectExemptReportingYearUpdates;
            Comments = comments;
        }

        public void UpdateModel(List<PerformanceMeasureActualUpdate> currentPerformanceMeasureActualUpdates,
            IList<PerformanceMeasureActualUpdate> allPerformanceMeasureActualUpdates,
            IList<PerformanceMeasureActualSubcategoryOptionUpdate> allPerformanceMeasureActualSubcategoryOptionUpdates,
            ProjectUpdateBatch projectUpdateBatch,
            IList<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods)
        {
            var currentPerformanceMeasureActualSubcategoryOptionUpdates =
                currentPerformanceMeasureActualUpdates.SelectMany(x => x.PerformanceMeasureActualSubcategoryOptionUpdates).ToList();
            var performanceMeasureActualUpdatesUpdated = new List<PerformanceMeasureActualUpdate>();

            if (PerformanceMeasureActualUpdates != null)
            {
                // Completely rebuild the list
                performanceMeasureActualUpdatesUpdated = PerformanceMeasureActualUpdates.Select(pmaus =>
                {
                    var performanceMeasureReportingPeriod = allPerformanceMeasureReportingPeriods.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodCalendarYear == pmaus.CalendarYear);
                    if (performanceMeasureReportingPeriod == null)
                    {
                        Check.EnsureNotNull(pmaus.PerformanceMeasureID, "We need to have a performance measure.");
                        performanceMeasureReportingPeriod = new PerformanceMeasureReportingPeriod((int)pmaus.PerformanceMeasureID, pmaus.CalendarYear, pmaus.CalendarYear.ToString());
                        allPerformanceMeasureReportingPeriods.Add(performanceMeasureReportingPeriod);
                        HttpRequestStorage.DatabaseEntities.SaveChanges();
                    }

                    var performanceMeasureActual = new PerformanceMeasureActualUpdate(pmaus.PerformanceMeasureActualUpdateID,
                        pmaus.ProjectUpdateBatchID,
                        pmaus.PerformanceMeasureID,
                        pmaus.ActualValue,
                        performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID);
                    if (pmaus.PerformanceMeasureActualSubcategoryOptionUpdates != null)
                    {
                        performanceMeasureActual.PerformanceMeasureActualSubcategoryOptionUpdates =
                            pmaus.PerformanceMeasureActualSubcategoryOptionUpdates.Where(pmavsou =>
                                ModelObjectHelpers.IsRealPrimaryKeyValue(pmavsou.PerformanceMeasureSubcategoryOptionID))
                            .Select(
                                y =>
                                    new PerformanceMeasureActualSubcategoryOptionUpdate(
                                        performanceMeasureActual.PerformanceMeasureActualUpdateID,
                                        y.PerformanceMeasureSubcategoryOptionID.Value,
                                        y.PerformanceMeasureID,
                                        y.PerformanceMeasureSubcategoryID))
                            .ToList();
                    }

                    return performanceMeasureActual;
                }).ToList();
            }

            var databaseEntities = HttpRequestStorage.DatabaseEntities;
            currentPerformanceMeasureActualUpdates.Merge(performanceMeasureActualUpdatesUpdated,
                allPerformanceMeasureActualUpdates,
                (x, y) => x.PerformanceMeasureActualUpdateID == y.PerformanceMeasureActualUpdateID,
                (x, y) =>
                {
                    x.PerformanceMeasureReportingPeriodID = y.PerformanceMeasureReportingPeriodID;
                    x.ActualValue = y.ActualValue;
                }, databaseEntities);

            currentPerformanceMeasureActualSubcategoryOptionUpdates.Merge(
                performanceMeasureActualUpdatesUpdated.SelectMany(x => x.PerformanceMeasureActualSubcategoryOptionUpdates).ToList(),
                allPerformanceMeasureActualSubcategoryOptionUpdates,
                (x, y) => x.PerformanceMeasureActualUpdateID == y.PerformanceMeasureActualUpdateID && x.PerformanceMeasureSubcategoryID == y.PerformanceMeasureSubcategoryID && x.PerformanceMeasureID == y.PerformanceMeasureID,
                (x, y) => x.PerformanceMeasureSubcategoryOptionID = y.PerformanceMeasureSubcategoryOptionID, databaseEntities);

            var currentProjectExemptYearUpdates = projectUpdateBatch.GetPerformanceMeasuresExemptReportingYears();
            databaseEntities.ProjectExemptReportingYearUpdates.Load();
            var allProjectExemptYearUpdates = databaseEntities.AllProjectExemptReportingYearUpdates.Local;
            var projectExemptReportingYears = new List<ProjectExemptReportingYearUpdate>();
            if (ProjectExemptReportingYearUpdates != null)
            {
                // Completely rebuild the list
                projectExemptReportingYears =
                    ProjectExemptReportingYearUpdates.Where(x => x.IsExempt)
                        .Select(x => new ProjectExemptReportingYearUpdate(x.ProjectExemptReportingYearUpdateID, x.ProjectUpdateBatchID, x.CalendarYear, ProjectExemptReportingType.PerformanceMeasures.ProjectExemptReportingTypeID))
                        .ToList();
            }
            currentProjectExemptYearUpdates.Merge(projectExemptReportingYears,
                allProjectExemptYearUpdates,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.CalendarYear == y.CalendarYear && x.ProjectExemptReportingTypeID == y.ProjectExemptReportingTypeID, HttpRequestStorage.DatabaseEntities);
            projectUpdateBatch.PerformanceMeasureActualYearsExemptionExplanation = Explanation;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ProjectExemptReportingYearUpdates != null && ProjectExemptReportingYearUpdates.Any(x => x.IsExempt) && string.IsNullOrWhiteSpace(Explanation))
            {
                yield return new SitkaValidationResult<ReportedPerformanceMeasuresViewModel, string>(
                    FirmaValidationMessages.ExplanationNecessaryForProjectExemptYears, x => x.Explanation);
            }
        }
    }
}
