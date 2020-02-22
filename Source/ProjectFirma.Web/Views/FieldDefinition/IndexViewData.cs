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
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.FieldDefinition
{
    public class IndexViewData : FirmaViewData
    {
        public FieldDefinitionGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public List<CustomFieldDefinitionConflicts> FieldDefinitionsWithConflict { get; }


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
            FieldDefinitionsWithConflict = new List<CustomFieldDefinitionConflicts>();
            foreach (var customFieldDefinition in customFieldDefinitions)
            {
                var fieldDefinitions = HttpRequestStorage.DatabaseEntities.FieldDefinitions.Where(fd =>
                    fd.FieldDefinitionID != customFieldDefinition.FieldDefinitionID && fd.FieldDefinitionDisplayName ==
                    customFieldDefinition.FieldDefinitionLabel).ToList();
                var itemsWithCollision = fieldDefinitions.Select(x => new CustomFieldDefinitionConflicts(x, customFieldDefinition));

                FieldDefinitionsWithConflict.AddRange(itemsWithCollision);
            }

        }
    }


    public class CustomFieldDefinitionConflicts
    {
        /// <summary>
        /// Default In Conflict Field Definition is referring to the system Default Display Name that conflicts with the tenant custom label
        /// </summary>
        public int DefaultInConflictFieldDefinitionID { get; set; }
        public string DefaultInConflictFieldDefinitionDisplayName { get; set; }
        
        /// <summary>
        /// Custom Field Definition is referring to the tenant custom label value that conflicts with the default display name
        /// </summary>
        public int CustomFieldDefinitionDataID { get; set; }
        public string CustomFieldDefinitionLabel { get; set; }

        /// <summary>
        /// Default Field Definition is referring to the field definition that is being overridden by the tenant custom label
        /// </summary>
        public int DefaultFieldDefinitionID { get; set; }
        public string DefaultFieldDefinitionDisplayName { get; set; }

        public CustomFieldDefinitionConflicts(ProjectFirmaModels.Models.FieldDefinition fieldDefinitionInConflict, FieldDefinitionData fieldDefinitionData)
        {
            DefaultInConflictFieldDefinitionID = fieldDefinitionInConflict.FieldDefinitionID;
            DefaultInConflictFieldDefinitionDisplayName = fieldDefinitionInConflict.FieldDefinitionDisplayName;

            CustomFieldDefinitionDataID = fieldDefinitionData.FieldDefinitionDataID;
            CustomFieldDefinitionLabel = fieldDefinitionData.FieldDefinitionLabel;

            DefaultFieldDefinitionID = fieldDefinitionData.FieldDefinition.FieldDefinitionID;
            DefaultFieldDefinitionDisplayName = fieldDefinitionData.FieldDefinition.FieldDefinitionDisplayName;
        }
    }
}
