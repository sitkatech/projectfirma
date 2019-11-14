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
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class PerformanceMeasuresViewModel : FormViewModel, IValidatableObject
    {
        public string Explanation { get; set; }
        public List<ProjectExemptReportingYearSimple> ProjectExemptReportingYears { get; set; }
        public List<PerformanceMeasureActualSimple> PerformanceMeasureActuals { get; set; }
        public int? ProjectID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public PerformanceMeasuresViewModel()
        {
        }

        public PerformanceMeasuresViewModel(List<PerformanceMeasureActualSimple> performanceMeasureActuals,
            string explanation,
            List<ProjectExemptReportingYearSimple> projectExemptReportingYears)
        {
            PerformanceMeasureActuals = performanceMeasureActuals;
            Explanation = explanation;
            ProjectExemptReportingYears = projectExemptReportingYears;
        }

        public void UpdateModel(List<ProjectFirmaModels.Models.PerformanceMeasureActual> currentPerformanceMeasureActuals,
            IList<ProjectFirmaModels.Models.PerformanceMeasureActual> allPerformanceMeasureActuals,
            IList<PerformanceMeasureActualSubcategoryOption> allPerformanceMeasureActualSubcategoryOptions,
            ProjectFirmaModels.Models.Project project)
        {
            var currentPerformanceMeasureActualSubcategoryOptions =
                currentPerformanceMeasureActuals.SelectMany(x => x.PerformanceMeasureActualSubcategoryOptions).ToList();
            var performanceMeasureActualsUpdated = new List<ProjectFirmaModels.Models.PerformanceMeasureActual>();

            if (PerformanceMeasureActuals != null)
            {
                // Completely rebuild the list
                performanceMeasureActualsUpdated = PerformanceMeasureActuals.Select(x =>
                {
                    var performanceMeasureActual = new ProjectFirmaModels.Models.PerformanceMeasureActual(x.PerformanceMeasureActualID.GetValueOrDefault(),
                        x.ProjectID.GetValueOrDefault(),
                        x.PerformanceMeasureID.GetValueOrDefault(),
                        x.ActualValue.GetValueOrDefault(),
                        x.PerformanceMeasureReportingPeriodID);
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
                    x.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear = y.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear;
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
            if (ProjectExemptReportingYears != null)
            {
                // Completely rebuild the list
                projectExemptReportingYears =
                    ProjectExemptReportingYears.Where(x => x.IsExempt)
                        .Select(x => new ProjectExemptReportingYear(x.ProjectExemptReportingYearID, x.ProjectID, x.CalendarYear, ProjectExemptReportingType.PerformanceMeasures.ProjectExemptReportingTypeID))
                        .ToList();
            }
            currentProjectExemptYears.Merge(projectExemptReportingYears,
                allProjectExemptYears,
                (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear && x.ProjectExemptReportingTypeID == y.ProjectExemptReportingTypeID, HttpRequestStorage.DatabaseEntities);
            project.PerformanceMeasureActualYearsExemptionExplanation = Explanation;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();

            if (ProjectExemptReportingYears != null && ProjectExemptReportingYears.Any(x => x.IsExempt) && string.IsNullOrWhiteSpace(Explanation))
            {
                errors.Add(new SitkaValidationResult<PerformanceMeasuresViewModel, string>(FirmaValidationMessages.ExplanationNecessaryForProjectExemptYears, x => x.Explanation));
            }

            errors.AddRange(ValidatePerformanceMeasures().GetWarningMessages().Select(m =>
                new ValidationResult(m)));

            return errors;
        }

        public PerformanceMeasuresValidationResult ValidatePerformanceMeasures()
        {
            var performanceMeasureActualSimples = PerformanceMeasureActuals ?? new List<PerformanceMeasureActualSimple>();
            var projectExemptReportingYearSimples = ProjectExemptReportingYears ?? new List<ProjectExemptReportingYearSimple>();

            var project = HttpRequestStorage.DatabaseEntities.Projects.Single(x => x.ProjectID == ProjectID);

            // validation 1: ensure that we have PM values from ProjectUpdate start year to min(endyear, currentyear)
            var exemptYears = projectExemptReportingYearSimples.Where(x => x.IsExempt).Select(x => x.CalendarYear).ToList();
            var yearsExpected = project.GetProjectUpdateImplementationStartToCompletionYearRange()
                .Where(x => !exemptYears.Contains(x)).ToList();
            var yearsEntered = performanceMeasureActualSimples.Select(x => x.CalendarYear).Distinct();
            var missingYears = yearsExpected.GetMissingYears(yearsEntered);

            // validation 2: incomplete PM row (missing performanceMeasureSubcategory option id)
            var performanceMeasureActualsWithIncompleteWarnings = ValidateNoIncompletePerformanceMeasureActualRow();

            //validation 3: duplicate PM row
            var performanceMeasureActualsWithDuplicateWarnings = ValidateNoDuplicatePerformanceMeasureActualRow();

            //validation4: data entered for exempt years
            var performanceMeasureActualsWithExemptYear = ValidateNoExemptYearsWithReportedPerformanceMeasureRow();

            var performanceMeasuresValidationResult = new PerformanceMeasuresValidationResult(missingYears,
                performanceMeasureActualsWithIncompleteWarnings, performanceMeasureActualsWithDuplicateWarnings,
                performanceMeasureActualsWithExemptYear);
            return performanceMeasuresValidationResult;
        }

        private HashSet<int> ValidateNoIncompletePerformanceMeasureActualRow()
        {
            if (PerformanceMeasureActuals == null)
            {
                return new HashSet<int>();
            }
            var performanceMeasureIDs =
                PerformanceMeasureActuals.Select(x => x.PerformanceMeasureID.GetValueOrDefault()).Distinct();
            var performanceMeasuresIDsAndSubcategoryCounts =
                HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Where(x =>
                    performanceMeasureIDs.Contains(x.PerformanceMeasureID)).Select(x => new {x.PerformanceMeasureID, SubcategoryCount = x.PerformanceMeasureSubcategories.Count});

            var performanceMeasureActualsWithMissingSubcategoryOptions =
                PerformanceMeasureActuals.Where(
                    x => !x.ActualValue.HasValue || performanceMeasuresIDsAndSubcategoryCounts.Single(y=>x.PerformanceMeasureID==y.PerformanceMeasureID).SubcategoryCount != x.PerformanceMeasureActualSubcategoryOptions.Count || x.PerformanceMeasureActualSubcategoryOptions.Any(y => y.PerformanceMeasureSubcategoryOptionID == null)).ToList();
            return new HashSet<int>(performanceMeasureActualsWithMissingSubcategoryOptions.Select(x => x.PerformanceMeasureActualID.GetValueOrDefault()));
        }

        private HashSet<int> ValidateNoDuplicatePerformanceMeasureActualRow()
        {
            if (PerformanceMeasureActuals == null)
            {
                return new HashSet<int>();
            }
            var duplicates = PerformanceMeasureActuals
                .GroupBy(x => new { x.PerformanceMeasureID, x.CalendarYear })
                .Select(x => x.ToList())
                .ToList()
                .Select(x => x)
                .Where(x => x.Select(m => m.PerformanceMeasureActualSubcategoryOptions).ToList().Select(z => String.Join("_", z.Select(s => s.PerformanceMeasureSubcategoryOptionID).ToList())).ToList().HasDuplicates()).ToList();

            return new HashSet<int>(duplicates.SelectMany(x => x).ToList().Select(x => x.PerformanceMeasureActualID.GetValueOrDefault()));
        }

        private HashSet<int> ValidateNoExemptYearsWithReportedPerformanceMeasureRow()
        {
            var performanceMeasureActualSimples = PerformanceMeasureActuals ?? new List<PerformanceMeasureActualSimple>();
            var projectExemptReportingYearSimples = ProjectExemptReportingYears ?? new List<ProjectExemptReportingYearSimple>();
            var exemptYears = projectExemptReportingYearSimples.Where(x => x.IsExempt).Select(x => x.CalendarYear).ToList();
            var performanceMeasureActualsWithExemptYear = performanceMeasureActualSimples.Where(x => exemptYears.Contains(x.CalendarYear)).ToList();
            return new HashSet<int>(performanceMeasureActualsWithExemptYear.Select(x => x.PerformanceMeasureActualID.GetValueOrDefault()));
        }
    }
}
