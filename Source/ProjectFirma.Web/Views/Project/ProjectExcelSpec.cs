using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ExcelWorkbookUtilities;

namespace ProjectFirma.Web.Views.Project
{
    public class ProjectExcelSpec : ExcelWorksheetSpec<Models.Project>
    {
        public ProjectExcelSpec()
        {
            AddColumn(Models.FieldDefinition.ProjectNumber.FieldDefinitionDisplayName, x => x.ProjectNumberString);
            AddColumn(Models.FieldDefinition.ProjectName.FieldDefinitionDisplayName, x => x.ProjectName);
            AddColumn(Models.FieldDefinition.LeadImplementer.FieldDefinitionDisplayName, x => x.LeadImplementerName);
            AddColumn(Models.FieldDefinition.PrimaryContact.FieldDefinitionDisplayName, x => (x.LeadImplementer != null) ? x.LeadImplementer.PrimaryContactPersonWithOrgAsString : string.Empty);
            AddColumn("Non-Lead Implementing Organizations",
                x => string.Join(",", x.ProjectImplementingOrganizations.Where(pio => pio.OrganizationID != x.LeadImplementer.OrganizationID).Select(pio => pio.Organization.DisplayName)));
            AddColumn(Models.FieldDefinition.Stage.FieldDefinitionDisplayName, x => x.ProjectStage.ProjectStageDisplayName);
            AddColumn("Threshold Categories", x => string.Join(",", x.ProjectThresholdCategories.Select(tc => tc.ThresholdCategory.DisplayName)));
            AddColumn("Local and Regional Plans", x => string.Join(",", x.ProjectLocalAndRegionalPlans.Select(ap => ap.LocalAndRegionalPlan.LocalAndRegionalPlanName)));
            AddColumn("Watersheds", x => string.Join(",", x.ProjectWatersheds.Select(pw => pw.Watershed.DisplayName)));
            AddColumn(Models.FieldDefinition.ImplementationStartYear.FieldDefinitionDisplayName, x => x.ImplementationStartYear);
            AddColumn(Models.FieldDefinition.CompletionYear.FieldDefinitionDisplayName, x => x.CompletionYear);
            AddColumn(Models.FieldDefinition.ProjectDescription.FieldDefinitionDisplayName, x => x.ProjectDescription);
            AddColumn(Models.FieldDefinition.FundingType.FieldDefinitionDisplayName, x => x.FundingType.FundingTypeShortName);
            AddColumn(Models.FieldDefinition.EstimatedTotalCost.FieldDefinitionDisplayName, x => x.EstimatedTotalCost);
            AddColumn(Models.FieldDefinition.SecuredFunding.FieldDefinitionDisplayName, x => x.SecuredFunding);
            AddColumn(Models.FieldDefinition.UnfundedNeed.FieldDefinitionDisplayName, x => x.UnfundedNeed);
            AddColumn(Models.FieldDefinition.Latitude.FieldDefinitionDisplayName, a => a.ProjectLocationPointLatitude);
            AddColumn(Models.FieldDefinition.Longitude.FieldDefinitionDisplayName, a => a.ProjectLocationPointLongitude);
            AddColumn(Models.FieldDefinition.Region.FieldDefinitionDisplayName, a => a.ProjectLocationTypeDisplay);
            AddColumn(Models.FieldDefinition.ProjectLocationState.FieldDefinitionDisplayName, a => a.ProjectLocationStateProvince);
            AddColumn(Models.FieldDefinition.ProjectLocationJurisdiction.FieldDefinitionDisplayName, a => a.ProjectLocationJurisdiction);
            AddColumn(Models.FieldDefinition.ProjectLocationWatershed.FieldDefinitionDisplayName, a => a.ProjectLocationWatershed);
            AddColumn("Project Location Notes", a => a.ProjectLocationNotes);
            AddColumn(Models.FieldDefinition.ProjectIsAProgram.FieldDefinitionDisplayName, x => x.ImplementsMultipleProjects.ToYesNo());
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

    public class PerformanceMeasureExpectedExcelSpec : ExcelWorksheetSpec<Models.PerformanceMeasureExpected>
    {
        public PerformanceMeasureExpectedExcelSpec()
        {
            AddColumn("Project #", x => x.Project.ProjectNumberString);
            AddColumn("Project Name", x => x.Project.ProjectName);
            AddColumn("Performance Measure ID", x => x.PerformanceMeasureID);
            AddColumn("Performance Measure Name", x => x.PerformanceMeasure.Indicator.IndicatorName);
            AddColumn("Performance Measure", x => x.PerformanceMeasure.DisplayName);
            AddColumn("Expected Value", x => x.ExpectedValue);
        }
    }

    public class PerformanceMeasureActualExcelSpec : ExcelWorksheetSpec<PerformanceMeasureReportedValue>
    {
        public PerformanceMeasureActualExcelSpec()
        {
            AddColumn("Project #", x => x.Project.ProjectNumberString);
            AddColumn("Project Name", x => x.Project.ProjectName);
            AddColumn("Performance Measure ID", x => x.PerformanceMeasureID);
            AddColumn("Performance Measure Name", x => x.PerformanceMeasure.Indicator.IndicatorName);
            AddColumn("Performance Measure", x => x.PerformanceMeasure.DisplayName);
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