/*-----------------------------------------------------------------------
<copyright file="ProjectCustomGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCustomGrid
{
    public class ProjectCustomGridSpec : GridSpec<ProjectFirmaModels.Models.Project>
    {

        private void AddProjectCustomGridField(ProjectCustomGridConfiguration projectCustomGridConfiguration)
        {
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.PerformanceMeasureCount.ProjectCustomGridColumnID)
            {
                Add($"Number Of Reported {MultiTenantHelpers.GetPerformanceMeasureName()} Records", x => x.PerformanceMeasureActuals.Count, 100);
                return;
            }
        }

        private void AddProjectCustomGridCustomAttributeField(ProjectCustomGridConfiguration projectCustomGridConfiguration)
        {
            var projectCustomAttributeType = projectCustomGridConfiguration.ProjectCustomAttributeType;
            Add($"{projectCustomAttributeType.ProjectCustomAttributeTypeName}", a => a.GetProjectCustomAttributesValue(projectCustomAttributeType), 150, DhtmlxGridColumnFilterType.Text);
        }

        private void AddProjectCustomGridGeospatialAreaField(ProjectCustomGridConfiguration projectCustomGridConfiguration)
        {
            var geospatialAreaType = projectCustomGridConfiguration.GeospatialAreaType;
            Add($"{geospatialAreaType.GeospatialAreaTypeNamePluralized}", a => a.GetProjectGeospatialAreaNamesAsHyperlinks(geospatialAreaType), 350, DhtmlxGridColumnFilterType.Html);
        }

    //        public ProjectCustomGridSpec(Person currentPerson, Dictionary<int, FundingType> fundingTypes, List<GeospatialAreaType> geospatialAreaTypes, List<ProjectFirmaModels.Models.ProjectCustomAttributeType> projectCustomAttributeTypes)
    public ProjectCustomGridSpec(Person currentPerson, List<ProjectCustomGridConfiguration> projectCustomGridConfigurations)
        {
            var userHasTagManagePermissions = new FirmaAdminFeature().HasPermissionByPerson(currentPerson);
            var userHasDeletePermissions = new ProjectDeleteFeature().HasPermissionByPerson(currentPerson);
            var userHasEmailViewingPermissions = new LoggedInAndNotUnassignedRoleUnclassifiedFeature().HasPermissionByPerson(currentPerson);

            // Mandatory fields appearing BEFORE configurable fields
            if (userHasTagManagePermissions)
            {
                BulkTagModalDialogForm = new BulkTagModalDialogForm(SitkaRoute<TagController>.BuildUrlFromExpression(x => x.BulkTagProjects(null)), $"Tag Checked {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", $"Tag {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}");
                AddCheckBoxColumn();
                Add("ProjectID", x => x.ProjectID, 0);
            }

            if (userHasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, DhtmlxGridColumnFilterType.None);
            }

            Add(string.Empty, x => UrlTemplate.MakeHrefString(x.GetFactSheetUrl(), FirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString()), 30, DhtmlxGridColumnFilterType.None);

            Add(FieldDefinitionEnum.ProjectName.ToType().ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetDetailUrl(), x.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().ToGridHeaderString(), x => x.GetPrimaryContactOrganization().GetShortNameAsUrl(), 150, DhtmlxGridColumnFilterType.Html);

            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), x => x.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            //

            // Implement configured fields here
            //
            foreach (var projectCustomGridConfiguration in projectCustomGridConfigurations.OrderBy(x => x.SortOrder))
            {
                if (projectCustomGridConfiguration.ProjectCustomAttributeType != null)
                {
                    if (projectCustomGridConfiguration.ProjectCustomAttributeType.HasViewPermission(currentPerson))
                    {
                        AddProjectCustomGridCustomAttributeField(projectCustomGridConfiguration);
                    }
                }
                else if (projectCustomGridConfiguration.GeospatialAreaType != null)
                {
                    AddProjectCustomGridGeospatialAreaField(projectCustomGridConfiguration);
                }
                else
                {
                    AddProjectCustomGridField(projectCustomGridConfiguration);
                }
            }


            // Mandatory fields appearing BEFORE configurable fields
            if (userHasTagManagePermissions)
            {
                Add("Tags", x => new HtmlString(!x.ProjectTags.Any() ? string.Empty : string.Join(", ", x.ProjectTags.Select(pt => pt.Tag.GetDisplayNameAsUrl()))), 100, DhtmlxGridColumnFilterType.Html);
            }
            //
        }
    }
}
