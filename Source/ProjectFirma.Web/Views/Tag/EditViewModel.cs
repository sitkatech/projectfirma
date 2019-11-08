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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Tag
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int TagID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.Tag.FieldLengths.TagName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TagName)]
        [RegularExpression(@"^[a-zA-Z0-9-_\s]{1,}$", ErrorMessage = FirmaValidationMessages.LettersNumbersSpacesDashesAndUnderscoresOnly)]
        public string TagName { get; set; }

        [StringLength(ProjectFirmaModels.Models.Tag.FieldLengths.TagDescription)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TagDescription)]
        public string TagDescription { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.Tag tag)
        {
            TagID = tag.TagID;
            TagName = tag.TagName;
            TagDescription = tag.TagDescription;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Tag tag, FirmaSession currentFirmaSession)
        {
            tag.TagName = TagName;
            tag.TagDescription = TagDescription;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingTags = HttpRequestStorage.DatabaseEntities.Tags.ToList();
            if (!TagModelExtensions.IsTagNameUnique(existingTags, TagName, TagID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>(FirmaValidationMessages.TagNameUnique, x => x.TagName));
            }

            return errors;
        }
    }
}
