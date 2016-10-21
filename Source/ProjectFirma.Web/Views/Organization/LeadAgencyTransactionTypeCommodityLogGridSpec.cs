using ProjectFirma.Web.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Organization
{
    public class LeadAgencyTransactionTypeCommodityLogGridSpec : GridSpec<LeadAgencyTransactionTypeCommodityLog>
    {
        public LeadAgencyTransactionTypeCommodityLogGridSpec()
        {
            Add(Models.FieldDefinition.LeadAgency.ToGridHeaderString(), a => a.LeadAgency.Organization.GetDisplayNameAsUrl(), 200);
            Add(Models.FieldDefinition.TransactionType.ToGridHeaderString(), a => a.TransactionTypeCommodity.TransactionType.TransactionTypeDisplayName, 150, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.Commodity.ToGridHeaderString("Development Right"), a => a.TransactionTypeCommodity.Commodity.CommodityDisplayName, 200, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Change Type", a => a.LeadAgencyTransactionTypeCommodityLogChangeType.LeadAgencyTransactionTypeCommodityLogChangeTypeDisplayName, 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Change Date", a => a.ChangeDate, 120);
        }
    }
}