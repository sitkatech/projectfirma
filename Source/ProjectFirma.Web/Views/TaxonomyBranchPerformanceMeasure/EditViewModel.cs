/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.TaxonomyBranchPerformanceMeasure
{
    public class EditViewModel : FormViewModel
    {
        public int? PrimaryTaxonomyBranchID { get; set; }
        public List<TaxonomyBranchPerformanceMeasureSimple> TaxonomyBranchPerformanceMeasures { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(List<TaxonomyBranchPerformanceMeasureSimple> taxonomyBranchPerformanceMeasureSimples, int? primaryTaxonomyBranchID)
        {
            TaxonomyBranchPerformanceMeasures = taxonomyBranchPerformanceMeasureSimples;
            PrimaryTaxonomyBranchID = primaryTaxonomyBranchID;
        }

        public void UpdateModel(List<Models.TaxonomyBranchPerformanceMeasure> currentTaxonomyBranchPerformanceMeasures, IList<Models.TaxonomyBranchPerformanceMeasure> allTaxonomyBranchPerformanceMeasures)
        {
            var taxonomyBranchPerformanceMeasuresUpdated = new List<Models.TaxonomyBranchPerformanceMeasure>();
            if (TaxonomyBranchPerformanceMeasures != null)
            {
                // Completely rebuild the list
                taxonomyBranchPerformanceMeasuresUpdated = TaxonomyBranchPerformanceMeasures.Select(x => new Models.TaxonomyBranchPerformanceMeasure(x.TaxonomyBranchID, x.PerformanceMeasureID, false)).ToList();
            }
            currentTaxonomyBranchPerformanceMeasures.Merge(taxonomyBranchPerformanceMeasuresUpdated,
                allTaxonomyBranchPerformanceMeasures,
                (x, y) => x.TaxonomyBranchID == y.TaxonomyBranchID && x.PerformanceMeasureID == y.PerformanceMeasureID,
                (x, y) => x.IsPrimaryTaxonomyBranch = (PrimaryTaxonomyBranchID == x.TaxonomyBranchID));
        }
    }
}
