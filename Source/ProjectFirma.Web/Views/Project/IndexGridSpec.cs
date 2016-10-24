using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Project
{
    public class IndexGridSpec : GridSpec<Models.Project>
    {
        public IndexGridSpec(Person currentPerson)
        {
            var userHasTagManagePermissions = new TagManageFeature().HasPermissionByPerson(currentPerson);
            var userHasTagViewPermissions = new TagViewFeature().HasPermissionByPerson(currentPerson);

            var userHasDeletePermissions = new ProjectDeleteFeature().HasPermissionByPerson(currentPerson);

            if (userHasTagManagePermissions)
            {
                BulkTagModalDialogForm = new BulkTagModalDialogForm(SitkaRoute<TagController>.BuildUrlFromExpression(x => x.BulkTagProjects(null)));
                AddCheckBoxColumn();
                Add("ProjectID", x => x.ProjectID, 0);
            }

            if (userHasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, x.CanDelete().HasPermission), 30);
            }

            Add(string.Empty, x => UrlTemplate.MakeHrefString(x.GetFactSheetUrl(), ProjectFirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString()), 30);

            Add(Models.FieldDefinition.ProjectNumber.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetSummaryUrl(), x.ProjectNumberString), 100, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.ProjectName.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetSummaryUrl(), x.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.LeadImplementer.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.LeadImplementer != null ? x.LeadImplementer.GetSummaryUrl() : null, x.LeadImplementerName), 175);
            Add(Models.FieldDefinition.Stage.ToGridHeaderStringWider(), x => x.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.PlanningDesignStartYear.ToGridHeaderString(), x => x.PlanningDesignStartYear, 90, DhtmlxGridColumnFormatType.None);
            Add(Models.FieldDefinition.ImplementationStartYear.ToGridHeaderString(), x => x.ImplementationStartYear, 115, DhtmlxGridColumnFormatType.None);
            Add(Models.FieldDefinition.CompletionYear.ToGridHeaderString(), x => x.CompletionYear, 90, DhtmlxGridColumnFormatType.None);
            Add(Models.FieldDefinition.NumberOfReportedPMRecords.ToGridHeaderString(), x => x.EIPPerformanceMeasureActuals.Count, 100);
            Add(Models.FieldDefinition.NumberOfReportedExpenditureRecords.ToGridHeaderString(), x => x.ProjectFundingSourceExpenditures.Count, 100);
            Add(Models.FieldDefinition.FundingType.ToGridHeaderString(), x => x.FundingType.FundingTypeShortName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.EstimatedTotalCost.ToGridHeaderString(), x => x.EstimatedTotalCost, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.SecuredFunding.ToGridHeaderString(), x => x.SecuredFunding, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.UnfundedNeed.ToGridHeaderString(), x => x.UnfundedNeed, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.Latitude.ToGridHeaderString(), a => a.ProjectLocationPointLatitude, 80, DhtmlxGridColumnFormatType.LatLong);
            Add(Models.FieldDefinition.Longitude.ToGridHeaderString(), a => a.ProjectLocationPointLongitude, 80, DhtmlxGridColumnFormatType.LatLong);
            Add(Models.FieldDefinition.Region.ToGridHeaderString(), a => a.ProjectLocationTypeDisplay, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.ProjectLocationState.ToGridHeaderString(), a => a.ProjectLocationStateProvince, 95, DhtmlxGridColumnFilterType.Text);
            Add(Models.FieldDefinition.ProjectLocationJurisdiction.ToGridHeaderString(), a => a.ProjectLocationJurisdiction, 95, DhtmlxGridColumnFilterType.Text);
            Add(Models.FieldDefinition.ProjectLocationWatershed.ToGridHeaderString(), a => a.ProjectLocationWatershed, 95, DhtmlxGridColumnFilterType.Text);
            Add(Models.FieldDefinition.ProjectDescription.ToGridHeaderString(), x => x.ProjectDescription, 200);
            if (userHasTagViewPermissions)
            {
                Add(Models.FieldDefinition.Tags.ToGridHeaderString(), x => new HtmlString(!x.ProjectTags.Any() ? string.Empty : string.Join(", ", x.ProjectTags.Select(pt => pt.Tag.DisplayNameAsUrl))), 100, DhtmlxGridColumnFilterType.Html);
            }

            Add(Models.FieldDefinition.OldEIPNumber.ToGridHeaderString(), x => x.OldEipNumber, 60);
            Add("# of Photos", x => x.ProjectImages.Count, 60);
            Add("Five Year List", x => x.IsOnFiveYearList.ToYesNo(), 60, DhtmlxGridColumnFilterType.SelectFilterStrict);


        }
    }
}