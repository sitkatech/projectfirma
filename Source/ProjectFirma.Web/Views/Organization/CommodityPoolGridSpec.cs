using ProjectFirma.Web.Areas.ParcelTracker.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Organization
{
    public class CommodityPoolGridSpec : GridSpec<CommodityPool>
    {
        public CommodityPoolGridSpec(bool hasEditPermissions)
        {
            if (hasEditPermissions)
            {
                Add(string.Empty,
                    a => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(SitkaRoute<DevelopmentRightPoolController>.BuildUrlFromExpression(t => t.Edit(a.CommodityPoolID)),
                        string.Format("Edit Pool '{0}'", a.CommodityPoolDisplayName))),
                    30);

                Add(string.Empty, a => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(SitkaRoute<DevelopmentRightPoolController>.BuildUrlFromExpression(t => t.DeleteDevelopmentRightPool(a.CommodityPoolID)), true, !a.HasDependentObjects()), 30);
            }
            Add(Models.FieldDefinition.CommodityPoolName.ToGridHeaderString("Pool"), a => a.GetDisplayNameAsUrl(), 250, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.Commodity.ToGridHeaderString("Development Right"), a => a.Commodity.CommodityDisplayName, 200, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Balance Remaining", a => a.GetBalanceRemaining(), 120, DhtmlxGridColumnAggregationType.Total);
            Add("# of Trans", a => a.TransactionCount, 80, DhtmlxGridColumnAggregationType.Total);
            Add("Active?", a => a.IsActive.ToYesNo(), 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
        }
    }
}