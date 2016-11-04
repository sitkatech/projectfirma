using System.Web.Mvc;
using NUnit.Framework;
using LtInfo.Common.Web.Testing.Path1.Path2;

namespace LtInfo.Common.HtmlHelperExtensions
{
    [TestFixture]
    public class SitkaHtmlHelpersTest
    {
        [Test]
        public void CalculateViewName()
        {
            var viewType = typeof(UnitTestUserControl1);
            var viewPath = SitkaHtmlHelpers.CalculateWebPathFromViewType<UnitTestUserControl1>();
            Assert.That(viewPath, Is.EqualTo(string.Format("~/Testing/Path1/Path2/{0}.ascx", viewType.Name)));
        }
    }
}

namespace LtInfo.Common.Web.Testing.Path1.Path2
{
    public class UnitTestUserControl1 : ViewUserControl { }
}
