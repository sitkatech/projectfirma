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
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class PerformanceMeasuresViewModel : FormViewModel, IValidatableObject
    {
        public string Explanation { get; set; }
        public List<ProjectExemptReportingYearSimple> ProjectExemptReportingYears { get; set; }
        public List<PerformanceMeasureActualSimple> PerformanceMeasureActuals { get; set; }

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

        public void UpdateModel(List<Models.PerformanceMeasureActual> currentPerformanceMeasureActuals,
            IList<Models.PerformanceMeasureActual> allPerformanceMeasureActuals,
            IList<PerformanceMeasureActualSubcategoryOption> allPerformanceMeasureActualSubcategoryOptions,
            Models.Project project)
        {
            var currentPerformanceMeasureActualSubcategoryOptions =
                currentPerformanceMeasureActuals.SelectMany(x => x.PerformanceMeasureActualSubcategoryOptions).ToList();
            var performanceMeasureActualsUpdated = new List<Models.PerformanceMeasureActual>();

            if (PerformanceMeasureActuals != null)
            {
                // Completely rebuild the list
                performanceMeasureActualsUpdated = PerformanceMeasureActuals.Select(x =>
                {
                    var performanceMeasureActual = new Models.PerformanceMeasureActual(x.PerformanceMeasureActualID.GetValueOrDefault(),
                        x.ProjectID.GetValueOrDefault(),
                        x.PerformanceMeasureID.GetValueOrDefault(),
                        x.CalendarYear.GetValueOrDefault(),
                        x.ActualValue.GetValueOrDefault());
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
            currentPerformanceMeasureActuals.Merge(performanceMeasureActualsUpdated,
                allPerformanceMeasureActuals,
                (x, y) => x.PerformanceMeasureActualID == y.PerformanceMeasureActualID,
                (x, y) =>
                {
                    x.CalendarYear = y.CalendarYear;
                    x.ActualValue = y.ActualValue;
                });

            currentPerformanceMeasureActualSubcategoryOptions.Merge(
                performanceMeasureActualsUpdated.SelectMany(x => x.PerformanceMeasureActualSubcategoryOptions).ToList(),
                allPerformanceMeasureActualSubcategoryOptions,
                (x, y) => x.PerformanceMeasureActualID == y.PerformanceMeasureActualID && x.PerformanceMeasureSubcategoryID == y.PerformanceMeasureSubcategoryID && x.PerformanceMeasureID == y.PerformanceMeasureID,
                (x, y) => x.PerformanceMeasureSubcategoryOptionID = y.PerformanceMeasureSubcategoryOptionID);

            var currentProjectExemptYears = project.ProjectExemptReportingYears.ToList();
            HttpRequestStorage.DatabaseEntities.ProjectExemptReportingYearUpdates.Load();
            var allProjectExemptYears = HttpRequestStorage.DatabaseEntities.AllProjectExemptReportingYears.Local;
            var projectExemptReportingYears = new List<ProjectExemptReportingYear>();
            if (ProjectExemptReportingYears != null)
            {
                // Completely rebuild the list
                projectExemptReportingYears =
                    ProjectExemptReportingYears.Where(x => x.IsExempt)
                        .Select(x => new ProjectExemptReportingYear(x.ProjectExemptReportingYearID, x.ProjectID, x.CalendarYear))
                        .ToList();
            }
            currentProjectExemptYears.Merge(projectExemptReportingYears,
                allProjectExemptYears,
                (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear);
            project.PerformanceMeasureActualYearsExemptionExplanation = Explanation;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (ProjectExemptReportingYears != null && ProjectExemptReportingYears.Any(x => x.IsExempt) && string.IsNullOrWhiteSpace(Explanation))
            {
                errors.Add(new SitkaValidationResult<PerformanceMeasuresViewModel, string>(FirmaValidationMessages.ExplanationNecessaryForProjectExemptYears, x => x.Explanation));
            }

            if ((ProjectExemptReportingYears == null || !ProjectExemptReportingYears.Any(x => x.IsExempt)) && !string.IsNullOrWhiteSpace(Explanation))
            {
                errors.Add(new SitkaValidationResult<PerformanceMeasuresViewModel, string>(FirmaValidationMessages.ExplanationNotNecessaryForProjectExemptYears, x => x.Explanation));
            }

            return errors;
        }
    }
}
