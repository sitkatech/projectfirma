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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using MoreLinq;

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

        public EditPerformanceMeasureActualsViewModel(List<PerformanceMeasureActualSimple> performanceMeasureActuals) : this(performanceMeasureActuals, null, null)
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

        public void UpdateModel(List<Models.PerformanceMeasureActual> currentPerformanceMeasureActuals,
            IList<Models.PerformanceMeasureActual> allPerformanceMeasureActuals,
            IList<PerformanceMeasureActualSubcategoryOption> allPerformanceMeasureActualSubcategoryOptions,
            Models.Project project)
        {
            UpdateModelImpl(currentPerformanceMeasureActuals, allPerformanceMeasureActuals, allPerformanceMeasureActualSubcategoryOptions);
            var currentProjectExemptYears = project.ProjectExemptReportingYears.ToList();
            HttpRequestStorage.DatabaseEntities.ProjectExemptReportingYears.Load();
            var allProjectExemptYears = HttpRequestStorage.DatabaseEntities.AllProjectExemptReportingYears.Local;
            var projectExemptReportingYears = new List<ProjectExemptReportingYear>();
            if (ProjectExemptReportingYears != null)
            {
                // Completely rebuild the list
                projectExemptReportingYears =
                    ProjectExemptReportingYears.Where(x => x.IsExempt).Select(x => new ProjectExemptReportingYear(x.ProjectExemptReportingYearID, x.ProjectID, x.CalendarYear)).ToList();
            }
            currentProjectExemptYears.Merge(projectExemptReportingYears, allProjectExemptYears, (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear);
            project.PerformanceMeasureActualYearsExemptionExplanation = Explanation;
        }

        private void UpdateModelImpl(List<Models.PerformanceMeasureActual> currentPerformanceMeasureActuals,
            IList<Models.PerformanceMeasureActual> allPerformanceMeasureActuals,
            IList<PerformanceMeasureActualSubcategoryOption> allPerformanceMeasureActualSubcategoryOptions)
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
                // Completely rebuild the list
                foreach (var x in PerformanceMeasureActuals)
                {
                    var performanceMeasureActual = new Models.PerformanceMeasureActual(x.ProjectID.Value, x.PerformanceMeasureID.Value, x.CalendarYear.Value, x.ActualValue.Value);
                    allPerformanceMeasureActuals.Add(performanceMeasureActual);
                    if (x.PerformanceMeasureActualSubcategoryOptions != null)
                    {
                        x.PerformanceMeasureActualSubcategoryOptions.ForEach(
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

            if ((ProjectExemptReportingYears == null || !ProjectExemptReportingYears.Any(x => x.IsExempt)) && !string.IsNullOrWhiteSpace(Explanation))
            {
                errors.Add(new ValidationResult(FirmaValidationMessages.ExplanationNotNecessaryForProjectExemptYears));
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
                    x.CalendarYear == null || x.ActualValue == null ||
                    x.PerformanceMeasureActualSubcategoryOptions.Any(y =>
                        y.PerformanceMeasureSubcategoryOptionID == null))
                .Select(x => x.PerformanceMeasureActualName).Distinct().ToList();

            var performanceMeasureActualsWithValuesInExemptYearsDisplayNames = PerformanceMeasureActuals
                ?.Where(x => x.CalendarYear != null && exemptYears.Contains(x.CalendarYear.Value))
                .Select(x => x.PerformanceMeasureActualName).Distinct().ToList();

            performanceMeasureActualsWithMissingDataDisplayNames?.ForEach(x => errors.Add(new ValidationResult($"{x} has rows with missing data. All values are required.")));

            performanceMeasureActualsWithDuplicatesDisplayNames?.ForEach(x => errors.Add(new ValidationResult($"{x} has duplicate rows. The {Models.FieldDefinition.PerformanceMeasureSubcategory.GetFieldDefinitionLabelPluralized()} must be unique for each {MultiTenantHelpers.GetPerformanceMeasureName()}. Collapse the duplicate rows into one entry row then save the page.")));

            performanceMeasureActualsWithValuesInExemptYearsDisplayNames?.ForEach(x =>
                errors.Add(new ValidationResult(
                    $"{x} has reported values for exempt years. For years which it is indicated that there are no accomplishments to report, you cannot enter {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()}. You must either correct the years for which you have no accomplishments to report, or the reported {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()}.")));
            

            return errors;
        }
    }
}
