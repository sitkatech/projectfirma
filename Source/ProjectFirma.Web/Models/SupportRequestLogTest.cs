using System.Linq;
using ProjectFirma.Web.Common;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class SupportRequestLogTest
    {       
        [Test]
        public void ShouldHaveAtLeastOneSupportEmail()
        {
            var supportPersonIDs = HttpRequestStorage.DatabaseEntities.People.Where(x => x.ReceiveSupportEmails).Select(x => x.PersonID).ToList();
            Assert.That(supportPersonIDs.Count, Is.GreaterThanOrEqualTo(1), "No support persons set!");
        }
    }
}