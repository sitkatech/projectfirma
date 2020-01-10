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

namespace ProjectFirma.Web.Views.AttachmentRelationshipType
{
    public class IndexViewData : FirmaViewData
    {

        public AttachmentRelationshipTypeGridSpec AttachmentRelationshipTypeGridSpec { get; }
        public string AttachmentRelationshipTypeGridName { get; }
        public string AttachmentRelationshipTypeGridDataUrl { get; }
        public bool HasManagePermissions { get; }
        public string NewProjectAssociationUrl { get; }

        public IndexViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {
            PageTitle = $"Manage {FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabelPluralized()}";

            var hasManagePermissions = new AttachmentRelationshipTypeManageFeature().HasPermissionByFirmaSession(currentFirmaSession);

            AttachmentRelationshipTypeGridSpec = new AttachmentRelationshipTypeGridSpec(hasManagePermissions) { ObjectNameSingular = $"{FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{ FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            AttachmentRelationshipTypeGridName = "relationshipTypeGrid";
            AttachmentRelationshipTypeGridDataUrl = SitkaRoute<AttachmentRelationshipTypeController>.BuildUrlFromExpression(otc => otc.AttachmentRelationshipTypeGridJsonData());
            HasManagePermissions = hasManagePermissions;
            NewProjectAssociationUrl = SitkaRoute<AttachmentRelationshipTypeController>.BuildUrlFromExpression(t => t.NewAttachmentRelationshipType());
        }
    }
}
