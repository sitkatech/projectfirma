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
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ExternalMapLayer
{
    public class IndexGridSpec : GridSpec<ProjectFirmaModels.Models.ExternalMapLayer>
    {
        public IndexGridSpec()
        {

            Add("Display Name", x => x.DisplayName, 150);
            Add("Layer Url", x => x.LayerUrl, 250);
            Add("Layer Description", x => x.LayerDescription, 400);
            Add("Display on all " + FieldDefinitionEnum.Project.ToType().ToGridHeaderString() + " maps?", x => x.DisplayOnAllProjectMaps ? "Yes" : "No", 150);
            Add("On by Default?", x => x.LayerIsOnByDefault ? "Yes" : "No", 90);
            Add("Is Active?", x => x.IsActive ? "Yes" : "No", 90);
        }
    }
}
