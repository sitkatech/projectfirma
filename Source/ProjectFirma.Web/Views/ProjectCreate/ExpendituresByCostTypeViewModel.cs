/*-----------------------------------------------------------------------
<copyright file="ExpendituresByCostTypeViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ExpendituresByCostTypeViewModel : FormViewModel, IValidatableObject
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
        public ExpendituresByCostTypeViewModel()
        {
        }

        public ExpendituresByCostTypeViewModel(ProjectFirmaModels.Models.Project project, List<int> calendarYearsToPopulate,
            List<ProjectExemptReportingYearSimple> projectExemptReportingYears)
        {
            ProjectExemptReportingYears = projectExemptReportingYears;
            Explanation = project.NoExpendituresToReportExplanation;
            ProjectFundingSourceExpenditures = ProjectFundingSourceExpenditureBulk.MakeFromListByCostType(project, calendarYearsToPopulate);
            ShowValidationWarnings = true;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project,
            List<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure> currentProjectFundingSourceExpenditures,
            IList<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure> allProjectFundingSourceExpenditures)
        {
            var databaseEntities = HttpRequestStorage.DatabaseEntities;
            databaseEntities.ProjectExemptReportingYearUpdates.Load();
            var projectFundingSourceExpendituresUpdated = new List<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure>();
            if (ProjectFundingSourceExpenditures != null)
            {
                // Completely rebuild the list
                projectFundingSourceExpendituresUpdated = ProjectFundingSourceExpenditures.SelectMany(x => x.ToProjectFundingSourceExpenditures()).ToList();
            }

            currentProjectFundingSourceExpenditures.Merge(projectFundingSourceExpendituresUpdated,
                allProjectFundingSourceExpenditures,
                (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID && x.CostTypeID == y.CostTypeID && x.CalendarYear == y.CalendarYear,
                (x, y) => x.ExpenditureAmount = y.ExpenditureAmount, databaseEntities);

            var currentProjectExemptYears = project.GetExpendituresExemptReportingYears();
            var allProjectExemptYears = databaseEntities.AllProjectExemptReportingYears.Local;
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
                (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear && x.ProjectExemptReportingTypeID == y.ProjectExemptReportingTypeID, databaseEntities);

            project.NoExpendituresToReportExplanation = Explanation;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var emptyRows = ProjectFundingSourceExpenditures?.Where(x =>
                x.CalendarYearExpenditures.All(y => !y.MonetaryAmount.HasValue));

            if (emptyRows?.Any() ?? false)
            {
                errors.Add(new ValidationResult($"The {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} could not be saved because there are blank rows. Enter a value in all fields or delete {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabelPluralized()} for which there is no expenditure data to report."));
            }

            return errors;
        }
    }
}