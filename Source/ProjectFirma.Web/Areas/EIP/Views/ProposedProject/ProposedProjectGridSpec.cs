using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.ProposedProject
{
    public class ProposedProjectGridSpec : GridSpec<Models.ProposedProject>
    {
        public ProposedProjectGridSpec(Person currentPerson)
        {
            //TODO: Need distinct privs here - Admins can always delete and edit, but end user can only delete and edit at certain times. Need to work out rules.
            var userHasDeletePermissions = new ProposedProjectEditFeature().HasPermissionByPerson(currentPerson);
            var userHasEditPermissions = new ProposedProjectEditFeature().HasPermissionByPerson(currentPerson); 

            if (userHasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, x.CanDelete().HasPermission), 30);
            }
            
            if (userHasEditPermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsHyperlinkBootstrap(x.GetEditUrl(), userHasEditPermissions), 30);
            }

            Add(FieldDefinition.ProjectName.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetSummaryUrl(), x.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinition.ActionPriorityName.ToGridHeaderString(), x => x.ActionPriority == null ? string.Empty : x.ActionPriority.DisplayName, 300, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinition.LeadImplementer.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.LeadImplementerOrganization.GetSummaryUrl(), x.LeadImplementerOrganization.DisplayName), 175);
            Add(FieldDefinition.PlanningDesignStartYear.ToGridHeaderString(), x => x.PlanningDesignStartYear, 90, DhtmlxGridColumnFormatType.None);
            Add(FieldDefinition.ImplementationStartYear.ToGridHeaderString(), x => x.ImplementationStartYear, 115, DhtmlxGridColumnFormatType.None);
            Add(FieldDefinition.CompletionYear.ToGridHeaderString(), x => x.CompletionYear, 90, DhtmlxGridColumnFormatType.None);
            Add(FieldDefinition.EstimatedTotalCost.ToGridHeaderString(), x => x.EstimatedTotalCost, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinition.SecuredFunding.ToGridHeaderString(), x => x.SecuredFunding, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinition.UnfundedNeed.ToGridHeaderString(), x => x.UnfundedNeed, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add("Submittal Status", a => a.ProposedProjectState.ToEnum.ToString(), 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Proposed By", a => a.ProposingPerson.GetFullNameFirstLastAndOrgAsUrl(), 200);
            Add("Proposed Date", a => a.ProposingDate, 120);
            Add("Submitted Date", a => a.SubmissionDate, 120);                     
            Add("Last Updated", a => a.LastUpdateDate, 120);
            Add(FieldDefinition.Region.ToGridHeaderString(), a => a.ProjectLocationTypeDisplay, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinition.ProjectLocationState.ToGridHeaderString(), a => a.ProjectLocationStateProvince, 95, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinition.ProjectLocationJurisdiction.ToGridHeaderString(), a => a.ProjectLocationJurisdiction, 95, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinition.ProjectLocationWatershed.ToGridHeaderString(), a => a.ProjectLocationWatershed, 95, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinition.ProjectDescription.ToGridHeaderString(), x => x.ProjectDescription, 300);
        }
    }
}