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
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.FieldDefinition
{
    public class IndexViewData : FirmaViewData
    {
        public FieldDefinitionGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public List<CustomFieldDefinitionCollisions> FieldDefinitionsWithCollision { get; }


        public IndexViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {
            PageTitle = "Manage Field Definitions";

            GridSpec = new FieldDefinitionGridSpec(new FieldDefinitionViewListFeature().HasPermissionByFirmaSession(currentFirmaSession))
            {
                ObjectNameSingular = "Field Definition",
                ObjectNamePlural = "Field Definitions",
                SaveFiltersInCookie = true
            };
            GridName = "fieldDefinitionsGrid";
            GridDataUrl = SitkaRoute<FieldDefinitionController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());

            var customFieldDefinitions = HttpRequestStorage.DatabaseEntities.FieldDefinitionDatas.ToList().Where(fdd => !string.IsNullOrWhiteSpace(fdd.FieldDefinitionLabel)).ToList();
            FieldDefinitionsWithCollision = new List<CustomFieldDefinitionCollisions>();
            foreach (var customFieldDefinition in customFieldDefinitions)
            {
                var fieldDefinitions = HttpRequestStorage.DatabaseEntities.FieldDefinitions.Where(fd =>
                    fd.FieldDefinitionID != customFieldDefinition.FieldDefinitionID && fd.FieldDefinitionDisplayName ==
                    customFieldDefinition.FieldDefinitionLabel).ToList();
                var itemsWithCollision = fieldDefinitions.Select(x => new CustomFieldDefinitionCollisions(x, customFieldDefinition));

                FieldDefinitionsWithCollision.AddRange(itemsWithCollision);
            }

        }
    }


    public class CustomFieldDefinitionCollisions
    {
        public int SystemFieldDefinitionID { get; set; }
        public string SystemFieldDefinitionDisplayName { get; set; }
        public int OverrideFieldDefinitionDataID { get; set; }
        public string OverrideFieldDefinitionLabel { get; set; }

        public CustomFieldDefinitionCollisions(ProjectFirmaModels.Models.FieldDefinition fieldDefinition, FieldDefinitionData fieldDefinitionData)
        {
            SystemFieldDefinitionID = fieldDefinition.FieldDefinitionID;
            SystemFieldDefinitionDisplayName = fieldDefinition.FieldDefinitionDisplayName;
            OverrideFieldDefinitionDataID = fieldDefinitionData.FieldDefinitionDataID;
            OverrideFieldDefinitionLabel = fieldDefinitionData.FieldDefinitionLabel;
        }
    }
}
