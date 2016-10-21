using System.Linq;
using LtInfo.Common;
using NUnit.Framework;
using ProjectFirma.Web.UnitTestCommon;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class LeadAgencyTest
    {
        [Test]
        public void ToJsonTest()
        {
            var leadAgency = TestLeadAgency.Create();
            var leadAgencyTransactionTypeJson = leadAgency.ToJson();
            var jsonString = leadAgencyTransactionTypeJson.ToJsonString();
            var expectedJson = JsonTools.DeserializeObject<LeadAgencyJson>(jsonString);
            Assert.That(expectedJson.LeadAgencyID, Is.EqualTo(leadAgency.LeadAgencyID));
            Assert.That(expectedJson.LeadAgencyName, Is.EqualTo(leadAgency.LeadAgencyName));
            Assert.That(expectedJson.TransactionTypes.Select(c => c.TransactionTypeID), Is.EquivalentTo(leadAgency.LeadAgencyTransactionTypeCommodities.Select(ttc => ttc.TransactionTypeCommodity.TransactionTypeID).Distinct()));
        }
    }
}