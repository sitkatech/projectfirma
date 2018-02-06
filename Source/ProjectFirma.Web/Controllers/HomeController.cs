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

using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Home;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;

namespace ProjectFirma.Web.Controllers
{
    public class HomeController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        public FileResult ExportGridToExcel(string gridName, bool printFooter)
        {
            return ExportGridToExcelImpl(gridName, printFooter);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult Index()
        {
            var firmaPageTypeHomePage = FirmaPageType.ToType(FirmaPageTypeEnum.HomePage);
            var firmaPageByPageTypeHomePage = FirmaPage.GetFirmaPageByPageType(firmaPageTypeHomePage);

            var firmaPageTypeHomePageAdditionalInfo = FirmaPageType.ToType(FirmaPageTypeEnum.HomeAdditionalInfo);
            var firmaPageByPageTypeHomePageAdditionalInfo = FirmaPage.GetFirmaPageByPageType(firmaPageTypeHomePageAdditionalInfo);

            var firmaPageTypeHomePageMapInfo = FirmaPageType.ToType(FirmaPageTypeEnum.HomeMapInfo);
            var firmaPageByPageTypeHomePageMapInfo = FirmaPage.GetFirmaPageByPageType(firmaPageTypeHomePageMapInfo);

            var firmaHomePageImages = HttpRequestStorage.DatabaseEntities.FirmaHomePageImages.ToList().OrderBy(x => x.SortOrder).ToList();

            var currentPersonCanViewProposals = CurrentPerson.CanViewProposals;
            var projectsToShow = ProjectMapCustomization.ProjectsForMap(currentPersonCanViewProposals);

            var projectMapCustomization = ProjectMapCustomization.CreateDefaultCustomization(projectsToShow, currentPersonCanViewProposals);
            var projectLocationsLayerGeoJson = new LayerGeoJson($"{FieldDefinition.ProjectLocation.GetFieldDefinitionLabelPluralized()}", Project.MappedPointsToGeoJsonFeatureCollection(projectsToShow, false), "red", 1, LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson,
                projectMapCustomization, "ProjectLocationsMap")
                {
                    AllowFullScreen = false,
                    Layers = HttpRequestStorage.DatabaseEntities.Organizations.GetBoundaryLayerGeoJson().Where(x => x.LayerInitialVisibility == LayerInitialVisibility.Show).ToList()
                };
            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, ProjectColorByType.ProjectStage.DisplayName, MultiTenantHelpers.GetTopLevelTaxonomyTiers(), currentPersonCanViewProposals);
            
            var featuredProjectsViewData = new FeaturedProjectsViewData(HttpRequestStorage.DatabaseEntities.Projects.Where(x => x.IsFeatured).ToList().GetActiveProjects());

            var viewData = new IndexViewData(CurrentPerson, firmaPageByPageTypeHomePage, firmaPageByPageTypeHomePageAdditionalInfo, firmaPageByPageTypeHomePageMapInfo, featuredProjectsViewData, projectLocationsMapViewData, projectLocationsMapInitJson, firmaHomePageImages);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult Error()
        {
            var viewData = new ErrorViewData(CurrentPerson);
            return RazorView<Error, ErrorViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult NotFound()
        {
            var viewData = new NotFoundViewData(CurrentPerson);
            return RazorView<NotFound, NotFoundViewData>(viewData);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult ViewPageContent(FirmaPageTypeEnum firmaPageTypeEnum)
        {
            var firmaPageType = FirmaPageType.ToType(firmaPageTypeEnum);
            var viewData = new DisplayPageContentViewData(CurrentPerson, firmaPageType);
            return RazorView<DisplayPageContent, DisplayPageContentViewData>(viewData);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult About()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(FirmaPageTypeEnum.About);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult Meetings()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(FirmaPageTypeEnum.MeetingsandDocuments);
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
            var viewData = new ManageHomePageImagesViewData(CurrentPerson, BuildImageGalleryViewData(CurrentPerson));
            return RazorView<ManageHomePageImages, ManageHomePageImagesViewData>(viewData);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public ViewResult InternalSetupNotes()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(FirmaPageTypeEnum.InternalSetupNotes);
        }

        private static ImageGalleryViewData BuildImageGalleryViewData(Person currentPerson)
        {
            var userCanAddPhotosToHomePage = new FirmaAdminFeature().HasPermissionByPerson(currentPerson);
            var newPhotoForProjectUrl = SitkaRoute<FirmaHomePageImageController>.BuildUrlFromExpression(x => x.New());
            var galleryName = "HomePageImagesGallery";
            var firmaHomePageImages = HttpRequestStorage.DatabaseEntities.FirmaHomePageImages.ToList(); 
            var imageGalleryViewData = new ImageGalleryViewData(currentPerson,
                galleryName,
                firmaHomePageImages,
                userCanAddPhotosToHomePage,
                newPhotoForProjectUrl,
                null,
                true,
                x => x.CaptionOnFullView,
                "Photo");
            return imageGalleryViewData;
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult Training()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(FirmaPageTypeEnum.Training);
        }
    }
}
