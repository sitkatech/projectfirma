/*-----------------------------------------------------------------------
<copyright file="ProjectExcelSpec.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ExcelWorkbookUtilities;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Project
{
    public class ProjectExcelSpec : ExcelWorksheetSpec<Models.Project>
    {
        public ProjectExcelSpec()
        {
            AddColumn(Models.FieldDefinition.ProjectName.GetFieldDefinitionLabel(), x => x.ProjectName);
            AddColumn(Models.FieldDefinition.LeadImplementer.GetFieldDefinitionLabel(), x => x.LeadImplementerName);
            AddColumn(Models.FieldDefinition.PrimaryContact.GetFieldDefinitionLabel(), x => x.LeadImplementerOrganization != null ? x.LeadImplementerOrganization.PrimaryContactPersonWithOrgAsString : string.Empty);
            AddColumn("Non-Lead Implementing Organizations",
                x => string.Join(",", x.ProjectOrganizations.Select(pio => pio.Organization.DisplayName)));
            AddColumn(Models.FieldDefinition.ProjectStage.GetFieldDefinitionLabel(), x => x.ProjectStage.ProjectStageDisplayName);
            AddColumn(Models.FieldDefinition.Classification.GetFieldDefinitionLabelPluralized(), x => string.Join(",", x.ProjectClassifications.Select(tc => tc.Classification.DisplayName)));
            AddColumn("Watersheds", x => string.Join(",", x.ProjectWatersheds.Select(pw => pw.Watershed.DisplayName)));
            AddColumn(Models.FieldDefinition.ImplementationStartYear.GetFieldDefinitionLabel(), x => x.ImplementationStartYear);
            AddColumn(Models.FieldDefinition.CompletionYear.GetFieldDefinitionLabel(), x => x.CompletionYear);
            AddColumn(Models.FieldDefinition.ProjectDescription.GetFieldDefinitionLabel(), x => x.ProjectDescription);
            AddColumn(Models.FieldDefinition.FundingType.GetFieldDefinitionLabel(), x => x.FundingType.FundingTypeShortName);
            AddColumn(Models.FieldDefinition.EstimatedTotalCost.GetFieldDefinitionLabel(), x => x.EstimatedTotalCost);
            AddColumn(Models.FieldDefinition.SecuredFunding.GetFieldDefinitionLabel(), x => x.SecuredFunding);
            AddColumn(Models.FieldDefinition.UnfundedNeed.GetFieldDefinitionLabel(), x => x.UnfundedNeed);
            AddColumn(Models.FieldDefinition.Region.GetFieldDefinitionLabel(), a => a.ProjectLocationTypeDisplay);
            AddColumn("State", a => a.ProjectLocationStateProvince);
            AddColumn("Watershed", a => a.ProjectLocationWatershed);
            AddColumn("Project Location Notes", a => a.ProjectLocationNotes);
        }
    }

    public class ProjectDescriptionExcelSpec : ExcelWorksheetSpec<Models.Project>
    {
        public ProjectDescriptionExcelSpec()
        {
            AddColumn("Project ID", x => x.ProjectID);
            AddColumn("Project Name", x => x.ProjectName);
            AddColumn("Description", x => x.ProjectDescription);
        }
    }

    public class ProjectImplementingOrganizationOrProjectFundingOrganizationExcelSpec : ExcelWorksheetSpec<Models.ProjectOrganization>
    {
        public ProjectImplementingOrganizationOrProjectFundingOrganizationExcelSpec()
        {
            AddColumn("Project ID", x => x.Project.ProjectID);
            AddColumn("Project Name", x => x.Project.ProjectName);
            AddColumn("Organization ID", x => x.Organization.OrganizationID);
            AddColumn("Organization Name", x => x.Organization.OrganizationName);
            AddColumn("Primary Contact for Organization", x => x.Organization.PrimaryContactPersonWithOrgAsString);
            AddColumn("Organization Type", x => x.Organization.OrganizationType?.OrganizationTypeName);
            AddColumn("Organization Relationship To Project", x => x.RelationshipType.RelationshipTypeName);
        }
    }

    public class ProjectNoteExcelSpec : ExcelWorksheetSpec<ProjectNote>
    {
        public ProjectNoteExcelSpec()
        {
            AddColumn("Project ID", x => x.Project.ProjectID);
            AddColumn("Project Name", x => x.Project.ProjectName);
            AddColumn("Project Note", x => x.Note);
            AddColumn("Create Person", x => x.CreatePersonName);
            AddColumn("Create Date", x => x.CreateDate);
        }
    }

    public class PerformanceMeasureExpectedExcelSpec : ExcelWorksheetSpec<PerformanceMeasureExpected>
    {
        public PerformanceMeasureExpectedExcelSpec()
        {
            AddColumn("Project ID", x => x.Project.ProjectID);
            AddColumn("Project Name", x => x.Project.ProjectName);
            AddColumn(MultiTenantHelpers.GetPerformanceMeasureName() + " ID", x => x.PerformanceMeasureID);
            AddColumn(MultiTenantHelpers.GetPerformanceMeasureName(), x => x.PerformanceMeasure.PerformanceMeasureDisplayName);
            AddColumn("Expected Value", x => x.ExpectedValue);
        }
    }

    public class PerformanceMeasureActualExcelSpec : ExcelWorksheetSpec<PerformanceMeasureReportedValue>
    {
        public PerformanceMeasureActualExcelSpec()
        {
            AddColumn("Project ID", x => x.Project.ProjectID);
            AddColumn("Project Name", x => x.Project.ProjectName);
            AddColumn(MultiTenantHelpers.GetPerformanceMeasureName() + " ID", x => x.PerformanceMeasureID);
            AddColumn(MultiTenantHelpers.GetPerformanceMeasureName(), x => x.PerformanceMeasure.PerformanceMeasureDisplayName);
            AddColumn("Calendar Year", x => x.CalendarYear);
            AddColumn("Subcategory 1 Name", x => x.PerformanceMeasureSubcategoryOptions.Count > 1 ? x.PerformanceMeasureSubcategoryOptions[0].PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : string.Empty);
            AddColumn("Subcategory 1 Option", x => x.PerformanceMeasureSubcategoryOptions.Count > 1 ? x.PerformanceMeasureSubcategoryOptions[0].PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName : string.Empty);
            AddColumn("Subcategory 2 Name", x => x.PerformanceMeasureSubcategoryOptions.Count > 2 ? x.PerformanceMeasureSubcategoryOptions[1].PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : string.Empty);
            AddColumn("Subcategory 2 Option", x => x.PerformanceMeasureSubcategoryOptions.Count > 2 ? x.PerformanceMeasureSubcategoryOptions[1].PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName : string.Empty);
            AddColumn("Subcategory 3 Name", x => x.PerformanceMeasureSubcategoryOptions.Count > 3 ? x.PerformanceMeasureSubcategoryOptions[2].PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : string.Empty);
            AddColumn("Subcategory 3 Option", x => x.PerformanceMeasureSubcategoryOptions.Count > 3 ? x.PerformanceMeasureSubcategoryOptions[2].PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName : string.Empty);
            AddColumn("Subcategory 4 Name", x => x.PerformanceMeasureSubcategoryOptions.Count > 4 ? x.PerformanceMeasureSubcategoryOptions[3].PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : string.Empty);
            AddColumn("Subcategory 4 Option", x => x.PerformanceMeasureSubcategoryOptions.Count > 4 ? x.PerformanceMeasureSubcategoryOptions[3].PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName : string.Empty);
            AddColumn("Reported Value", x => x.ReportedValue);
        }
    }

    public class ProjectFundingSourceExpenditureExcelSpec : ExcelWorksheetSpec<Models.ProjectFundingSourceExpenditure>
    {
        public ProjectFundingSourceExpenditureExcelSpec()
        {
            AddColumn("Project ID", x => x.Project.ProjectID);
            AddColumn("Project Name", x => x.Project.ProjectName);
            AddColumn("Funding Source", x => x.FundingSource.FundingSourceName);
            AddColumn("Funding Organization", x => x.FundingSource.Organization.OrganizationName);
            AddColumn("Sector", x => x.FundingSource.Organization.OrganizationType.OrganizationTypeName);
            AddColumn("Calendar Year", x => x.CalendarYear);
            AddColumn("Expenditure Amount", x => x.ExpenditureAmount);
        }
    }

    public class ProjectWatershedExcelSpec : ExcelWorksheetSpec<Models.ProjectWatershed>
    {
        public ProjectWatershedExcelSpec()
        {
            AddColumn("Project ID", x => x.Project.ProjectID);
            AddColumn("Project Name", x => x.Project.ProjectName);
            AddColumn("Watershed", x => x.Watershed.DisplayName);
        }
    }

    public class ProjectClassificationExcelSpec : ExcelWorksheetSpec<Models.ProjectClassification>
    {
        public ProjectClassificationExcelSpec()
        {
            AddColumn("Project ID", x => x.Project.ProjectID);
            AddColumn("Project Name", x => x.Project.ProjectName);
            AddColumn(Models.FieldDefinition.Classification.GetFieldDefinitionLabel(), x => x.Classification.DisplayName);
        }
    }
}
