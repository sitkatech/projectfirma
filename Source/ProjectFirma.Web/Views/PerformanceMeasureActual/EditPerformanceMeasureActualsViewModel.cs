/*-----------------------------------------------------------------------
<copyright file="EditPerformanceMeasureActualsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;

namespace ProjectFirma.Web.Views.PerformanceMeasureActual
{
    public class EditPerformanceMeasureActualsViewModel : FormViewModel, IValidatableObject
    {
        public string Explanation { get; set; }
        public List<ProjectExemptReportingYearSimple> ProjectExemptReportingYears { get; set; }
        public List<PerformanceMeasureActualSimple> PerformanceMeasureActuals { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditPerformanceMeasureActualsViewModel()
        {
        }


        public EditPerformanceMeasureActualsViewModel(List<PerformanceMeasureActualSimple> performanceMeasureActuals,
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

            ProjectFirmaModels.Models.Project project,
            IList<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods)
        {

            UpdateModelImpl(currentPerformanceMeasureActuals, allPerformanceMeasureActuals, allPerformanceMeasureActualSubcategoryOptions, allPerformanceMeasureReportingPeriods);
            var currentProjectExemptYears = project.GetPerformanceMeasuresExemptReportingYears();
            HttpRequestStorage.DatabaseEntities.ProjectExemptReportingYears.Load();
            var allProjectExemptYears = HttpRequestStorage.DatabaseEntities.AllProjectExemptReportingYears.Local;
            var projectExemptReportingYears = new List<ProjectExemptReportingYear>();
            if (ProjectExemptReportingYears != null)
            {
                // Completely rebuild the list
                projectExemptReportingYears =
                    ProjectExemptReportingYears.Where(x => x.IsExempt).Select(x => new ProjectExemptReportingYear(x.ProjectID, x.CalendarYear, ProjectExemptReportingType.PerformanceMeasures.ProjectExemptReportingTypeID)).ToList();
            }
            currentProjectExemptYears.Merge(projectExemptReportingYears, allProjectExemptYears, (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear && x.ProjectExemptReportingTypeID == y.ProjectExemptReportingTypeID, HttpRequestStorage.DatabaseEntities);
            project.PerformanceMeasureActualYearsExemptionExplanation = Explanation;
        }

        private void UpdateModelImpl(List<ProjectFirmaModels.Models.PerformanceMeasureActual> currentPerformanceMeasureActuals,
            IList<ProjectFirmaModels.Models.PerformanceMeasureActual> allPerformanceMeasureActuals,

            IList<PerformanceMeasureActualSubcategoryOption> allPerformanceMeasureActualSubcategoryOptions,
            IList<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods)
        {
            // Remove all existing associations
            currentPerformanceMeasureActuals.ForEach(pmav =>
            {
                pmav.PerformanceMeasureActualSubcategoryOptions.ToList().ForEach(pmavso => allPerformanceMeasureActualSubcategoryOptions.Remove(pmavso));
                allPerformanceMeasureActuals.Remove(pmav);
            });
            currentPerformanceMeasureActuals.Clear();

            if (PerformanceMeasureActuals != null)
            {
                var performanceMeasureReportingPeriodsFromDatabase = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureReportingPeriods.Local;
                // Completely rebuild the list
                foreach (var performanceMeasureActualSimple in PerformanceMeasureActuals)
                {

                    var performanceMeasureReportingPeriod = allPerformanceMeasureReportingPeriods.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodCalendarYear == performanceMeasureActualSimple.CalendarYear);
                    if (performanceMeasureReportingPeriod == null)
                    {
                        Check.EnsureNotNull(performanceMeasureActualSimple.PerformanceMeasureID, "We need to have a performance measure.");
                        performanceMeasureReportingPeriod = new PerformanceMeasureReportingPeriod((int)performanceMeasureActualSimple.PerformanceMeasureID, performanceMeasureActualSimple.CalendarYear, performanceMeasureActualSimple.CalendarYear.ToString());
                        performanceMeasureReportingPeriodsFromDatabase.Add(performanceMeasureReportingPeriod);
                        HttpRequestStorage.DatabaseEntities.SaveChanges();
                    }
                    var performanceMeasureActual = new ProjectFirmaModels.Models.PerformanceMeasureActual(performanceMeasureActualSimple.ProjectID.Value, performanceMeasureActualSimple.PerformanceMeasureID.Value, performanceMeasureActualSimple.ActualValue.Value, performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID);
                    allPerformanceMeasureActuals.Add(performanceMeasureActual);
                    if (performanceMeasureActualSimple.PerformanceMeasureActualSubcategoryOptions != null)
                    {
                        performanceMeasureActualSimple.PerformanceMeasureActualSubcategoryOptions.ForEach(
                            y =>
                                allPerformanceMeasureActualSubcategoryOptions.Add(new PerformanceMeasureActualSubcategoryOption(
                                    performanceMeasureActual.PerformanceMeasureActualID,
                                    y.PerformanceMeasureSubcategoryOptionID.Value,
                                    y.PerformanceMeasureID,
                                    y.PerformanceMeasureSubcategoryID)));
                    }
                }
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (ProjectExemptReportingYears != null && ProjectExemptReportingYears.Any(x => x.IsExempt) && string.IsNullOrWhiteSpace(Explanation))
            {
                errors.Add(new ValidationResult(FirmaValidationMessages.ExplanationNecessaryForProjectExemptYears));
            }

            var exemptYears = ProjectExemptReportingYears?.Where(x => x.IsExempt).Select(x => x.CalendarYear).ToList();

            var performanceMeasureActualsWithDuplicatesDisplayNames = PerformanceMeasureActuals
                ?.GroupBy(x => new {x.PerformanceMeasureID, x.CalendarYear})
                .Select(x => x.ToList())
                .ToList()
                .Select(x => x)
                .Where(x => x.Select(m => m.PerformanceMeasureActualSubcategoryOptions).ToList()
                    .Select(z => String.Join("_", z.Select(s => s.PerformanceMeasureSubcategoryOptionID).ToList()))
                    .ToList().HasDuplicates()).SelectMany(x => x.Select(y => y.PerformanceMeasureActualName).Distinct())
                .ToList();

            var performanceMeasureActualsWithMissingDataDisplayNames = PerformanceMeasureActuals?.Where(x =>
                    x.ActualValue == null ||
                    x.PerformanceMeasureActualSubcategoryOptions.Any(y =>
                        y.PerformanceMeasureSubcategoryOptionID == null))
                .Select(x => x.PerformanceMeasureActualName).Distinct().ToList();

            var performanceMeasureActualsWithValuesInExemptYearsDisplayNames = PerformanceMeasureActuals
                ?.Where(x => exemptYears.Contains(x.CalendarYear))
                .Select(x => x.PerformanceMeasureActualName).Distinct().ToList();

            performanceMeasureActualsWithMissingDataDisplayNames?.ForEach(x => errors.Add(new ValidationResult($"{x} has rows with missing data. All values are required.")));

            performanceMeasureActualsWithDuplicatesDisplayNames?.ForEach(x => errors.Add(new ValidationResult($"{x} has duplicate rows. The {FieldDefinitionEnum.PerformanceMeasureSubcategory.ToType().GetFieldDefinitionLabelPluralized()} must be unique for each {MultiTenantHelpers.GetPerformanceMeasureName()}. Collapse the duplicate rows into one entry row then save the page.")));

            performanceMeasureActualsWithValuesInExemptYearsDisplayNames?.ForEach(x =>
                errors.Add(new ValidationResult(
                    $"{x} has reported values for exempt years. For years which it is indicated that there are no accomplishments to report, you cannot enter {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()}. You must either correct the years for which you have no accomplishments to report, or the reported {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()}.")));
            

            return errors;
        }
    }
}
