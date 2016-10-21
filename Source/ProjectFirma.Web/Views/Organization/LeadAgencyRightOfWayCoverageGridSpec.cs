using ProjectFirma.Web.Areas.ParcelTracker.Controllers;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Organization
{
    public class LeadAgencyRightOfWayCoverageGridSpec : GridSpec<Models.LeadAgencyRightOfWayCoverage>
    {
        public LeadAgencyRightOfWayCoverageGridSpec(bool hasManagePermissions)
        {
            SaveFiltersInCookie = true;

            if (hasManagePermissions)
            {
                Add(string.Empty,
                    a =>
                        DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(
                            SitkaRoute<LeadAgencyRightOfWayCoverageController>.BuildUrlFromExpression(t => t.Edit(a.LeadAgencyRightOfWayCoverageID)),
                            "Edit Right of Way Coverage")),
                    30);
                Add(string.Empty,
                    a => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(SitkaRoute<LeadAgencyRightOfWayCoverageController>.BuildUrlFromExpression(t => t.DeleteLeadAgencyRightOfWayCoverage(a.LeadAgencyRightOfWayCoverageID)), true),
                    30);
            }
            Add(Models.FieldDefinition.Commodity.ToGridHeaderString("Development Right"), a => a.DisplayName, 220, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.RightOfWayCoverageAmount.ToGridHeaderString("Coverage Amount"), a => a.RightOfWayCoverageAmount, 80);
            Add(Models.FieldDefinition.RightOfWayCoverageEffectiveDate.ToGridHeaderString("Effective Date"), a => a.RightOfWayCoverageEffectiveDate, 120, DhtmlxGridColumnFormatType.Date);
            Add("Updated By", a => a.LastUpdatePerson.FullNameFirstLast, 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Updated", a => a.LastUpdateDate, 120);
            Add(Models.FieldDefinition.RightOfWayCoverageNotes.ToGridHeaderString("Notes"), a => a.RightOfWayCoverageNotes, 200);
        }
    }
}