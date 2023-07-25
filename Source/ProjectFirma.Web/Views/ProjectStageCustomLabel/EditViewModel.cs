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
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectStageCustomLabel
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        public int ProjectStageID { get; set; }

        [Required]
        [DisplayName("Custom Label")]
        [StringLength(ProjectFirmaModels.Models.ProjectStageCustomLabel.FieldLengths.ProjectStageLabel)]
        public string ProjectStageCustomLabel { get; set; }


        /// <summary>
        /// Needed by model binder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(int projectStageID, ProjectFirmaModels.Models.ProjectStageCustomLabel projectStageCustomLabel)
        {
            ProjectStageID = projectStageID;
            ProjectStageCustomLabel = projectStageCustomLabel?.ProjectStageLabel;
        }

        public void UpdateModel(ProjectFirmaModels.Models.ProjectStageCustomLabel projectStageCustomLabel)
        {
            projectStageCustomLabel.ProjectStageLabel = ProjectStageCustomLabel;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            var defaultProjectStageLabels = ProjectStage.All.Where(x => x.ProjectStageID != ProjectStageID).Select(x => x.ProjectStageDisplayName.ToLower());
            if (defaultProjectStageLabels.Contains(ProjectStageCustomLabel.ToLower()))
            {
                validationResults.Add(new ValidationResult($"This label is already used as a default label for a different {FieldDefinitionEnum.ProjectStage.ToType().GetFieldDefinitionLabel()}. To prevent confusion, you cannot label this stage the same thing as a system default label for a different stage."));
            }

            var customProjectStageLabels =
                HttpRequestStorage.DatabaseEntities.ProjectStageCustomLabels.Where(x => x.ProjectStageID != ProjectStageID).Select(x => x.ProjectStageLabel.ToLower());
            if (customProjectStageLabels.Contains(ProjectStageCustomLabel.ToLower()))
            {
                validationResults.Add(new ValidationResult($"This label is already used as a custom label for a different {FieldDefinitionEnum.ProjectStage.ToType().GetFieldDefinitionLabel()}. To prevent confusion, you cannot label this stage the same thing as a custom label for a different stage."));

            }

            return validationResults;
        }
    }
}
