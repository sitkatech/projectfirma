using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.AttachmentRelationshipType;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class AttachmentRelationshipTypeController : FirmaBaseController
    {
        [AttachmentRelationshipTypeViewFeature]
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

        [AttachmentRelationshipTypeViewFeature]
        public GridJsonNetJObjectResult<AttachmentRelationshipType> AttachmentRelationshipTypeGridJsonData()
        {
            var hasManagePermissions = new AttachmentRelationshipTypeManageFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            var gridSpec = new AttachmentRelationshipTypeGridSpec(hasManagePermissions);
            var attachmentRelationshipTypes = HttpRequestStorage.DatabaseEntities.AttachmentRelationshipTypes.ToList().OrderBy(x => x.AttachmentRelationshipTypeName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<AttachmentRelationshipType>(attachmentRelationshipTypes, gridSpec);
            return gridJsonNetJObjectResult;
        }


        [HttpGet]
        [AttachmentRelationshipTypeManageFeature]
        public PartialViewResult NewAttachmentRelationshipType()
        {
            var viewModel = new EditAttachmentRelationshipTypeViewModel();
            return ViewNewAttachmentRelationshipType(viewModel);
        }

        [HttpPost]
        [AttachmentRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewAttachmentRelationshipType(EditAttachmentRelationshipTypeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNewAttachmentRelationshipType(viewModel);
            }

            var relationshipType = new AttachmentRelationshipType(viewModel.AttachmentRelationshipTypeName, viewModel.MaxFileSize);
            
            HttpRequestStorage.DatabaseEntities.AllAttachmentRelationshipTypes.Add(relationshipType);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            HttpRequestStorage.DatabaseEntities.AttachmentRelationshipTypeFileResourceMimeTypes.Load();
            var relationshipTypeFileResourceMimeTypes = HttpRequestStorage.DatabaseEntities.AllAttachmentRelationshipTypeFileResourceMimeTypes.Local;

            HttpRequestStorage.DatabaseEntities.AttachmentRelationshipTypeTaxonomyTrunks.Load();
            var relationshipTypeTaxonomyTrunks = HttpRequestStorage.DatabaseEntities.AllAttachmentRelationshipTypeTaxonomyTrunks.Local;

            viewModel.UpdateModel(relationshipType, relationshipTypeFileResourceMimeTypes, relationshipTypeTaxonomyTrunks);
            
            SetMessageForDisplay(
                $"New {FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel()} {relationshipType.AttachmentRelationshipTypeName} successfully created!");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [AttachmentRelationshipTypeManageFeature]
        public PartialViewResult EditAttachmentRelationshipType(AttachmentRelationshipTypePrimaryKey attachmentRelationshipTypePrimaryKey)
        {
            var attachmentRelationshipType = attachmentRelationshipTypePrimaryKey.EntityObject;
            var viewModel = new EditAttachmentRelationshipTypeViewModel(attachmentRelationshipType);
            return ViewEditAttachmentRelationshipType(viewModel);
        }

        [HttpPost]
        [AttachmentRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditAttachmentRelationshipType(AttachmentRelationshipTypePrimaryKey attachmentRelationshipTypePrimaryKey, EditAttachmentRelationshipTypeViewModel viewModel)
        {
            var relationshipType = attachmentRelationshipTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditAttachmentRelationshipType(viewModel);
            }

            HttpRequestStorage.DatabaseEntities.AttachmentRelationshipTypeFileResourceMimeTypes.Load();
            var relationshipTypeFileResourceMimeTypes = HttpRequestStorage.DatabaseEntities.AllAttachmentRelationshipTypeFileResourceMimeTypes.Local;

            HttpRequestStorage.DatabaseEntities.AttachmentRelationshipTypeTaxonomyTrunks.Load();
            var relationshipTypeTaxonomyTrunks = HttpRequestStorage.DatabaseEntities.AllAttachmentRelationshipTypeTaxonomyTrunks.Local;

            viewModel.UpdateModel(relationshipType, relationshipTypeFileResourceMimeTypes, relationshipTypeTaxonomyTrunks);

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNewAttachmentRelationshipType(EditAttachmentRelationshipTypeViewModel viewModel)
        {
            return ViewEditAttachmentRelationshipType(viewModel);
        }

        private PartialViewResult ViewEditAttachmentRelationshipType(EditAttachmentRelationshipTypeViewModel viewModel)
        {
            var allTaxonomyTrunks = HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.ToList();
            bool hasTaxonomyTrunks = MultiTenantHelpers.IsTaxonomyLevelTrunk();

            var viewData = new EditAttachmentRelationshipTypeViewData(FileResourceMimeType.All, allTaxonomyTrunks, hasTaxonomyTrunks);
            return RazorPartialView<EditAttachmentRelationshipType, EditAttachmentRelationshipTypeViewData, EditAttachmentRelationshipTypeViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [AttachmentRelationshipTypeManageFeature]
        public PartialViewResult DeleteAttachmentRelationshipType(AttachmentRelationshipTypePrimaryKey attachmentRelationshipTypePrimaryKey)
        {
            var attachmentRelationshipType = attachmentRelationshipTypePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(attachmentRelationshipType.AttachmentRelationshipTypeID);
            return ViewDeleteRelationshipType(attachmentRelationshipType, viewModel);
        }

        private PartialViewResult ViewDeleteRelationshipType(AttachmentRelationshipType attachmentRelationshipType, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = attachmentRelationshipType.CanDelete();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this {FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel()} '{attachmentRelationshipType.AttachmentRelationshipTypeName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel(), SitkaRoute<AttachmentRelationshipTypeController>.BuildLinkFromExpression(x => x.Index(), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [AttachmentRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteAttachmentRelationshipType(AttachmentRelationshipTypePrimaryKey attachmentRelationshipTypePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var attachmentRelationshipType = attachmentRelationshipTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteRelationshipType(attachmentRelationshipType, viewModel);
            }
            attachmentRelationshipType.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }
    }
}