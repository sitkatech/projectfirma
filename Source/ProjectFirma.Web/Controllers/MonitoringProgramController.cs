using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.MonitoringProgram;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using Index = ProjectFirma.Web.Views.MonitoringProgram.Index;
using IndexGridSpec = ProjectFirma.Web.Views.MonitoringProgram.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.MonitoringProgram.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class MonitoringProgramController : FirmaBaseController
    {
        [MonitoringProgramViewFeature]
        public ViewResult Index()
        {
            return IndexImpl();
        }

        [FirmaAdminFeature]
        public ViewResult Manage()
        {
            return IndexImpl();
        }

        private ViewResult IndexImpl()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.MonitoringProgramsList);
            var viewData = new IndexViewData(CurrentPerson, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [MonitoringProgramViewFeature]
        public GridJsonNetJObjectResult<MonitoringProgram> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(new MonitoringProgramManageFeature().HasPermissionByPerson(CurrentPerson));
            var monitoringPrograms = HttpRequestStorage.DatabaseEntities.MonitoringPrograms.OrderBy(x => x.MonitoringProgramName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<MonitoringProgram>(monitoringPrograms, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [MonitoringProgramManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [MonitoringProgramManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var monitoringProgram = new MonitoringProgram(string.Empty);
            viewModel.UpdateModel(monitoringProgram, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllMonitoringPrograms.Add(monitoringProgram);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [MonitoringProgramManageFeature]
        public PartialViewResult Edit(MonitoringProgramPrimaryKey monitoringProgramPrimaryKey)
        {
            var monitoringProgram = monitoringProgramPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(monitoringProgram);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [MonitoringProgramManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(MonitoringProgramPrimaryKey monitoringProgramPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var monitoringProgram = monitoringProgramPrimaryKey.EntityObject;
            viewModel.UpdateModel(monitoringProgram, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [MonitoringProgramManageFeature]
        public PartialViewResult DeleteMonitoringProgram(MonitoringProgramPrimaryKey monitoringProgramPrimaryKey)
        {
            var monitoringProgram = monitoringProgramPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(monitoringProgram.MonitoringProgramID);
            return ViewDeleteMonitoringProgram(monitoringProgram, viewModel);
        }

        private PartialViewResult ViewDeleteMonitoringProgram(MonitoringProgram monitoringProgram, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !monitoringProgram.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this Monitoring Program '{0}'?", monitoringProgram.MonitoringProgramName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Monitoring Program",
                    SitkaRoute<MonitoringProgramController>.BuildLinkFromExpression(x => x.Detail(monitoringProgram), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [MonitoringProgramManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteMonitoringProgram(MonitoringProgramPrimaryKey monitoringProgramPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var monitoringProgram = monitoringProgramPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteMonitoringProgram(monitoringProgram, viewModel);
            }
            monitoringProgram.DeleteMonitoringProgram();
            return new ModalDialogFormJsonResult();
        }

        [MonitoringProgramViewFeature]
        public ViewResult Detail(MonitoringProgramPrimaryKey monitoringProgramPrimaryKey)
        {
            var monitoringProgram = monitoringProgramPrimaryKey.EntityObject;
            var viewData = new DetailViewData(CurrentPerson, monitoringProgram);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [HttpGet]
        [MonitoringProgramManageFeature]
        public ActionResult NewMonitoringProgramDocument(MonitoringProgramPrimaryKey monitoringProgramID)
        {
            var viewModel = new NewMonitoringProgramDocumentViewModel();
            return ViewNewMonitoringProgramDocument(viewModel);
        }

        [HttpPost]
        [MonitoringProgramManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewMonitoringProgramDocument(MonitoringProgramPrimaryKey monitoringProgramID, NewMonitoringProgramDocumentViewModel viewModel)
        {
            var monitoringProgram = monitoringProgramID.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewNewMonitoringProgramDocument(viewModel);
            }
            var monitoringProgramDocument = new MonitoringProgramDocument(monitoringProgram);
            viewModel.UpdateModel(monitoringProgramDocument, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllMonitoringProgramDocuments.Add(monitoringProgramDocument);
            return new ModalDialogFormJsonResult();

        }

        private PartialViewResult ViewNewMonitoringProgramDocument(NewMonitoringProgramDocumentViewModel viewModel)
        {
            var viewData = new NewMonitoringProgramDocumentViewData();
            return RazorPartialView<NewMonitoringProgramDocument, NewMonitoringProgramDocumentViewData, NewMonitoringProgramDocumentViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [MonitoringProgramManageFeature]
        public PartialViewResult DeleteMonitoringProgramDocument(MonitoringProgramDocumentPrimaryKey monitoringProgramDocumentPrimaryKey)
        {
            var monitoringProgramDocument = monitoringProgramDocumentPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(monitoringProgramDocument.MonitoringProgramID);
            return ViewDeleteMonitoringProgramDocument(monitoringProgramDocument, viewModel);
        }

        private PartialViewResult ViewDeleteMonitoringProgramDocument(MonitoringProgramDocument monitoringProgramDocument, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !monitoringProgramDocument.HasDependentObjects();
            var confirmMessage = canDelete
                ? "Are you sure you want to delete this Monitoring Program Document?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Monitoring Program Document",
                    SitkaRoute<MonitoringProgramController>.BuildLinkFromExpression(x => x.Detail(monitoringProgramDocument.MonitoringProgramID), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [MonitoringProgramManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteMonitoringProgramDocument(MonitoringProgramDocumentPrimaryKey monitoringProgramDocumentPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var monitoringProgramDocument = monitoringProgramDocumentPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteMonitoringProgramDocument(monitoringProgramDocument, viewModel);
            }
            monitoringProgramDocument.DeleteMonitoringProgramDocument();
            return new ModalDialogFormJsonResult();
        }

    }
}