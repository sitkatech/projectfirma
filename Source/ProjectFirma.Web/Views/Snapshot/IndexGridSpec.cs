/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Tuesday, February 28, 2017</date>
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
using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Snapshot
{
    public class IndexGridSpec : GridSpec<Models.Snapshot>
    {
        public IndexGridSpec()
        {
            Add(string.Empty,
                snapshot => UrlTemplate.MakeHrefString(snapshot.GetSummaryUrl(), "View", new Dictionary<string, string>() {{"class", "btn btn-xs btn-firma"}}),
                50,
                DhtmlxGridColumnFilterType.None);
            
            Add("Snapshot Date", snapshot => snapshot.SnapshotDate, 125, DhtmlxGridColumnFormatType.Date);
            Add("Snapshot Note", snapshot => snapshot.SnapshotNote, 300);
            Add("Projects Added", snapshot => snapshot.SnapshotProjects.Count(snapshotProject => snapshotProject.SnapshotProjectType == SnapshotProjectType.Added), 75);
            Add("Projects Updated", snapshot => snapshot.SnapshotProjects.Count(snapshotProject => snapshotProject.SnapshotProjectType == SnapshotProjectType.Updated), 75);
            Add("Total Projects", snapshot => snapshot.ProjectCount, 75);
        }
    }
}
