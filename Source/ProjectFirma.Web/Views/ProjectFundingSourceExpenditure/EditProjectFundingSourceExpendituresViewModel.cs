/*-----------------------------------------------------------------------
<copyright file="EditProjectFundingSourceExpendituresViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectUpdate;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectFundingSourceExpenditure
{
    public class EditProjectFundingSourceExpendituresViewModel : FormViewModel, IValidatableObject
    {
        public int ProjectID { get; set; }

        public List<ProjectFundingSourceExpenditureBulk> ProjectFundingSourceExpenditures { get; set; }
        public string ExpendituresNote { get; set; }

        public List<ProjectExemptReportingYearSimple> ProjectExemptReportingYears { get; set; }
        public bool HasExpenditures { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectFundingSourceExpendituresViewModel()
        {
        }

        public EditProjectFundingSourceExpendituresViewModel(ProjectFirmaModels.Models.Project project,
                                                            List<ProjectFundingSourceExpenditureBulk> projectFundingSourceExpenditureBulks)
        {
            // Preconditions
            Check.EnsureNotNull(project);
            Check.EnsureNotNull(projectFundingSourceExpenditureBulks);

            ProjectFundingSourceExpenditures = projectFundingSourceExpenditureBulks;
            ExpendituresNote = project.ExpendituresNote;
            ProjectID = project.ProjectID;
            HasExpenditures = projectFundingSourceExpenditureBulks.Any();
        }

        public void UpdateModel(List<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure> currentProjectFundingSourceExpenditures,
            IList<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure> allProjectFundingSourceExpenditures, ProjectFirmaModels.Models.Project project)
        {
            var projectFundingSourceExpendituresUpdated = new List<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure>();
            if (ProjectFundingSourceExpenditures != null)
            {
                // Completely rebuild the list
                projectFundingSourceExpendituresUpdated = ProjectFundingSourceExpenditures.Where(x => x.IsRelevant).SelectMany(x => x.ToProjectFundingSourceExpenditures()).ToList();
            }

            var databaseEntities = HttpRequestStorage.DatabaseEntities;

            project.ExpendituresNote = ExpendituresNote;

            currentProjectFundingSourceExpenditures.Merge(projectFundingSourceExpendituresUpdated,
                allProjectFundingSourceExpenditures,
                (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID && x.CalendarYear == y.CalendarYear,
                (x, y) => x.ExpenditureAmount = y.ExpenditureAmount, databaseEntities);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var project = HttpRequestStorage.DatabaseEntities.Projects.Single(x => x.ProjectID == ProjectID);
            var validationErrors = ExpendituresValidationResult.Validate(ProjectFundingSourceExpenditures, ExpendituresNote, project.GetProjectUpdatePlanningDesignStartToCompletionYearRange(), HasExpenditures);
            errors.AddRange(validationErrors.Select(x => new ValidationResult(x)));
            return errors;
        }
    }
}
