/*-----------------------------------------------------------------------
<copyright file="GeospatialAreaViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class GeospatialAreaViewModel : EditProjectGeospatialAreasViewModel
    {

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public GeospatialAreaViewModel()
        {
        }

        public GeospatialAreaViewModel(List<int> geospatialAreaIDs, string geospatialAreaNotes) : base(geospatialAreaIDs, geospatialAreaNotes)
        {
        }
        
        public void UpdateModel(ProjectFirmaModels.Models.Project project, List<ProjectGeospatialArea> currentProjectGeospatialAreas, ObservableCollection<ProjectGeospatialArea> allProjectGeospatialAreas)
        {
            base.UpdateModel(project, currentProjectGeospatialAreas, allProjectGeospatialAreas);
        }
    }    
}
