/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectStewardOrganization
{
    public class IndexGridSpec : GridSpec<ProjectFirmaModels.Models.Organization>
    {
        public IndexGridSpec(FirmaSession currentFirmaSession)
        {
            Add(FieldDefinitionEnum.Organization.ToType().ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.OrganizationName), 400, DhtmlxGridColumnFilterType.Html);
            Add("Short Name", a => a.OrganizationShortName, 100);
            Add(FieldDefinitionEnum.OrganizationPrimaryContact.ToType().ToGridHeaderString(), a => a.GetPrimaryContactPersonAsUrl(currentFirmaSession), 120);
            Add($"# of {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", a => a.GetAllActiveProjectsAndProposals(currentFirmaSession).Count, 90);
            Add($"# of {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabelPluralized()}", a => a.FundingSources.Count, 150);
            Add("# of Users", a => a.People.Count, 90);
            
        }
    }
}
