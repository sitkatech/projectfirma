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
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectWatershed
{
    public class EditProjectWatershedsViewModel : FormViewModel
    {
        [DisplayName("Project Watersheds")]
        public IEnumerable<int> WatershedIDs { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectWatershedsViewModel()
        {
        }

        public EditProjectWatershedsViewModel(Models.Project project)
        {
            WatershedIDs = project.ProjectWatersheds.Select(x => x.WatershedID).ToList();
        }

        public void UpdateModel(Models.Project project, List<Models.ProjectWatershed> currentProjectWatersheds, IList<Models.ProjectWatershed> allProjectWatersheds)
        {
            var newProjectWatersheds = WatershedIDs?.Select(x => new Models.ProjectWatershed(project.ProjectID, x)).ToList() ?? new List<Models.ProjectWatershed>();
            currentProjectWatersheds.Merge(newProjectWatersheds, allProjectWatersheds, (x, y) => x.ProjectID == y.ProjectID && x.WatershedID == y.WatershedID);
        }
    }
}
