/*-----------------------------------------------------------------------
<copyright file="IPerformanceMeasureValueSubcategoryOption<PerformanceMeasureSubcategoryOption>.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public interface IPerformanceMeasureValueSubcategoryOption
    {
        int PerformanceMeasureID { get; }
        int PerformanceMeasureSubcategoryID { get; }
        PerformanceMeasureSubcategoryOption PerformanceMeasureSubcategoryOption { get; }
        PerformanceMeasure PerformanceMeasure { get; }
        PerformanceMeasureSubcategory PerformanceMeasureSubcategory { get; }
        int PrimaryKey { get; }
        int PerformanceMeasureSubcategoryOptionID { get; }
    }

    /// <summary>
    /// This exists so that overrides of <see cref="PerformanceMeasureDataSourceType.GetReportedPerformanceMeasureValues"/> can set their Subcategory/Options in a customized way
    /// </summary>
    public class VirtualPerformanceMeasureValueSubcategoryOption : IPerformanceMeasureValueSubcategoryOption
    {
        public int PerformanceMeasureID => PerformanceMeasure.PerformanceMeasureID;
        public int PerformanceMeasureSubcategoryID => PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryID;
        public PerformanceMeasureSubcategoryOption PerformanceMeasureSubcategoryOption { get; }
        public PerformanceMeasure PerformanceMeasure { get; }
        public PerformanceMeasureSubcategory PerformanceMeasureSubcategory { get; }
        public int PrimaryKey => ModelObjectHelpers.NotYetAssignedID;
        public int PerformanceMeasureSubcategoryOptionID { get; }

        public VirtualPerformanceMeasureValueSubcategoryOption(
            PerformanceMeasureSubcategory performanceMeasureSubcategory)
        {
            PerformanceMeasureSubcategoryOptionID = ModelObjectHelpers.NotYetAssignedID;
            PerformanceMeasureSubcategory = performanceMeasureSubcategory;
            PerformanceMeasure = PerformanceMeasureSubcategory.PerformanceMeasure;
        }
    }
}
