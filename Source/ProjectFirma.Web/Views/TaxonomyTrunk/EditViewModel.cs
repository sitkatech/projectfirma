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
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.TaxonomyTrunk
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int TaxonomyTrunkID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.TaxonomyTrunk.FieldLengths.TaxonomyTrunkName)]
        [DisplayName("Name")]
        public string TaxonomyTrunkName { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyTrunkDescription)]
        [Required]
        public HtmlString TaxonomyTrunkDescription { get; set; }

        [DisplayName("Theme Color")]
        [Required]
        public string ThemeColor { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.TaxonomyTrunk taxonomyTrunk)
        {
            TaxonomyTrunkID = taxonomyTrunk.TaxonomyTrunkID;
            TaxonomyTrunkName = taxonomyTrunk.TaxonomyTrunkName;
            TaxonomyTrunkDescription = taxonomyTrunk.TaxonomyTrunkDescriptionHtmlString;
            ThemeColor = taxonomyTrunk.ThemeColor;
        }

        public void UpdateModel(ProjectFirmaModels.Models.TaxonomyTrunk taxonomyTrunk, FirmaSession currentFirmaSession)
        {
            taxonomyTrunk.TaxonomyTrunkName = TaxonomyTrunkName;
            taxonomyTrunk.TaxonomyTrunkDescriptionHtmlString = TaxonomyTrunkDescription;
            taxonomyTrunk.ThemeColor = ThemeColor;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingTaxonomyTrunks = HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.ToList();
            if (!existingTaxonomyTrunks.IsTaxonomyTrunkNameUnique(TaxonomyTrunkName, TaxonomyTrunkID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>("Name already exists", x => x.TaxonomyTrunkName));
            }

            return errors;
        }
    }
}
