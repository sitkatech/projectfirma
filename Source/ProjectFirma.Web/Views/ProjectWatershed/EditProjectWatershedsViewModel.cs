/*-----------------------------------------------------------------------
<copyright file="EditProjectWatershedsViewModel.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectWatershed
{
    public class EditProjectWatershedsViewModel : FormViewModel
    {
        public List<ProjectWatershedSimple> ProjectWatersheds { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectWatershedsViewModel()
        {
        }

        public EditProjectWatershedsViewModel(List<ProjectWatershedSimple> projectWatersheds)
        {
            ProjectWatersheds = projectWatersheds;
        }

        public void UpdateModel(List<Models.ProjectWatershed> currentProjectWatersheds, IList<Models.ProjectWatershed> allProjectWatersheds)
        {
            var projectWatershedsUpdated = new List<Models.ProjectWatershed>();
            if (ProjectWatersheds != null)
            {
                // Completely rebuild the list
                projectWatershedsUpdated = ProjectWatersheds.Select(x => new Models.ProjectWatershed(x.ProjectID, x.WatershedID)).ToList();
            }
            currentProjectWatersheds.Merge(projectWatershedsUpdated, allProjectWatersheds, (x, y) => x.ProjectID == y.ProjectID && x.WatershedID == y.WatershedID);
        }
    }
}
