using System.Collections.Generic;
using System.Linq;
using ApprovalTests;
using ApprovalTests.Reporters;
using LtInfo.Common.DesignByContract;
using NUnit.Framework;

namespace ProjectFirma.Web.Views
{
    [TestFixture]
    public class LtInfoMenuItemTest
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CanRenderBlankMenuTest()
        {
            var menuItem1 = new LtInfoMenuItem("menu1");
            var result = menuItem1.RenderMenu().ToString();
            Assert.That(result, Is.EqualTo(string.Empty), "No visible menu items, should return empty");
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CanRenderSimpleMenuTest()
        {
            var menuItem1 = new LtInfoMenuItem("url1", "menu1", true, false, null);
            var result = menuItem1.RenderMenu();
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void TopLevelMenuItemWithNoChildrenShouldNotRenderTest()
        {
            var menuItem1 = new LtInfoMenuItem("menu1");
            var result = menuItem1.RenderMenu().ToString();
            Assert.That(result, Is.EqualTo(string.Empty), "Is top level menu and has no children and has no url, should return empty");
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void TopLevelMenuItemThatIsALinkCannotAddChildrenTest()
        {
            var menuItem1 = new LtInfoMenuItem("url1", "menu1", true, true, null);
            Assert.Throws<PreconditionException>(() => menuItem1.AddMenuItem(new LtInfoMenuItem("Some menu item")));
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void TopLevelMenuItemThatIsNotALinkCanAddChildrenTest()
        {
            var menuItem1 = new LtInfoMenuItem("menu1");
            Assert.DoesNotThrow(() => menuItem1.AddMenuItem(new LtInfoMenuItem("Some menu item")));
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CanRenderNestedMenuTest()
        {
            var menuItem1 = new LtInfoMenuItem("menu1");
            var menuItem2 = new LtInfoMenuItem("url2", "menu2", true, false, null);
            menuItem1.AddMenuItem(menuItem2);
            var menuItem3 = new LtInfoMenuItem("url3", "menu3", true, false, null);
            menuItem1.AddMenuItem(menuItem3);
            var menuItem4 = new LtInfoMenuItem("url4", "menu4", true, false, null);
            menuItem1.AddMenuItem(menuItem4);
            var menuItem5 = new LtInfoMenuItem(null, "menu5", true, false, null);
            menuItem1.AddMenuItem(menuItem5);
            var menuItem6 = new LtInfoMenuItem("url6", "menu6", true, false, null);
            menuItem5.AddMenuItem(menuItem6);

            var result = menuItem1.RenderMenu();
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CanRenderMultipleNestedMenuTest()
        {
            var menuItem1 = new LtInfoMenuItem("menu1");
            var menuItem2 = new LtInfoMenuItem("url2", "menu2", true, false, null);
            menuItem1.AddMenuItem(menuItem2);
            var menuItem3 = new LtInfoMenuItem("url3", "menu3", true, false, null);
            menuItem1.AddMenuItem(menuItem3);
            var menuItem4 = new LtInfoMenuItem("url4", "menu4", true, false, null);
            menuItem1.AddMenuItem(menuItem4);
            var menuItem5 = new LtInfoMenuItem(null, "menu5", true, false, null);
            menuItem1.AddMenuItem(menuItem5);
            var menuItem6 = new LtInfoMenuItem("url6", "menu6", true, false, null);
            menuItem5.AddMenuItem(menuItem6);
            var menuItem7 = new LtInfoMenuItem("menu7");
            var menuItem8 = new LtInfoMenuItem("url8", "menu8", true, false, null);
            menuItem7.AddMenuItem(menuItem8);
            var menuItem9 = new LtInfoMenuItem("url9", "menu9", true, false, null);
            menuItem7.AddMenuItem(menuItem9);
            var menuItem10 = new LtInfoMenuItem("menu10");
            var menuItem11 = new LtInfoMenuItem("url11", "menu11", true, false, null);
            menuItem10.AddMenuItem(menuItem11);
            var menuItem12 = new LtInfoMenuItem("url12", "menu12", true, true, null);
            var menuItem13 = new LtInfoMenuItem("menu13");

            var topLevelMenus = new List<LtInfoMenuItem> {menuItem1, menuItem7, menuItem10, menuItem12, menuItem13};

            var result = string.Join("\r\n", topLevelMenus.Select(x => x.RenderMenu()));
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CanRenderMenuWithGroupsTest()
        {
            var menuItem1 = new LtInfoMenuItem("menu1");
            var menuItem2 = new LtInfoMenuItem("url2", "menu2", true, false, "1");
            menuItem1.AddMenuItem(menuItem2);
            var menuItem3 = new LtInfoMenuItem("url3", "menu3", true, false, "1");
            menuItem1.AddMenuItem(menuItem3);
            var menuItem4 = new LtInfoMenuItem("url4", "menu4", true, false, "2");
            menuItem1.AddMenuItem(menuItem4);
            var menuItem5 = new LtInfoMenuItem(null, "menu5", true, false, "2");
            menuItem1.AddMenuItem(menuItem5);
            var menuItem6 = new LtInfoMenuItem("url6", "menu6", true, false, null);
            menuItem5.AddMenuItem(menuItem6);
            var menuItem7 = new LtInfoMenuItem("menu7");
            var menuItem8 = new LtInfoMenuItem("url8", "menu8", true, false, "3");
            menuItem7.AddMenuItem(menuItem8);
            var menuItem9 = new LtInfoMenuItem("url9", "menu9", true, false, null);
            menuItem7.AddMenuItem(menuItem9);
            var menuItem10 = new LtInfoMenuItem("menu10");
            var menuItem11 = new LtInfoMenuItem("url11", "menu11", true, false, null);
            menuItem10.AddMenuItem(menuItem11);
            var menuItem12 = new LtInfoMenuItem("url12", "menu12", true, true, null);
            var menuItem13 = new LtInfoMenuItem("menu13");

            var topLevelMenus = new List<LtInfoMenuItem> {menuItem1, menuItem7, menuItem10, menuItem12, menuItem13};

            var result = string.Join("\r\n", topLevelMenus.Select(x => x.RenderMenu()));
            Approvals.Verify(result);
        }
    }
}