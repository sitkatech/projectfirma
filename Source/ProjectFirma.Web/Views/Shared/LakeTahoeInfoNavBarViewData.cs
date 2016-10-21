using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using HomeController = ProjectFirma.Web.Controllers.HomeController;

namespace ProjectFirma.Web.Views.Shared
{
    public class LakeTahoeInfoNavBarViewData
    {
        public List<LtInfoMenuItem> TopLevelLtInfoMenuItems;

        public readonly Person CurrentPerson;
        public readonly bool IsLogInPage;
        public readonly bool IsHomePage;
        public readonly string RequestSupportUrl;
        public readonly string LogInUrl;
        public readonly string LogOutUrl;


        public LakeTahoeInfoNavBarViewData(Person currentPerson, bool isLogInPage, bool isHomePage, string logInUrl, string logOutUrl, string requestSupportUrl)
        {
            CurrentPerson = currentPerson;
            IsLogInPage = isLogInPage;
            IsHomePage = isHomePage;

            LogInUrl = logInUrl;
            LogOutUrl = logOutUrl;
            RequestSupportUrl = requestSupportUrl;

            TopLevelLtInfoMenuItems = MakeFullLakeTahoeInfoMenu(currentPerson);
        }

        private List<LtInfoMenuItem> MakeFullLakeTahoeInfoMenu(Person currentPerson)
        {
            // About Menu
            // ----------
            var aboutMenuItem = LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.About()), currentPerson, "About");

            // Manage Menu
            // -----------
            var manageMenu = new LtInfoMenuItem("Manage");
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<IndicatorController>(c => c.Manage()), currentPerson, "Indicators", "Group1"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<LocalAndRegionalPlanController>(c => c.Manage()), currentPerson, "Local and Regional Plans", "Group1"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<WatershedController>(c => c.Manage()), currentPerson, "Watersheds", "Group1"));

            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectFirmaPageController>(c => c.Index()), currentPerson, "Page Content", "Group2"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FieldDefinitionController>(c => c.Index()), currentPerson, "Field Definitions", "Group2"));

            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<OrganizationController>(c => c.Manage()), currentPerson, "Organizations", "Group3"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<UserController>(c => c.Index()), currentPerson, "Users", "Group3"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<RoleController>(c => c.Index()), currentPerson, "Roles", "Group3"));

            if (manageMenu.ChildMenus.Any(x => x.ShouldShow))
            {
                manageMenu.AddMenuItem(new LtInfoMenuItem(LogOutUrl, "Log Out", HttpContext.Current.Request.IsAuthenticated, false, "Group4"));
            }
            else
            {
                manageMenu = new LtInfoMenuItem(LogOutUrl, "Log Out", HttpContext.Current.Request.IsAuthenticated, true, "Group1");
            }

            // Log in Button
            var logInMenuItem = new LtInfoMenuItem(LogInUrl, "Log In", !IsLogInPage && !HttpContext.Current.Request.IsAuthenticated, true, "Group1");
            
            var topLevelLtInfoMenuItems = new List<LtInfoMenuItem> { aboutMenuItem, manageMenu, logInMenuItem };

            topLevelLtInfoMenuItems.ForEach(x => x.ExtraTopLevelMenuCssClasses = new List<string> {"btn", "btn-outline"});
            topLevelLtInfoMenuItems.SelectMany(x => x.ChildMenus).ToList().ForEach(x => x.ExtraTopLevelMenuCssClasses = new List<string> { "btn", "btn-outline", "btn-dropdown" });

            return topLevelLtInfoMenuItems;
        }
    }
}