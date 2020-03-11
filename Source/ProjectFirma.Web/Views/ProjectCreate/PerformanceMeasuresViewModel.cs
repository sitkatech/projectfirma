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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class PerformanceMeasuresViewModel : FormViewModel, IValidatableObject
    {
        public string Explanation { get; set; }
        public List<ProjectExemptReportingYearSimple> ProjectExemptReportingYearSimples { get; set; }
        public List<PerformanceMeasureActualSimple> PerformanceMeasureActualSimples { get; set; }
        public int? ProjectID { get; set; }

        [DisplayName("Reviewer Comments")]
        [StringLength(ProjectFirmaModels.Models.Project.FieldLengths.ReportedAccomplishmentsComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public PerformanceMeasuresViewModel()
        {
        }

        public PerformanceMeasuresViewModel(List<PerformanceMeasureActualSimple> performanceMeasureActualSimples,
                                            string explanation,
                                            List<ProjectExemptReportingYearSimple> projectExemptReportingYearSimples,
                                            ProjectFirmaModels.Models.Project project)

        {
            PerformanceMeasureActualSimples = performanceMeasureActualSimples;
            Explanation = explanation;
            ProjectExemptReportingYearSimples = projectExemptReportingYearSimples;
            Comments = project.ReportedAccomplishmentsComment;
        }

        public void UpdateModel(List<ProjectFirmaModels.Models.PerformanceMeasureActual> currentPerformanceMeasureActuals,
            IList<ProjectFirmaModels.Models.PerformanceMeasureActual> allPerformanceMeasureActuals,
            IList<PerformanceMeasureActualSubcategoryOption> allPerformanceMeasureActualSubcategoryOptions,
            ProjectFirmaModels.Models.Project project,
            IList<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods)
        {
            var currentPerformanceMeasureActualSubcategoryOptions =
                currentPerformanceMeasureActuals.SelectMany(x => x.PerformanceMeasureActualSubcategoryOptions).ToList();
            var performanceMeasureActualsUpdated = new List<ProjectFirmaModels.Models.PerformanceMeasureActual>();

            if (PerformanceMeasureActualSimples != null)
            {
                // Renumber negative indexes for PerformanceMeasureActuals
                RenumberPerformanceMeasureActuals(PerformanceMeasureActualSimples);

                var performanceMeasureReportingPeriodsFromDatabase = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureReportingPeriods.Local;
                // Completely rebuild the list
                performanceMeasureActualsUpdated = PerformanceMeasureActualSimples.Select(x =>
                {

                    var performanceMeasureReportingPeriod = allPerformanceMeasureReportingPeriods.SingleOrDefault(y => y.PerformanceMeasureReportingPeriodCalendarYear == x.CalendarYear);
                    if (performanceMeasureReportingPeriod == null)
                    {
                        Check.EnsureNotNull(x.PerformanceMeasureID, "We need to have a performance measure.");
                        performanceMeasureReportingPeriod = new PerformanceMeasureReportingPeriod((int)x.PerformanceMeasureID, x.CalendarYear, x.CalendarYear.ToString());
                        performanceMeasureReportingPeriodsFromDatabase.Add(performanceMeasureReportingPeriod);
                        HttpRequestStorage.DatabaseEntities.SaveChanges();
                    }

                    var performanceMeasureActual = new ProjectFirmaModels.Models.PerformanceMeasureActual(x.PerformanceMeasureActualID.GetValueOrDefault(),
                        x.ProjectID.GetValueOrDefault(),
                        x.PerformanceMeasureID.GetValueOrDefault(),
                        x.ActualValue.GetValueOrDefault(),
                        performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID);
                    if (x.PerformanceMeasureActualSubcategoryOptions != null)
                    {
                        performanceMeasureActual.PerformanceMeasureActualSubcategoryOptions =
                            x.PerformanceMeasureActualSubcategoryOptions.Where(pmavsou => ModelObjectHelpers.IsRealPrimaryKeyValue(pmavsou.PerformanceMeasureSubcategoryOptionID))
                                .Select(
                                    y =>
                                        new PerformanceMeasureActualSubcategoryOption(performanceMeasureActual.PerformanceMeasureActualID,
                                            y.PerformanceMeasureSubcategoryOptionID.GetValueOrDefault(),
                                            y.PerformanceMeasureID,
                                            y.PerformanceMeasureSubcategoryID))
                                .ToList();
                    }
                    return performanceMeasureActual;
                }).ToList();
            }

            var databaseEntities = HttpRequestStorage.DatabaseEntities;
            currentPerformanceMeasureActuals.Merge(performanceMeasureActualsUpdated,
                allPerformanceMeasureActuals,
                (x, y) => x.PerformanceMeasureActualID == y.PerformanceMeasureActualID,
                (x, y) =>
                {
                    x.PerformanceMeasureReportingPeriodID = y.PerformanceMeasureReportingPeriodID;
                    x.ActualValue = y.ActualValue;
                }, databaseEntities);

            currentPerformanceMeasureActualSubcategoryOptions.Merge(
                performanceMeasureActualsUpdated.SelectMany(x => x.PerformanceMeasureActualSubcategoryOptions).ToList(),
                allPerformanceMeasureActualSubcategoryOptions,
                (x, y) => x.PerformanceMeasureActualID == y.PerformanceMeasureActualID && x.PerformanceMeasureSubcategoryID == y.PerformanceMeasureSubcategoryID && x.PerformanceMeasureID == y.PerformanceMeasureID,
                (x, y) => x.PerformanceMeasureSubcategoryOptionID = y.PerformanceMeasureSubcategoryOptionID, databaseEntities);

            var currentProjectExemptYears = project.GetPerformanceMeasuresExemptReportingYears();
            databaseEntities.ProjectExemptReportingYears.Load();
            var allProjectExemptYears = databaseEntities.AllProjectExemptReportingYears.Local;
            var projectExemptReportingYears = new List<ProjectExemptReportingYear>();
            if (ProjectExemptReportingYearSimples != null)
            {
                // Completely rebuild the list
                projectExemptReportingYears =
                    ProjectExemptReportingYearSimples.Where(x => x.IsExempt)
                        .Select(x => new ProjectExemptReportingYear(x.ProjectExemptReportingYearID, x.ProjectID, x.CalendarYear, ProjectExemptReportingType.PerformanceMeasures.ProjectExemptReportingTypeID))
                        .ToList();
            }
            currentProjectExemptYears.Merge(projectExemptReportingYears,
                allProjectExemptYears,
                (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear && x.ProjectExemptReportingTypeID == y.ProjectExemptReportingTypeID, HttpRequestStorage.DatabaseEntities);
            project.PerformanceMeasureActualYearsExemptionExplanation = Explanation;
            if (project.ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval)
            {
                project.ReportedAccomplishmentsComment = Comments;
            }
        }

        /// <summary>
        /// For whatever reason - I haven't checked yet - we get batches of duplicate negative indexes,
        /// which gives the merge function heartburn. So, here we re-number all the negative indexes (new records)
        /// to eliminate dupes. -- SLG 1/23/2020
        /// </summary>
        /// <param name="performanceMeasureActuals"></param>
        /// <returns></returns>
        private void RenumberPerformanceMeasureActuals(List<PerformanceMeasureActualSimple> performanceMeasureActuals)
        {
            int currentNegativeIndex = -1;
            foreach (var pmas in performanceMeasureActuals)
            {
                if (pmas.PerformanceMeasureActualID < 0)
                {
                    pmas.PerformanceMeasureActualID = currentNegativeIndex;
                    currentNegativeIndex--;
                }
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();

            if (ProjectExemptReportingYearSimples != null && ProjectExemptReportingYearSimples.Any(x => x.IsExempt) && string.IsNullOrWhiteSpace(Explanation))
            {
                errors.Add(new SitkaValidationResult<PerformanceMeasuresViewModel, string>(FirmaValidationMessages.ExplanationNecessaryForProjectExemptYears, x => x.Explanation));
            }

            var pmValidationResults = ValidatePerformanceMeasures();
            var allWarningMessages = pmValidationResults.SelectMany(pmvr => pmvr.GetWarningMessages());
            errors.AddRange(allWarningMessages.Select(m => new ValidationResult(m)));

            return errors;
        }

        /// <summary>
        /// Validate Performance Measures by groups
        /// </summary>
        /// <returns>Null if there's nothing to validate, otherwise, a PerformanceMeasuresValidationResult</returns>
        public List<PerformanceMeasuresValidationResult> ValidatePerformanceMeasures()
        {
            List<PerformanceMeasuresValidationResult> results = new List<PerformanceMeasuresValidationResult>();

            var performanceMeasureActualSimples = PerformanceMeasureActualSimples ?? new List<PerformanceMeasureActualSimple>();
            var projectExemptReportingYearSimples = ProjectExemptReportingYearSimples ?? new List<ProjectExemptReportingYearSimple>();

            // What project are we dealing with?
            var project = HttpRequestStorage.DatabaseEntities.Projects.Single(x => x.ProjectID == ProjectID);

            // What years are expected for this Project?
            var exemptYears = projectExemptReportingYearSimples.Where(x => x.IsExempt).Select(x => x.CalendarYear).ToList();
            var yearsExpected = project.GetProjectUpdateImplementationStartToCompletionYearRange()
                .Where(x => !exemptYears.Contains(x)).ToList();

            // What distinct PerformanceMeasures are being worked with? 
            var pmasGrouped = performanceMeasureActualSimples.GroupBy(pmas => pmas.PerformanceMeasureID.Value);

            // Examine each PerformanceMeasure group as a unit to check for problems within the group
            foreach (var performanceMeasureActualSimpleGroup in pmasGrouped)
            {
                int currentPerformanceMeasureID = performanceMeasureActualSimpleGroup.Key;
                var currentPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(pm => pm.PerformanceMeasureID == currentPerformanceMeasureID);
                string currentPerformanceMeasureDisplayName = currentPerformanceMeasure.PerformanceMeasureDisplayName;

                // validation 1: ensure that we have PM values from ProjectUpdate start year to min(endyear, currentyear)
                var yearsEntered = performanceMeasureActualSimpleGroup.Select(x => x.CalendarYear).Distinct();
                var missingYears = yearsExpected.GetMissingYears(yearsEntered);

                // validation 2: incomplete PM row (missing performanceMeasureSubcategory option id)
                var performanceMeasureActualsWithIncompleteWarnings = ValidateNoIncompletePerformanceMeasureActualRow(currentPerformanceMeasureID);

                // validation 3: duplicate PM row
                var performanceMeasureActualsWithDuplicateWarnings = ValidateNoDuplicatePerformanceMeasureActualRow(currentPerformanceMeasureID);

                // validation 4: data entered for exempt years
                var performanceMeasureActualsWithExemptYear = ValidateNoExemptYearsWithReportedPerformanceMeasureRow(currentPerformanceMeasureID);

                var performanceMeasuresValidationResult = new PerformanceMeasuresValidationResult(
                    currentPerformanceMeasureID,
                    currentPerformanceMeasureDisplayName,
                    missingYears,
                    performanceMeasureActualsWithIncompleteWarnings,
                    performanceMeasureActualsWithDuplicateWarnings,
                    performanceMeasureActualsWithExemptYear);

                results.Add(performanceMeasuresValidationResult);
            }

            return results;
        }


        private HashSet<int> ValidateNoIncompletePerformanceMeasureActualRow(int relevantPerformanceMeasureID)
        {
            if (PerformanceMeasureActualSimples == null)
            {
                return new HashSet<int>();
            }

            var performanceMeasureIDs = PerformanceMeasureActualSimples.Select(x => x.PerformanceMeasureID.GetValueOrDefault()).Distinct();

            var performanceMeasuresIDsAndSubcategoryCounts =
                HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Where(x =>
                    performanceMeasureIDs.Contains(x.PerformanceMeasureID)).Select(x => new {x.PerformanceMeasureID, SubcategoryCount = x.PerformanceMeasureSubcategories.Count});

            var performanceMeasureActualsWithMissingSubcategoryOptions =
                PerformanceMeasureActualSimples.Where(
                    x => x.PerformanceMeasureID == relevantPerformanceMeasureID && (!x.ActualValue.HasValue || performanceMeasuresIDsAndSubcategoryCounts.Single(y => x.PerformanceMeasureID == y.PerformanceMeasureID).SubcategoryCount != x.PerformanceMeasureActualSubcategoryOptions.Count || x.PerformanceMeasureActualSubcategoryOptions.Any(y => y.PerformanceMeasureSubcategoryOptionID == null))).ToList();
            return new HashSet<int>(performanceMeasureActualsWithMissingSubcategoryOptions.Select(x => x.PerformanceMeasureActualID.GetValueOrDefault()));
        }

        private HashSet<int> ValidateNoDuplicatePerformanceMeasureActualRow(int relevantPerformanceMeasureID)
        {
            if (PerformanceMeasureActualSimples == null)
            {
                return new HashSet<int>();
            }
            var duplicates = PerformanceMeasureActualSimples
                .Where(x => x.PerformanceMeasureID == relevantPerformanceMeasureID)
                .GroupBy(x => new { x.PerformanceMeasureID, x.CalendarYear })
                .Select(x => x.ToList())
                .ToList()
                .Select(x => x)
                .Where(x => x.Select(m => m.PerformanceMeasureActualSubcategoryOptions).ToList().Select(z => String.Join("_", z.Select(s => s.PerformanceMeasureSubcategoryOptionID).ToList())).ToList().HasDuplicates()).ToList();

            return new HashSet<int>(duplicates.SelectMany(x => x).ToList().Select(x => x.PerformanceMeasureActualID.GetValueOrDefault()));
        }

        private HashSet<int> ValidateNoExemptYearsWithReportedPerformanceMeasureRow(int relevantPerformanceMeasureID)
        {
            var performanceMeasureActualSimples = PerformanceMeasureActualSimples.Where(pma => pma.PerformanceMeasureID == relevantPerformanceMeasureID).ToList();
            var projectExemptReportingYearSimples = ProjectExemptReportingYearSimples ?? new List<ProjectExemptReportingYearSimple>();
            var exemptYears = projectExemptReportingYearSimples.Where(x => x.IsExempt).Select(x => x.CalendarYear).ToList();
            var performanceMeasureActualsWithExemptYear = performanceMeasureActualSimples.Where(x => exemptYears.Contains(x.CalendarYear)).ToList();
            return new HashSet<int>(performanceMeasureActualsWithExemptYear.Select(x => x.PerformanceMeasureActualID.GetValueOrDefault()));
        }
    }
}
