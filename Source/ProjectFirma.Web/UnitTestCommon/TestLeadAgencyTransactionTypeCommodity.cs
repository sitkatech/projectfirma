using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestLeadAgencyTransactionTypeCommodity
    {
        public static LeadAgencyTransactionTypeCommodity Create()
        {
            var leadAgency = TestLeadAgency.Create();
            var transactionTypeCommodity = TestTransactionTypeCommodity.GetRecord(TransactionType.Allocation);
            return Create(leadAgency, transactionTypeCommodity);
        }

        public static LeadAgencyTransactionTypeCommodity Create(LeadAgency leadAgency)
        {
            var transactionTypeCommodity = TestTransactionTypeCommodity.GetRecord(TransactionType.Allocation);
            return Create(leadAgency, transactionTypeCommodity);
        }

        public static LeadAgencyTransactionTypeCommodity Create(LeadAgency leadAgency, TransactionTypeCommodity transactionTypeCommodity)
        {
            var leadAgencyTransactionTypeCommodity = new LeadAgencyTransactionTypeCommodity(leadAgency.LeadAgencyID, transactionTypeCommodity.TransactionTypeCommodityID) { LeadAgency = leadAgency, TransactionTypeCommodity = transactionTypeCommodity};
            leadAgency.LeadAgencyTransactionTypeCommodities.Add(leadAgencyTransactionTypeCommodity);
            transactionTypeCommodity.LeadAgencyTransactionTypeCommodities.Add(leadAgencyTransactionTypeCommodity);
            return leadAgencyTransactionTypeCommodity;
        }
    }
}