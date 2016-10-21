using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Areas.Threshold.Controllers;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.Threshold.Views.Shared
{
    public class ThresholdNavBarViewData
    {
        public List<LtInfoMenuItem> TopLevelLtInfoMenuItems;

        public readonly Person CurrentPerson;
        public readonly bool IsLogInPage;
        public readonly bool IsHomePage;
        public readonly string RequestSupportUrl;
        public readonly string LogInUrl;
        public readonly string LogOutUrl;


        public ThresholdNavBarViewData(Person currentPerson, bool isLogInPage, bool isHomePage, string logInUrl, string logOutUrl, string requestSupportUrl)
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
            // Log in Button
            var logInMenuItem = new LtInfoMenuItem(LogInUrl, "Log In", !IsLogInPage && !HttpContext.Current.Request.IsAuthenticated, true, "Group1");

            // Manage Menu
            // -----------
            var manageMenu = new LtInfoMenuItem("Manage");
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ThresholdCategoryController>(c => c.Index()), currentPerson, "Threshold Categories", "Group1"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<MonitoringProgramController>(c => c.Index()), currentPerson, "Monitoring Programs", "Group1"));

            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectFirmaPageController>(c => c.Index()), currentPerson, "Page Content", "Group2"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FieldDefinitionController>(c => c.Index()), currentPerson, "Field Definitions", "Group2"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<UserController>(c => c.Index()), currentPerson, "Users", "Group2"));
            
            if (manageMenu.ChildMenus.Any(x => x.ShouldShow))
            {
                manageMenu.AddMenuItem(new LtInfoMenuItem(LogOutUrl, "Log Out", HttpContext.Current.Request.IsAuthenticated, false, "Group3"));
            }
            else
            {
                manageMenu = new LtInfoMenuItem(LogOutUrl, "Log Out", HttpContext.Current.Request.IsAuthenticated, true, "Group3");
            }

            // Explore Menu
            // -----------
            var exploreMenu = new LtInfoMenuItem("Explore");
            exploreMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ThresholdCategoryController>(c => c.Index()), currentPerson, "Evaluation Overview", "Group1"));

            foreach (var category in HttpRequestStorage.DatabaseEntities.ThresholdCategories.ToList())
            {
                var thresholdCategoryName = category.ThresholdCategoryName;
                var sitkaRoute = new SitkaRoute<ThresholdCategoryController>(c => c.Summary(thresholdCategoryName));
                exploreMenu.AddMenuItem(LtInfoMenuItem.MakeItem(sitkaRoute, currentPerson, category.DisplayName, "Group2"));
            }
            
            // Build List of Menu Items
            var topLevelLtInfoMenuItems = new List<LtInfoMenuItem> {exploreMenu, manageMenu, logInMenuItem };

            topLevelLtInfoMenuItems.ForEach(x => x.ExtraTopLevelMenuCssClasses = new List<string> {"btn", "btn-outline"});
            topLevelLtInfoMenuItems.SelectMany(x => x.ChildMenus).ToList().ForEach(x => x.ExtraTopLevelMenuCssClasses = new List<string> { "btn", "btn-outline", "btn-dropdown" });

            return topLevelLtInfoMenuItems;
        }
    }
}