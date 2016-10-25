using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Controllers
{
    public class HomeController : Web.Controllers.FirmaBaseController
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
            return ViewPageContent(ProjectFirmaPageTypeEnum.HomePage);
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