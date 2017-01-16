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
            AddColumn(Models.FieldDefinition.ProjectName.FieldDefinitionDisplayName, x => x.ProjectName);
            AddColumn(Models.FieldDefinition.LeadImplementer.FieldDefinitionDisplayName, x => x.LeadImplementerName);
            AddColumn(Models.FieldDefinition.PrimaryContact.FieldDefinitionDisplayName, x => (x.LeadImplementer != null) ? x.LeadImplementer.PrimaryContactPersonWithOrgAsString : string.Empty);
            AddColumn("Non-Lead Implementing Organizations",
                x => string.Join(",", x.ProjectImplementingOrganizations.Where(pio => pio.OrganizationID != x.LeadImplementer.OrganizationID).Select(pio => pio.Organization.DisplayName)));
            AddColumn(Models.FieldDefinition.ProjectStage.FieldDefinitionDisplayName, x => x.ProjectStage.ProjectStageDisplayName);
            AddColumn(MultiTenantHelpers.GetClassificationDisplayNamePluralized(), x => string.Join(",", x.ProjectClassifications.Select(tc => tc.Classification.DisplayName)));
            AddColumn("Watersheds", x => string.Join(",", x.ProjectWatersheds.Select(pw => pw.Watershed.DisplayName)));
            AddColumn(Models.FieldDefinition.ImplementationStartYear.FieldDefinitionDisplayName, x => x.ImplementationStartYear);
            AddColumn(Models.FieldDefinition.CompletionYear.FieldDefinitionDisplayName, x => x.CompletionYear);
            AddColumn(Models.FieldDefinition.ProjectDescription.FieldDefinitionDisplayName, x => x.ProjectDescription);
            AddColumn(Models.FieldDefinition.FundingType.FieldDefinitionDisplayName, x => x.FundingType.FundingTypeShortName);
            AddColumn(Models.FieldDefinition.EstimatedTotalCost.FieldDefinitionDisplayName, x => x.EstimatedTotalCost);
            AddColumn(Models.FieldDefinition.SecuredFunding.FieldDefinitionDisplayName, x => x.SecuredFunding);
            AddColumn(Models.FieldDefinition.UnfundedNeed.FieldDefinitionDisplayName, x => x.UnfundedNeed);
            AddColumn(Models.FieldDefinition.Region.FieldDefinitionDisplayName, a => a.ProjectLocationTypeDisplay);
            AddColumn("State", a => a.ProjectLocationStateProvince);
            AddColumn("Jurisdiction", a => a.ProjectLocationJurisdiction);
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

    public class ProjectImplementingOrganizationOrProjectFundingOrganizationExcelSpec : ExcelWorksheetSpec<ProjectImplementingOrganizationOrProjectFundingOrganization>
    {
        public ProjectImplementingOrganizationOrProjectFundingOrganizationExcelSpec()
        {
            AddColumn("Project ID", x => x.Project.ProjectID);
            AddColumn("Project Name", x => x.Project.ProjectName);
            AddColumn("Organization ID", x => x.Organization.OrganizationID);
            AddColumn("Organization Name", x => x.Organization.OrganizationName);
            AddColumn("Primary Contact for Organization", x => x.Organization.PrimaryContactPersonWithOrgAsString);
            AddColumn("Is Lead Implementer", x => x.IsLeadOrganization.ToYesNo());
            AddColumn("Is Implementing Organization", x => x.IsImplementingOrganization.ToYesNo());
            AddColumn("Is Funding Organization", x => x.IsFundingOrganization.ToYesNo());
        }
    }

    public class ProjectNoteExcelSpec : ExcelWorksheetSpec<Models.ProjectNote>
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

    public class PerformanceMeasureExpectedExcelSpec : ExcelWorksheetSpec<Models.PerformanceMeasureExpected>
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
            AddColumn("Sector", x => x.FundingSource.Organization.Sector.SectorDisplayName);
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
            AddColumn(MultiTenantHelpers.GetClassificationDisplayName(), x => x.Classification.DisplayName);
        }
    }
}