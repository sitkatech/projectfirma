/*-----------------------------------------------------------------------
<copyright file="AddGeospatialAreaToPerformanceMeasureViewData.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.GeospatialAreaPerformanceMeasureTarget
{
    public class AddGeospatialAreaToPerformanceMeasureViewData
    {        
        public ProjectFirmaModels.Models.PerformanceMeasure PerformanceMeasure { get; }
        public AddGeospatialAreaToPerformanceMeasureViewDataForAngular ViewDataForAngular { get; }

        public AddGeospatialAreaToPerformanceMeasureViewData(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, AddGeospatialAreaToPerformanceMeasureViewDataForAngular viewDataForAngular)
        {
            PerformanceMeasure = performanceMeasure;
            ViewDataForAngular = viewDataForAngular;

        }
    }

    public class AddGeospatialAreaToPerformanceMeasureViewDataForAngular
    {
        public List<GeospatialAreaTypeSimple> GeospatialAreaTypeSimples { get; set; }
        public List<GeospatialAreaSimple> GeospatialAreaSimples { get; set; }
        

        public AddGeospatialAreaToPerformanceMeasureViewDataForAngular(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, List<GeospatialAreaTypeSimple> geospatialAreaTypeSimples, List<GeospatialAreaSimple> geospatialAreaSimples)
        {
            GeospatialAreaTypeSimples = geospatialAreaTypeSimples;
            GeospatialAreaSimples = geospatialAreaSimples;//todo: probably want this data coming from an AJAX call
        }
    }
}
