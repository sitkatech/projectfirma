/*-----------------------------------------------------------------------
<copyright file="BulkTagProjectsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Tag
{
    public class BulkTagProjectsViewData : FirmaUserControlViewData
    {
        public string FindTagUrl { get; }
        public List<string> ProjectDisplayNames { get; }
        public string ProjectLabel { get; }

        public BulkTagProjectsViewData(List<string> projectDisplayNames)
        {
            ProjectDisplayNames = projectDisplayNames;
            FindTagUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.Find(null));

            ProjectLabel = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}" + (ProjectDisplayNames.Count > 1 ? "s" : String.Empty);

        }
    }
}
