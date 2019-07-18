/*-----------------------------------------------------------------------
<copyright file="ProjectExcelSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.ExcelWorkbookUtilities;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class ProjectExcelSpec : ExcelWorksheetSpec<ProjectFirmaModels.Models.Project>
    {
        public ProjectExcelSpec(IEnumerable<GeospatialAreaType> geospatialAreaTypes, List<ProjectFirmaModels.Models.ProjectCustomAttributeType> projectCustomAttributeTypes)
        {
            AddColumn($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} ID", x => x.ProjectID);
            AddColumn(FieldDefinitionEnum.ProjectName.ToType().GetFieldDefinitionLabel(), x => x.ProjectName);
            AddColumn(FieldDefinitionEnum.ProjectPrimaryContact.ToType().GetFieldDefinitionLabel(), x => x.GetPrimaryContact()?.GetFullNameLastFirst());
            AddColumn(FieldDefinitionEnum.ProjectPrimaryContactEmail.ToType().GetFieldDefinitionLabel(), x => x.GetPrimaryContact()?.Email);
            AddColumn($"Non-Lead Implementing {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabelPluralized()}",
                x => string.Join(",", x.GetAssociatedOrganizations().Select(pio => pio.GetDisplayName())));
            AddColumn(FieldDefinitionEnum.ProjectStage.ToType().GetFieldDefinitionLabel(), x => x.ProjectStage.ProjectStageDisplayName);
            MultiTenantHelpers.GetClassificationSystems().ForEach(y =>
                {
                    AddColumn(ClassificationSystemModelExtensions.GetClassificationSystemNamePluralized(y), x => string.Join(",", x.ProjectClassifications.Where(z => z.Classification.ClassificationSystem == y).Select(tc => tc.Classification.GetDisplayName())));
                });

            foreach (var projectCustomAttributeType in projectCustomAttributeTypes)
            {
                AddColumn($"{projectCustomAttributeType.ProjectCustomAttributeTypeName}",
                    a => a.GetProjectCustomAttributesValue(projectCustomAttributeType));
            }

            foreach (var geospatialAreaType in geospatialAreaTypes)
            {
                AddColumn($"{geospatialAreaType.GeospatialAreaTypeNamePluralized}", x => string.Join(", ", x.ProjectGeospatialAreas.Where(y => y.GeospatialArea.GeospatialAreaType == geospatialAreaType).Select(y => y.GeospatialArea.GeospatialAreaName).ToList()));
            }
            AddColumn(FieldDefinitionEnum.ImplementationStartYear.ToType().GetFieldDefinitionLabel(), x => x.ImplementationStartYear);
            AddColumn(FieldDefinitionEnum.CompletionYear.ToType().GetFieldDefinitionLabel(), x => x.CompletionYear);


            AddColumn($"Primary {FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabel()}", x => x.TaxonomyLeaf.GetDisplayName());
            var enableSecondaryProjectTaxonomyLeaf = MultiTenantHelpers.GetTenantAttribute().EnableSecondaryProjectTaxonomyLeaf;
            if (enableSecondaryProjectTaxonomyLeaf)
            {
                AddColumn(FieldDefinitionEnum.SecondaryProjectTaxonomyLeaf.ToType().GetFieldDefinitionLabelPluralized(), x => string.Join(", ", x.SecondaryProjectTaxonomyLeafs.Select(y => y.TaxonomyLeaf.GetDisplayName())));
            }
            AddColumn(FieldDefinitionEnum.ProjectDescription.ToType().GetFieldDefinitionLabel(), x => x.ProjectDescription);
            AddColumn(FieldDefinitionEnum.FundingType.ToType().GetFieldDefinitionLabel(), x => x.FundingType.FundingTypeName);
            AddColumn(FieldDefinitionEnum.EstimatedTotalCost.ToType().GetFieldDefinitionLabel(), x => x.EstimatedTotalCost);
            AddColumn(FieldDefinitionEnum.EstimatedAnnualOperatingCost.ToType().GetFieldDefinitionLabel(), x => x.EstimatedAnnualOperatingCost);
            AddColumn(FieldDefinitionEnum.SecuredFunding.ToType().GetFieldDefinitionLabel(), x => x.GetSecuredFunding());
            AddColumn(FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel(), x => x.GetTargetedFunding());
            AddColumn(FieldDefinitionEnum.NoFundingSourceIdentified.ToType().GetFieldDefinitionLabel(), x => x.GetNoFundingSourceIdentifiedAmount());
            AddColumn("State", a => a.GetProjectLocationStateProvince());
            AddColumn($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()} Notes", a => a.ProjectLocationNotes);
        }
    }

    public class ProjectDescriptionExcelSpec : ExcelWorksheetSpec<ProjectFirmaModels.Models.Project>
    {
        public ProjectDescriptionExcelSpec()
        {
            AddColumn($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} ID", x => x.ProjectID);
            AddColumn($"{FieldDefinitionEnum.ProjectName.ToType().GetFieldDefinitionLabel()}", x => x.ProjectName);
            AddColumn("Description", x => x.ProjectDescription);
        }
    }

    public class ProjectImplementingOrganizationOrProjectFundingOrganizationExcelSpec : ExcelWorksheetSpec<ProjectOrganizationRelationship>
    {
        public ProjectImplementingOrganizationOrProjectFundingOrganizationExcelSpec()
        {
            AddColumn($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} ID", x => x.Project.ProjectID);
            AddColumn($"{FieldDefinitionEnum.ProjectName.ToType().GetFieldDefinitionLabel()}", x => x.Project.ProjectName);
            AddColumn($"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} ID", x => x.Organization.OrganizationID);
            AddColumn($"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} Name", x => x.Organization.OrganizationName);
            AddColumn($"{FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()} for {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}", x => x.Organization.GetPrimaryContactPersonWithOrgAsString());
            AddColumn(FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabel(), x => x.Organization.OrganizationType?.OrganizationTypeName);
            AddColumn($"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} Relationship To {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", x => x.RelationshipTypeName);
        }
    }

    public class ProjectNoteExcelSpec : ExcelWorksheetSpec<ProjectNote>
    {
        public ProjectNoteExcelSpec()
        {
            AddColumn($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} ID", x => x.Project.ProjectID);
            AddColumn($"{FieldDefinitionEnum.ProjectName.ToType().GetFieldDefinitionLabel()}", x => x.Project.ProjectName);
            AddColumn($"{FieldDefinitionEnum.ProjectNote.ToType().GetFieldDefinitionLabel()}", x => x.Note);
            AddColumn("Create Person", x => (x.CreatePersonID.HasValue ? x.CreatePerson.GetFullNameFirstLast() : string.Empty));
            AddColumn("Create Date", x => x.CreateDate);
        }
    }

    public class PerformanceMeasureExpectedExcelSpec : ExcelWorksheetSpec<PerformanceMeasureExpected>
    {
        public PerformanceMeasureExpectedExcelSpec()
        {
            AddColumn($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} ID", x => x.Project.ProjectID);
            AddColumn($"{FieldDefinitionEnum.ProjectName.ToType().GetFieldDefinitionLabel()}", x => x.Project.ProjectName);
            AddColumn(MultiTenantHelpers.GetPerformanceMeasureName() + " ID", x => x.PerformanceMeasureID);
            AddColumn(MultiTenantHelpers.GetPerformanceMeasureName(), x => x.PerformanceMeasure.PerformanceMeasureDisplayName);
            AddColumn($"{FieldDefinitionEnum.ExpectedValue.ToType().GetFieldDefinitionLabel()}", x => x.ExpectedValue);
        }
    }

    public class PerformanceMeasureActualExcelSpec : ExcelWorksheetSpec<PerformanceMeasureReportedValue>
    {
        public PerformanceMeasureActualExcelSpec()
        {
            AddColumn($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} ID", x => x.Project.ProjectID);
            AddColumn($"{FieldDefinitionEnum.ProjectName.ToType().GetFieldDefinitionLabel()}", x => x.Project.ProjectName);
            AddColumn(MultiTenantHelpers.GetPerformanceMeasureName() + " ID", x => x.PerformanceMeasureID);
            AddColumn(MultiTenantHelpers.GetPerformanceMeasureName(), x => x.PerformanceMeasure.PerformanceMeasureDisplayName);
            AddColumn("Calendar Year", x => x.CalendarYear);
            AddColumn($"{FieldDefinitionEnum.PerformanceMeasureSubcategory.ToType().GetFieldDefinitionLabel()} 1 Name", x => x.GetPerformanceMeasureSubcategoryOptions().Count > 1 ? x.GetPerformanceMeasureSubcategoryOptions()[0].PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : string.Empty);
            AddColumn($"{FieldDefinitionEnum.PerformanceMeasureSubcategory.ToType().GetFieldDefinitionLabel()} 1 Option", x => x.GetPerformanceMeasureSubcategoryOptions().Count > 1 ? x.GetPerformanceMeasureSubcategoryOptions()[0].PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName : string.Empty);
            AddColumn($"{FieldDefinitionEnum.PerformanceMeasureSubcategory.ToType().GetFieldDefinitionLabel()} 2 Name", x => x.GetPerformanceMeasureSubcategoryOptions().Count > 2 ? x.GetPerformanceMeasureSubcategoryOptions()[1].PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : string.Empty);
            AddColumn($"{FieldDefinitionEnum.PerformanceMeasureSubcategory.ToType().GetFieldDefinitionLabel()} 2 Option", x => x.GetPerformanceMeasureSubcategoryOptions().Count > 2 ? x.GetPerformanceMeasureSubcategoryOptions()[1].PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName : string.Empty);
            AddColumn($"{FieldDefinitionEnum.PerformanceMeasureSubcategory.ToType().GetFieldDefinitionLabel()} 3 Name", x => x.GetPerformanceMeasureSubcategoryOptions().Count > 3 ? x.GetPerformanceMeasureSubcategoryOptions()[2].PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : string.Empty);
            AddColumn($"{FieldDefinitionEnum.PerformanceMeasureSubcategory.ToType().GetFieldDefinitionLabel()} 3 Option", x => x.GetPerformanceMeasureSubcategoryOptions().Count > 3 ? x.GetPerformanceMeasureSubcategoryOptions()[2].PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName : string.Empty);
            AddColumn($"{FieldDefinitionEnum.PerformanceMeasureSubcategory.ToType().GetFieldDefinitionLabel()} 4 Name", x => x.GetPerformanceMeasureSubcategoryOptions().Count > 4 ? x.GetPerformanceMeasureSubcategoryOptions()[3].PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : string.Empty);
            AddColumn($"{FieldDefinitionEnum.PerformanceMeasureSubcategory.ToType().GetFieldDefinitionLabel()} 4 Option", x => x.GetPerformanceMeasureSubcategoryOptions().Count > 4 ? x.GetPerformanceMeasureSubcategoryOptions()[3].PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName : string.Empty);
            AddColumn($"{FieldDefinitionEnum.ReportedValue.ToType().GetFieldDefinitionLabel()}", x => x.GetReportedValue());
        }
    }

    public class ProjectFundingSourceExpenditureExcelSpec : ExcelWorksheetSpec<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure>
    {
        public ProjectFundingSourceExpenditureExcelSpec(List<ProjectFirmaModels.Models.FundingSourceCustomAttributeType> fundingSourceCustomAttributeTypes)
        {
            AddColumn($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} ID", x => x.Project.ProjectID);
            AddColumn($"{FieldDefinitionEnum.ProjectName.ToType().GetFieldDefinitionLabel()}", x => x.Project.ProjectName);
            AddColumn($"{FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()}", x => x.FundingSource.FundingSourceName);
            AddColumn($"Funding {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}", x => x.FundingSource.Organization.OrganizationName);
            AddColumn(FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabel(), x => x.FundingSource.Organization.OrganizationType?.OrganizationTypeName);
            foreach (var fundingSourceCustomAttributeType in fundingSourceCustomAttributeTypes)
            {
                AddColumn($"{fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeName}",
                    a => a.GetFundingSourceCustomAttributesValue(fundingSourceCustomAttributeType));
            }
            AddColumn("Calendar Year", x => x.CalendarYear);
            AddColumn("Expenditure Amount", x => x.ExpenditureAmount);
        }
    }

    public class ProjectGeospatialAreaExcelSpec : ExcelWorksheetSpec<ProjectGeospatialArea>
    {
        public ProjectGeospatialAreaExcelSpec()
        {
            AddColumn($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} ID", x => x.Project.ProjectID);
            AddColumn($"{FieldDefinitionEnum.ProjectName.ToType().GetFieldDefinitionLabel()}", x => x.Project.ProjectName);
            foreach (var geospatialAreaType in new List<GeospatialAreaType>())
            {
                AddColumn($"{geospatialAreaType.GeospatialAreaTypeNamePluralized}", x => x.GeospatialArea.GetDisplayName());
            }
        }
    }

    public class ProjectClassificationExcelSpec : ExcelWorksheetSpec<ProjectClassification>
    {
        public ProjectClassificationExcelSpec()
        {
            AddColumn($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} ID", x => x.Project.ProjectID);
            AddColumn($"{FieldDefinitionEnum.ProjectName.ToType().GetFieldDefinitionLabel()}", x => x.Project.ProjectName);
            AddColumn(FieldDefinitionEnum.Classification.ToType().GetFieldDefinitionLabel(), x => x.Classification.GetDisplayName());
        }
    }
}
