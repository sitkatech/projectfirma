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
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Solicitation
{
    public class IndexGridSpec : GridSpec<ProjectFirmaModels.Models.Solicitation>
    {
        public IndexGridSpec(bool hasEditPermissions)
        {
            if (hasEditPermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(SitkaRoute<SolicitationController>.BuildUrlFromExpression(sc => sc.DeleteSolicitation(x)), true), 30);

                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(SitkaRoute<SolicitationController>.BuildUrlFromExpression(sc => sc.Edit(x)), $"Edit {FieldDefinitionEnum.Solicitation.ToType().GetFieldDefinitionLabel()}"), 30);
            }

            Add($"{FieldDefinitionEnum.Solicitation.ToType().ToGridHeaderString()} Name", a => a.SolicitationName, 200, DhtmlxGridColumnFilterType.Text);
            Add("Instructions", a => a.Instructions, 600);
            Add("Is Active", a => a.IsActive.ToYesNo(), 65, DhtmlxGridColumnFilterType.SelectFilterStrict);
        }
    }
}
