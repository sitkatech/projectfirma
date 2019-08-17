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
        [DisplayName("Show Validation Warnings?")]
        public bool ShowValidationWarnings { get; set; }

        public List<ProjectFundingSourceExpenditureBulk> ProjectFundingSourceExpenditures { get; set; }

        public string Explanation { get; set; }

        public List<ProjectRelevantCostTypeSimple> ProjectRelevantCostTypes { get; set; }
        public bool HasExpenditures { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ExpendituresByCostTypeViewModel()
        {
        }

        public ExpendituresByCostTypeViewModel(ProjectFirmaModels.Models.Project project, List<int> calendarYearsToPopulate, List<ProjectRelevantCostTypeSimple> projectRelevantCostTypes)
        {
            ProjectRelevantCostTypes = projectRelevantCostTypes;
            Explanation = project.NoExpendituresToReportExplanation;
            ProjectFundingSourceExpenditures = ProjectFundingSourceExpenditureBulk.MakeFromListByCostType(project, calendarYearsToPopulate);
            HasExpenditures = ProjectFundingSourceExpenditures.Any();
            ShowValidationWarnings = true;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project,
            List<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure> currentProjectFundingSourceExpenditures,
            IList<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure> allProjectFundingSourceExpenditures)
        {
            var databaseEntities = HttpRequestStorage.DatabaseEntities;
            databaseEntities.ProjectExemptReportingYearUpdates.Load();
            databaseEntities.ProjectRelevantCostTypes.Load();

            var projectFundingSourceExpendituresUpdated = new List<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure>();
            if (ProjectFundingSourceExpenditures != null)
            {
                // Completely rebuild the list
                projectFundingSourceExpendituresUpdated = ProjectFundingSourceExpenditures.Where(x => x.IsRelevant ?? false).SelectMany(x => x.ToProjectFundingSourceExpendituresSetNullToZero()).ToList();
            }

            currentProjectFundingSourceExpenditures.Merge(projectFundingSourceExpendituresUpdated,
                allProjectFundingSourceExpenditures,
                (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID && x.CostTypeID == y.CostTypeID && x.CalendarYear == y.CalendarYear,
                (x, y) => x.ExpenditureAmount = y.ExpenditureAmount, databaseEntities);

            var currentProjectRelevantCostTypes = project.GetExpendituresRelevantCostTypes();
            var allProjectRelevantCostTypes = databaseEntities.AllProjectRelevantCostTypes.Local;
            var projectRelevantCostTypes = new List<ProjectRelevantCostType>();
            if (ProjectRelevantCostTypes != null)
            {
                // Completely rebuild the list
                projectRelevantCostTypes =
                    ProjectRelevantCostTypes.Where(x => x.IsRelevant)
                        .Select(x => new ProjectRelevantCostType(x.ProjectRelevantCostTypeID, x.ProjectID, x.CostTypeID, ProjectRelevantCostTypeGroup.Expenditures.ProjectRelevantCostTypeGroupID))
                        .ToList();
            }
            currentProjectRelevantCostTypes.Merge(projectRelevantCostTypes,
                allProjectRelevantCostTypes,
                (x, y) => x.ProjectID == y.ProjectID && x.CostTypeID == y.CostTypeID && x.ProjectRelevantCostTypeGroupID == y.ProjectRelevantCostTypeGroupID, databaseEntities);

            project.NoExpendituresToReportExplanation = ProjectFundingSourceExpenditures != null && ProjectFundingSourceExpenditures.Any() ? null : Explanation;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if (ProjectFundingSourceExpenditures == null)
            {
                ProjectFundingSourceExpenditures = new List<ProjectFundingSourceExpenditureBulk>();
            }
            var projectFundingSourceExpenditureBulks = ProjectFundingSourceExpenditures.Where(x => x.IsRelevant ?? false).ToList();
            if (HasExpenditures && !projectFundingSourceExpenditureBulks.Any())
            {
                errors.Add(new ValidationResult("Please enter your expenditures"));
            }

            if (!HasExpenditures && string.IsNullOrWhiteSpace(Explanation))
            {
                errors.Add(new ValidationResult("Please enter an explanation why you do not have any expenditures"));
            }
            return errors;
        }
    }
}