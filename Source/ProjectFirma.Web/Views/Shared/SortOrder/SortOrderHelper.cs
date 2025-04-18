﻿/*-----------------------------------------------------------------------
<copyright file="SortOrderHelper.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common.ModalDialog;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.SortOrder
{
    public static class SortOrderHelper
    {
        public static HtmlString SortOrderModalLink(string url, bool hasPermission)
        {
            return ModalDialogFormHelper.ModalDialogFormLink("Edit Sort Order", url,
                "Edit sort order", new List<string> {"btn", "btn-firma"}, hasPermission);
        }

        public static IOrderedEnumerable<T> SortByOrderThenName<T>(this IEnumerable<T> sortableList) where T : IHaveASortOrder
        {
            return sortableList.OrderBy(x => x.GetSortOrder()).ThenBy(x => x.GetDisplayName(), StringComparer.InvariantCultureIgnoreCase);
        }
    }
}