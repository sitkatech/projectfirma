using System.Linq;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class LeadAgencyTransactionTypeCommodity : IAuditableEntity
    {
        public static LeadAgencyTransactionTypeCommodity GetByLeadAgencyAndTransactionTypeCommodity(int leadAgencyID, int transactionTypeCommodityID)
        {
            var leadAgencyTransactionTypeCommodity = HttpRequestStorage.DatabaseEntities.LeadAgencyTransactionTypeCommodities.SingleOrDefault(lattc => lattc.LeadAgencyID == leadAgencyID && lattc.TransactionTypeCommodityID == transactionTypeCommodityID);
            Check.RequireNotNullThrowNotFound(leadAgencyTransactionTypeCommodity, string.Format("LeadAgencyID={0} and TransactionTypeCommodityID={1}", leadAgencyID, transactionTypeCommodityID));
            return leadAgencyTransactionTypeCommodity;
        }

        public string AuditDescriptionString 
        {
            get
            {
                var leadAgency = HttpRequestStorage.DatabaseEntities.LeadAgencies.Find(LeadAgencyID);
                var transactionTypeCommodity = HttpRequestStorage.DatabaseEntities.TransactionTypeCommodities.Find(TransactionTypeCommodityID);
                var leadAgencyName = leadAgency != null ? leadAgency.DisplayName : ViewUtilities.NotFoundString;
                var transactionTypeName = transactionTypeCommodity.TransactionType.DisplayName;
                var commodityName = transactionTypeCommodity.Commodity.DisplayName;
                return string.Format("Lead Agency: {0}, Transaction Type: {1}, Commodity: {2}", leadAgencyName, transactionTypeName, commodityName);
            } 
        }
    }
}