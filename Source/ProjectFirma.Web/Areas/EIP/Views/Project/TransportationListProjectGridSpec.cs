using System.Linq;
using System.Web;
using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.Project
{
    public class TransportationListProjectGridSpec : GridSpec<Models.Project>
    {
        public TransportationListProjectGridSpec(Person currentPerson)
        {
            var userHasTagManagePermissions = new TagManageFeature().HasPermissionByPerson(currentPerson);
            var userHasTagViewPermissions = new TagViewFeature().HasPermissionByPerson(currentPerson);

            var basicsColumnGroupCount = 6;
            var lastColumnCount = 3;

            if (userHasTagManagePermissions)
            {
                BulkTagModalDialogForm = new BulkTagModalDialogForm(SitkaRoute<TagController>.BuildUrlFromExpression(x => x.BulkTagProjects(null)));
                AddCheckBoxColumn();
                Add("ProjectID", x => x.ProjectID, 0);
                basicsColumnGroupCount += 2;
            }

            Add(string.Empty, x => UrlTemplate.MakeHrefString(x.GetFactSheetUrl(), ProjectFirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString()), 30); Add(FieldDefinition.ProjectNumber.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetSummaryUrl(), x.ProjectNumberString), 100, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinition.ProjectName.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetSummaryUrl(), x.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinition.LeadImplementer.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.LeadImplementer != null ? x.LeadImplementer.GetSummaryUrl() : null, x.LeadImplementerName), 140);
            
            Add(FieldDefinition.TransportationStrategy.ToGridHeaderStringWider(),
                x => x.TransportationObjective == null
                    ? new HtmlString(string.Empty)
                    : UrlTemplate.MakeHrefString(x.TransportationObjective.TransportationStrategy.SummaryUrl, x.TransportationObjective.TransportationStrategy.DisplayName),
                200);
            Add(FieldDefinition.TransportationObjective.ToGridHeaderStringWider(),
                x => x.TransportationObjective == null ? new HtmlString(string.Empty) : UrlTemplate.MakeHrefString(x.TransportationObjective.SummaryUrl, x.TransportationObjective.DisplayName),
                200);

            Add(FieldDefinition.Stage.ToGridHeaderStringWider(), x => x.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinition.PlanningDesignStartYear.ToGridHeaderString(), x => x.PlanningDesignStartYear, 120, DhtmlxGridColumnFormatType.None);
            Add(FieldDefinition.ImplementationStartYear.ToGridHeaderString(), x => x.ImplementationStartYear, 120, DhtmlxGridColumnFormatType.None);
            Add(FieldDefinition.CompletionYear.ToGridHeaderString(), x => x.CompletionYear, 90, DhtmlxGridColumnFormatType.None);
            Add(FieldDefinition.FundingType.ToGridHeaderString(), x => x.FundingType.FundingTypeShortName, 70, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinition.EstimatedTotalCost.ToGridHeaderString(), x => x.EstimatedTotalCost, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinition.SecuredFunding.ToGridHeaderString(), x => x.SecuredFunding, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinition.UnfundedNeed.ToGridHeaderString(), x => x.UnfundedNeed, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinition.ProjectCostInYearOfExpenditure.ToGridHeaderString(),
                x =>
                    Models.TransportationCostParameterSet.CanCalculateCapitalCostInYearOfExpenditure(x)
                        ? Models.TransportationCostParameterSet.CalculateCapitalCostInYearOfExpenditure(x)
                        : (decimal?) null,
                100,
                DhtmlxGridColumnFormatType.Currency);
            Add(FieldDefinition.EstimatedAnnualOperatingCost.ToGridHeaderString(), x => x.EstimatedAnnualOperatingCost, 100, DhtmlxGridColumnFormatType.Currency);
            Add(FieldDefinition.CalculatedTotalRemainingOperatingCost.ToGridHeaderString(),
                x =>
                    Models.TransportationCostParameterSet.CanCalculateTotalRemainingOperatingCostInYearOfExpenditure(x)
                        ? Models.TransportationCostParameterSet.CalculateTotalRemainingOperatingCost(x)
                        : (decimal?) null,
                100, DhtmlxGridColumnFormatType.Currency);
            Add(FieldDefinition.LifecycleOperatingCost.ToGridHeaderString(),
                x => Models.TransportationCostParameterSet.CanCalculateLifecycleOperatingCost(x) ? Models.TransportationCostParameterSet.LifecycleOperatingCost(x) : (decimal?) null,
                100,
                DhtmlxGridColumnFormatType.Currency);
            Add("Last Updated", a => a.LastUpdateDate, 120);

            Add("Expected", x => CalculatePM23ExpectedSum(x), 100, DhtmlxGridColumnFormatType.Decimal);
            Add("Reported", x => CalculatePM23ReportedSum(x), 100, DhtmlxGridColumnFormatType.Decimal);

            Add(FieldDefinition.ProjectOnFTIPList.ToGridHeaderString("FTIP"),
                x => new HtmlString(
                    x.OnFederalTransportationImprovementProgramList
                        ? string.Format("<span style='display:none'>Yes</span><span style='margin-left: 20px'>{0}</span>", x.OnFederalTransportationImprovementProgramList.ToCheckboxImageOrEmpty())
                        : "<span style='display:none'>No</span>"
                        ),
                60);
            Add("Local and Regional Plans", x => new HtmlString(string.Join(", ", x.ProjectLocalAndRegionalPlans.Select(y => y.LocalAndRegionalPlan.DisplayNameAsUrl))), 300, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinition.ProjectDescription.ToGridHeaderString(), x => x.ProjectDescription, 300);
            if (userHasTagViewPermissions)
            {
                Add(FieldDefinition.Tags.ToGridHeaderString(), x => new HtmlString(!x.ProjectTags.Any() ? string.Empty : string.Join(", ", x.ProjectTags.Select(pt => pt.Tag.DisplayNameAsUrl))), 100, DhtmlxGridColumnFilterType.Html);
                lastColumnCount++;
            }

            GroupingHeader =
                BuildGroupingHeader(new ColumnHeaderGroupingList
                {
                    {"Transportation Project Basics", basicsColumnGroupCount},
                    {"Project Timing", 4},
                    {string.Empty, 1},
                    {"Capital Costs", 4},
                    {"Operating Costs", 3},
                    {string.Empty, 1},
                    {"Miles of Bicycle and Pedestrian Routes Improved or Constructed", 2},
                    {string.Empty, lastColumnCount}
                });

        }

        private static double? CalculatePM23ExpectedSum(Models.Project project)
        {
            if (!(project.ProjectStage == ProjectStage.PlanningDesign || project.ProjectStage == ProjectStage.Deferred))
                return null;

            return project.EIPPerformanceMeasureExpecteds.Where(x => x.EIPPerformanceMeasureID == Models.EIPPerformanceMeasure.EIPPerformanceMeasureIDMilesOfPedestrianAndBicycleRoutesImprovedOrConstructed).Sum(x => x.ExpectedValue);
        }

        private static double? CalculatePM23ReportedSum(Models.Project project)
        {
            if (!(project.ProjectStage == ProjectStage.Implementation || project.ProjectStage == ProjectStage.PostImplementation || project.ProjectStage == ProjectStage.Completed))
                return null;

            return project.EIPPerformanceMeasureActuals.Where(x => x.EIPPerformanceMeasureID == Models.EIPPerformanceMeasure.EIPPerformanceMeasureIDMilesOfPedestrianAndBicycleRoutesImprovedOrConstructed).Sum(x => x.ReportedValue ?? 0);

        }
    }
}