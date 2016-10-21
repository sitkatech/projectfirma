using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.Snapshot
{
    public class SnapshotProjectGridSpec : GridSpec<Models.SnapshotProject>
    {
        public SnapshotProjectGridSpec()
        {
            Add(string.Empty, x => UrlTemplate.MakeHrefString(x.Project.GetFactSheetUrl(), ProjectFirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString()), 30);
            Add(FieldDefinition.ProjectNumber.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.Project.GetSummaryUrl(), x.Project.ProjectNumberString), 100, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinition.ProjectName.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.Project.GetSummaryUrl(), x.Project.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
            Add("Added/ Updated", x => x.SnapshotProjectType.SnapshotProjectTypeDisplayName, 60, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinition.LeadImplementer.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.Project.LeadImplementer != null ? x.Project.LeadImplementer.GetSummaryUrl() : null, x.Project.LeadImplementerName), 140);
            Add(FieldDefinition.Stage.ToGridHeaderStringWider(), x => x.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinition.PlanningDesignStartYear.ToGridHeaderString(), x => x.Project.PlanningDesignStartYear, 90, DhtmlxGridColumnFormatType.None);
            Add(FieldDefinition.ImplementationStartYear.ToGridHeaderString(), x => x.Project.ImplementationStartYear, 115, DhtmlxGridColumnFormatType.None);
            Add(FieldDefinition.CompletionYear.ToGridHeaderString(), x => x.Project.CompletionYear, 90, DhtmlxGridColumnFormatType.None);
            Add(FieldDefinition.FundingType.ToGridHeaderString(), x => x.Project.FundingType.FundingTypeShortName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinition.EstimatedTotalCost.ToGridHeaderString(), x => x.Project.EstimatedTotalCost, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinition.SecuredFunding.ToGridHeaderString(), x => x.Project.SecuredFunding, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinition.UnfundedNeed.ToGridHeaderString(), x => x.Project.UnfundedNeed, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinition.Latitude.ToGridHeaderString(), x => x.Project.ProjectLocationPointLatitude, 80, DhtmlxGridColumnFormatType.LatLong);
            Add(FieldDefinition.Longitude.ToGridHeaderString(), x => x.Project.ProjectLocationPointLongitude, 80, DhtmlxGridColumnFormatType.LatLong);
            Add(FieldDefinition.Region.ToGridHeaderString(), x => x.Project.ProjectLocationTypeDisplay, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinition.ProjectLocationState.ToGridHeaderString(), x => x.Project.ProjectLocationStateProvince, 95, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinition.ProjectLocationJurisdiction.ToGridHeaderString(), x => x.Project.ProjectLocationJurisdiction, 95, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinition.ProjectLocationWatershed.ToGridHeaderString(), x => x.Project.ProjectLocationWatershed, 95, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinition.ProjectDescription.ToGridHeaderString(), x => x.Project.ProjectDescription, 300);
        }
    }
}