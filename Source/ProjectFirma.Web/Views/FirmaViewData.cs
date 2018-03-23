/*-----------------------------------------------------------------------
<copyright file="FirmaViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views
{
    public abstract class FirmaViewData
    {
        public List<LtInfoMenuItem> TopLevelLtInfoMenuItems;

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
        public readonly ViewPageContentViewData ViewPageContentViewData;

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

            FullProjectListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Index());
            ProjectSearchUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Search(UrlTemplate.Parameter1String));
            ProjectFindUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Find(string.Empty));

            ViewPageContentViewData = firmaPage != null ? new ViewPageContentViewData(firmaPage, new FirmaPageManageFeature().HasPermission(currentPerson, firmaPage).HasPermission) : null;
        }

        public LtInfoMenuItem HelpMenu { get; set; }


        private void MakeFirmaMenu(Person currentPerson)
        {
            var homeMenuItem = LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.Index()), currentPerson, "Home");

            TopLevelLtInfoMenuItems = new List<LtInfoMenuItem>();
            TopLevelLtInfoMenuItems.Add(homeMenuItem);
            TopLevelLtInfoMenuItems.Add(BuildAboutMenu(currentPerson));
            TopLevelLtInfoMenuItems.Add(BuildProjectsMenu(currentPerson));
            TopLevelLtInfoMenuItems.Add(BuildProgramInfoMenu(currentPerson));
            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                TopLevelLtInfoMenuItems.Add(BuildResultsMenu(currentPerson));
            }
            TopLevelLtInfoMenuItems.Add(BuildManageMenu(currentPerson));

            TopLevelLtInfoMenuItems.ForEach(x => x.ExtraTopLevelMenuCssClasses = new List<string> { "navigation-root-item" });
            TopLevelLtInfoMenuItems.SelectMany(x => x.ChildMenus).ToList().ForEach(x => x.ExtraTopLevelMenuCssClasses = new List<string> { "navigation-dropdown-item" });

            HelpMenu = new LtInfoMenuItem("Help");
            HelpMenu.AddMenuItem(LtInfoMenuItem.MakeItem("Request Support", ModalDialogFormHelper.ModalDialogFormLink("Request Support", RequestSupportUrl, "Request Support", 800, "Submit Request", "Cancel", new List<string>(), null, null).ToString()));
            HelpMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c=>c.Training()), currentPerson, "Training"));
            HelpMenu.AddMenuItem(new LtInfoMenuItem(@"http://www.sitkatech.com/products/ProjectFirma/projectfirma-faqs/", "About ProjectFirma", true, false, null));
        }

        private static LtInfoMenuItem BuildAboutMenu(Person currentPerson)
        {
            var aboutMenu = new LtInfoMenuItem("About");

            MultiTenantHelpers.GetCustomPages().ForEach(x =>
            {
                var isVisible = x.CustomPageDisplayType == CustomPageDisplayType.Public ||
                                (!currentPerson.IsAnonymousUser &&
                                 x.CustomPageDisplayType == CustomPageDisplayType.Protected);
                if (isVisible)
                {
                    aboutMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<CustomPageController>(c => c.About(x.CustomPageVanityUrl)), currentPerson, x.CustomPageDisplayName, "Group1"));
                }
                
            });
            return aboutMenu;
        }

        private static LtInfoMenuItem BuildResultsMenu(Person currentPerson)
        {
            var resultsMenu = new LtInfoMenuItem("Results");

            resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.AccomplishmentsDashboard()), currentPerson, "Accomplishments Dashboard"));
            //resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.ResultsByTaxonomyTierTwo(null)), currentPerson,
            //    $"Results by {Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabel()}"));
            //resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.ProjectMap()), currentPerson, $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Map"));

            //resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<SnapshotController>(c => c.Index()), currentPerson, "System Snapshot", "Group2"));
            return resultsMenu;
        }

        private static LtInfoMenuItem BuildProgramInfoMenu(Person currentPerson)
        {
            var programInfoMenu = new LtInfoMenuItem("Program Info");
            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProgramInfoController>(c => c.Taxonomy()), currentPerson, MultiTenantHelpers.GetTaxonomySystemName(), "Group1"));

            MultiTenantHelpers.GetClassificationSystems().ForEach(x =>
            {
                programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProgramInfoController>(c => c.ClassificationSystem(x.ClassificationSystemID)), currentPerson, x.ClassificationSystemNamePluralized, "Group1"));
            });            
            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<PerformanceMeasureController>(c => c.Index()), currentPerson, MultiTenantHelpers.GetPerformanceMeasureNamePluralized(), "Group1"));          

            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<WatershedController>(c => c.Index()), currentPerson, $"{Models.FieldDefinition.Watershed.GetFieldDefinitionLabelPluralized()}", "Group2"));
            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectStewardOrganizationController>(c => c.Index()), currentPerson, $"{Models.FieldDefinition.ProjectStewardOrganizationDisplayName.GetFieldDefinitionLabelPluralized()}", "Group3"));
            }
            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<OrganizationController>(c => c.Index()), currentPerson, $"{Models.FieldDefinition.Organization.GetFieldDefinitionLabelPluralized()}", "Group3"));
            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FundingSourceController>(c => c.Index()), currentPerson, $"{Models.FieldDefinition.FundingSource.GetFieldDefinitionLabelPluralized()}", "Group3"));

            return programInfoMenu;
        }


        private static LtInfoMenuItem BuildManageMenu(Person currentPerson)
        {
            var manageMenu = new LtInfoMenuItem("Manage");

            // Group 1 - Project Classifications Stuff (taxonomies, classification systems, PMs)
            if (MultiTenantHelpers.GetNumberOfTaxonomyTiers() == 3)
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TaxonomyTierThreeController>(c => c.Manage()), currentPerson, Models.FieldDefinition.TaxonomyTierThree.GetFieldDefinitionLabelPluralized(), "Group1"));
            }

            if (MultiTenantHelpers.GetNumberOfTaxonomyTiers() >= 2)
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TaxonomyTierTwoController>(c => c.Manage()), currentPerson, Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabelPluralized(), "Group1"));
            }
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TaxonomyLeafController>(c => c.Manage()), currentPerson, Models.FieldDefinition.TaxonomyLeaf.GetFieldDefinitionLabelPluralized(), "Group1"));
            MultiTenantHelpers.GetClassificationSystems().ForEach(x =>
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ClassificationController>(c => c.Index(x.ClassificationSystemID)), currentPerson, x.ClassificationSystemNamePluralized, "Group1"));
            });
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<PerformanceMeasureController>(c => c.Manage()), currentPerson, MultiTenantHelpers.GetPerformanceMeasureNamePluralized(), "Group1"));

            // Group 2 - System Config stuff
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<UserController>(c => c.Index()), currentPerson, "Users", "Group2"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.FeaturedList()), currentPerson, $"Featured {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}", "Group2"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TagController>(c => c.Index()), currentPerson, $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Tags", "Group2"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectUpdateController>(c => c.Manage()), currentPerson, $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Updates", "Group2"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.ManageHomePageImages()), currentPerson, "Homepage Configuration", "Group2"));

            // Group 3 - Content Editing stuff
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FirmaPageController>(c => c.Index()), currentPerson, "Custom Page Content", "Group3"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FieldDefinitionController>(c => c.Index()), currentPerson, "Custom Labels & Definitions", "Group3"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<CustomPageController>(c => c.Index()), currentPerson, "Custom About Pages", "Group3"));

            // Group 4 - Other
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.InternalSetupNotes()), currentPerson, "Internal Setup Notes", "Group4"));

            // Group 5 - Project Firma Configuation stuff
            if (HttpRequestStorage.Tenant == Models.Tenant.SitkaTechnologyGroup)
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.DemoScript()), currentPerson, "Demo Script", "Group5")); // TODO: poor man's hack until we do tenant specific menu and features
            }

            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<CostParameterSetController>(c => c.Detail()), currentPerson, "Cost Parameters", "Group5"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<OrganizationAndRelationshipTypeController>(c => c.Index()), currentPerson, Models.FieldDefinition.OrganizationType.GetFieldDefinitionLabelPluralized(), "Group5"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TenantController>(c => c.Detail()), currentPerson, "Tenant Configuration", "Group5"));
           
            return manageMenu;
        }


        private static LtInfoMenuItem BuildProjectsMenu(Person currentPerson)
        {
            var projectsMenu = new LtInfoMenuItem($"{Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}");
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.ProjectMap()), currentPerson, $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Map", "Group1"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.Index()), currentPerson, $"Full {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} List", "Group2"));            
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.MyOrganizationsProjects()), currentPerson, $"My {Models.FieldDefinition.Organization.GetFieldDefinitionLabel()}'s {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}", "Group2"));
            //projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectUpdateController>(c => c.MyProjectsRequiringAnUpdate()), currentPerson, "Update My Project(s)", "Group3"));
            //var projectUpdateStatusMenuItemName = string.Format("{0} Status of Project Updates", FirmaDateUtilities.CalculateCurrentYearToUseForReporting());
            //projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectUpdateController>(c => c.ProjectUpdateStatus()), currentPerson, projectUpdateStatusMenuItemName, "Group3"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.Proposed()), currentPerson, $"{Models.FieldDefinition.Proposal.GetFieldDefinitionLabelPluralized()}", "Group3"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.Pending()), currentPerson, "Pending Projects", "Group3"));
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
                return $" | {BreadCrumbTitle}";
            }
            else if (!string.IsNullOrWhiteSpace(PageTitle))
            {
                return $" | {PageTitle}";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
