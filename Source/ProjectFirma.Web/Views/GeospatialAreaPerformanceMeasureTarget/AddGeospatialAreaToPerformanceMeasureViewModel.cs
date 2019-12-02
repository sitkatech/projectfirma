/*-----------------------------------------------------------------------
<copyright file="AddGeospatialAreaToPerformanceMeasureViewModel.cs" company="Tahoe Regional Planning Agency">
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
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.GeospatialAreaPerformanceMeasureTarget
{
    public class AddGeospatialAreaToPerformanceMeasureViewModel : FormViewModel
    {
        [Required]
        public int PerformanceMeasureID { get; set; }
        public int GeospatialAreaTypeID { get; set; }
        public List<int> GeospatialAreas { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public AddGeospatialAreaToPerformanceMeasureViewModel()
        {
        }

        public AddGeospatialAreaToPerformanceMeasureViewModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
        }

        public void UpdateModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            

        }




    }
}
