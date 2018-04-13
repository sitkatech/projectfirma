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

namespace ProjectFirma.Web.Views.TaxonomyLeaf
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int TaxonomyLeafID { get; set; }

        [Required]
        [StringLength(Models.TaxonomyLeaf.FieldLengths.TaxonomyLeafName)]
        [DisplayName("Name")]
        public string TaxonomyLeafName { get; set; }

        [StringLength(Models.TaxonomyLeaf.FieldLengths.TaxonomyLeafDescription)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyLeafDescription)]
        [Required]
        public string TaxonomyLeafDescription { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyBranch)]
        public int TaxonomyBranchID { get; set; }

        public string ThemeColor { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.TaxonomyLeaf taxonomyLeaf)
        {
            TaxonomyLeafID = taxonomyLeaf.TaxonomyLeafID;
            TaxonomyLeafName = taxonomyLeaf.TaxonomyLeafName;
            TaxonomyLeafDescription = taxonomyLeaf.TaxonomyLeafDescription;
            TaxonomyBranchID = taxonomyLeaf.TaxonomyBranchID;
            ThemeColor = taxonomyLeaf.ThemeColor;
        }

        public void UpdateModel(Models.TaxonomyLeaf taxonomyLeaf, Person currentPerson)
        {
            taxonomyLeaf.TaxonomyLeafName = TaxonomyLeafName;
            taxonomyLeaf.TaxonomyLeafDescription = TaxonomyLeafDescription;
            taxonomyLeaf.TaxonomyBranchID = TaxonomyBranchID;
            taxonomyLeaf.ThemeColor = ThemeColor;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingTaxonomyLeafs = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.ToList();
            if (!Models.TaxonomyLeaf.IsTaxonomyLeafNameUnique(existingTaxonomyLeafs, TaxonomyLeafName, TaxonomyLeafID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>("Name already exists", x => x.TaxonomyLeafName));
            }

            return errors;
        }
    }
}
