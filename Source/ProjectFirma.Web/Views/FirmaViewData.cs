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
using LtInfo.Common;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views
{
    public abstract class FirmaViewData
    {
        public List<LtInfoMenuItem> TopLevelLtInfoMenuItems { get; set; }
        public string FullProjectListUrl { get; }
        public string ProjectSearchUrl { get; }
        public string ProjectFindUrl { get; }
        public string PageTitle { get; set; }
        public string HtmlPageTitle { get; set; }
        public string BreadCrumbTitle { get; set; }
        public string EntityName { get; set; }
        public ProjectFirmaModels.Models.FirmaPage FirmaPage { get; }
        public Person CurrentPerson { get; }
        public string FirmaHomeUrl { get; }
        public string LogInUrl { get; }
        public string LogOutUrl { get; }
        public string RequestSupportUrl { get; }
        public ViewPageContentViewData ViewPageContentViewData { get; }
        public LtInfoMenuItem HelpMenu { get; private set; }
        public ViewPageContentViewData CustomFooterViewData { get; }
        public string TenantName { get; private set; }
        public string TenantShortDisplayName { get; private set; }
        public string TenantToolDisplayName { get; }
        public string TenantBannerLogoUrl { get; private set; }

        /// <summary>
        /// Call for page without associated FirmaPage
        /// </summary>
        protected FirmaViewData(Person currentPerson) : this(currentPerson, null)
        {
        }
     
        /// <summary>
        /// Call for page with associated FirmaPage
        /// </summary>
        protected FirmaViewData(Person currentPerson, ProjectFirmaModels.Models.FirmaPage firmaPage)
        {
            FirmaPage = firmaPage;

            CurrentPerson = currentPerson;
            FirmaHomeUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(c => c.Index());

            LogInUrl = FirmaHelpers.GenerateLogInUrl();
            LogOutUrl = FirmaHelpers.GenerateLogOutUrlWithReturnUrl();

            RequestSupportUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(c => c.Support());

            MakeFirmaMenu(currentPerson);

            FullProjectListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Index());
            ProjectSearchUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Search(UrlTemplate.Parameter1String));
            ProjectFindUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Find(string.Empty));

            var currentPersonCanManage = new FirmaPageManageFeature().HasPermission(currentPerson, firmaPage).HasPermission;
            ViewPageContentViewData = firmaPage != null ? new ViewPageContentViewData(firmaPage, currentPersonCanManage) : null;
            CustomFooterViewData = new ViewPageContentViewData(FirmaPageTypeEnum.CustomFooter.GetFirmaPage(), currentPersonCanManage);
            TenantName = MultiTenantHelpers.GetTenantName();
            TenantShortDisplayName = MultiTenantHelpers.GetTenantShortDisplayName();
            TenantBannerLogoUrl = MultiTenantHelpers.GetTenantBannerLogoUrl();
            TenantToolDisplayName = MultiTenantHelpers.GetToolDisplayName();
        }


        private void MakeFirmaMenu(Person currentPerson)
        {
            TopLevelLtInfoMenuItems = new List<LtInfoMenuItem>
            {
                BuildAboutMenu(currentPerson),
                BuildProjectsMenu(currentPerson),
                BuildProgramInfoMenu(currentPerson)
            };
            if (MultiTenantHelpers.DisplayAccomplishmentDashboard() || MultiTenantHelpers.UsesCustomResultsPages(currentPerson))
            {
                TopLevelLtInfoMenuItems.Add(BuildResultsMenu(currentPerson));
            }
            TopLevelLtInfoMenuItems.Add(BuildManageMenu(currentPerson));

            TopLevelLtInfoMenuItems.ForEach(x => x.ExtraTopLevelMenuCssClasses = new List<string> { "navigation-root-item" });
            TopLevelLtInfoMenuItems.SelectMany(x => x.ChildMenus).ToList().ForEach(x => x.ExtraTopLevelMenuCssClasses = new List<string> { "navigation-dropdown-item" });

            HelpMenu = new LtInfoMenuItem("Help");
            HelpMenu.AddMenuItem(LtInfoMenuItem.MakeItem("Request Support",
                ModalDialogFormHelper.ModalDialogFormLink("Request Support", RequestSupportUrl, "Request Support", 800,
                    "Submit Request", "Cancel", new List<string>(), null, null).ToString(), "ToolHelp"));
            HelpMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c=>c.Training()), currentPerson, "Training", "ToolHelp"));
            HelpMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.ReleaseNotes()), currentPerson, "Release Notes", "ToolHelp"));
            HelpMenu.AddMenuItem(LtInfoMenuItem.MakeItem("About ProjectFirma",
                @"<a href='http://www.sitkatech.com/products/ProjectFirma/projectfirma-faqs/' target='_blank'>About ProjectFirma <span class='glyphicon glyphicon-new-window'></span></a>", "ExternalHelp"));
        }

        private static LtInfoMenuItem BuildAboutMenu(Person currentPerson)
        {
            var aboutMenu = new LtInfoMenuItem("About");

            MultiTenantHelpers.GetCustomPages().ForEach(x =>
            {
                var isVisible = x.CustomPageDisplayType == CustomPageDisplayType.Public ||
                                (!currentPerson.IsAnonymousUser() &&
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
            if (MultiTenantHelpers.DisplayAccomplishmentDashboard())
            {
                resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.AccomplishmentsDashboard()), currentPerson, "Accomplishments Dashboard"));
            }
            MultiTenantHelpers.AddTechnicalAssistanceReportMenuItem(resultsMenu, currentPerson);
            MultiTenantHelpers.AddFundingStatusMenuItem(resultsMenu, currentPerson);

            //resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.ProjectMap()), currentPerson, $"{Models.FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Map"));
            //resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<SnapshotController>(c => c.Index()), currentPerson, "System Snapshot", "Group2"));
            return resultsMenu;
        }

        private static LtInfoMenuItem BuildProgramInfoMenu(Person currentPerson)
        {
            var programInfoMenu = new LtInfoMenuItem("Program Info");
            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProgramInfoController>(c => c.Taxonomy()), currentPerson, MultiTenantHelpers.GetTaxonomySystemName(), "Group1"));

            MultiTenantHelpers.GetClassificationSystems().ForEach(x =>
            {
                programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProgramInfoController>(c => c.ClassificationSystem(x.ClassificationSystemID)), currentPerson, ClassificationSystemModelExtensions.GetClassificationSystemNamePluralized(x), "Group1"));
            });            
            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<PerformanceMeasureController>(c => c.Index()), currentPerson, MultiTenantHelpers.GetPerformanceMeasureNamePluralized(), "Group1"));
            
            foreach (var geospatialAreaType in HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.ToList())
            {
                programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<GeospatialAreaController>(c => c.Index(geospatialAreaType)), currentPerson, $"{geospatialAreaType.GeospatialAreaTypeNamePluralized}", "Group2"));
            }
            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectStewardOrganizationController>(c => c.Index()), currentPerson, $"{FieldDefinitionEnum.ProjectStewardOrganizationDisplayName.ToType().GetFieldDefinitionLabelPluralized()}", "Group3"));
            }
            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<OrganizationController>(c => c.Index()), currentPerson, $"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabelPluralized()}", "Group3"));
            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FundingSourceController>(c => c.Index()), currentPerson, $"{FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabelPluralized()}", "Group3"));

            return programInfoMenu;
        }


        private static LtInfoMenuItem BuildManageMenu(Person currentPerson)
        {
            var manageMenu = new LtInfoMenuItem("Manage");

            // Group 1 - Project Classifications Stuff (taxonomies, classification systems, PMs)
            if (MultiTenantHelpers.IsTaxonomyLevelTrunk())
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TaxonomyTrunkController>(c => c.Manage()), currentPerson, FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabelPluralized(), "Group1"));
            }

            if (!MultiTenantHelpers.IsTaxonomyLevelLeaf())
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TaxonomyBranchController>(c => c.Manage()), currentPerson, FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabelPluralized(), "Group1"));
            }
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TaxonomyLeafController>(c => c.Manage()), currentPerson, FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabelPluralized(), "Group1"));
            MultiTenantHelpers.GetClassificationSystems().ForEach(x =>
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ClassificationController>(c => c.Index(x.ClassificationSystemID)), currentPerson, ClassificationSystemModelExtensions.GetClassificationSystemNamePluralized(x), "Group1"));
            });
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<PerformanceMeasureController>(c => c.Manage()), currentPerson, MultiTenantHelpers.GetPerformanceMeasureNamePluralized(), "Group1"));
            
            MultiTenantHelpers.AddTechnicalAssistanceParametersMenuItem(manageMenu, currentPerson, "Group1");

            // Group 2 - System Config stuff
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<UserController>(c => c.Index()), currentPerson, "Users", "Group2"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.FeaturedList()), currentPerson, $"Featured {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", "Group2"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TagController>(c => c.Index()), currentPerson, $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Tags", "Group2"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectUpdateController>(c => c.Manage()), currentPerson, $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Updates", "Group2"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.ManageHomePageImages()), currentPerson, "Homepage Configuration", "Group2"));
            

            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(
                new SitkaRoute<AttachmentRelationshipTypeController>(c => c.Index()), currentPerson,
                "Attachment Relationship Type Configuration", "Group2"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(
                new SitkaRoute<ProjectAttachmentController>(c => c.ProjectAttachmentIndex()), currentPerson,
                "Full Attachments List", "Group2"));

            // Group 3 - Content Editing stuff
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FieldDefinitionController>(c => c.Index()), currentPerson, "Custom Labels & Definitions", "Group3"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<CustomPageController>(c => c.Index()), currentPerson, "Custom About Pages", "Group3"));
            if (MultiTenantHelpers.GetTenantAttribute().CanManageCustomAttributes)
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(
                    new SitkaRoute<ProjectCustomAttributeTypeController>(c => c.Manage()), currentPerson,
                    $"{FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabelPluralized()}", "Group3"));
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FundingSourceCustomAttributeTypeController>(c => c.Manage()), currentPerson, $"{FieldDefinitionEnum.FundingSourceCustomAttribute.ToType().GetFieldDefinitionLabelPluralized()}", "Group3"));
            }
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectCustomGridController>(c => c.ManageProjectCustomGrids()), currentPerson, $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Custom Grids", "Group3"));


            // Group 4 - Other
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.InternalSetupNotes()), currentPerson, "Internal Setup Notes", "Group4"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.StyleGuide()), currentPerson, "Style Guide", "Group4"));

            // Group 5 - Project Firma Configuration stuff
            if (HttpRequestStorage.Tenant == ProjectFirmaModels.Models.Tenant.SitkaTechnologyGroup)
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.DemoScript()), currentPerson, "Demo Script", "Group5")); // TODO: poor man's hack until we do tenant specific menu and features
            }
            
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<OrganizationTypeAndOrganizationRelationshipTypeController>(c => c.Index()), currentPerson, FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabelPluralized(), "Group5"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ContactRelationshipTypeController>(c => c.Index()), currentPerson, FieldDefinitionEnum.ContactType.ToType().GetFieldDefinitionLabelPluralized(), "Group5"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TenantController>(c => c.Detail()), currentPerson, "Tenant Configuration", "Group5"));
           
            return manageMenu;
        }


        private static LtInfoMenuItem BuildProjectsMenu(Person currentPerson)
        {
            var projectsMenu = new LtInfoMenuItem($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}");
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.ProjectMap()), currentPerson, $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Map", "Group1"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.Index()), currentPerson, $"Full {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} List", "Group2"));            
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.MyOrganizationsProjects()), currentPerson, $"My {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}'s {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", "Group2"));
            //projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectUpdateController>(c => c.MyProjectsRequiringAnUpdate()), currentPerson, "Update My Project(s)", "Group3"));
            //var projectUpdateStatusMenuItemName = string.Format("{0} Status of Project Updates", FirmaDateUtilities.CalculateCurrentYearToUseForReporting());
            //projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectUpdateController>(c => c.ProjectUpdateStatus()), currentPerson, projectUpdateStatusMenuItemName, "Group3"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.Proposed()), currentPerson, $"{FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabelPluralized()}", "Group3"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.Pending()), currentPerson, $"Pending {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", "Group3"));
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
