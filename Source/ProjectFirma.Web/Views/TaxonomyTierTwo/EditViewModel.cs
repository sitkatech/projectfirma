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

namespace ProjectFirma.Web.Views.TaxonomyTierTwo
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int TaxonomyTierTwoID { get; set; }

        [Required]
        [StringLength(Models.TaxonomyTierTwo.FieldLengths.TaxonomyTierTwoName)]
        [DisplayName("Name")]
        public string TaxonomyTierTwoName { get; set; }

        [StringLength(Models.TaxonomyTierTwo.FieldLengths.TaxonomyTierTwoDescription)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyTierTwoDescription)]
        public string TaxonomyTierTwoDescription { get; set; }

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

        public EditViewModel(Models.TaxonomyTierTwo taxonomyTierTwo)
        {
            TaxonomyTierTwoID = taxonomyTierTwo.TaxonomyTierTwoID;
            TaxonomyTierTwoName = taxonomyTierTwo.TaxonomyTierTwoName;
            TaxonomyTierTwoDescription = taxonomyTierTwo.TaxonomyTierTwoDescription;
            TaxonomyTrunkID = taxonomyTierTwo.TaxonomyTrunkID;
            ThemeColor = taxonomyTierTwo.ThemeColor;
        }

        public void UpdateModel(Models.TaxonomyTierTwo taxonomyTierTwo, Person currentPerson)
        {
            taxonomyTierTwo.TaxonomyTierTwoName = TaxonomyTierTwoName;
            taxonomyTierTwo.TaxonomyTierTwoDescription = TaxonomyTierTwoDescription;
            taxonomyTierTwo.TaxonomyTrunkID = MultiTenantHelpers.GetNumberOfTaxonomyTiers() == 3
                ? TaxonomyTrunkID
                : HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.First().TaxonomyTrunkID; // really should only be one
            taxonomyTierTwo.ThemeColor = ThemeColor;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var existingTaxonomyTierTwos = HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.ToList();
            if (!Models.TaxonomyTierTwo.IsTaxonomyTierTwoNameUnique(existingTaxonomyTierTwos, TaxonomyTierTwoName, TaxonomyTierTwoID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>("Name already exists", x => x.TaxonomyTierTwoName));
            }
            return errors;
        }
    }
}
