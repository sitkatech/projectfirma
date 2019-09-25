/*-----------------------------------------------------------------------
<copyright file="EditSortOrderInGroupViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.SortOrder
{
    public class EditSortOrderInGroupViewModel : FormViewModel
    {
        public const int SortOrderIncrement = 10;

        public List<int> ReorderedSortableIDs { get; set; }

        public EditSortOrderInGroupViewModel()
        {
        }

        public void UpdateModel(ICollection<ISortingGroup> collectionOfSortingGroups)
        {
            foreach (var sortingGroup in collectionOfSortingGroups)
            {
                var sortableItems = sortingGroup.GetSortableList();
                for (var i = 0; i < ReorderedSortableIDs.Count; i++)
                {
                    var current = sortableItems.SingleOrDefault(x => x.GetID() == ReorderedSortableIDs[i]);

                    current?.SetSortOrder(i * SortOrderIncrement);
                }
            }
        }
    }
}
