/*-----------------------------------------------------------------------
<copyright file="ExpectedFundingViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ExpectedFundingViewModel : FormViewModel, IValidatableObject
    {
        public List<ProjectFundingSourceBudgetSimple> ProjectFundingSourceBudgets { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ExpectedFundingViewModel()
        {
        }

        public ExpectedFundingViewModel(List<ProjectFirmaModels.Models.ProjectFundingSourceBudget> projectFundingSourceRequests)
        {
            ProjectFundingSourceBudgets = projectFundingSourceRequests
                .Select(x => new ProjectFundingSourceBudgetSimple(x)).ToList();
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project,
            List<ProjectFirmaModels.Models.ProjectFundingSourceBudget> currentProjectFundingSourceBudgets,
            IList<ProjectFirmaModels.Models.ProjectFundingSourceBudget> allProjectFundingSourceBudgets)
        {
            var projectFundingSourceRequestsUpdated = new List<ProjectFirmaModels.Models.ProjectFundingSourceBudget>();
            if (ProjectFundingSourceBudgets != null)
            {
                // Completely rebuild the list
                projectFundingSourceRequestsUpdated = ProjectFundingSourceBudgets
                    .Select(x => x.ToProjectFundingSourceBudget()).ToList();
            }

            currentProjectFundingSourceBudgets.Merge(projectFundingSourceRequestsUpdated,
                allProjectFundingSourceBudgets,
                (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID,
                (x, y) =>
                {
                    x.SecuredAmount = y.SecuredAmount;
                    x.TargetedAmount = y.TargetedAmount;
                }, HttpRequestStorage.DatabaseEntities);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            if (ProjectFundingSourceBudgets == null)
            {
                yield break;
            }

            if (ProjectFundingSourceBudgets.GroupBy(x => x.FundingSourceID).Any(x => x.Count() > 1))
            {
                yield return new ValidationResult("Each funding source can only be used once.");
            }

            foreach (var projectFundingSourceRequest in ProjectFundingSourceBudgets)
            {
                if (projectFundingSourceRequest.AreBothValuesZero())
                {
                    var fundingSource =
                        HttpRequestStorage.DatabaseEntities.FundingSources.Single(x =>
                            x.FundingSourceID == projectFundingSourceRequest.FundingSourceID);
                    yield return new ValidationResult(
                        $"Secured Funding and {FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel()} cannot both be zero for funding source: {fundingSource.GetDisplayName()}. If the amount of Secured or {FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel()} is unknown, you can leave the amounts blank.");
                }
            }
        }
    }
}