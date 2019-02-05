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
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ProjectTypeSelectionViewModel : FormViewModel, IValidatableObject
    {
        public enum ProjectCreateType
        {
            Proposal,
            Existing,
            ImportExternal
        }
        
        [DisplayName("Project Create Type")]
        [Required(ErrorMessage = "You must select an option in order to proceed.")]
        public ProjectCreateType? CreateType { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            // Should only be able to import external when project external data source is set on tenant attribute
            if (CreateType == ProjectCreateType.ImportExternal &&
                !MultiTenantHelpers.GetTenantAttribute().ProjectExternalDataSourceEnabled)
            {
                errors.Add(new SitkaValidationResult<ProjectTypeSelectionViewModel, ProjectCreateType?>("Invalid option.", m => m.CreateType));
            }

            return errors;
        }
    }
}
