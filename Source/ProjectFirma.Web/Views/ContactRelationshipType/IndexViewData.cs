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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ContactRelationshipType
{
    public class IndexViewData : FirmaViewData
    {
        public ContactRelationshipTypeGridSpec ContactRelationshipTypeGridSpec { get; }
        public string ContactRelationshipTypeGridName { get; }
        public string ContactRelationshipTypeGridDataUrl { get; }
        public bool HasManagePermissions { get; }
        public string NewProjectAssociationUrl { get; }

        public IndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = $"Manage {FieldDefinitionEnum.ContactType.ToType().GetFieldDefinitionLabelPluralized()}";

            var hasManagePermissions = new ContactRelationshipTypeManageFeature().HasPermissionByFirmaSession(currentFirmaSession);

            ContactRelationshipTypeGridSpec = new ContactRelationshipTypeGridSpec(hasManagePermissions) { ObjectNameSingular = $"{FieldDefinitionEnum.ProjectContactRelationshipType.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{ FieldDefinitionEnum.ProjectContactRelationshipType.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            ContactRelationshipTypeGridName = "relationshipTypeGrid";
            ContactRelationshipTypeGridDataUrl = SitkaRoute<ContactRelationshipTypeController>.BuildUrlFromExpression(otc => otc.ContactRelationshipTypeGridJsonData());
            HasManagePermissions = hasManagePermissions;
            NewProjectAssociationUrl = SitkaRoute<ContactRelationshipTypeController>.BuildUrlFromExpression(t => t.NewContactRelationshipType());
        }
    }
}
