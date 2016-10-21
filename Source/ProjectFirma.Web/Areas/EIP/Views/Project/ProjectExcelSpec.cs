using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ExcelWorkbookUtilities;

namespace ProjectFirma.Web.Areas.EIP.Views.Project
{
    public class ProjectExcelSpec : ExcelWorksheetSpec<Models.Project>
    {
        public ProjectExcelSpec()
        {
            AddColumn(FieldDefinition.ProjectNumber.FieldDefinitionDisplayName, x => x.ProjectNumberString);
            AddColumn(FieldDefinition.ProjectName.FieldDefinitionDisplayName, x => x.ProjectName);
            AddColumn(FieldDefinition.LeadImplementer.FieldDefinitionDisplayName, x => x.LeadImplementerName);
            AddColumn(FieldDefinition.PrimaryContact.FieldDefinitionDisplayName, x => (x.LeadImplementer != null) ? x.LeadImplementer.PrimaryContactPersonWithOrgAsString : string.Empty);
            AddColumn("Non-Lead Implementing Organizations",
                x => string.Join(",", x.ProjectImplementingOrganizations.Where(pio => pio.OrganizationID != x.LeadImplementer.OrganizationID).Select(pio => pio.Organization.DisplayName)));
            AddColumn(Models.FieldDefinition.Stage.FieldDefinitionDisplayName, x => x.ProjectStage.ProjectStageDisplayName);
            AddColumn("Threshold Categories", x => string.Join(",", x.ProjectThresholdCategories.Select(tc => tc.ThresholdCategory.DisplayName)));
            AddColumn("Local and Regional Plans", x => string.Join(",", x.ProjectLocalAndRegionalPlans.Select(ap => ap.LocalAndRegionalPlan.LocalAndRegionalPlanName)));
            AddColumn("Watersheds", x => string.Join(",", x.ProjectWatersheds.Select(pw => pw.Watershed.DisplayName)));
            AddColumn(FieldDefinition.ImplementationStartYear.FieldDefinitionDisplayName, x => x.ImplementationStartYear);
            AddColumn(FieldDefinition.CompletionYear.FieldDefinitionDisplayName, x => x.CompletionYear);
            AddColumn(FieldDefinition.ProjectDescription.FieldDefinitionDisplayName, x => x.ProjectDescription);
            AddColumn(FieldDefinition.FundingType.FieldDefinitionDisplayName, x => x.FundingType.FundingTypeShortName);
            AddColumn(FieldDefinition.EstimatedTotalCost.FieldDefinitionDisplayName, x => x.EstimatedTotalCost);
            AddColumn(FieldDefinition.SecuredFunding.FieldDefinitionDisplayName, x => x.SecuredFunding);
            AddColumn(FieldDefinition.UnfundedNeed.FieldDefinitionDisplayName, x => x.UnfundedNeed);
            AddColumn(FieldDefinition.Latitude.FieldDefinitionDisplayName, a => a.ProjectLocationPointLatitude);
            AddColumn(FieldDefinition.Longitude.FieldDefinitionDisplayName, a => a.ProjectLocationPointLongitude);
            AddColumn(FieldDefinition.Region.FieldDefinitionDisplayName, a => a.ProjectLocationTypeDisplay);
            AddColumn(FieldDefinition.ProjectLocationState.FieldDefinitionDisplayName, a => a.ProjectLocationStateProvince);
            AddColumn(FieldDefinition.ProjectLocationJurisdiction.FieldDefinitionDisplayName, a => a.ProjectLocationJurisdiction);
            AddColumn(FieldDefinition.ProjectLocationWatershed.FieldDefinitionDisplayName, a => a.ProjectLocationWatershed);
            AddColumn("Project Location Notes", a => a.ProjectLocationNotes);
            AddColumn(FieldDefinition.OldEIPNumber.FieldDefinitionDisplayName, x => x.OldEipNumber);
            AddColumn(FieldDefinition.ProjectIsAProgram.FieldDefinitionDisplayName, x => x.ImplementsMultipleProjects.ToYesNo());
        }
    }

    public class ProjectDescriptionExcelSpec : ExcelWorksheetSpec<Models.Project>
    {
        public ProjectDescriptionExcelSpec()
        {
            AddColumn("Project #", x => x.ProjectNumberString);
            AddColumn("Project Name", x => x.ProjectName);
            AddColumn("Description", x => x.ProjectDescription);
        }
    }

    public class ProjectImplementingOrganizationOrProjectFundingOrganizationExcelSpec : ExcelWorksheetSpec<ProjectImplementingOrganizationOrProjectFundingOrganization>
    {
        public ProjectImplementingOrganizationOrProjectFundingOrganizationExcelSpec()
        {
            AddColumn("Project #", x => x.Project.ProjectNumberString);
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
            AddColumn("Project #", x => x.Project.ProjectNumberString);
            AddColumn("Project Name", x => x.Project.ProjectName);
            AddColumn("Project Note", x => x.Note);
            AddColumn("Create Person", x => x.CreatePersonName);
            AddColumn("Create Date", x => x.CreateDate);
        }
    }

    public class EIPPerformanceMeasureExpectedExcelSpec : ExcelWorksheetSpec<Models.EIPPerformanceMeasureExpected>
    {
        public EIPPerformanceMeasureExpectedExcelSpec()
        {
            AddColumn("Project #", x => x.Project.ProjectNumberString);
            AddColumn("Project Name", x => x.Project.ProjectName);
            AddColumn("Performance Measure ID", x => x.EIPPerformanceMeasureID);
            AddColumn("Performance Measure Name", x => x.EIPPerformanceMeasure.Indicator.IndicatorName);
            AddColumn("Performance Measure", x => x.EIPPerformanceMeasure.DisplayName);
            AddColumn("Expected Value", x => x.ExpectedValue);
        }
    }

    public class EIPPerformanceMeasureActualExcelSpec : ExcelWorksheetSpec<EIPPerformanceMeasureReportedValue>
    {
        public EIPPerformanceMeasureActualExcelSpec()
        {
            AddColumn("Project #", x => x.Project.ProjectNumberString);
            AddColumn("Project Name", x => x.Project.ProjectName);
            AddColumn("Performance Measure ID", x => x.EIPPerformanceMeasureID);
            AddColumn("Performance Measure Name", x => x.EIPPerformanceMeasure.Indicator.IndicatorName);
            AddColumn("Performance Measure", x => x.EIPPerformanceMeasure.DisplayName);
            AddColumn("Calendar Year", x => x.CalendarYear);
            AddColumn("Subcategory 1 Name", x => x.IndicatorSubcategoryOptions.Count > 1 ? x.IndicatorSubcategoryOptions[0].IndicatorSubcategory.IndicatorSubcategoryDisplayName : string.Empty);
            AddColumn("Subcategory 1 Option", x => x.IndicatorSubcategoryOptions.Count > 1 ? x.IndicatorSubcategoryOptions[0].IndicatorSubcategoryOption.IndicatorSubcategoryOptionName : string.Empty);
            AddColumn("Subcategory 2 Name", x => x.IndicatorSubcategoryOptions.Count > 2 ? x.IndicatorSubcategoryOptions[1].IndicatorSubcategory.IndicatorSubcategoryDisplayName : string.Empty);
            AddColumn("Subcategory 2 Option", x => x.IndicatorSubcategoryOptions.Count > 2 ? x.IndicatorSubcategoryOptions[1].IndicatorSubcategoryOption.IndicatorSubcategoryOptionName : string.Empty);
            AddColumn("Subcategory 3 Name", x => x.IndicatorSubcategoryOptions.Count > 3 ? x.IndicatorSubcategoryOptions[2].IndicatorSubcategory.IndicatorSubcategoryDisplayName : string.Empty);
            AddColumn("Subcategory 3 Option", x => x.IndicatorSubcategoryOptions.Count > 3 ? x.IndicatorSubcategoryOptions[2].IndicatorSubcategoryOption.IndicatorSubcategoryOptionName : string.Empty);
            AddColumn("Subcategory 4 Name", x => x.IndicatorSubcategoryOptions.Count > 4 ? x.IndicatorSubcategoryOptions[3].IndicatorSubcategory.IndicatorSubcategoryDisplayName : string.Empty);
            AddColumn("Subcategory 4 Option", x => x.IndicatorSubcategoryOptions.Count > 4 ? x.IndicatorSubcategoryOptions[3].IndicatorSubcategoryOption.IndicatorSubcategoryOptionName : string.Empty);
            AddColumn("Reported Value", x => x.ReportedValue);
        }
    }

    public class ProjectFundingSourceExpenditureExcelSpec : ExcelWorksheetSpec<Models.ProjectFundingSourceExpenditure>
    {
        public ProjectFundingSourceExpenditureExcelSpec()
        {
            AddColumn("Project #", x => x.Project.ProjectNumberString);
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
            AddColumn("Project #", x => x.Project.ProjectNumberString);
            AddColumn("Project Name", x => x.Project.ProjectName);
            AddColumn("Watershed", x => x.Watershed.DisplayName);
        }
    }

    public class ProjectThresholdCategoryExcelSpec : ExcelWorksheetSpec<Models.ProjectThresholdCategory>
    {
        public ProjectThresholdCategoryExcelSpec()
        {
            AddColumn("Project #", x => x.Project.ProjectNumberString);
            AddColumn("Project Name", x => x.Project.ProjectName);
            AddColumn("Threshold Category", x => x.ThresholdCategory.DisplayName);
        }
    }

    public class ProjectLocalAndRegionalPlanExcelSpec : ExcelWorksheetSpec<Models.ProjectLocalAndRegionalPlan>
    {
        public ProjectLocalAndRegionalPlanExcelSpec()
        {
            AddColumn("Project #", x => x.Project.ProjectNumberString);
            AddColumn("Project Name", x => x.Project.ProjectName);
            AddColumn("Local and Regional Plan", x => x.LocalAndRegionalPlan.DisplayName);
        }
    }
}