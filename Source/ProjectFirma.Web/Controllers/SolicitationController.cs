using System;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Solicitation;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class SolicitationController : FirmaBaseController
    {
        [FirmaAdminFeature]
        public ActionResult Index()
        {
            var firmaPage = FirmaPageTypeEnum.TagList.GetFirmaPage();
            var viewData = new IndexViewData(CurrentFirmaSession, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<Solicitation> IndexGridJsonData()
        {
            var hasTagDeletePermission = new FirmaAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            var gridSpec = new IndexGridSpec(hasTagDeletePermission);
            var solicitations = HttpRequestStorage.DatabaseEntities.Solicitations.OrderBy(x => x.SolicitationName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Solicitation>(solicitations, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }

            var solicitation = new Solicitation(string.Empty, false);
            viewModel.UpdateModel(solicitation, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllSolicitations.Add(solicitation);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"{FieldDefinitionEnum.Solicitation.ToType().GetFieldDefinitionLabel()} '{solicitation.SolicitationName}' successfully created.");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult Edit(SolicitationPrimaryKey solicitationPrimaryKey)
        {
            var solicitation = solicitationPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(solicitation);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(SolicitationPrimaryKey solicitationPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var tag = solicitationPrimaryKey.EntityObject;
            viewModel.UpdateModel(tag, CurrentFirmaSession);
            return new ModalDialogFormJsonResult(SitkaRoute<SolicitationController>.BuildUrlFromExpression(x => x.Index()));
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult DeleteTag(SolicitationPrimaryKey solicitationPrimaryKey)
        {
            var solicitation = solicitationPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(solicitation.SolicitationID);
            return ViewDeleteTag(solicitation, viewModel);
        }

        private PartialViewResult ViewDeleteTag(Solicitation solicitation, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage = $"Are you sure you want to delete this {FieldDefinitionEnum.Solicitation.ToType().GetFieldDefinitionLabel()} '{solicitation.SolicitationName}'?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTag(SolicitationPrimaryKey solicitationPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var solicitation = solicitationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteTag(solicitation, viewModel);
            }
            solicitation.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }
    }
}