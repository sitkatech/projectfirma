/*-----------------------------------------------------------------------
<copyright file="SpendingByPerformanceMeasureByProjectViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingByPerformanceMeasureByProjectViewModel : FormViewModel
    {
        public int? PerformanceMeasureID { get; set; }

        public Models.PerformanceMeasure PerformanceMeasure { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public SpendingByPerformanceMeasureByProjectViewModel()
        {
        }

        public SpendingByPerformanceMeasureByProjectViewModel(int? performanceMeasureID, Models.PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureID = performanceMeasureID;
            PerformanceMeasure = performanceMeasure;
        }
    }
}
