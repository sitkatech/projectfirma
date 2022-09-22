/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using NUnit.Framework;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Solicitation
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int SolicitationID { get; set; }

        [Required]
        [DisplayName("Name")]
        [StringLength(ProjectFirmaModels.Models.Solicitation.FieldLengths.SolicitationName)]
        public string SolicitationName { get; set; }

        [DisplayName("Attachment Instructions")]
        public HtmlString AttachmentInstructions { get; set; }

        [DisplayName("Is Active?")]
        public bool IsActive { get; set; }

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
            AttachmentInstructions = solicitation.AttachmentInstructionsHtmlString;
            IsActive = solicitation.IsActive;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Solicitation solicitation, FirmaSession currentFirmaSession)
        {
            solicitation.SolicitationName = SolicitationName;
            solicitation.AttachmentInstructionsHtmlString = AttachmentInstructions;
            solicitation.IsActive = IsActive;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();


            return errors;
        }
    }
}
