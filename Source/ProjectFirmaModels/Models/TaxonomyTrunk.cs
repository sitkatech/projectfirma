/*-----------------------------------------------------------------------
<copyright file="TaxonomyTrunk.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

namespace ProjectFirmaModels.Models
{
    public partial class TaxonomyTrunk : IAuditableEntity, IHaveASortOrder, ISortingGroup
    {
        public void SetSortOrder(int? value) => TaxonomyTrunkSortOrder = value;

        public int? GetSortOrder() => TaxonomyTrunkSortOrder;
        public int GetID() => TaxonomyTrunkID;

        public string GetDisplayName()
        {
            var taxonomyPrefix = string.IsNullOrWhiteSpace(TaxonomyTrunkCode)
                ? string.Empty
                : $"{TaxonomyTrunkCode}: ";
            return $"{taxonomyPrefix}{TaxonomyTrunkName}";
        }

        public string GetAuditDescriptionString()
        {
            return GetDisplayName();
        }

        public List<TaxonomyLeaf> GetTaxonomyLeafs()
        {
            return TaxonomyBranches.SelectMany(x => x.TaxonomyLeafs).OrderBy(x => x.TaxonomyLeafName).ToList();
        }

        public List<IGrouping<PerformanceMeasure, TaxonomyLeafPerformanceMeasure>> GetTaxonomyTierPerformanceMeasures()
        {
            return GetTaxonomyLeafs().SelectMany(x => x.TaxonomyLeafPerformanceMeasures).GroupBy(x => x.PerformanceMeasure).ToList();
        }

        public List<IHaveASortOrder> GetSortableList()
        {
            return new List<IHaveASortOrder>(TaxonomyBranches);
        }
    }
}
