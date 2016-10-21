using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectFirmaPage;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectFirmaPageController : LakeTahoeInfoBaseController
    {
        [ProjectFirmaPageViewListFeature]
        public ViewResult Index()
        {
            var projectFirmaPage = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.PagesWithIntroTextList);
            var viewData = new IndexViewData(CurrentPerson, projectFirmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [ProjectFirmaPageViewListFeature]
        public GridJsonNetJObjectResult<ProjectFirmaPage> IndexGridJsonData()
        {
            ProjectFirmaPageGridSpec gridSpec;
            var projectFirmaPages = GetProjectFirmaPagesAndGridSpec(out gridSpec, CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectFirmaPage>(projectFirmaPages, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<ProjectFirmaPage> GetProjectFirmaPagesAndGridSpec(out ProjectFirmaPageGridSpec gridSpec, Person currentPerson)
        {
            gridSpec = new ProjectFirmaPageGridSpec(new ProjectFirmaPageViewListFeature().HasPermissionByPerson(currentPerson));
            return
                HttpRequestStorage.DatabaseEntities.ProjectFirmaPages.ToList()
                    .Where(x => new ProjectFirmaPageManageFeature().HasPermission(currentPerson, x).HasPermission)
                    .OrderBy(x => x.ProjectFirmaPageType.ProjectFirmaPageTypeDisplayName)
                    .ToList();
        }

        [HttpGet]
        [ProjectFirmaPageManageFeature]
        public PartialViewResult EditInDialog(ProjectFirmaPagePrimaryKey projectFirmaPagePrimaryKey)
        {
            var projectFirmaPage = projectFirmaPagePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(projectFirmaPage);
            return ViewEditInDialog(viewModel, projectFirmaPage);
        }

        [HttpPost]
        [ProjectFirmaPageManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditInDialog(ProjectFirmaPagePrimaryKey projectFirmaPagePrimaryKey, EditViewModel viewModel)
        {
            var projectFirmaPage = projectFirmaPagePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditInDialog(viewModel, projectFirmaPage);
            }
            viewModel.UpdateModel(projectFirmaPage);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditInDialog(EditViewModel viewModel, ProjectFirmaPage projectFirmaPage)
        {
            var ckEditorToolbar = projectFirmaPage.ProjectFirmaPageType.ProjectFirmaPageRenderType == ProjectFirmaPageRenderType.PageContent ? CkEditorExtension.CkEditorToolbar.AllOnOneRowNoMaximize : CkEditorExtension.CkEditorToolbar.All;
            var viewData = new EditViewData(ckEditorToolbar,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(x => x.CkEditorUploadFileResource(projectFirmaPage)));
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectFirmaPageManageFeature]
        public PartialViewResult ProjectFirmaPageDetails(ProjectFirmaPagePrimaryKey projectFirmaPagePrimaryKey)
        {
            var projectFirmaPage = projectFirmaPagePrimaryKey.EntityObject;
            var projectFirmaPageContentHtmlString = projectFirmaPage.ProjectFirmaPageContentHtmlString;
            if (!projectFirmaPage.HasProjectFirmaPageContent)
            {
                projectFirmaPageContentHtmlString = new HtmlString(string.Format("No page content for Page \"{0}\".", projectFirmaPage.ProjectFirmaPageType.ProjectFirmaPageTypeDisplayName));
            }
            var viewData = new ProjectFirmaPageDetailsViewData(projectFirmaPageContentHtmlString);
            return RazorPartialView<ProjectFirmaPageDetails, ProjectFirmaPageDetailsViewData>(viewData);
        }
    }
}