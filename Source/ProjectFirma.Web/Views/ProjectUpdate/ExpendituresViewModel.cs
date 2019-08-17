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

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExpendituresViewModel : FormViewModel, IValidatableObject
    {
        [DisplayName("Show Validation Warnings?")]
        public bool ShowValidationWarnings { get; set; }

        [DisplayName("Review Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.ExpendituresComment)]
        public string Comments { get; set; }

        public List<ProjectFundingSourceExpenditureBulk> ProjectFundingSourceExpenditures { get; set; }

        public string Explanation { get; set; }

        public List<ProjectExemptReportingYearSimple> ProjectExemptReportingYears { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ExpendituresViewModel()
        {
        }

        public ExpendituresViewModel(ProjectUpdateBatch projectUpdateBatch, List<int> calendarYearsToPopulate,
            List<ProjectExemptReportingYearSimple> projectExemptReportingYears)
        {
            ProjectExemptReportingYears = projectExemptReportingYears;
            Explanation = projectUpdateBatch.NoExpendituresToReportExplanation;
            ProjectFundingSourceExpenditures = ProjectFundingSourceExpenditureBulk.MakeFromList(projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList(), calendarYearsToPopulate);
            ShowValidationWarnings = true;
            Comments = projectUpdateBatch.ExpendituresComment;
        }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch,
            List<ProjectFundingSourceExpenditureUpdate> currentProjectFundingSourceExpenditureUpdates,
            IList<ProjectFundingSourceExpenditureUpdate> allProjectFundingSourceExpenditureUpdates)
        {
            var projectFundingSourceExpenditureUpdatesUpdated = new List<ProjectFundingSourceExpenditureUpdate>();
            if (ProjectFundingSourceExpenditures != null)
            {
                // Completely rebuild the list
                projectFundingSourceExpenditureUpdatesUpdated = ProjectFundingSourceExpenditures.SelectMany(x => x.ToProjectFundingSourceExpenditureUpdates(projectUpdateBatch)).ToList();
            }

            var currentProjectExemptYears = projectUpdateBatch.GetExpendituresExemptReportingYears();
            var databaseEntities = HttpRequestStorage.DatabaseEntities;
            databaseEntities.ProjectExemptReportingYearUpdates.Load();
            var allProjectExemptYears = databaseEntities.AllProjectExemptReportingYearUpdates.Local;
            var projectExemptReportingYears = new List<ProjectExemptReportingYearUpdate>();
            if (ProjectExemptReportingYears != null)
            {
                // Completely rebuild the list
                projectExemptReportingYears =
                    ProjectExemptReportingYears.Where(x => x.IsExempt)
                        .Select(x => new ProjectExemptReportingYearUpdate(x.ProjectExemptReportingYearID, x.ProjectID, x.CalendarYear, ProjectExemptReportingType.Expenditures.ProjectExemptReportingTypeID))
                        .ToList();
            }
            currentProjectExemptYears.Merge(projectExemptReportingYears,
                allProjectExemptYears,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.CalendarYear == y.CalendarYear && x.ProjectExemptReportingTypeID == y.ProjectExemptReportingTypeID, databaseEntities);

            projectUpdateBatch.NoExpendituresToReportExplanation = Explanation;

            currentProjectFundingSourceExpenditureUpdates.Merge(projectFundingSourceExpenditureUpdatesUpdated,
                allProjectFundingSourceExpenditureUpdates,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.FundingSourceID == y.FundingSourceID && x.CalendarYear == y.CalendarYear,
                (x, y) => x.ExpenditureAmount = y.ExpenditureAmount, databaseEntities);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var emptyRows = ProjectFundingSourceExpenditures?.Where(x =>
                x.CalendarYearExpenditures.All(y => !y.MonetaryAmount.HasValue));

            if (emptyRows?.Any() ?? false)
            {
                errors.Add(new ValidationResult($"The {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update could not be saved because there are blank rows. Enter a value in all fields or delete funding sources for which there is no expenditure data to report."));
            }

            return errors;
        }
    }
}
