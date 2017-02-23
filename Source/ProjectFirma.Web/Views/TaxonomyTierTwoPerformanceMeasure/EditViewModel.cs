/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.TaxonomyTierTwoPerformanceMeasure
{
    public class EditViewModel : FormViewModel
    {
        public int? PrimaryTaxonomyTierTwoID { get; set; }
        public List<TaxonomyTierTwoPerformanceMeasureSimple> TaxonomyTierTwoPerformanceMeasures { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(List<TaxonomyTierTwoPerformanceMeasureSimple> taxonomyTierTwoPerformanceMeasureSimples, int? primaryTaxonomyTierTwoID)
        {
            TaxonomyTierTwoPerformanceMeasures = taxonomyTierTwoPerformanceMeasureSimples;
            PrimaryTaxonomyTierTwoID = primaryTaxonomyTierTwoID;
        }

        public void UpdateModel(List<Models.TaxonomyTierTwoPerformanceMeasure> currentTaxonomyTierTwoPerformanceMeasures, IList<Models.TaxonomyTierTwoPerformanceMeasure> allTaxonomyTierTwoPerformanceMeasures)
        {
            var taxonomyTierTwoPerformanceMeasuresUpdated = new List<Models.TaxonomyTierTwoPerformanceMeasure>();
            if (TaxonomyTierTwoPerformanceMeasures != null)
            {
                // Completely rebuild the list
                taxonomyTierTwoPerformanceMeasuresUpdated = TaxonomyTierTwoPerformanceMeasures.Select(x => new Models.TaxonomyTierTwoPerformanceMeasure(x.TaxonomyTierTwoID, x.PerformanceMeasureID, false)).ToList();
            }
            currentTaxonomyTierTwoPerformanceMeasures.Merge(taxonomyTierTwoPerformanceMeasuresUpdated,
                allTaxonomyTierTwoPerformanceMeasures,
                (x, y) => x.TaxonomyTierTwoID == y.TaxonomyTierTwoID && x.PerformanceMeasureID == y.PerformanceMeasureID,
                (x, y) => x.IsPrimaryTaxonomyTierTwo = (PrimaryTaxonomyTierTwoID == x.TaxonomyTierTwoID));
        }
    }
}
