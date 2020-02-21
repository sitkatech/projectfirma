/*-----------------------------------------------------------------------
<copyright file="EditProjectCustomGridViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectCustomGrid
{
    public class EditProjectCustomGridViewModel : FormViewModel, IValidatableObject
    {
        [DisplayName("Project Custom Grid Configurations")]
        public List<ProjectCustomGridConfigurationSimple> ProjectCustomGridConfigurationSimples { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectCustomGridViewModel()
        {
        }

        public EditProjectCustomGridViewModel(int projectCustomGridTypeID, List<ProjectCustomGridConfiguration> projectCustomGridConfigurations, List<GeospatialAreaType> geospatialAreaTypes, List<ProjectFirmaModels.Models.ProjectCustomAttributeType> projectCustomAttributeTypes)
        {
            var projectCustomGridConfigurationSimples = new List<ProjectCustomGridConfigurationSimple>();
            var projectCustomGridColumns = GeneralUtility.EnumGetValues<ProjectCustomGridColumnEnum>();
            // Remove the Secondary Taxonomy Leaf Column if Tenant doesn't use them
            if (!MultiTenantHelpers.GetTenantAttribute().EnableSecondaryProjectTaxonomyLeaf)
            {
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.SecondaryTaxonomyLeaf).ToList();
            }
            // Remove the Project Status Column if Tenant doesn't use the timeline
            if (!MultiTenantHelpers.GetTenantAttribute().UseProjectTimeline)
            {
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.ProjectStatus).ToList();
            }
            // Remove the Final Status Update Status Column if Tenant doesn't use the require submitting lessons learned
            if (!MultiTenantHelpers.GetTenantAttribute().UseProjectTimeline)
            {
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.FinalStatusUpdateStatus).ToList();
            }
            // Remove the Project Type Column if Tenant doesn't use the attribute
            if (!MultiTenantHelpers.GetTenantAttribute().EnableProjectCategories)
            {
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.ProjectCategory).ToList();
            }

            foreach (var projectCustomGridColumn in projectCustomGridColumns)
            {
                if (projectCustomGridColumn == ProjectCustomGridColumnEnum.CustomAttribute)
                {
                    foreach (var projectCustomAttributeType in projectCustomAttributeTypes)
                    {
                        var enabled = projectCustomGridConfigurations.Any(x => x.ProjectCustomGridTypeID == projectCustomGridTypeID && x.ProjectCustomGridColumnID == (int)projectCustomGridColumn && x.ProjectCustomAttributeTypeID == projectCustomAttributeType.ProjectCustomAttributeTypeID && x.IsEnabled);
                        var sortOrder = projectCustomGridConfigurations.SingleOrDefault(x => x.ProjectCustomGridTypeID == projectCustomGridTypeID && x.ProjectCustomGridColumnID == (int)projectCustomGridColumn && x.ProjectCustomAttributeTypeID == projectCustomAttributeType.ProjectCustomAttributeTypeID && x.IsEnabled)?.SortOrder;
                        projectCustomGridConfigurationSimples.Add(new ProjectCustomGridConfigurationSimple(projectCustomGridTypeID, ProjectCustomGridColumn.ToType(projectCustomGridColumn), projectCustomAttributeType, null, enabled, sortOrder));
                    }
                }

                else if (projectCustomGridColumn == ProjectCustomGridColumnEnum.GeospatialAreaName)
                {
                    foreach (var geospatialAreaType in geospatialAreaTypes)
                    {
                        var enabled = projectCustomGridConfigurations.Any(x => x.ProjectCustomGridTypeID == projectCustomGridTypeID && x.ProjectCustomGridColumnID == (int)projectCustomGridColumn && x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID && x.IsEnabled);
                        var sortOrder = projectCustomGridConfigurations.SingleOrDefault(x => x.ProjectCustomGridTypeID == projectCustomGridTypeID && x.ProjectCustomGridColumnID == (int)projectCustomGridColumn && x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID && x.IsEnabled)?.SortOrder;
                        projectCustomGridConfigurationSimples.Add(new ProjectCustomGridConfigurationSimple(projectCustomGridTypeID, ProjectCustomGridColumn.ToType(projectCustomGridColumn), null, geospatialAreaType, enabled, sortOrder));
                    }
                }

                else
                {
                    var enabled = projectCustomGridConfigurations.Any(x => x.ProjectCustomGridTypeID == projectCustomGridTypeID && x.ProjectCustomGridColumnID == (int) projectCustomGridColumn && x.IsEnabled);
                    var sortOrder = projectCustomGridConfigurations.SingleOrDefault(x => x.ProjectCustomGridTypeID == projectCustomGridTypeID && x.ProjectCustomGridColumnID == (int) projectCustomGridColumn && x.IsEnabled)?.SortOrder;
                    projectCustomGridConfigurationSimples.Add(new ProjectCustomGridConfigurationSimple(projectCustomGridTypeID, ProjectCustomGridColumn.ToType(projectCustomGridColumn), null, null, enabled, sortOrder));
                }
            }
            ProjectCustomGridConfigurationSimples = projectCustomGridConfigurationSimples;
        }

        public void UpdateModel(List<ProjectCustomGridConfiguration> existingProjectCustomGridConfiguration, IList<ProjectCustomGridConfiguration> allProjectCustomGridConfigurations)
        {
            var databaseEntities = HttpRequestStorage.DatabaseEntities;
            var incomingProjectCustomGridConfigurations = ProjectCustomGridConfigurationSimples.Select(x =>
                new ProjectCustomGridConfiguration(ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue(), x.ProjectCustomGridTypeID, x.ProjectCustomGridColumnID, x.ProjectCustomAttributeTypeID, x.GeospatialAreaTypeID, x.IsEnabled, x.SortOrder)).ToList();
            existingProjectCustomGridConfiguration.Merge(incomingProjectCustomGridConfigurations,
                allProjectCustomGridConfigurations,
                (x, y) => x.ProjectCustomGridTypeID == y.ProjectCustomGridTypeID && x.ProjectCustomGridColumnID == y.ProjectCustomGridColumnID && x.ProjectCustomAttributeTypeID == y.ProjectCustomAttributeTypeID && x.GeospatialAreaTypeID == y.GeospatialAreaTypeID,
                (x, y) => x.SetEnabledAndSortOrder(y.IsEnabled, y.SortOrder),
                databaseEntities);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            return errors;
        }
    }
}
