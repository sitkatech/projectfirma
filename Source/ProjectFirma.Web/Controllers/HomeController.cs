/*-----------------------------------------------------------------------
<copyright file="HomeController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Home;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;

namespace ProjectFirma.Web.Controllers
{
    public class HomeController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        public FileResult ExportGridToExcel(string gridName)
        {
            return ExportGridToExcelImpl(gridName);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult Index()
        {
            var firmaPageByPageTypeHomePage = FirmaPageTypeEnum.HomePage.GetFirmaPage();

            var firmaPageByPageTypeHomePageAdditionalInfo = FirmaPageTypeEnum.HomeAdditionalInfo.GetFirmaPage();

            var firmaPageByPageTypeHomePageMapInfo = FirmaPageTypeEnum.HomeMapInfo.GetFirmaPage();

            var firmaHomePageImages = HttpRequestStorage.DatabaseEntities.FirmaHomePageImages.ToList().OrderBy(x => x.SortOrder).ToList();

            var currentPersonCanViewProposals = CurrentPerson.CanViewProposals();
            var projectsToShow = ProjectMapCustomization.ProjectsForMap(currentPersonCanViewProposals);

            var projectMapCustomization = ProjectMapCustomization.CreateDefaultCustomization(projectsToShow, currentPersonCanViewProposals);
            var projectLocationsLayerGeoJson = new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabelPluralized()}", projectsToShow.MappedPointsToGeoJsonFeatureCollection(false, true), "red", 1, LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson,
                projectMapCustomization, "ProjectLocationsMap", false)
                {
                    AllowFullScreen = false,
                    Layers = HttpRequestStorage.DatabaseEntities.Organizations.GetBoundaryLayerGeoJson().Where(x => x.LayerInitialVisibility == LayerInitialVisibility.Show).ToList()
                };
            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, ProjectColorByType.ProjectStage.GetDisplayNameFieldDefinition(), MultiTenantHelpers.GetTopLevelTaxonomyTiers(), currentPersonCanViewProposals);
            
            var featuredProjectsViewData = new FeaturedProjectsViewData(HttpRequestStorage.DatabaseEntities.Projects.Where(x => x.IsFeatured).ToList().GetActiveProjects());

            var viewData = new IndexViewData(CurrentFirmaSession, firmaPageByPageTypeHomePage, firmaPageByPageTypeHomePageAdditionalInfo, firmaPageByPageTypeHomePageMapInfo, featuredProjectsViewData, projectLocationsMapViewData, projectLocationsMapInitJson, firmaHomePageImages);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult Error()
        {
            var viewData = new ErrorViewData(CurrentFirmaSession);
            return RazorView<Error, ErrorViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult NotFound()
        {
            var viewData = new NotFoundViewData(CurrentFirmaSession);
            return RazorView<NotFound, NotFoundViewData>(viewData);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult ViewPageContent(FirmaPageTypeEnum firmaPageTypeEnum)
        {
            var firmaPage = firmaPageTypeEnum.GetFirmaPage();
            var hasPermission = new FirmaPageManageFeature().HasPermission(CurrentFirmaSession, firmaPage).HasPermission;
            var viewData = new DisplayPageContentViewData(CurrentFirmaSession, firmaPage, hasPermission);
            return RazorView<DisplayPageContent, DisplayPageContentViewData>(viewData);
        }

        [HttpGet]
        [SitkaAdminFeature]
        public ViewResult DemoScript()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(FirmaPageTypeEnum.DemoScript);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public ViewResult ManageHomePageImages()
        {
            var canAddPhotos = new FirmaAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            var firmaHomePageImages = HttpRequestStorage.DatabaseEntities.FirmaHomePageImages.ToList().Select(x => new FileResourcePhoto(x)).ToList();
            var addNewPhotoUrl = SitkaRoute<FirmaHomePageImageController>.BuildUrlFromExpression(x => x.New());
            var imageGalleryViewData = new ImageGalleryViewData(CurrentFirmaSession,
                "HomePageImagesGallery",
                firmaHomePageImages,
                canAddPhotos,
                addNewPhotoUrl,
                null,
                true,
                x => x.CaptionOnFullView,
                "Photo");
            var viewData = new ManageHomePageImagesViewData(CurrentFirmaSession, imageGalleryViewData, canAddPhotos);
            return RazorView<ManageHomePageImages, ManageHomePageImagesViewData>(viewData);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public ViewResult InternalSetupNotes()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(FirmaPageTypeEnum.InternalSetupNotes);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult Training()
        {
            var firmaPage = FirmaPageTypeEnum.Training.GetFirmaPage();
            List<ProjectFirmaModels.Models.TrainingVideo> trainingVideos = HttpRequestStorage.DatabaseEntities.TrainingVideos.ToList();
            var viewData = new TrainingVideoViewData(CurrentFirmaSession, firmaPage, trainingVideos);
            return RazorView<Views.Home.TrainingVideo, TrainingVideoViewData>(viewData);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public ViewResult StyleGuide()
        {
            var firmaPage = FirmaPageTypeEnum.Training.GetFirmaPage();
            var viewData = new StyleGuideViewData(CurrentFirmaSession, firmaPage);
            return RazorView<StyleGuide, StyleGuideViewData>(viewData);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult ReleaseNotes()
        {
            var releaseNotes = HttpRequestStorage.DatabaseEntities.ReleaseNotes.OrderByDescending(rn => rn.CreateDate).ToList();
            var userHasEditReleaseNotePermission = new SitkaAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            var viewData = new ReleaseNotesViewData(CurrentFirmaSession, releaseNotes, SitkaRoute<ReleaseNoteController>.BuildUrlFromExpression(x => x.New()), "Release Notes", userHasEditReleaseNotePermission);
            return RazorView<ReleaseNotes, ReleaseNotesViewData>(viewData);
        }

    }
}
