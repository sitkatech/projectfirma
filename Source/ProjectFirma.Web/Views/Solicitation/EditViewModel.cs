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

namespace ProjectFirma.Web.Views.Solicitation
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int SolicitationID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.Solicitation.FieldLengths.SolicitationName)]
        public string SolicitationName { get; set; }

        [StringLength(ProjectFirmaModels.Models.Solicitation.FieldLengths.Instructions)]
        public string Instructions { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.Solicitation solicitation)
        {
            SolicitationID = solicitation.SolicitationID;
            SolicitationName = solicitation.SolicitationName;
            Instructions = solicitation.Instructions;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Solicitation solicitation, FirmaSession currentFirmaSession)
        {
            solicitation.SolicitationName = SolicitationName;
            solicitation.Instructions = Instructions;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            //var existingTags = HttpRequestStorage.DatabaseEntities.Tags.ToList();
            //if (!TagModelExtensions.IsTagNameUnique(existingTags, SolicitationName, SolicitationID))
            //{
            //    errors.Add(new SitkaValidationResult<EditViewModel, string>(FirmaValidationMessages.TagNameUnique, x => x.SolicitationName));
            //}

            return errors;
        }
    }
}
