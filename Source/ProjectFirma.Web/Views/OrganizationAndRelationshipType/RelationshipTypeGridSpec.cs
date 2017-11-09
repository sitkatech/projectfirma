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

using System.Collections.Generic;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.OrganizationAndRelationshipType
{
    public class RelationshipTypeGridSpec : GridSpec<RelationshipType>
    {
        public RelationshipTypeGridSpec(bool hasManagePermissions, List<OrganizationType> allOrganizationTypes)
        {
            var basicsColumnGroupCount = 4;

            if (hasManagePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.DeleteUrl, true, x.CanDelete()), 30, DhtmlxGridColumnFilterType.None);
                Add(string.Empty, a => DhtmlxGridHtmlHelpers.MakeLtInfoEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(SitkaRoute<OrganizationAndRelationshipTypeController>.BuildUrlFromExpression(t => t.EditRelationshipType(a)),
                        $"Edit {Models.FieldDefinition.ProjectRelationshipType.GetFieldDefinitionLabel()} \"{a.RelationshipTypeName}\"")),
                    30, DhtmlxGridColumnFilterType.None);
                basicsColumnGroupCount += 2;
            }

            Add($"{Models.FieldDefinition.ProjectRelationshipType.GetFieldDefinitionLabel()} Name", a => a.RelationshipTypeName, 240);
            Add($"Can Steward {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}?", a => a.CanStewardProjects.ToCheckboxImageOrEmptyForGrid(), 90);
            Add("Serves as Primary Contact?", a => a.IsPrimaryContact.ToCheckboxImageOrEmptyForGrid(), 90);
            Add("Must be related to a project once?", a => a.CanOnlyBeRelatedOnceToAProject.ToCheckboxImageOrEmptyForGrid(), 90);

            foreach (var organizationType in allOrganizationTypes)
            {
                Add(organizationType.OrganizationTypeName, a => a.IsAssociatedWithOrganiztionType(organizationType).ToCheckboxImageOrEmptyForGrid(), 90);
            }

            GroupingHeader =
                BuildGroupingHeader(new ColumnHeaderGroupingList
                {
                    {"", basicsColumnGroupCount},
                    {$"Applicable to the following {Models.FieldDefinition.OrganizationType.GetFieldDefinitionLabelPluralized()}:", allOrganizationTypes.Count}                    
                });

        }
    }
}
