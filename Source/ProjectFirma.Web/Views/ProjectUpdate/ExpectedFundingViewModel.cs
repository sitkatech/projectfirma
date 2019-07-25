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
        [FieldDefinitionDisplay(FieldDefinitionEnum.NoFundingSourceIdentified)]
        public Money? NoFundingSourceIdentifiedYet { get; set; }

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
            NoFundingSourceIdentifiedYet = projectUpdateBatch.ProjectUpdate.NoFundingSourceIdentifiedYet;
            Comments = comments;
            ViewModelForAngular = new ViewModelForAngularEditor(projectUpdateBatch.ProjectUpdate.FundingTypeID ?? 0, projectFundingSourceBudgetUpdates, NoFundingSourceIdentifiedYet);
        }

        public class ViewModelForAngularEditor
        {
            [FieldDefinitionDisplay(FieldDefinitionEnum.FundingType)]
            [Required]
            public int FundingTypeID { get; set; }
            public List<ProjectFundingSourceBudgetSimple> ProjectFundingSourceBudgetUpdateSimples { get; set; }
            public decimal? NoFundingSourceIdentifiedYet { get; set; }

            public ViewModelForAngularEditor()
            {
            }

            public ViewModelForAngularEditor(int fundingTypeID, List<ProjectFundingSourceBudgetUpdate> projectFundingSourceBudgetUpdates, decimal? noFundingSourceIdentifiedYet)
            {
                FundingTypeID = fundingTypeID;
                ProjectFundingSourceBudgetUpdateSimples = projectFundingSourceBudgetUpdates
                    .Select(x => new ProjectFundingSourceBudgetSimple(x)).ToList();
                NoFundingSourceIdentifiedYet = noFundingSourceIdentifiedYet;
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
            projectUpdateBatch.ProjectUpdate.NoFundingSourceIdentifiedYet = ViewModelForAngular.NoFundingSourceIdentifiedYet;
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
            ViewModelForAngular = ViewModelForAngular ?? new ViewModelForAngularEditor(0, new List<ProjectFundingSourceBudgetUpdate>(), 0);

            if (ViewModelForAngular.FundingTypeID == 0 && (ViewModelForAngular.NoFundingSourceIdentifiedYet != null || ViewModelForAngular.ProjectFundingSourceBudgetUpdateSimples != null))
            {
                validationResults.Add(new ValidationResult($"You must answer the question \"Does the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} budget vary by year or is it the same?\" when entering any funding values."));
            }

            if (ViewModelForAngular.FundingTypeID != 0 && ViewModelForAngular.NoFundingSourceIdentifiedYet == null)
            {
                validationResults.Add(new ValidationResult($"{FieldDefinitionEnum.NoFundingSourceIdentified.ToType().GetFieldDefinitionLabel()} cannot be blank. If the amount is unknown, you can enter zero."));
            }

            if (ViewModelForAngular.ProjectFundingSourceBudgetUpdateSimples == null)
            {
                // set to empty list so model will be valid when returning with validation error
                ViewModelForAngular.ProjectFundingSourceBudgetUpdateSimples = new List<ProjectFundingSourceBudgetSimple>();
                return validationResults;
            }

            if (ViewModelForAngular.ProjectFundingSourceBudgetUpdateSimples.GroupBy(x => x.FundingSourceID).Any(x => x.Count() > 1))
            {
                validationResults.Add(new ValidationResult($"Each {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()} can only be used once."));
            }

            foreach (var projectFundingSourceBudget in ViewModelForAngular.ProjectFundingSourceBudgetUpdateSimples)
            {
                if (projectFundingSourceBudget.AnyValueIsNull())
                {
                    var fundingSource =
                        HttpRequestStorage.DatabaseEntities.FundingSources.Single(x =>
                            x.FundingSourceID == projectFundingSourceBudget.FundingSourceID);
                    validationResults.Add(new ValidationResult(
                        $"{FieldDefinitionEnum.SecuredFunding.ToType().GetFieldDefinitionLabel()} and {FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel()} must both have values for {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()}: {fundingSource.GetDisplayName()}. If the amount of {FieldDefinitionEnum.SecuredFunding.ToType().GetFieldDefinitionLabel()} or {FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel()} is unknown, you can enter zero."));
                }
            }
            return validationResults;
        }
    }
}
