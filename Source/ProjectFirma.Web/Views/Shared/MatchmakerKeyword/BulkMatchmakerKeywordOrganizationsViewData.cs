/*-----------------------------------------------------------------------
<copyright file="BulkMatchmakerKeywordProjectsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

namespace ProjectFirma.Web.Views.Shared.MatchmakerKeyword
{
    public class BulkMatchmakerKeywordOrganizationsViewData : FirmaUserControlViewData
    {
        public string FindMatchmakerKeywordUrl { get; }
        public List<string> OrganizationDisplayNames { get; }
        public string OrganizationLabel { get; }

        public BulkMatchmakerKeywordOrganizationsViewData(List<string> organizationDisplayNames)
        {
            OrganizationDisplayNames = organizationDisplayNames;
            FindMatchmakerKeywordUrl = SitkaRoute<KeywordController>.BuildUrlFromExpression(c => c.FindMatchmakerKeyword(null));

            OrganizationLabel = $"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}" + (OrganizationDisplayNames.Count > 1 ? "s" : String.Empty);
        }
    }
}
