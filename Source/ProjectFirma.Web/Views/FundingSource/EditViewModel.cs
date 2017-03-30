/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency">
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.FundingSource
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int FundingSourceID { get; set; }

        [Required]
        [StringLength(Models.FundingSource.FieldLengths.FundingSourceName)]
        [DisplayName("Name")]
        public string FundingSourceName { get; set; }

        [Required]
        public int OrganizationID { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [StringLength(Models.FundingSource.FieldLengths.FundingSourceDescription)]
        [DisplayName("Description")]
        public string FundingSourceDescription { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.FundingSource fundingSource)
        {
            FundingSourceID = fundingSource.FundingSourceID;
            FundingSourceName = fundingSource.FundingSourceName;
            FundingSourceDescription = fundingSource.FundingSourceDescription;
            OrganizationID = fundingSource.OrganizationID;
            IsActive = fundingSource.IsActive;
        }

        public void UpdateModel(Models.FundingSource fundingSource, Person currentPerson)
        {
            fundingSource.FundingSourceName = FundingSourceName;
            fundingSource.FundingSourceDescription = FundingSourceDescription;
            fundingSource.OrganizationID = OrganizationID;
            fundingSource.IsActive = IsActive;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.Where(x => x.OrganizationID == OrganizationID).ToList();
            if (!Models.FundingSource.IsFundingSourceNameUnique(existingFundingSources, FundingSourceName, FundingSourceID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>(FirmaValidationMessages.FundingSourceNameUnique, x => x.FundingSourceName));
            }
            return errors;
        }
    }
}
