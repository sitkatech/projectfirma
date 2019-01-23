/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.ProjectStewardOrganization
{
    public class IndexGridSpec : GridSpec<Models.Organization>
    {
        public IndexGridSpec(Person currentPerson)
        {
            var userViewFeature = new UserViewFeature();
            
            Add(Models.FieldDefinition.Organization.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.OrganizationName), 400, DhtmlxGridColumnFilterType.Html);
            Add("Short Name", a => a.OrganizationShortName, 100);
            Add(Models.FieldDefinition.OrganizationPrimaryContact.ToGridHeaderString(), a => userViewFeature.HasPermission(currentPerson, a.PrimaryContactPerson).HasPermission ? a.GetPrimaryContactPersonAsUrl() : new HtmlString(a.GetPrimaryContactPersonAsString()), 120);
            Add($"# of {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}", a => a.GetAllActiveProjectsAndProposals(currentPerson).Count, 90);
            Add($"# of {Models.FieldDefinition.FundingSource.GetFieldDefinitionLabelPluralized()}", a => a.FundingSources.Count, 150);
            Add("# of Users", a => a.People.Count, 90);
            
        }
    }
}
