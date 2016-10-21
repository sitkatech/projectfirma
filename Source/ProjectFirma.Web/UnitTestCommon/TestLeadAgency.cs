using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestLeadAgency
    {
        public static LeadAgency Create()
        {
            var randomInMemoryOnlyUniqueID = TestFramework.RandomInMemoryOnlyUniqueID();
            var testLeadAgencyAbbreviation = string.Format("{0}Abbr", randomInMemoryOnlyUniqueID);
            var testOrganization = TestFramework.TestOrganization.Create(TestFramework.MakeTestName("organizationName"));
            var leadAgency = new LeadAgency(randomInMemoryOnlyUniqueID, testOrganization.OrganizationID, testLeadAgencyAbbreviation, 100, true) {Organization = testOrganization};
            var transactionTypeCommodity1 = TestTransactionTypeCommodity.GetRecord(TransactionType.Allocation);
            var transactionTypeCommodity2 = TestTransactionTypeCommodity.GetRecord(transactionTypeCommodity1.TransactionType);
            var transactionTypeCommodity3 = TestTransactionTypeCommodity.GetRecord(transactionTypeCommodity1.TransactionType);
            var transactionTypeCommodity4 = TestTransactionTypeCommodity.GetRecord(TransactionType.Allocation);
            var transactionTypeCommodity5 = TestTransactionTypeCommodity.GetRecord(transactionTypeCommodity4.TransactionType);
            TestLeadAgencyTransactionTypeCommodity.Create(leadAgency, transactionTypeCommodity1);
            TestLeadAgencyTransactionTypeCommodity.Create(leadAgency, transactionTypeCommodity2);
            TestLeadAgencyTransactionTypeCommodity.Create(leadAgency, transactionTypeCommodity3);
            TestLeadAgencyTransactionTypeCommodity.Create(leadAgency, transactionTypeCommodity4);
            TestLeadAgencyTransactionTypeCommodity.Create(leadAgency, transactionTypeCommodity5);
            return leadAgency;
        }
    }
}