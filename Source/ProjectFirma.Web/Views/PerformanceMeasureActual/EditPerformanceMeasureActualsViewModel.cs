/*-----------------------------------------------------------------------
<copyright file="EditPerformanceMeasureActualsViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
        /*
         * JHB & LC 10/10/16: We fixed issues around validating when Subcategory Options are not selected, but this ViewModel still has a bug. To reproduce:
         * 1. Open "Reported Performance Measures" dialog
         * 2. Click "What is my project has no accomplishments to report..."
         * 3. Select a year, but do not enter any explanation text
         * 4. Save
         * 5. Select a Performance Measure and hit "Add". 
         * 6. Angular pukes.            
         */
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

            

            return errors;
        }
    }
}
