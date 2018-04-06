/*-----------------------------------------------------------------------
<copyright file="TaxonomyBranchPerformanceMeasure.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class TaxonomyLeafPerformanceMeasure : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var program = HttpRequestStorage.DatabaseEntities.AllTaxonomyLeafs.Find(TaxonomyLeafID);
                var performanceMeasure = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasures.Find(PerformanceMeasureID);
                var projectName = program != null ? program.AuditDescriptionString : ViewUtilities.NotFoundString;
                var performanceMeasureName = performanceMeasure != null ? performanceMeasure.AuditDescriptionString : ViewUtilities.NotFoundString;
                return $"TaxonomyBranch: {projectName}, Performance Measure: {performanceMeasureName}";
            }
        }
    }
}
