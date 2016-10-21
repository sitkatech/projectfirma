using System.Collections.Generic;
using System.Linq;
using ApprovalTests;
using ApprovalTests.Reporters;
using ProjectFirma.Web.Common;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class NotificationTest
    {
        [Ignore]
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateProjectUpdateReminderMessageTest()
        {
            const string primaryContactPersonEmail = "ekingsland@lands.nv.gov";
            var person = HttpRequestStorage.DatabaseEntities.People.Single(x => x.Email == primaryContactPersonEmail);
            var mailMessage = ReminderMessageType.KickoffReminder.GenerateReminderForPerson(person);
            Assert.That(mailMessage.To.Select(x => x.Address), Is.EquivalentTo(new List<string> {primaryContactPersonEmail}));
            Approvals.Verify(mailMessage.Body);
        }
    }
}