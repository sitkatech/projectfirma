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

using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ContactTypeAndContactRelationshipType
{
    public class IndexViewData : FirmaViewData
    {
        public ContactTypeGridSpec ContactTypeGridSpec { get; } 
        public string ContactTypeGridName { get; }
        public string ContactTypeGridDataUrl { get; }

        public ContactRelationshipTypeGridSpec ContactRelationshipTypeGridSpec { get; }
        public string ContactRelationshipTypeGridName { get; }
        public string ContactRelationshipTypeGridDataUrl { get; }
        public bool HasManagePermissions { get; }
        public string NewContactTypeUrl { get; }
        public string NewProjectAssociationUrl { get; }

        public IndexViewData(Person currentPerson) : base(currentPerson)
        {
            PageTitle = $"Manage {FieldDefinitionEnum.ContactType.ToType().GetFieldDefinitionLabelPluralized()}";

            var hasManagePermissions = new ContactAndContactRelationshipTypeManageFeature().HasPermissionByPerson(currentPerson);
            ContactTypeGridSpec = new ContactTypeGridSpec(hasManagePermissions) { ObjectNameSingular = $"{FieldDefinitionEnum.ContactType.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.ContactType.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };


            ContactTypeGridName = "contactTypeGrid";
            ContactTypeGridDataUrl = SitkaRoute<ContactTypeAndContactRelationshipTypeController>.BuildUrlFromExpression(otc => otc.ContactTypeGridJsonData());

            ContactRelationshipTypeGridSpec = new ContactRelationshipTypeGridSpec(hasManagePermissions, HttpRequestStorage.DatabaseEntities.ContactTypes.ToList()) { ObjectNameSingular = $"{FieldDefinitionEnum.ProjectRelationshipType.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{ FieldDefinitionEnum.ProjectRelationshipType.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            ContactRelationshipTypeGridName = "relationshipTypeGrid";
            ContactRelationshipTypeGridDataUrl = SitkaRoute<ContactTypeAndContactRelationshipTypeController>.BuildUrlFromExpression(otc => otc.ContactRelationshipTypeGridJsonData());
            HasManagePermissions = hasManagePermissions;
            NewContactTypeUrl = SitkaRoute<ContactTypeAndContactRelationshipTypeController>.BuildUrlFromExpression(t => t.NewContactType());
            NewProjectAssociationUrl = SitkaRoute<ContactTypeAndContactRelationshipTypeController>.BuildUrlFromExpression(t => t.NewContactRelationshipType());
        }
    }
}
