using System.Linq;
using ProjectFirma.Web.Common;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class SupportRequestLogTest
    {       
        [Test]
        public void AllAreasHaveAtLeastOneSupportEmail()
        {
            foreach (var ltInfoArea in LTInfoArea.SortedAll)
            {
                var supportPersonIDs = HttpRequestStorage.DatabaseEntities.PersonAreas.Where(x => x.LTInfoAreaID == ltInfoArea.LTInfoAreaID && x.ReceiveSupportEmails).Select(x => x.PersonID).ToList();
                Assert.That(supportPersonIDs.Count, Is.GreaterThanOrEqualTo(1), string.Format("{0} does not have any support persons set!", ltInfoArea.LTInfoAreaDisplayName));
            }
        }
    }
}