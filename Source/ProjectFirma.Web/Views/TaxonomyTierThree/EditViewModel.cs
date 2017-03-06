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

namespace ProjectFirma.Web.Views.TaxonomyTierThree
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int TaxonomyTierThreeID { get; set; }

        [Required]
        [StringLength(Models.TaxonomyTierThree.FieldLengths.TaxonomyTierThreeName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyTierThreeName)]
        public string TaxonomyTierThreeName { get; set; }

        [StringLength(Models.TaxonomyTierThree.FieldLengths.TaxonomyTierThreeDescription)]
        [DisplayName("Description")]
        [Required]
        public string TaxonomyTierThreeDescription { get; set; }

        [Required]
        public string ThemeColor { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.TaxonomyTierThree taxonomyTierThree)
        {
            TaxonomyTierThreeID = taxonomyTierThree.TaxonomyTierThreeID;
            TaxonomyTierThreeName = taxonomyTierThree.TaxonomyTierThreeName;
            TaxonomyTierThreeDescription = taxonomyTierThree.TaxonomyTierThreeDescription;
            ThemeColor = taxonomyTierThree.ThemeColor;
        }

        public void UpdateModel(Models.TaxonomyTierThree taxonomyTierThree, Person currentPerson)
        {
            taxonomyTierThree.TaxonomyTierThreeName = TaxonomyTierThreeName;
            taxonomyTierThree.TaxonomyTierThreeDescription = TaxonomyTierThreeDescription;
            taxonomyTierThree.ThemeColor = ThemeColor;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingTaxonomyTierThrees = HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.ToList();
            if (!Models.TaxonomyTierThree.IsTaxonomyTierThreeNameUnique(existingTaxonomyTierThrees, TaxonomyTierThreeName, TaxonomyTierThreeID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>("Name already exists", x => x.TaxonomyTierThreeName));
            }

            return errors;
        }
    }
}
