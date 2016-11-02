using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Home;

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
            var firmaPageType = FirmaPageType.ToType(FirmaPageTypeEnum.HomePage);
            var firmaPageByPageType = FirmaPage.GetFirmaPageByPageType(firmaPageType);
            var viewData = new IndexViewData(CurrentPerson, firmaPageByPageType);
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
        [PageContentManageFeature]
        public ActionResult EditPageContent(FirmaPageTypeEnum firmaPageTypeEnum)
        {
            var firmaPageType = FirmaPageType.ToType(firmaPageTypeEnum);
            var viewModel = new EditPageContentViewModel(firmaPageType);
            var viewData = new EditPageContentViewData(CurrentPerson, firmaPageType);
            return RazorView<EditPageContent, EditPageContentViewData, EditPageContentViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [PageContentManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPageContent(FirmaPageTypeEnum firmaPageTypeEnum, EditPageContentViewModel viewModel)
        {
            var firmaPageType = FirmaPageType.ToType(firmaPageTypeEnum);
            if (!ModelState.IsValid)
            {
                var viewData = new EditPageContentViewData(CurrentPerson, firmaPageType);
                return RazorView<EditPageContent, EditPageContentViewData, EditPageContentViewModel>(viewData, viewModel);
            }
            viewModel.UpdateModel(firmaPageType, CurrentPerson);

            return RedirectToAction((new SitkaRoute<HomeController>(c => c.ViewPageContent(firmaPageTypeEnum))));
        }
    }
}