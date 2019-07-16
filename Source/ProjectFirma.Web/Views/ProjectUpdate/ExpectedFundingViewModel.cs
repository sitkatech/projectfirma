/*-----------------------------------------------------------------------
<copyright file="ExpendituresViewModel.cs" company="Tahoe Regional Planning Agency">
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

using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExpectedFundingViewModel : FormViewModel, IValidatableObject
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.EstimatedTotalCost)]
        public Money? EstimatedTotalCost { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.EstimatedAnnualOperatingCost)]
        public Money? EstimatedAnnualOperatingCost { get; set; }

        [DisplayName("Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.ExpendituresComment)]
        public string Comments { get; set; }

        public ViewModelForAngularEditor ViewModelForAngular { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ExpectedFundingViewModel()
        {
        }

        public ExpectedFundingViewModel(ProjectUpdateBatch projectUpdateBatch, List<ProjectFundingSourceBudgetUpdate> projectFundingSourceBudgetUpdates,
            string comments)
        {
            EstimatedTotalCost = projectUpdateBatch.ProjectUpdate.EstimatedTotalCost;
            EstimatedAnnualOperatingCost = projectUpdateBatch.ProjectUpdate.EstimatedAnnualOperatingCost;
            Comments = comments;
            ViewModelForAngular = new ViewModelForAngularEditor(projectUpdateBatch.ProjectUpdate.FundingTypeID ?? 0, projectFundingSourceBudgetUpdates);
        }

        public class ViewModelForAngularEditor
        {
            [FieldDefinitionDisplay(FieldDefinitionEnum.FundingType)]
            [Required]
            public int FundingTypeID { get; set; }
            public List<ProjectFundingSourceBudgetSimple> ProjectFundingSourceBudgetUpdateSimples { get; set; }

            public ViewModelForAngularEditor()
            {
            }

            public ViewModelForAngularEditor(int fundingTypeID, List<ProjectFundingSourceBudgetUpdate> projectFundingSourceBudgetUpdates)
            {
                FundingTypeID = fundingTypeID;
                ProjectFundingSourceBudgetUpdateSimples = projectFundingSourceBudgetUpdates
                    .Select(x => new ProjectFundingSourceBudgetSimple(x)).ToList();
            }
        }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch,
            List<ProjectFundingSourceBudgetUpdate> currentProjectFundingSourceBudgetUpdates,
            IList<ProjectFundingSourceBudgetUpdate> allProjectFundingSourceBudgetUpdates)
        {
            if (ViewModelForAngular.FundingTypeID > 0)
            {
                projectUpdateBatch.ProjectUpdate.FundingTypeID = ViewModelForAngular.FundingTypeID;
            }
            projectUpdateBatch.ProjectUpdate.EstimatedTotalCost = EstimatedTotalCost;
            projectUpdateBatch.ProjectUpdate.EstimatedAnnualOperatingCost = EstimatedAnnualOperatingCost;
            var projectFundingSourceBudgetUpdatesUpdated = new List<ProjectFundingSourceBudgetUpdate>();
            if (ViewModelForAngular.ProjectFundingSourceBudgetUpdateSimples != null)
            {
                // Completely rebuild the list
                projectFundingSourceBudgetUpdatesUpdated = ViewModelForAngular.ProjectFundingSourceBudgetUpdateSimples.Select(x => x.ToProjectFundingSourceBudgetUpdate()).ToList();
            }

            currentProjectFundingSourceBudgetUpdates.Merge(projectFundingSourceBudgetUpdatesUpdated,
                allProjectFundingSourceBudgetUpdates,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.FundingSourceID == y.FundingSourceID,
                (x, y) =>
                {
                    x.SecuredAmount = y.SecuredAmount;
                    x.TargetedAmount = y.TargetedAmount;
                }, HttpRequestStorage.DatabaseEntities);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            // ViewModelForAngular will be null if no ProjectFundingSourceBudgets are entered, recreate it so model will be valid when returning with validation error
            ViewModelForAngular = ViewModelForAngular ?? new ViewModelForAngularEditor(0, new List<ProjectFundingSourceBudgetUpdate>());

            if (ViewModelForAngular.ProjectFundingSourceBudgetUpdateSimples == null)
            {
                return validationResults;
            }

            if (ViewModelForAngular.ProjectFundingSourceBudgetUpdateSimples.GroupBy(x => x.FundingSourceID).Any(x => x.Count() > 1))
            {
                validationResults.Add(new ValidationResult($"Each {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()} can only be used once."));
            }

            foreach (var projectFundingSourceBudget in ViewModelForAngular.ProjectFundingSourceBudgetUpdateSimples)
            {
                if (projectFundingSourceBudget.AreBothValuesZero())
                {
                    var fundingSource =
                        HttpRequestStorage.DatabaseEntities.FundingSources.Single(x =>
                            x.FundingSourceID == projectFundingSourceBudget.FundingSourceID);
                    validationResults.Add(new ValidationResult(
                        $"{FieldDefinitionEnum.SecuredFunding.ToType().GetFieldDefinitionLabel()} and {FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel()} cannot both be zero for {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()}: {fundingSource.GetDisplayName()}. If the amount of {FieldDefinitionEnum.SecuredFunding.ToType().GetFieldDefinitionLabel()} or {FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel()} is unknown, you can leave the amounts blank."));
                }
            }
            return validationResults;
        }
    }
}
