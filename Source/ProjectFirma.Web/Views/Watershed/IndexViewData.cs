/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Watershed
{
    public class IndexViewData : FirmaViewData
    {
        public readonly MapInitJson MapInitJson;
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage, MapInitJson mapInitJson) : base(currentPerson, firmaPage)
        {
            PageTitle = $"{Models.FieldDefinition.Watershed.GetFieldDefinitionLabelPluralized()}";
            MapInitJson = mapInitJson;
            GridSpec = new IndexGridSpec {ObjectNameSingular = $"{Models.FieldDefinition.Watershed.GetFieldDefinitionLabel()}", ObjectNamePlural = $"{Models.FieldDefinition.Watershed.GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true};
            GridName = "watershedsGrid";
            GridDataUrl = SitkaRoute<WatershedController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}
