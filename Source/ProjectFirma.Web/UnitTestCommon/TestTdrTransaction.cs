using System;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestTdrTransaction
    {
        public static TdrTransaction Create()
        {
            var leadAgencyTransactionTypeCommodity = TestLeadAgencyTransactionTypeCommodity.Create();
            var person = TestFramework.TestPerson.Create(ParcelTrackerRole.Admin);
            var tdrTransaction = TdrTransaction.CreateTdrTransaction(leadAgencyTransactionTypeCommodity, person);
            tdrTransaction.ProjectNumber = TestFramework.MakeTestName("ProjectNumber");
            return tdrTransaction;
        }

        public static TdrTransaction Create(LeadAgencyTransactionTypeCommodity leadAgencyTransactionTypeCommodity, Person person)
        {
            var tdrTransaction = TdrTransaction.CreateTdrTransaction(leadAgencyTransactionTypeCommodity, person);
            tdrTransaction.ProjectNumber = TestFramework.MakeTestName("ProjectNumber", 30);
            tdrTransaction.Comments = string.Format("Pushed to Accela on via unit test on {0}", DateTime.Now);
            return tdrTransaction;
        }
    }
}