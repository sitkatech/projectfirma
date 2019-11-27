/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.FundingSource
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int FundingSourceID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.FundingSource.FieldLengths.FundingSourceName)]
        [DisplayName("Name")]
        public string FundingSourceName { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.Organization)]
        public int? OrganizationID { get; set; }

        [Required]
        [DisplayName("Active?")]
        public bool? IsActive { get; set; }

        [StringLength(ProjectFirmaModels.Models.FundingSource.FieldLengths.FundingSourceDescription)]
        [DisplayName("Description")]
        public string FundingSourceDescription { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingSourceAmount)]
        public MoneyWholeNumber? FundingSourceAmount { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.FundingSource fundingSource)
        {
            FundingSourceID = fundingSource.FundingSourceID;
            FundingSourceName = fundingSource.FundingSourceName;
            FundingSourceDescription = fundingSource.FundingSourceDescription;
            OrganizationID = fundingSource.OrganizationID;
            IsActive = fundingSource.IsActive;
            FundingSourceAmount = fundingSource.FundingSourceAmount;
        }

        public void UpdateModel(ProjectFirmaModels.Models.FundingSource fundingSource, FirmaSession currentFirmaSession)
        {
            fundingSource.FundingSourceName = FundingSourceName;
            fundingSource.FundingSourceDescription = FundingSourceDescription;
            fundingSource.OrganizationID = OrganizationID ?? ModelObjectHelpers.NotYetAssignedID; // should never be null due to Required Validation Attribute
            fundingSource.IsActive = IsActive ?? false; // should never be null due to Required Validation Attribute
            fundingSource.FundingSourceAmount = FundingSourceAmount;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.Where(x => x.OrganizationID == OrganizationID).ToList();
            if (!FundingSourceModelExtensions.IsFundingSourceNameUnique(existingFundingSources, FundingSourceName, FundingSourceID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>(FirmaValidationMessages.FundingSourceNameUnique, x => x.FundingSourceName));
            }

            var currentPerson = HttpRequestStorage.Person;
            if (new List<ProjectFirmaModels.Models.Role> {ProjectFirmaModels.Models.Role.Admin, ProjectFirmaModels.Models.Role.SitkaAdmin}.All(
                x => x.RoleID != currentPerson.RoleID) && currentPerson.OrganizationID != OrganizationID)
            {
                var errorMessage = $"You cannot create a {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()} for an {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} other than your own.";
                errors.Add(new SitkaValidationResult<EditViewModel, int?>(errorMessage, x => x.OrganizationID));
            }

            if (FundingSourceAmount != null && FundingSourceAmount < 0)
            {
                errors.Add(new SitkaValidationResult<EditViewModel, MoneyWholeNumber?>(FieldDefinitionEnum.FundingSourceAmount.ToType().GetFieldDefinitionLabel() + " cannot be a negative amount", x => x.FundingSourceAmount));
            }

            return errors;
        }
    }
}
