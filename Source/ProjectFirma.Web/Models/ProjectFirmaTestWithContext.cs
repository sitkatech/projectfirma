using ProjectFirma.Web.Common;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public abstract class ProjectFirmaTestWithContext
    {
        [SetUp]
        public void TheSetUp()
        {
            HttpRequestStorage.StartContextForTest();
        }

        [TearDown]
        public void TheTearDown()
        {
            HttpRequestStorage.EndContextForTest();
        }
    }
}