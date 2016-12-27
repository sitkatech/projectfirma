using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views
{
    public abstract class FirmaViewData
    {
        public List<LtInfoMenuItem> TopLevelLtInfoMenuItems;
        
        public readonly string ManageTaxonomyTierThreesUrl;
        public readonly string ManageTaxonomyTierTwosUrl;
        public readonly string ManageTaxonomyTierOnesUrl;
        public readonly string ManagePerformanceMeasuresUrl;

        public readonly string FullProjectListUrl;
        public readonly string ProjectSearchUrl;
        public readonly string ProjectFindUrl;
        public string PageTitle;
        public string HtmlPageTitle;
        public string BreadCrumbTitle;
        public string EntityName;
        public readonly Models.FirmaPage FirmaPage;
        public readonly Person CurrentPerson;
        public readonly string FirmaHomeUrl;
        public readonly string LogInUrl;
        public readonly string LogOutUrl;
        public readonly string RequestSupportUrl;

        /// <summary>
        /// Call for page without associated FirmaPage
        /// </summary>
        protected FirmaViewData(Person currentPerson) : this(currentPerson, null)
        {
        }
     
        /// <summary>
        /// Call for page with associated FirmaPage
        /// </summary>
        protected FirmaViewData(Person currentPerson, Models.FirmaPage firmaPage)
        {
            FirmaPage = firmaPage;

            CurrentPerson = currentPerson;
            FirmaHomeUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(c => c.Index());

            LogInUrl = FirmaHelpers.GenerateLogInUrlWithReturnUrl();
            LogOutUrl = FirmaHelpers.GenerateLogOutUrlWithReturnUrl();

            RequestSupportUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(c => c.Support());

            MakeFirmaMenu(currentPerson);
            
            ManageTaxonomyTierThreesUrl = SitkaRoute<TaxonomyTierThreeController>.BuildUrlFromExpression(c => c.Index());
            ManageTaxonomyTierTwosUrl = SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(c => c.Index());
            ManageTaxonomyTierOnesUrl = SitkaRoute<TaxonomyTierOneController>.BuildUrlFromExpression(c => c.Index());
            ManagePerformanceMeasuresUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.Index());

            FullProjectListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Index());
            ProjectSearchUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Search(UrlTemplate.Parameter1String));
            ProjectFindUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Find(string.Empty));
        }

        private void MakeFirmaMenu(Person currentPerson)
        {
            var homeMenuItem = LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.Index()), currentPerson, "Home");

            TopLevelLtInfoMenuItems = new List<LtInfoMenuItem>
            {
                homeMenuItem,
                BuildAboutMenu(currentPerson),
                //BuildProjectsMenu(currentPerson),
                BuildTaxonomyTierTwoInfoMenu(currentPerson),
                //BuildResultsMenu(currentPerson),
                BuildManageMenu(currentPerson)
            };

            TopLevelLtInfoMenuItems.ForEach(x => x.ExtraTopLevelMenuCssClasses = new List<string> { "navigation-root-item" });
            TopLevelLtInfoMenuItems.SelectMany(x => x.ChildMenus).ToList().ForEach(x => x.ExtraTopLevelMenuCssClasses = new List<string> { "navigation-dropdown-item" });
        }

        private static LtInfoMenuItem BuildAboutMenu(Person currentPerson)
        {
            var aboutMenu = new LtInfoMenuItem("About");
            aboutMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<AboutController>(c => c.AboutClackamasPartnership()), currentPerson, "About the Partnership"));
            aboutMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<AboutController>(c => c.Meetings()), currentPerson, "Meetings and Documents"));
            return aboutMenu;
        }

        private static LtInfoMenuItem BuildResultsMenu(Person currentPerson)
        {
            var resultsMenu = new LtInfoMenuItem("Results");
            resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.InvestmentByFundingSector(null)), currentPerson, "Investment by Funding Sector"));
            resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwo(null)),
                currentPerson,
                string.Format("Spending by Funding Sector by {0} by {1}", MultiTenantHelpers.GetTaxonomyTierThreeDisplayName(), MultiTenantHelpers.GetTaxonomyTierTwoDisplayName())));
            resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.ResultsByTaxonomyTierTwo(null)), currentPerson, string.Format("Results by {0}", MultiTenantHelpers.GetTaxonomyTierTwoDisplayName())));
            resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.ProjectMap()), currentPerson, "Project Map"));

            resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<SnapshotController>(c => c.Index()), currentPerson, "System Snapshot", "Group2"));
            return resultsMenu;
        }

        private static LtInfoMenuItem BuildTaxonomyTierTwoInfoMenu(Person currentPerson)
        {
            var taxonomyTierTwoInfoMenu = new LtInfoMenuItem("Program Info");
            //taxonomyTierTwoInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<PerformanceMeasureController>(c => c.Index()), currentPerson, "Performance Measures", "Group1"));
            //taxonomyTierTwoInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProgramInfoController>(c => c.Taxonomy()), currentPerson, "Taxonomy", "Group1"));

            //taxonomyTierTwoInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ThresholdCategoryController>(c => c.Index()), currentPerson, "Threshold Categories", "Group3"));

            //taxonomyTierTwoInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<AssessmentController>(c => c.Manage()), currentPerson, " Assessment", "Group1"));
            //taxonomyTierTwoInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<CostParameterSetController>(c => c.Manage()), currentPerson, "Cost Parameters", "Group2"));

            //taxonomyTierTwoInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<WatershedController>(c => c.Index()), currentPerson, "Watersheds", "Group4"));

            taxonomyTierTwoInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<OrganizationController>(c => c.Index()), currentPerson, "Organizations", "Group1"));
            taxonomyTierTwoInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FundingSourceController>(c => c.Index()), currentPerson, "Funding Sources", "Group1"));
            return taxonomyTierTwoInfoMenu;
        }

        private LtInfoMenuItem BuildManageMenu(Person currentPerson)
        {
            var manageMenu = new LtInfoMenuItem("Manage");
            //manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<PerformanceMeasureController>(c => c.Manage()), currentPerson, "Performance Measures", "Group1"));
            //manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.SpendingByPerformanceMeasureByProject(null)), currentPerson, "Spending by Performance Measures", "Group1"));

            //manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TaxonomyTierThreeController>(c => c.Manage()), currentPerson, MultiTenantHelpers.GetTaxonomyTierThreeDisplayNamePluralized(), "Group2"));
            //manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TaxonomyTierTwoController>(c => c.Manage()), currentPerson, MultiTenantHelpers.GetTaxonomyTierTwoDisplayNamePluralized(), "Group2"));
            //manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TaxonomyTierOneController>(c => c.Manage()), currentPerson, MultiTenantHelpers.GetTaxonomyTierOneDisplayNamePluralized(), "Group2"));

            //manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.FeaturedList()), currentPerson, "Featured Projects", "Group6"));
            //manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TagController>(c => c.Index()), currentPerson, "Project Tags", "Group6"));
            //manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectUpdateController>(c => c.Manage()), currentPerson, "Manage Project Updates", "Group6"));

            //manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FirmaPageController>(c => c.Index()), currentPerson, "Page Content", "Group7"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FieldDefinitionController>(c => c.Index()), currentPerson, "Field Definitions", "Group7"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<UserController>(c => c.Index()), currentPerson, "Users", "Group1"));

            return manageMenu;
        }


        private static LtInfoMenuItem BuildProjectsMenu(Person currentPerson)
        {
            var projectsMenu = new LtInfoMenuItem("Projects");
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.ProjectMap()), currentPerson, "Project Map", "Group1"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.Index()), currentPerson, "Full Project List", "Group2"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.CompletedList()), currentPerson, "Completed Project List", "Group2"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.FiveYearList()), currentPerson, "5-Year Project List", "Group2"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.TerminatedList()), currentPerson, "Terminated Project List", "Group2"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.MyOrganizationsProjects()), currentPerson, "My Organization's Projects", "Group2"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectUpdateController>(c => c.MyProjectsRequiringAnUpdate()), currentPerson, "Update My Project(s)", "Group3"));
            var projectUpdateStatusMenuItemName = string.Format("{0} Status of Project Updates", FirmaDateUtilities.CalculateCurrentYearToUseForReporting());
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectUpdateController>(c => c.ProjectUpdateStatus()), currentPerson, projectUpdateStatusMenuItemName, "Group3"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProposedProjectController>(c => c.Index()), currentPerson, "Proposed Projects", "Group3"));
            return projectsMenu;
        }

        public string IsActiveUrl(string currentUrlPathAndQuery, string urlToCompare)
        {
            return currentUrlPathAndQuery == urlToCompare ? " class=\"active\"" : string.Empty;
        }

        public string GetBreadCrumbTitle()
        {
            if (!string.IsNullOrWhiteSpace(BreadCrumbTitle))
            {
                return string.Format(" | {0}", BreadCrumbTitle);
            }
            else if (!string.IsNullOrWhiteSpace(PageTitle))
            {
                return string.Format(" | {0}", PageTitle);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}