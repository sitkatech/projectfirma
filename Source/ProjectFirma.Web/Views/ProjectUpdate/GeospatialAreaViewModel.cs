/*-----------------------------------------------------------------------
<copyright file="LocationSimpleViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class GeospatialAreaViewModel : EditProjectGeospatialAreasViewModel
    {
        [DisplayName("Review Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.GeospatialAreaComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public GeospatialAreaViewModel()
        {
        }

        public GeospatialAreaViewModel(List<int> geospatialAreaIDs,
            string geospatialAreaNotes,
            string comments)
            : base(geospatialAreaIDs, geospatialAreaNotes)
        {
            Comments = comments;
        }

        public void UpdateModelBatch(ProjectUpdateBatch projectUpdateBatch, List<ProjectGeospatialAreaUpdate> currentProjectUpdateGeospatialAreas, ObservableCollection<ProjectGeospatialAreaUpdate> allProjectUpdateGeospatialAreas)
        {
            UpdateModel(projectUpdateBatch, currentProjectUpdateGeospatialAreas, allProjectUpdateGeospatialAreas);
        }
    }
}
