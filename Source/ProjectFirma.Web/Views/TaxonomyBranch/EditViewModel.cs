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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.TaxonomyBranch
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int TaxonomyBranchID { get; set; }

        [Required]
        [StringLength(Models.TaxonomyBranch.FieldLengths.TaxonomyBranchName)]
        [DisplayName("Name")]
        public string TaxonomyBranchName { get; set; }

        [StringLength(Models.TaxonomyBranch.FieldLengths.TaxonomyBranchDescription)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyBranchDescription)]
        public string TaxonomyBranchDescription { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyTrunk)]
        public int TaxonomyTrunkID { get; set; }

        [Required]
        public string ThemeColor { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.TaxonomyBranch taxonomyBranch)
        {
            TaxonomyBranchID = taxonomyBranch.TaxonomyBranchID;
            TaxonomyBranchName = taxonomyBranch.TaxonomyBranchName;
            TaxonomyBranchDescription = taxonomyBranch.TaxonomyBranchDescription;
            TaxonomyTrunkID = taxonomyBranch.TaxonomyTrunkID;
            ThemeColor = taxonomyBranch.ThemeColor;
        }

        public void UpdateModel(Models.TaxonomyBranch taxonomyBranch, Person currentPerson)
        {
            taxonomyBranch.TaxonomyBranchName = TaxonomyBranchName;
            taxonomyBranch.TaxonomyBranchDescription = TaxonomyBranchDescription;
            taxonomyBranch.TaxonomyTrunkID = MultiTenantHelpers.IsTaxonomyLevelTrunk()
                ? TaxonomyTrunkID
                : HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.First().TaxonomyTrunkID; // really should only be one
            taxonomyBranch.ThemeColor = ThemeColor;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var existingTaxonomyBranches = HttpRequestStorage.DatabaseEntities.TaxonomyBranches.ToList();
            if (!Models.TaxonomyBranch.IsTaxonomyBranchNameUnique(existingTaxonomyBranches, TaxonomyBranchName, TaxonomyBranchID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>("Name already exists", x => x.TaxonomyBranchName));
            }
            return errors;
        }
    }
}
