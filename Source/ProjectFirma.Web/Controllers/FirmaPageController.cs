using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.FirmaPage;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class FirmaPageController : FirmaBaseController
    {
        [FirmaPageViewListFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.PagesWithIntroTextList);
            var viewData = new IndexViewData(CurrentPerson, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [FirmaPageViewListFeature]
        public GridJsonNetJObjectResult<FirmaPage> IndexGridJsonData()
        {
            var gridSpec = new FirmaPageGridSpec(new FirmaPageViewListFeature().HasPermissionByPerson(CurrentPerson));
            var firmaPages = HttpRequestStorage.DatabaseEntities.FirmaPages.ToList()
                .Where(x => new FirmaPageManageFeature().HasPermission(CurrentPerson, x).HasPermission)
                .OrderBy(x => x.FirmaPageType.FirmaPageTypeDisplayName)
                .ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<FirmaPage>(firmaPages, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [FirmaPageManageFeature]
        public PartialViewResult EditInDialog(FirmaPagePrimaryKey firmaPagePrimaryKey)
        {
            var firmaPage = firmaPagePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(firmaPage);
            return ViewEditInDialog(viewModel, firmaPage);
        }

        [HttpPost]
        [FirmaPageManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditInDialog(FirmaPagePrimaryKey firmaPagePrimaryKey, EditViewModel viewModel)
        {
            var firmaPage = firmaPagePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditInDialog(viewModel, firmaPage);
            }
            viewModel.UpdateModel(firmaPage);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditInDialog(EditViewModel viewModel, FirmaPage firmaPage)
        {
            var ckEditorToolbar = firmaPage.FirmaPageType.FirmaPageRenderType == FirmaPageRenderType.PageContent ? CkEditorExtension.CkEditorToolbar.AllOnOneRowNoMaximize : CkEditorExtension.CkEditorToolbar.All;
            var viewData = new EditViewData(ckEditorToolbar,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(x => x.CkEditorUploadFileResource(firmaPage)));
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [FirmaPageManageFeature]
        public PartialViewResult FirmaPageDetails(FirmaPagePrimaryKey firmaPagePrimaryKey)
        {
            var firmaPage = firmaPagePrimaryKey.EntityObject;
            var firmaPageContentHtmlString = firmaPage.FirmaPageContentHtmlString;
            if (!firmaPage.HasFirmaPageContent)
            {
                firmaPageContentHtmlString = new HtmlString(string.Format("No page content for Page \"{0}\".", firmaPage.FirmaPageType.FirmaPageTypeDisplayName));
            }
            var viewData = new FirmaPageDetailsViewData(firmaPageContentHtmlString);
            return RazorPartialView<FirmaPageDetails, FirmaPageDetailsViewData>(viewData);
        }
    }
}