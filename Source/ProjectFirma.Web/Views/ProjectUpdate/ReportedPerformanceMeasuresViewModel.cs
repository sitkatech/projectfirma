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
using System.Transactions;
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

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch)
        {

            var allPerformanceMeasureReportingPeriods = HttpRequestStorage.DatabaseEntities.PerformanceMeasureReportingPeriods.ToList();
            var performanceMeasureReportingPeriodsToAdd = new List<PerformanceMeasureReportingPeriod>();

            if (PerformanceMeasureActualUpdates != null)
            {
                foreach (var performanceMeasureActualUpdateSimple in PerformanceMeasureActualUpdates)
                {
                    var performanceMeasureReportingPeriod = allPerformanceMeasureReportingPeriods.SingleOrDefault(x =>
                        x.PerformanceMeasureReportingPeriodCalendarYear ==
                        performanceMeasureActualUpdateSimple.CalendarYear);

                    if (performanceMeasureReportingPeriod == null)
                    {
                        Check.EnsureNotNull(performanceMeasureActualUpdateSimple.PerformanceMeasureID, "We need to have a performance measure.");
                        performanceMeasureReportingPeriod = new PerformanceMeasureReportingPeriod((int)performanceMeasureActualUpdateSimple.PerformanceMeasureID, performanceMeasureActualUpdateSimple.CalendarYear, performanceMeasureActualUpdateSimple.CalendarYear.ToString());
                        performanceMeasureReportingPeriodsToAdd.Add(performanceMeasureReportingPeriod);
                    }

                }
            }

            HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureReportingPeriods.AddRange(performanceMeasureReportingPeriodsToAdd);
            HttpRequestStorage.DatabaseEntities.SaveChanges(IsolationLevel.ReadUncommitted);


            var allPerformanceMeasureReportingPeriodsReloaded = HttpRequestStorage.DatabaseEntities.PerformanceMeasureReportingPeriods.ToList();
            var performanceMeasureActualUpdatesUpdated = new List<PerformanceMeasureActualUpdate>();
            if (PerformanceMeasureActualUpdates != null)
            {
                foreach (var performanceMeasureActualUpdateSimple in PerformanceMeasureActualUpdates)
                {
                    var performanceMeasureReportingPeriod = allPerformanceMeasureReportingPeriodsReloaded.Single(x =>
                        x.PerformanceMeasureReportingPeriodCalendarYear ==
                        performanceMeasureActualUpdateSimple.CalendarYear);
                    var performanceMeasureActual = new PerformanceMeasureActualUpdate(
                        performanceMeasureActualUpdateSimple.PerformanceMeasureActualUpdateID,
                        performanceMeasureActualUpdateSimple.ProjectUpdateBatchID,
                        performanceMeasureActualUpdateSimple.PerformanceMeasureID,
                        performanceMeasureActualUpdateSimple.ActualValue,
                        performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID);
                    if (performanceMeasureActualUpdateSimple.PerformanceMeasureActualSubcategoryOptionUpdates != null)
                    {
                        AddPerformanceMeasureActualSubcategoryOptionUpdates(performanceMeasureActual, performanceMeasureActualUpdateSimple);
                    }

                    performanceMeasureActualUpdatesUpdated.Add(performanceMeasureActual);
                }
            }




            var listOfPerformanceMeasureActualUpdateIDsToMergeWith = performanceMeasureActualUpdatesUpdated
                .Select(x => x.PerformanceMeasureActualUpdateID).ToList();

            var updateList = HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualUpdates.Where(x =>
                listOfPerformanceMeasureActualUpdateIDsToMergeWith.Contains(x.PerformanceMeasureActualUpdateID)).ToList();
            var updateListOfIds = updateList.Select(x => x.PerformanceMeasureActualUpdateID).ToList();

            var deleteList = projectUpdateBatch.PerformanceMeasureActualUpdates.Where(x =>
                    !listOfPerformanceMeasureActualUpdateIDsToMergeWith.Contains(x.PerformanceMeasureActualUpdateID))
                .ToList();
            var deleteListOfIds = deleteList.Select(x => x.PerformanceMeasureActualUpdateID).ToList();
            updateListOfIds.AddRange(deleteListOfIds);

            var addList = performanceMeasureActualUpdatesUpdated
                .Where(x => !ModelObjectHelpers.IsRealPrimaryKeyValue(x.PerformanceMeasureActualUpdateID) || !updateListOfIds.Contains(x.PerformanceMeasureActualUpdateID)).ToList();

            foreach (var performanceMeasureActualUpdate in updateList)
            {
                var update = performanceMeasureActualUpdatesUpdated.Single(x => x.PerformanceMeasureActualUpdateID == performanceMeasureActualUpdate.PerformanceMeasureActualUpdateID);
                performanceMeasureActualUpdate.PerformanceMeasureReportingPeriodID = update.PerformanceMeasureReportingPeriodID;
                performanceMeasureActualUpdate.ActualValue = update.ActualValue;
            }
            HttpRequestStorage.DatabaseEntities.SaveChanges(IsolationLevel.Chaos);

            deleteList.ForEach(x => x.DeleteFull(HttpRequestStorage.DatabaseEntities));
            HttpRequestStorage.DatabaseEntities.SaveChanges(IsolationLevel.ReadUncommitted);


            HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualUpdates.AddRange(addList);
            HttpRequestStorage.DatabaseEntities.SaveChanges(IsolationLevel.ReadUncommitted);

            
            


            var listOfOptionsToAdd = performanceMeasureActualUpdatesUpdated.SelectMany(x => x.PerformanceMeasureActualSubcategoryOptionUpdates).ToList();
            var listOfOptionsToDelete = projectUpdateBatch.PerformanceMeasureActualUpdates
                .SelectMany(x => x.PerformanceMeasureActualSubcategoryOptionUpdates).ToList();
            listOfOptionsToDelete.ForEach(x => x.DeleteFull(HttpRequestStorage.DatabaseEntities));
            HttpRequestStorage.DatabaseEntities.SaveChanges(IsolationLevel.ReadUncommitted);
            HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualSubcategoryOptionUpdates.AddRange(listOfOptionsToAdd);
            HttpRequestStorage.DatabaseEntities.SaveChanges(IsolationLevel.ReadUncommitted);

            var databaseEntities = HttpRequestStorage.DatabaseEntities;
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

        private static void AddPerformanceMeasureActualSubcategoryOptionUpdates(
            PerformanceMeasureActualUpdate performanceMeasureActual,
            PerformanceMeasureActualUpdateSimple performanceMeasureActualUpdateSimple)
        {

            var performanceMeasureActualSubcategoryOptionUpdates = new List<PerformanceMeasureActualSubcategoryOptionUpdate>();
            var optionUpdates = performanceMeasureActualUpdateSimple.PerformanceMeasureActualSubcategoryOptionUpdates;
            foreach (var optionUpdate in optionUpdates)
            {
                if (ModelObjectHelpers.IsRealPrimaryKeyValue(optionUpdate
                    .PerformanceMeasureSubcategoryOptionID) && optionUpdate
                    .PerformanceMeasureSubcategoryOptionID.HasValue)
                {
                    var performanceMeasureActualSubcategoryOptionUpdate =
                        new PerformanceMeasureActualSubcategoryOptionUpdate(
                            performanceMeasureActual.PerformanceMeasureActualUpdateID
                            , optionUpdate.PerformanceMeasureSubcategoryOptionID.Value
                            , optionUpdate.PerformanceMeasureID
                            , optionUpdate.PerformanceMeasureSubcategoryID);
                    performanceMeasureActualSubcategoryOptionUpdates.Add(performanceMeasureActualSubcategoryOptionUpdate);
                }
            }

            performanceMeasureActual.PerformanceMeasureActualSubcategoryOptionUpdates = performanceMeasureActualSubcategoryOptionUpdates;

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ProjectExemptReportingYearUpdates != null && ProjectExemptReportingYearUpdates.Any(x => x.IsExempt) && string.IsNullOrWhiteSpace(Explanation))
            {
                yield return new SitkaValidationResult<ReportedPerformanceMeasuresViewModel, string>(
                    FirmaValidationMessages.ExplanationNecessaryForProjectExemptYears, x => x.Explanation);
            }
            if (!string.IsNullOrWhiteSpace(Explanation) && Explanation.Length > ProjectUpdateBatch.FieldLengths.PerformanceMeasureActualYearsExemptionExplanation)
            {
                yield return new SitkaValidationResult<ReportedPerformanceMeasuresViewModel, string>(
                    FirmaValidationMessages.ExplanationForProjectExemptYearsExceedsMax(ProjectUpdateBatch.FieldLengths.PerformanceMeasureActualYearsExemptionExplanation), x => x.Explanation);
            }
        }
    }
}
