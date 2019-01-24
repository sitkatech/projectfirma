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
using LtInfo.Common;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.OrganizationAndRelationshipType
{
    public class IndexViewData : FirmaViewData
    {
        public readonly OrganizationTypeGridSpec OrganizationTypeGridSpec;
        public readonly string OrganizationTypeGridName;
        public readonly string OrganizationTypeGridDataUrl;

        public readonly RelationshipTypeGridSpec RelationshipTypeGridSpec;
        public readonly string RelationshipTypeGridName;
        public readonly string RelationshipTypeGridDataUrl;

        public IndexViewData(Person currentPerson) : base(currentPerson)
        {
            PageTitle = $"Manage {FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabelPluralized()}";

            var hasManagePermissions = new OrganizationAndRelationshipTypeManageFeature().HasPermissionByPerson(currentPerson);
            OrganizationTypeGridSpec = new OrganizationTypeGridSpec(hasManagePermissions) { ObjectNameSingular = $"{FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            if (hasManagePermissions)
            {
                OrganizationTypeGridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<OrganizationAndRelationshipTypeController>.BuildUrlFromExpression(t => t.NewOrganizationType()), $"Create a new {FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabel()}");
            }

            OrganizationTypeGridName = "organizationTypeGrid";
            OrganizationTypeGridDataUrl = SitkaRoute<OrganizationAndRelationshipTypeController>.BuildUrlFromExpression(otc => otc.OrganizationTypeGridJsonData());

            RelationshipTypeGridSpec = new RelationshipTypeGridSpec(hasManagePermissions, HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList()) { ObjectNameSingular = $"{FieldDefinitionEnum.ProjectRelationshipType.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{ FieldDefinitionEnum.ProjectRelationshipType.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            if (hasManagePermissions)
            {
                RelationshipTypeGridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<OrganizationAndRelationshipTypeController>.BuildUrlFromExpression(t => t.NewRelationshipType()), $"Create a new {FieldDefinitionEnum.ProjectRelationshipType.ToType().GetFieldDefinitionLabel()}");
            }

            RelationshipTypeGridName = "relationshipTypeGrid";
            RelationshipTypeGridDataUrl = SitkaRoute<OrganizationAndRelationshipTypeController>.BuildUrlFromExpression(otc => otc.RelationshipTypeGridJsonData());
        }
    }
}
