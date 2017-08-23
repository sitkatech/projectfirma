/*-----------------------------------------------------------------------
<copyright file="EditProjectWatershedsViewModel.cs" company="Tahoe Regional Planning Agency">
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
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectWatershedControls
{
    public class EditProjectWatershedsViewModel : FormViewModel, IValidatableObject
    {
        [DisplayName("Project Watersheds")]
        public IEnumerable<int> WatershedIDs { get; set; }

        [DisplayName("Notes")]
        [StringLength(Models.Project.FieldLengths.ProjectWatershedNotes)]
        public string ProjectWatershedNotes { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectWatershedsViewModel()
        {
        }

        public EditProjectWatershedsViewModel(List<int> watershedIDs, string projectWatershedNotes)
        {
            WatershedIDs = watershedIDs;
            ProjectWatershedNotes = projectWatershedNotes;
        }

        public void UpdateModel(Models.Project project, List<Models.ProjectWatershed> currentProjectWatersheds, IList<Models.ProjectWatershed> allProjectWatersheds)
        {
            var newProjectWatersheds = WatershedIDs?.Select(x => new Models.ProjectWatershed(project.ProjectID, x)).ToList() ?? new List<Models.ProjectWatershed>();
            currentProjectWatersheds.Merge(newProjectWatersheds, allProjectWatersheds, (x, y) => x.ProjectID == y.ProjectID && x.WatershedID == y.WatershedID);
            project.ProjectWatershedNotes = ProjectWatershedNotes;
        }

        public void UpdateModel(Models.ProposedProject project, List<ProposedProjectWatershed> currentProjectWatersheds, IList<ProposedProjectWatershed> allProjectWatersheds)
        {
            var newProjectWatersheds = WatershedIDs?.Select(x => new ProposedProjectWatershed(project.ProposedProjectID, x)).ToList() ?? new List<ProposedProjectWatershed>();
            currentProjectWatersheds.Merge(newProjectWatersheds, allProjectWatersheds, (x, y) => x.ProposedProjectID == y.ProposedProjectID && x.WatershedID == y.WatershedID);
            project.ProjectWatershedNotes = ProjectWatershedNotes;
        }

        public void UpdateModel(Models.ProjectUpdate project, List<ProposedProjectWatershed> currentProjectWatersheds, IList<ProposedProjectWatershed> allProjectWatersheds)
        {
            //todo
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();

            if (!WatershedIDs.Any() && string.IsNullOrWhiteSpace(ProjectWatershedNotes))
            {
                errors.Add(
                    new SitkaValidationResult<EditProjectWatershedsViewModel, string>(
                        "If no watershed are selected, explanatory information in the Notes section is required.",
                        x => x.ProjectWatershedNotes));
            }

            return errors;
        }
    }
}
