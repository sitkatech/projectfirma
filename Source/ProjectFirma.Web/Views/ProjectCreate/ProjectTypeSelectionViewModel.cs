/*-----------------------------------------------------------------------
<copyright file="ProjectTypeSelectionViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ProjectTypeSelectionViewModel : FormViewModel, IValidatableObject
    {
        public bool? ProjectIsProposal { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ProjectTypeSelectionViewModel()
        {
        }

        // Chose this validation pattern instead of the RequiredAttribute because the qtip validation message is unfriendly
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if (ProjectIsProposal == null)
            {
                errors.Add(new ValidationResult("You must select an option in order to proceed."));
            }

            return errors;
        }
    }
}
