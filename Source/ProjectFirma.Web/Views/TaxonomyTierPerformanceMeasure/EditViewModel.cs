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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.TaxonomyTierPerformanceMeasure
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

        public void UpdateModel(List<TaxonomyLeafPerformanceMeasure> currentTaxonomyLeafPerformanceMeasures, IList<TaxonomyLeafPerformanceMeasure> allTaxonomyLeafPerformanceMeasures)
        {
            var taxonomyLeafPerformanceMeasuresUpdated = new List<TaxonomyLeafPerformanceMeasure>();
            if (TaxonomyBranchPerformanceMeasures != null)
            {
                // Completely rebuild the list
                var taxonomyBranchIDsSelected = TaxonomyBranchPerformanceMeasures.Select(x => x.TaxonomyBranchID).ToList();
                var taxonomyBranches = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.Where(x => taxonomyBranchIDsSelected.Contains(x.TaxonomyBranchID)).ToLookup(x => x.TaxonomyBranchID);
                taxonomyLeafPerformanceMeasuresUpdated = TaxonomyBranchPerformanceMeasures.SelectMany(tb => taxonomyBranches[tb.TaxonomyBranchID].Select(x => new TaxonomyLeafPerformanceMeasure(x.TaxonomyLeafID, tb.PerformanceMeasureID, tb.TaxonomyBranchID == PrimaryTaxonomyBranchID))).ToList();
            }
            currentTaxonomyLeafPerformanceMeasures.Merge(taxonomyLeafPerformanceMeasuresUpdated,
                allTaxonomyLeafPerformanceMeasures,
                (x, y) => x.TaxonomyLeafID == y.TaxonomyLeafID && x.PerformanceMeasureID == y.PerformanceMeasureID,
                (x, y) => x.IsPrimaryTaxonomyLeaf = y.IsPrimaryTaxonomyLeaf);
        }
    }
}
