using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Security.Shared;

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
        public ActionResult Index()
        {
            return ViewPageContent(FirmaPageTypeEnum.HomePage);
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
            var viewData = new DisplayEIPPageContentViewData(CurrentPerson, firmaPageType);
            return RazorView<DisplayEIPPageContent, DisplayEIPPageContentViewData>(viewData);
        }

        [HttpGet]
        [PageContentManageFeature]
        public ActionResult EditPageContent(FirmaPageTypeEnum firmaPageTypeEnum)
        {
            var firmaPageType = FirmaPageType.ToType(firmaPageTypeEnum);
            var viewModel = new EditEIPPageContentViewModel(firmaPageType);
            var viewData = new EditEIPPageContentViewData(CurrentPerson, firmaPageType);
            return RazorView<EditEIPPageContent, EditEIPPageContentViewData, EditEIPPageContentViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [PageContentManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPageContent(FirmaPageTypeEnum firmaPageTypeEnum, EditEIPPageContentViewModel viewModel)
        {
            var firmaPageType = FirmaPageType.ToType(firmaPageTypeEnum);
            if (!ModelState.IsValid)
            {
                var viewData = new EditEIPPageContentViewData(CurrentPerson, firmaPageType);
                return RazorView<EditEIPPageContent, EditEIPPageContentViewData, EditEIPPageContentViewModel>(viewData, viewModel);
            }
            viewModel.UpdateModel(firmaPageType, CurrentPerson);

            return RedirectToAction((new SitkaRoute<HomeController>(c => c.ViewPageContent(firmaPageTypeEnum))));
        }
    }
}