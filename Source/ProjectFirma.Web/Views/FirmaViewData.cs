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
        public FirmaSession CurrentFirmaSession { get; }
        // Eventually this should be removed in favor of CurrentFirmaSession whenever possible.
        public Person CurrentPerson
        {
            get { return CurrentFirmaSession.Person; }
        }
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
        
        protected FirmaViewData(FirmaSession currentFirmaSession) : this(currentFirmaSession, null)
        {
            // TODO: MUST change currentPerson to CurrentSession
        }
     
        /// <summary>
        /// Call for page with associated FirmaPage
        /// </summary>
        protected FirmaViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage)
        {
            FirmaPage = firmaPage;

            //CurrentPerson = currentPerson;
            CurrentFirmaSession = currentFirmaSession;
            FirmaHomeUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(c => c.Index());

            LogInUrl = FirmaHelpers.GenerateLogInUrl();
            LogOutUrl = FirmaHelpers.GenerateLogOutUrlWithReturnUrl();

            RequestSupportUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(c => c.Support());

            MakeFirmaMenu(currentFirmaSession);

            FullProjectListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Index());
            ProjectSearchUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Search(UrlTemplate.Parameter1String));
            ProjectFindUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Find(string.Empty));

            var currentPersonCanManage = new FirmaPageManageFeature().HasPermission(currentFirmaSession, firmaPage).HasPermission;
            ViewPageContentViewData = firmaPage != null ? new ViewPageContentViewData(firmaPage, currentPersonCanManage) : null;
            CustomFooterViewData = new ViewPageContentViewData(FirmaPageTypeEnum.CustomFooter.GetFirmaPage(), currentPersonCanManage);
            TenantName = MultiTenantHelpers.GetTenantName();
            TenantShortDisplayName = MultiTenantHelpers.GetTenantShortDisplayName();
            TenantBannerLogoUrl = MultiTenantHelpers.GetTenantBannerLogoUrl();
            TenantToolDisplayName = MultiTenantHelpers.GetToolDisplayName();
        }

        private void MakeFirmaMenu(FirmaSession currentFirmaSession)
        {
            TopLevelLtInfoMenuItems = new List<LtInfoMenuItem>
            {
                BuildAboutMenu(currentFirmaSession),
                BuildProjectsMenu(currentFirmaSession),
                BuildProgramInfoMenu(currentFirmaSession)
            };
            if (MultiTenantHelpers.DisplayAccomplishmentDashboard() || MultiTenantHelpers.UsesCustomResultsPages(currentFirmaSession))
            {
                TopLevelLtInfoMenuItems.Add(BuildResultsMenu(currentFirmaSession));
            }
            TopLevelLtInfoMenuItems.Add(BuildManageMenu(currentFirmaSession));
            TopLevelLtInfoMenuItems.Add(BuildConfigureMenu(currentFirmaSession));

            TopLevelLtInfoMenuItems.ForEach(x => x.ExtraTopLevelMenuCssClasses = new List<string> { "navigation-root-item" });
            TopLevelLtInfoMenuItems.SelectMany(x => x.ChildMenus).ToList().ForEach(x => x.ExtraTopLevelMenuCssClasses = new List<string> { "navigation-dropdown-item" });

            HelpMenu = new LtInfoMenuItem("Help");
            HelpMenu.AddMenuItem(LtInfoMenuItem.MakeItem("Request Support",
                ModalDialogFormHelper.ModalDialogFormLink("Request Support", RequestSupportUrl, "Request Support", 800,
                    "Submit Request", "Cancel", new List<string>(), null, null).ToString(), "ToolHelp"));
            HelpMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c=>c.Training()), currentFirmaSession, "Training", "ToolHelp"));
            HelpMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.InternalSetupNotes()), currentFirmaSession, "Internal Setup Notes", "ToolHelp"));
            HelpMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.ReleaseNotes()), currentFirmaSession, "Release Notes", "ToolHelp"));
            HelpMenu.AddMenuItem(LtInfoMenuItem.MakeItem("About ProjectFirma",
                @"<a href='http://www.sitkatech.com/products/ProjectFirma/projectfirma-faqs/' target='_blank'>About ProjectFirma <span class='glyphicon glyphicon-new-window'></span></a>", "ExternalHelp"));
        }

        private static LtInfoMenuItem BuildAboutMenu(FirmaSession currentFirmaSession)
        {
            var aboutMenu = new LtInfoMenuItem("About");

            MultiTenantHelpers.GetCustomPages().ForEach(x =>
            {
                var pageTypeIsPublic = x.CustomPageDisplayType == CustomPageDisplayType.Public;
                var currentUserIsAnonymous = currentFirmaSession != null && currentFirmaSession.IsAnonymousUser();
                var pageTypeIsProtected = x.CustomPageDisplayType == CustomPageDisplayType.Protected;
                var isVisible = pageTypeIsPublic || (!currentUserIsAnonymous && pageTypeIsProtected);
                if (isVisible)
                {
                    aboutMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<CustomPageController>(c => c.About(x.CustomPageVanityUrl)), currentFirmaSession, x.CustomPageDisplayName, "Group1"));
                }
                
            });
            return aboutMenu;
        }

        private static LtInfoMenuItem BuildResultsMenu(FirmaSession firmaSession)
        {
            var resultsMenu = new LtInfoMenuItem("Results");
            if (MultiTenantHelpers.DisplayAccomplishmentDashboard())
            {
                resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.AccomplishmentsDashboard()), firmaSession, "Accomplishments Dashboard"));
            }
            MultiTenantHelpers.AddTechnicalAssistanceReportMenuItem(resultsMenu, firmaSession);
            MultiTenantHelpers.AddFundingStatusMenuItem(resultsMenu, firmaSession);

            //resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.ProjectMap()), currentPerson, $"{Models.FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Map"));
            //resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<SnapshotController>(c => c.Index()), currentPerson, "System Snapshot", "Group2"));
            return resultsMenu;
        }

        private static LtInfoMenuItem BuildProgramInfoMenu(FirmaSession currentFirmaSession)
        {
            var programInfoMenu = new LtInfoMenuItem("Program Info");
            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProgramInfoController>(c => c.Taxonomy()), currentFirmaSession, MultiTenantHelpers.GetTaxonomySystemName(), "Group1"));

            MultiTenantHelpers.GetClassificationSystems().ForEach(x =>
            {
                programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProgramInfoController>(c => c.ClassificationSystem(x.ClassificationSystemID)), currentFirmaSession, ClassificationSystemModelExtensions.GetClassificationSystemNamePluralized(x), "Group1"));
            });
            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<PerformanceMeasureController>(c => c.Index()), currentFirmaSession, MultiTenantHelpers.GetPerformanceMeasureNamePluralized(), "Group1"));
            
            foreach (var geospatialAreaType in HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.ToList())
            {
                programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<GeospatialAreaController>(c => c.Index(geospatialAreaType)), currentFirmaSession, $"{geospatialAreaType.GeospatialAreaTypeNamePluralized}", "Group2"));
            }

            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectStewardOrganizationController>(c => c.Index()), currentFirmaSession, $"{FieldDefinitionEnum.ProjectStewardOrganizationDisplayName.ToType().GetFieldDefinitionLabelPluralized()}", "Group3"));
            }
            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<OrganizationController>(c => c.Index()), currentFirmaSession, $"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabelPluralized()}", "Group3"));
            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FundingSourceController>(c => c.Index()), currentFirmaSession, $"{FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabelPluralized()}", "Group3"));

            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<WebServicesController>(c => c.Index()), currentFirmaSession, $"Web Services", "Group4"));
            
            return programInfoMenu;
        }


        private static LtInfoMenuItem BuildManageMenu(FirmaSession currentFirmaSession)
        {
            var manageMenu = new LtInfoMenuItem("Manage");

            // Group 1 - Project Classifications Stuff (taxonomies, classification systems, PMs)
            if (MultiTenantHelpers.IsTaxonomyLevelTrunk())
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TaxonomyTrunkController>(c => c.Manage()), currentFirmaSession, FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabelPluralized(), "Group1"));
            }

            if (!MultiTenantHelpers.IsTaxonomyLevelLeaf())
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TaxonomyBranchController>(c => c.Manage()), currentFirmaSession, FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabelPluralized(), "Group1"));
            }

            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TaxonomyLeafController>(c => c.Manage()), currentFirmaSession, FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabelPluralized(), "Group1"));
            MultiTenantHelpers.GetClassificationSystems().ForEach(x =>
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ClassificationController>(c => c.Index(x.ClassificationSystemID)), currentFirmaSession, ClassificationSystemModelExtensions.GetClassificationSystemNamePluralized(x), "Group1"));
            });
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<PerformanceMeasureController>(c => c.Manage()), currentFirmaSession, MultiTenantHelpers.GetPerformanceMeasureNamePluralized(), "Group1"));
            
            MultiTenantHelpers.AddTechnicalAssistanceParametersMenuItem(manageMenu, currentFirmaSession, "Group1");
            MultiTenantHelpers.AddEvaluationsMenuItem(manageMenu, currentFirmaSession, "Group1");

            // Group 2 - System Config stuff
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.FeaturedList()), currentFirmaSession, $"Featured {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", "Group2"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.ManageHomePageImages()), currentFirmaSession, "Homepage Images", "Group2"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<CustomPageController>(c => c.Index()), currentFirmaSession, "About Pages", "Group2"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FieldDefinitionController>(c => c.Index()), currentFirmaSession, "Labels & Definitions", "Group2"));

            // Group 3
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TagController>(c => c.Index()), currentFirmaSession, $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Tags", "Group3"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectUpdateController>(c => c.Manage()), currentFirmaSession, $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Updates", "Group3"));
            
            // Group 4
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<UserController>(c => c.Index()), currentFirmaSession, "Users", "Group4"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ReportCenterController>(c => c.Index()), currentFirmaSession, $"Report Center", "Group4"));
            // Group 4 - Other

            // Group 5 - Project Firma Configuration stuff
            if (HttpRequestStorage.Tenant == ProjectFirmaModels.Models.Tenant.SitkaTechnologyGroup)
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.DemoScript()), currentFirmaSession, "Demo Script", "Group5")); // TODO: poor man's hack until we do tenant specific menu and features
            }
            
            return manageMenu;
        }

        private static LtInfoMenuItem BuildConfigureMenu(FirmaSession currentFirmaSession)
        {
            var configureMenu = new LtInfoMenuItem("Configure");

            // Group 1 - Projects
            if (MultiTenantHelpers.GetTenantAttribute().CanManageCustomAttributes)
            {
                configureMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectCustomAttributeTypeController>(c => c.Manage()), currentFirmaSession, $"{FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabelPluralized()}", "Group1"));
                configureMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectCustomAttributeGroupController>(c => c.Manage()), currentFirmaSession, $"{FieldDefinitionEnum.ProjectCustomAttributeGroup.ToType().GetFieldDefinitionLabelPluralized()}", "Group1"));
            }
            configureMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectCustomGridController>(c => c.ManageProjectCustomGrids()), currentFirmaSession, $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Custom Grids", "Group1"));

            if (MultiTenantHelpers.GetTenantAttribute().UseProjectTimeline)
            {
                configureMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectStatusController>(c => c.Manage()), currentFirmaSession, $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {FieldDefinitionEnum.Status.ToType().GetFieldDefinitionLabelPluralized()}", "Group1"));
            }

            if (MultiTenantHelpers.GetTenantAttribute().CanManageCustomAttributes)
            {
                // Group 2 - Funding source
                configureMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FundingSourceCustomAttributeTypeController>(c => c.Manage()), currentFirmaSession, $"{FieldDefinitionEnum.FundingSourceCustomAttribute.ToType().GetFieldDefinitionLabelPluralized()}", "Group2"));
            }

            // Group 3 - Attachments
            configureMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<AttachmentRelationshipTypeController>(c => c.Index()), currentFirmaSession, FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabelPluralized(), "Group3"));

            // Group 4 - External Map Layers
            configureMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ExternalMapLayerController>(c => c.Index()), currentFirmaSession, FieldDefinitionEnum.ExternalMapLayer.ToType().GetFieldDefinitionLabelPluralized(), "Group4"));

            // Group 5 - Sitka admins only
            configureMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<OrganizationTypeAndOrganizationRelationshipTypeController>(c => c.Index()), currentFirmaSession, FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabelPluralized(), "Group5"));
            configureMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ContactRelationshipTypeController>(c => c.Index()), currentFirmaSession, FieldDefinitionEnum.ContactType.ToType().GetFieldDefinitionLabelPluralized(), "Group5"));
            configureMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TenantController>(c => c.Detail()), currentFirmaSession, "Tenant Configuration", "Group5"));
            if (currentFirmaSession.IsSitkaAdministrator())
            {
                configureMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.StyleGuide()), currentFirmaSession, "Style Guide", "Group5"));

                // The Site Monitor (Health Check) page is deliberately Anonymous to allow Nagios to hit it easily, but we don't want to advertise it to non-admins.
                configureMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<SiteMonitorController>(c => c.SiteMonitor()), currentFirmaSession, "Site Monitor (Health Checks)", "Group6"));
            }

            return configureMenu;
        }


        private static LtInfoMenuItem BuildProjectsMenu(FirmaSession currentFirmaSession)
        {
            var projectsMenu = new LtInfoMenuItem($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}");

            // Group 1 - Project map
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.ProjectMap()), currentFirmaSession, $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Map", "Group1"));

            // Group 2 - Project list and organization's projects
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.Index()), currentFirmaSession, $"Full {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} List", "Group2"));            
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.MyOrganizationsProjects()), currentFirmaSession, $"My {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}'s {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", "Group2"));

            // Group 3 - Proposals and pending projects
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.Proposed()), currentFirmaSession, $"{FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabelPluralized()}", "Group3"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.Pending()), currentFirmaSession, $"Pending {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", "Group3"));

            // Group 4 - Attachments
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectAttachmentController>(c => c.ProjectAttachmentIndex()), currentFirmaSession, "Project Attachments", "Group4"));

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
