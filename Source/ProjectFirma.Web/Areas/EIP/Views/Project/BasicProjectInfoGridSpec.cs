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
    public class BasicProjectInfoGridSpec : GridSpec<Models.Project>
    {
        public BasicProjectInfoGridSpec(Person currentPerson, bool allowTaggingFunctionality)
        {
            var userHasTagManagePermissions = new TagManageFeature().HasPermissionByPerson(currentPerson);
            var userHasTagViewPermissions = new TagViewFeature().HasPermissionByPerson(currentPerson);

            if (userHasTagManagePermissions && allowTaggingFunctionality)
            {
                BulkTagModalDialogForm = new BulkTagModalDialogForm(SitkaRoute<TagController>.BuildUrlFromExpression(x => x.BulkTagProjects(null)));
                AddCheckBoxColumn();
                Add("ProjectID", x => x.ProjectID, 0);
            }

            Add(string.Empty, x => UrlTemplate.MakeHrefString(x.GetFactSheetUrl(), ProjectFirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString()), 30);
            Add(FieldDefinition.ProjectNumber.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetSummaryUrl(), x.ProjectNumberString), 100, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinition.ProjectName.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetSummaryUrl(), x.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinition.LeadImplementer.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.LeadImplementer != null ? x.LeadImplementer.GetSummaryUrl() : null, x.LeadImplementerName), 140);
            Add(FieldDefinition.Stage.ToGridHeaderStringWider(), x => x.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinition.PlanningDesignStartYear.ToGridHeaderString(), x => x.PlanningDesignStartYear, 90, DhtmlxGridColumnFormatType.None);
            Add(FieldDefinition.ImplementationStartYear.ToGridHeaderString(), x => x.ImplementationStartYear, 115, DhtmlxGridColumnFormatType.None);
            Add(FieldDefinition.CompletionYear.ToGridHeaderString(), x => x.CompletionYear, 90, DhtmlxGridColumnFormatType.None);
            Add(FieldDefinition.FundingType.ToGridHeaderString(), x => x.FundingType.FundingTypeShortName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinition.EstimatedTotalCost.ToGridHeaderString(), x => x.EstimatedTotalCost, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinition.SecuredFunding.ToGridHeaderString(), x => x.SecuredFunding, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinition.UnfundedNeed.ToGridHeaderString(), x => x.UnfundedNeed, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinition.Latitude.ToGridHeaderString(), a => a.ProjectLocationPointLatitude, 80, DhtmlxGridColumnFormatType.LatLong);
            Add(FieldDefinition.Longitude.ToGridHeaderString(), a => a.ProjectLocationPointLongitude, 80, DhtmlxGridColumnFormatType.LatLong);
            Add(FieldDefinition.Region.ToGridHeaderString(), a => a.ProjectLocationTypeDisplay, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinition.ProjectLocationState.ToGridHeaderString(), a => a.ProjectLocationStateProvince, 95, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinition.ProjectLocationJurisdiction.ToGridHeaderString(), a => a.ProjectLocationJurisdiction, 95, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinition.ProjectLocationWatershed.ToGridHeaderString(), a => a.ProjectLocationWatershed, 95, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinition.ProjectDescription.ToGridHeaderString(), x => x.ProjectDescription, 300);
            if (userHasTagViewPermissions)
            {
                Add(FieldDefinition.Tags.ToGridHeaderString(), x => new HtmlString(!x.ProjectTags.Any() ? string.Empty : string.Join(", ", x.ProjectTags.Select(pt => pt.Tag.DisplayNameAsUrl))), 100, DhtmlxGridColumnFilterType.Html);    
            }
            
        }
    }
}