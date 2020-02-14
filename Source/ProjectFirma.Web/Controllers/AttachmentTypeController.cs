using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.AttachmentType;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class AttachmentTypeController : FirmaBaseController
    {
        [AttachmentTypeViewFeature]
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
            var viewData = new IndexViewData(CurrentFirmaSession);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [AttachmentTypeViewFeature]
        public GridJsonNetJObjectResult<AttachmentType> AttachmentTypeGridJsonData()
        {
            var hasManagePermissions = new AttachmentTypeManageFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            var gridSpec = new AttachmentTypeGridSpec(hasManagePermissions);
            var attachmentTypes = HttpRequestStorage.DatabaseEntities.AttachmentTypes.ToList().OrderBy(x => x.AttachmentTypeName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<AttachmentType>(attachmentTypes, gridSpec);
            return gridJsonNetJObjectResult;
        }


        [HttpGet]
        [AttachmentTypeManageFeature]
        public PartialViewResult NewAttachmentType()
        {
            var viewModel = new EditAttachmentTypeViewModel();
            return ViewNewAttachmentType(viewModel);
        }

        [HttpPost]
        [AttachmentTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewAttachmentType(EditAttachmentTypeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNewAttachmentType(viewModel);
            }

            var attachmentType = new AttachmentType(viewModel.AttachmentTypeName, viewModel.MaxFileSize);
            
            HttpRequestStorage.DatabaseEntities.AllAttachmentTypes.Add(attachmentType);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            HttpRequestStorage.DatabaseEntities.AttachmentTypeFileResourceMimeTypes.Load();
            var attachmentTypeFileResourceMimeTypes = HttpRequestStorage.DatabaseEntities.AllAttachmentTypeFileResourceMimeTypes.Local;

            HttpRequestStorage.DatabaseEntities.AttachmentTypeTaxonomyTrunks.Load();
            var attachmentTypeTaxonomyTrunks = HttpRequestStorage.DatabaseEntities.AllAttachmentTypeTaxonomyTrunks.Local;

            viewModel.UpdateModel(attachmentType, attachmentTypeFileResourceMimeTypes, attachmentTypeTaxonomyTrunks);
            
            SetMessageForDisplay(
                $"New {FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel()} {attachmentType.AttachmentTypeName} successfully created!");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [AttachmentTypeManageFeature]
        public PartialViewResult EditAttachmentType(AttachmentTypePrimaryKey attachmentTypePrimaryKey)
        {
            var attachmentType = attachmentTypePrimaryKey.EntityObject;
            var viewModel = new EditAttachmentTypeViewModel(attachmentType);
            return ViewEditAttachmentType(viewModel);
        }

        [HttpPost]
        [AttachmentTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditAttachmentType(AttachmentTypePrimaryKey attachmentTypePrimaryKey, EditAttachmentTypeViewModel viewModel)
        {
            var attachmentType = attachmentTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditAttachmentType(viewModel);
            }

            HttpRequestStorage.DatabaseEntities.AttachmentTypeFileResourceMimeTypes.Load();
            var attachmentTypeFileResourceMimeTypes = HttpRequestStorage.DatabaseEntities.AllAttachmentTypeFileResourceMimeTypes.Local;

            HttpRequestStorage.DatabaseEntities.AttachmentTypeTaxonomyTrunks.Load();
            var attachmentTypeTaxonomyTrunks = HttpRequestStorage.DatabaseEntities.AllAttachmentTypeTaxonomyTrunks.Local;

            viewModel.UpdateModel(attachmentType, attachmentTypeFileResourceMimeTypes, attachmentTypeTaxonomyTrunks);

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNewAttachmentType(EditAttachmentTypeViewModel viewModel)
        {
            return ViewEditAttachmentType(viewModel);
        }

        private PartialViewResult ViewEditAttachmentType(EditAttachmentTypeViewModel viewModel)
        {
            var allTaxonomyTrunks = HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.ToList();
            bool hasTaxonomyTrunks = MultiTenantHelpers.IsTaxonomyLevelTrunk();

            var viewData = new EditAttachmentTypeViewData(FileResourceMimeType.All, allTaxonomyTrunks, hasTaxonomyTrunks);
            return RazorPartialView<EditAttachmentType, EditAttachmentTypeViewData, EditAttachmentTypeViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [AttachmentTypeManageFeature]
        public PartialViewResult DeleteAttachmentType(AttachmentTypePrimaryKey attachmentTypePrimaryKey)
        {
            var attachmentType = attachmentTypePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(attachmentType.AttachmentTypeID);
            return ViewDeleteAttachmentType(attachmentType, viewModel);
        }

        private PartialViewResult ViewDeleteAttachmentType(AttachmentType attachmentType, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = attachmentType.CanDelete();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this {FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel()} '{attachmentType.AttachmentTypeName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel(), SitkaRoute<AttachmentTypeController>.BuildLinkFromExpression(x => x.Index(), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [AttachmentTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteAttachmentType(AttachmentTypePrimaryKey attachmentTypePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var attachmentType = attachmentTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteAttachmentType(attachmentType, viewModel);
            }
            attachmentType.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }
    }
}