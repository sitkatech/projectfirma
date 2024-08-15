/*-----------------------------------------------------------------------
<copyright file="EditProjectCustomGridViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

        public EditProjectCustomGridViewModel(int projectCustomGridTypeID, List<ProjectCustomGridConfiguration> projectCustomGridConfigurations, List<GeospatialAreaType> geospatialAreaTypes, List<ProjectFirmaModels.Models.ProjectCustomAttributeType> projectCustomAttributeTypes, List<ProjectFirmaModels.Models.ClassificationSystem> classificationSystems)
        {
            var projectCustomGridConfigurationSimples = new List<ProjectCustomGridConfigurationSimple>();
            var projectCustomGridColumns = GeneralUtility.EnumGetValues<ProjectCustomGridColumnEnum>();
            // Remove the Secondary Taxonomy Leaf Column if Tenant doesn't use them
            if (!MultiTenantHelpers.GetTenantAttributeFromCache().EnableSecondaryProjectTaxonomyLeaf)
            {
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.SecondaryTaxonomyLeaf).ToList();
            }
            // Remove the Project Status Column if Tenant doesn't use the timeline and status updates
            if (!MultiTenantHelpers.GetTenantAttributeFromCache().EnableStatusUpdates)
            {
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.ProjectStatus).ToList();
            }
            // Remove the Final Status Update Status Column if Tenant doesn't use the require submitting lessons learned
            if (!MultiTenantHelpers.GetTenantAttributeFromCache().EnableStatusUpdates)
            {
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.FinalStatusUpdateStatus).ToList();
            }
            // Remove the Project Type Column if Tenant doesn't use the attribute
            if (!MultiTenantHelpers.GetTenantAttributeFromCache().EnableProjectCategories)
            {
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.ProjectCategory).ToList();
            }
            // Remove Performance Measure Columns if Tenant doesn't Track Accomplishments
            if (!MultiTenantHelpers.TrackAccomplishments())
            {
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.NumberOfExpectedPerformanceMeasureRecords).ToList();
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.NumberOfReportedPerformanceMeasures).ToList();
            }
            // Remove Solicitation Column if Tenant doesn't have solicitations
            if (!MultiTenantHelpers.HasSolicitations())
            {
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.Solicitation).ToList();
            }

            // Remove Project financial related columns if Tenant does not Report Financials at the project level
            if (!MultiTenantHelpers.ReportFinancialsAtProjectLevel())
            {
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.NumberOfReportedExpenditures).ToList();
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.FundingType).ToList();
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.EstimatedTotalCost).ToList();
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.SecuredFunding).ToList();
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.TargetedFunding).ToList();
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.NoFundingSourceIdentified).ToList();
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.FundingSources).ToList();
            }
            // Remove the Source of Record Column if Tenant doesn't have Project External Data Source enabled
            if (!MultiTenantHelpers.GetTenantAttributeFromCache().ProjectExternalDataSourceEnabled)
            {
                projectCustomGridColumns = projectCustomGridColumns.Where(x => x != ProjectCustomGridColumnEnum.SourceOfRecord).ToList();
            }

            foreach (var projectCustomGridColumn in projectCustomGridColumns)
            {
                if (projectCustomGridColumn == ProjectCustomGridColumnEnum.CustomAttribute)
                {
                    foreach (var projectCustomAttributeType in projectCustomAttributeTypes)
                    {
                        var enabled = projectCustomGridConfigurations.Any(x => x.ProjectCustomGridTypeID == projectCustomGridTypeID && x.ProjectCustomGridColumnID == (int)projectCustomGridColumn && x.ProjectCustomAttributeTypeID == projectCustomAttributeType.ProjectCustomAttributeTypeID && x.IsEnabled);
                        var sortOrder = projectCustomGridConfigurations.SingleOrDefault(x => x.ProjectCustomGridTypeID == projectCustomGridTypeID && x.ProjectCustomGridColumnID == (int)projectCustomGridColumn && x.ProjectCustomAttributeTypeID == projectCustomAttributeType.ProjectCustomAttributeTypeID && x.IsEnabled)?.SortOrder;
                        projectCustomGridConfigurationSimples.Add(new ProjectCustomGridConfigurationSimple(projectCustomGridTypeID, ProjectCustomGridColumn.ToType(projectCustomGridColumn), projectCustomAttributeType, null, null, enabled, sortOrder));
                    }
                }

                else if (projectCustomGridColumn == ProjectCustomGridColumnEnum.GeospatialAreaName)
                {
                    foreach (var geospatialAreaType in geospatialAreaTypes)
                    {
                        var enabled = projectCustomGridConfigurations.Any(x => x.ProjectCustomGridTypeID == projectCustomGridTypeID && x.ProjectCustomGridColumnID == (int)projectCustomGridColumn && x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID && x.IsEnabled);
                        var sortOrder = projectCustomGridConfigurations.SingleOrDefault(x => x.ProjectCustomGridTypeID == projectCustomGridTypeID && x.ProjectCustomGridColumnID == (int)projectCustomGridColumn && x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID && x.IsEnabled)?.SortOrder;
                        projectCustomGridConfigurationSimples.Add(new ProjectCustomGridConfigurationSimple(projectCustomGridTypeID, ProjectCustomGridColumn.ToType(projectCustomGridColumn), null, geospatialAreaType, null, enabled, sortOrder));
                    }
                }
                
                else if (projectCustomGridColumn == ProjectCustomGridColumnEnum.ClassificationSystem)
                {
                    foreach (var classificationSystem in classificationSystems)
                    {
                        var enabled = projectCustomGridConfigurations.Any(x => x.ProjectCustomGridTypeID == projectCustomGridTypeID && x.ProjectCustomGridColumnID == (int)projectCustomGridColumn && x.ClassificationSystemID == classificationSystem.ClassificationSystemID && x.IsEnabled);
                        var sortOrder = projectCustomGridConfigurations.SingleOrDefault(x => x.ProjectCustomGridTypeID == projectCustomGridTypeID && x.ProjectCustomGridColumnID == (int)projectCustomGridColumn && x.ClassificationSystemID == classificationSystem.ClassificationSystemID && x.IsEnabled)?.SortOrder;
                        projectCustomGridConfigurationSimples.Add(new ProjectCustomGridConfigurationSimple(projectCustomGridTypeID, ProjectCustomGridColumn.ToType(projectCustomGridColumn), null, null, classificationSystem, enabled, sortOrder));
                    }
                }

                else
                {
                    var enabled = projectCustomGridConfigurations.Any(x => x.ProjectCustomGridTypeID == projectCustomGridTypeID && x.ProjectCustomGridColumnID == (int) projectCustomGridColumn && x.IsEnabled);
                    var sortOrder = projectCustomGridConfigurations.SingleOrDefault(x => x.ProjectCustomGridTypeID == projectCustomGridTypeID && x.ProjectCustomGridColumnID == (int) projectCustomGridColumn && x.IsEnabled)?.SortOrder;
                    projectCustomGridConfigurationSimples.Add(new ProjectCustomGridConfigurationSimple(projectCustomGridTypeID, ProjectCustomGridColumn.ToType(projectCustomGridColumn), null, null, null, enabled, sortOrder));
                }
            }
            ProjectCustomGridConfigurationSimples = projectCustomGridConfigurationSimples;
        }

        public void UpdateModel(List<ProjectCustomGridConfiguration> existingProjectCustomGridConfiguration, IList<ProjectCustomGridConfiguration> allProjectCustomGridConfigurations)
        {
            var databaseEntities = HttpRequestStorage.DatabaseEntities;
            var incomingProjectCustomGridConfigurations = ProjectCustomGridConfigurationSimples.Select(x =>
                new ProjectCustomGridConfiguration(ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue(), x.ProjectCustomGridTypeID, x.ProjectCustomGridColumnID, x.ProjectCustomAttributeTypeID, x.GeospatialAreaTypeID, x.IsEnabled, x.SortOrder, x.ClassificationSystemID)).ToList();
            existingProjectCustomGridConfiguration.Merge(incomingProjectCustomGridConfigurations,
                allProjectCustomGridConfigurations,
                (x, y) => x.ProjectCustomGridTypeID == y.ProjectCustomGridTypeID && x.ProjectCustomGridColumnID == y.ProjectCustomGridColumnID && x.ProjectCustomAttributeTypeID == y.ProjectCustomAttributeTypeID && x.GeospatialAreaTypeID == y.GeospatialAreaTypeID && x.ClassificationSystemID == y.ClassificationSystemID,
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
