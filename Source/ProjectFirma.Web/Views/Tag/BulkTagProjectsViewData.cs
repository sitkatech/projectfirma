/*-----------------------------------------------------------------------
<copyright file="BulkTagProjectsViewData.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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
using System;
using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Tag
{
    public class BulkTagProjectsViewData : FirmaUserControlViewData
    {
        public readonly string FindTagUrl;
        public readonly List<string> ProjectDisplayNames;
        public readonly string ProjectLabel;

        public BulkTagProjectsViewData(List<string> projectDisplayNames)
        {
            ProjectDisplayNames = projectDisplayNames;
            FindTagUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.Find(null));

            ProjectLabel = "Project" + (ProjectDisplayNames.Count > 1 ? "s" : String.Empty);

        }
    }
}
