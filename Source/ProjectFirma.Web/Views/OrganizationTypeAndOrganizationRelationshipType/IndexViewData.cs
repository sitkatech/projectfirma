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

namespace ProjectFirma.Web.Views.OrganizationTypeAndOrganizationRelationshipType
{
    public class IndexViewData : FirmaViewData
    {
        public OrganizationTypeGridSpec OrganizationTypeGridSpec { get; } 
        public string OrganizationTypeGridName { get; }
        public string OrganizationTypeGridDataUrl { get; }

        public OrganizationRelationshipTypeGridSpec OrganizationRelationshipTypeGridSpec { get; }
        public string OrganizationRelationshipTypeGridName { get; }
        public string OrganizationRelationshipTypeGridDataUrl { get; }
        public bool HasManagePermissions { get; }
        public string NewOrganizationTypeUrl { get; }
        public string NewProjectAssociationUrl { get; }

        public IndexViewData(Person currentPerson) : base(currentPerson)
        {
            PageTitle = $"Manage {FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabelPluralized()}";

            var hasManagePermissions = new OrganizationAndRelationshipTypeManageFeature().HasPermissionByPerson(currentPerson);
            OrganizationTypeGridSpec = new OrganizationTypeGridSpec(hasManagePermissions) { ObjectNameSingular = $"{FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            OrganizationTypeGridName = "organizationTypeGrid";
            OrganizationTypeGridDataUrl = SitkaRoute<OrganizationTypeAndOrganizationRelationshipTypeController>.BuildUrlFromExpression(otc => otc.OrganizationTypeGridJsonData());

            OrganizationRelationshipTypeGridSpec = new OrganizationRelationshipTypeGridSpec(hasManagePermissions, HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList()) { ObjectNameSingular = $"{FieldDefinitionEnum.ProjectOrganizationRelationshipType.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{ FieldDefinitionEnum.ProjectOrganizationRelationshipType.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            OrganizationRelationshipTypeGridName = "relationshipTypeGrid";
            OrganizationRelationshipTypeGridDataUrl = SitkaRoute<OrganizationTypeAndOrganizationRelationshipTypeController>.BuildUrlFromExpression(otc => otc.OrganizationRelationshipTypeGridJsonData());
            HasManagePermissions = hasManagePermissions;
            NewOrganizationTypeUrl = SitkaRoute<OrganizationTypeAndOrganizationRelationshipTypeController>.BuildUrlFromExpression(t => t.NewOrganizationType());
            NewProjectAssociationUrl = SitkaRoute<OrganizationTypeAndOrganizationRelationshipTypeController>.BuildUrlFromExpression(t => t.NewOrganizationRelationshipType());
        }
    }
}
