using System.Linq;
using ProjectFirma.Web.Common;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public abstract class FirmaTestWithContext
    {
        [SetUp]
        public void TheSetUp()
        {
            HttpRequestStorage.StartContextForTest();
            HttpRequestStorage.Person = HttpRequestStorage.DatabaseEntities.People.First();
        }

        [TearDown]
        public void TheTearDown()
        {
            HttpRequestStorage.EndContextForTest();
        }
    }
}