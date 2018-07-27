/*-----------------------------------------------------------------------
<copyright file="ExpendituresViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Data.Entity;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ExpendituresViewModel : FormViewModel, IValidatableObject
    {
        public int? ProjectID { get; set; }

        [DisplayName("Show Validation Warnings?")]
        public bool ShowValidationWarnings { get; set; }

        public List<ProjectFundingSourceExpenditureBulk> ProjectFundingSourceExpenditures { get; set; }
        public string Explanation { get; set; }

        public List<ProjectExemptReportingYearSimple> ProjectExemptReportingYears { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ExpendituresViewModel()
        {
        }

        public ExpendituresViewModel(List<Models.ProjectFundingSourceExpenditure> projectFundingSourceExpenditures,
            List<int> calendarYearsToPopulate, Models.Project project,
            List<ProjectExemptReportingYearSimple> projectExemptReportingYears)
        {
            ProjectExemptReportingYears = projectExemptReportingYears;
            Explanation = project.NoExpendituresToReportExplanation;
            ProjectFundingSourceExpenditures = ProjectFundingSourceExpenditureBulk.MakeFromList(projectFundingSourceExpenditures, calendarYearsToPopulate);
            ShowValidationWarnings = true;
        }

        public void UpdateModel(Models.Project project,
            List<Models.ProjectFundingSourceExpenditure> currentProjectFundingSourceExpenditures,
            IList<Models.ProjectFundingSourceExpenditure> allProjectFundingSourceExpenditures)
        {
            var projectFundingSourceExpendituresUpdated = new List<Models.ProjectFundingSourceExpenditure>();
            if (ProjectFundingSourceExpenditures != null)
            {
                // Completely rebuild the list
                projectFundingSourceExpendituresUpdated = ProjectFundingSourceExpenditures.SelectMany(x => x.ToProjectFundingSourceExpenditures()).ToList();
            }


            var currentProjectExemptYears = project.ProjectExemptReportingYears.Where(x => x.ProjectExemptReportingType == ProjectExemptReportingType.Expenditures).ToList();
            HttpRequestStorage.DatabaseEntities.ProjectExemptReportingYears.Load();
            var allProjectExemptYears = HttpRequestStorage.DatabaseEntities.AllProjectExemptReportingYears.Local;
            var projectExemptReportingYears = new List<ProjectExemptReportingYear>();
            if (ProjectExemptReportingYears != null)
            {
                // Completely rebuild the list
                projectExemptReportingYears =
                    ProjectExemptReportingYears.Where(x => x.IsExempt)
                        .Select(x => new ProjectExemptReportingYear(x.ProjectExemptReportingYearID, x.ProjectID, x.CalendarYear, ProjectExemptReportingType.Expenditures.ProjectExemptReportingTypeID))
                        .ToList();
            }
            currentProjectExemptYears.Merge(projectExemptReportingYears,
                allProjectExemptYears,
                (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear && x.ProjectExemptReportingTypeID == y.ProjectExemptReportingTypeID);

            project.NoExpendituresToReportExplanation = Explanation;

            currentProjectFundingSourceExpenditures.Merge(projectFundingSourceExpendituresUpdated,
                allProjectFundingSourceExpenditures,
                (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID && x.CalendarYear == y.CalendarYear,
                (x, y) => x.ExpenditureAmount = y.ExpenditureAmount);




        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();
            var emptyRows = ProjectFundingSourceExpenditures?.Where(x =>
                x.CalendarYearExpenditures.All(y => !y.MonetaryAmount.HasValue));

            if (ProjectFundingSourceExpenditures == null)
            {
                ProjectFundingSourceExpenditures = new List<ProjectFundingSourceExpenditureBulk>();
            }

            if (emptyRows?.Any() ?? false)
            {
                errors.Add(new ValidationResult("The Project could not be saved because there are blank rows. Enter a value in all fields or delete funding sources for which there is no expenditure data to report."));
            }

            var project = HttpRequestStorage.DatabaseEntities.Projects.Single(x => x.ProjectID == ProjectID);

            // get distinct Funding Sources
            var fundingSourcesIDs = ProjectFundingSourceExpenditures?.SelectMany(x => x.ToProjectFundingSourceExpenditures()).Select(x => x.FundingSourceID).Distinct().ToList();
            var fundingSources =
                HttpRequestStorage.DatabaseEntities.FundingSources.Where(x =>
                    fundingSourcesIDs.Contains(x.FundingSourceID));
            
            // validation 1: ensure that we have expenditure values from ProjectUpdate start year to min(endyear, currentyear)
            var yearsExpected = project.GetProjectUpdatePlanningDesignStartToCompletionYearRange();

            if (ProjectExemptReportingYears != null && ProjectExemptReportingYears.Any(x => x.IsExempt) && string.IsNullOrWhiteSpace(Explanation))
            {
                errors.Add(new SitkaValidationResult<PerformanceMeasuresViewModel, string>(FirmaValidationMessages.ExplanationNecessaryForProjectExemptYears, x => x.Explanation));
            }

            if ((ProjectExemptReportingYears == null || !ProjectExemptReportingYears.Any(x => x.IsExempt)) && !string.IsNullOrWhiteSpace(Explanation))
            {
                errors.Add(new SitkaValidationResult<PerformanceMeasuresViewModel, string>(FirmaValidationMessages.ExplanationNotNecessaryForProjectExemptYears, x => x.Explanation));
            }

            if (!fundingSources.Any())
            {
                //If there are no funding sources then every year is missing.
                if (yearsExpected.Count() > 2)
                {
                    errors.Add(new ValidationResult($"Missing Expenditures for {MultiTenantHelpers.FormatReportingYear(yearsExpected.Min())} - {MultiTenantHelpers.FormatReportingYear(yearsExpected.Max())}"));
                }
                else
                {
                    errors.Add(new ValidationResult($"Missing Expenditures for {string.Join(", ", yearsExpected.Select(MultiTenantHelpers.FormatReportingYear))}"));
                }

            }
            else
            {
                var missingFundingSourceYears = new Dictionary<Models.FundingSource, IEnumerable<int>>();
                foreach (var fundingSource in fundingSources)
                {
                    var currentFundingSource = fundingSource;
                    var missingYears =
                        yearsExpected
                            .GetMissingYears(ProjectFundingSourceExpenditures
                                .Where(x => x.FundingSourceID == currentFundingSource.FundingSourceID)
                                .SelectMany(x => x.ToProjectFundingSourceExpenditures()).Select(x => x.CalendarYear)).ToList()
                            .Where(year =>
                                !ProjectExemptReportingYears.Where(reportingYear => reportingYear.IsExempt).Select(reportingYear
                                    => reportingYear.CalendarYear).Contains(year)).ToList();

                    if (missingYears.Any())
                    {
                        missingFundingSourceYears.Add(currentFundingSource, missingYears);
                    }
                }
                foreach (var fundingSource in missingFundingSourceYears)
                {
                    var missingYearsForFundingSource = fundingSource.Value;
                    var missingYearsCount = missingYearsForFundingSource.Count();
                    if (missingYearsCount > 2)
                    {
                        errors.Add(new ValidationResult($"Missing Expenditures for {Models.FieldDefinition.FundingSource.GetFieldDefinitionLabel()} '{fundingSource.Key.DisplayName}' for the following years: {MultiTenantHelpers.FormatReportingYear(fundingSource.Value.Min())} - {MultiTenantHelpers.FormatReportingYear(fundingSource.Value.Max())}"));
                    }
                    else
                    {
                        errors.Add(new ValidationResult($"Missing Expenditures for {Models.FieldDefinition.FundingSource.GetFieldDefinitionLabel()} '{fundingSource.Key.DisplayName}' for the following years: {string.Join(", ", fundingSource.Value.Select(MultiTenantHelpers.FormatReportingYear))}"));
                    }
                }
            }

            // duplicate funding sources
            errors.AddRange(ProjectFundingSourceExpenditures.GroupBy(x => x.FundingSourceID).Where(x => x.Count() > 1)
                .Select(x =>
                    new ValidationResult(
                        $"Duplicate funding source: {fundingSources.Single(y => y.FundingSourceID == x.Key).FundingSourceName}")));

            // reported expenditures in exempt years
            foreach (var fundingSource in ProjectFundingSourceExpenditures)
            {
                var exemptYearsWithReportedValues = fundingSource.CalendarYearExpenditures.Where(x =>
                    x.MonetaryAmount.HasValue && ProjectExemptReportingYears.Where(y => y.IsExempt)
                        .Select(y => y.CalendarYear).Contains(x.CalendarYear)).Select(x=>x.CalendarYear).ToList();
                if (exemptYearsWithReportedValues.Any())
                {
                    var fundingSourceName = fundingSources.Single(x=>x.FundingSourceID == fundingSource.FundingSourceID).FundingSourceName;
                    string yearsForErrorDisplay;

                    if (exemptYearsWithReportedValues.Count > 2)
                    {
                        yearsForErrorDisplay =
                            $"{MultiTenantHelpers.FormatReportingYear(exemptYearsWithReportedValues.Min())} - {MultiTenantHelpers.FormatReportingYear(exemptYearsWithReportedValues.Max())}";
                    }
                    else
                    {
                        yearsForErrorDisplay = string.Join(", ", exemptYearsWithReportedValues.Select(MultiTenantHelpers.FormatReportingYear));
                    }

                    errors.Add(new ValidationResult($"Funding source {fundingSourceName} has reported values for the exempt years: {yearsForErrorDisplay}"));
                }
            }

            return errors;
        }
    }
}
