using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;
using ProjectFirma.Web.Areas.EIP.Views.Home;
using ProjectFirma.Web.Areas.EIP.Views.Map;
using ProjectFirma.Web.Areas.EIP.Views.Shared;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Areas.EIP.Controllers
{
    public class HomeController : Web.Controllers.LakeTahoeInfoBaseController
    {
        [AnonymousUnclassifiedFeature]
        public FileResult ExportGridToExcel(string gridName, bool printFooter)
        {
            return ExportGridToExcelImpl(gridName, printFooter);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ActionResult Index()
        {
            var projectFirmaPageHome = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.EIPTrackerNarrative);
            var projectFirmaPageHomeAdditionalInfo = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.EIPHomeAdditionalInfo);
            var featuredProjects = HttpRequestStorage.DatabaseEntities.Projects.Where(x => x.IsFeatured).ToList();

            var allProjects = HttpRequestStorage.DatabaseEntities.Projects.ToList();
            var projects = IsCurrentUserAnonymous() ? allProjects.Where(p => p.IsVisibleToEveryone()).ToList() : allProjects;
            var projectMapCustomization = ProjectMapCustomization.CreateDefaultCustomization(projects);
            var projectLocationsLayerGeoJson = new LayerGeoJson("Project Locations", Project.MappedPointsToGeoJsonFeatureCollection(projects, false), "red", 1, LayerInitialVisibility.Show);
            var namedAreasAsPointsLayerGeoJson = new LayerGeoJson("Named Areas", Project.NamedAreasToPointGeoJsonFeatureCollection(projects, false), "red", 1, LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson, namedAreasAsPointsLayerGeoJson, projectMapCustomization, "EIPProjectLocationsMap") {AllowFullScreen =  false};

            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, ProjectColorByType.FocusArea.ProjectColorByTypeDisplayName);

            var viewData = new IndexViewData(CurrentPerson,
                projectFirmaPageHome,
                new ProjectFirmaPageViewListFeature().HasPermissionByPerson(CurrentPerson),
                projectFirmaPageHome.ProjectFirmaPageContentHtmlString,
                projectFirmaPageHomeAdditionalInfo.ProjectFirmaPageContentHtmlString,
                featuredProjects,
                projectLocationsMapViewData,
                projectLocationsMapInitJson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult ViewPageContent(ProjectFirmaPageTypeEnum projectFirmaPageTypeEnum)
        {
            var projectFirmaPageType = ProjectFirmaPageType.ToType(projectFirmaPageTypeEnum);
            var viewData = new DisplayEIPPageContentViewData(CurrentPerson, projectFirmaPageType);
            return RazorView<DisplayEIPPageContent, DisplayEIPPageContentViewData>(viewData);
        }

        [HttpGet]
        [PageContentManageFeature]
        public ActionResult EditPageContent(ProjectFirmaPageTypeEnum projectFirmaPageTypeEnum)
        {
            var projectFirmaPageType = ProjectFirmaPageType.ToType(projectFirmaPageTypeEnum);
            var viewModel = new EditEIPPageContentViewModel(projectFirmaPageType);
            var viewData = new EditEIPPageContentViewData(CurrentPerson, projectFirmaPageType);
            return RazorView<EditEIPPageContent, EditEIPPageContentViewData, EditEIPPageContentViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [PageContentManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPageContent(ProjectFirmaPageTypeEnum projectFirmaPageTypeEnum, EditEIPPageContentViewModel viewModel)
        {
            var projectFirmaPageType = ProjectFirmaPageType.ToType(projectFirmaPageTypeEnum);
            if (!ModelState.IsValid)
            {
                var viewData = new EditEIPPageContentViewData(CurrentPerson, projectFirmaPageType);
                return RazorView<EditEIPPageContent, EditEIPPageContentViewData, EditEIPPageContentViewModel>(viewData, viewModel);
            }
            viewModel.UpdateModel(projectFirmaPageType, CurrentPerson);

            return RedirectToAction((new SitkaRoute<HomeController>(c => c.ViewPageContent(projectFirmaPageTypeEnum))));
        }
    }
}