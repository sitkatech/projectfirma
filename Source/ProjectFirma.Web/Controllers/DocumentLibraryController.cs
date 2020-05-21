/*-----------------------------------------------------------------------
<copyright file="DocumentLibraryController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.DocumentLibrary;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class DocumentLibraryController : FirmaBaseController
    {
        [DocumentLibraryManageFeature]
        public ViewResult Index()
        {
            var viewData = new IndexViewData(CurrentFirmaSession);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [DocumentLibraryManageFeature]
        public GridJsonNetJObjectResult<DocumentLibrary> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(new DocumentLibraryManageFeature().HasPermissionByFirmaSession(CurrentFirmaSession));
            var documentLibraries = HttpRequestStorage.DatabaseEntities.DocumentLibraries
                .ToList()
                .OrderBy(x => x.DocumentLibraryName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<DocumentLibrary>(documentLibraries, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [DocumentLibraryManageFeature]
        public ViewResult Detail(DocumentLibraryPrimaryKey documentLibraryPrimaryKey)
        {
            var documentLibrary = documentLibraryPrimaryKey.EntityObject;
            var viewData = new DetailViewData(CurrentFirmaSession, documentLibrary);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [HttpGet]
        [DocumentLibraryManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [DocumentLibraryManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var documentLibrary = new DocumentLibrary(
                ModelObjectHelpers.NotYetAssignedID, // Should never be null due to View Model validation
                string.Empty,
                null);

            HttpRequestStorage.DatabaseEntities.DocumentLibraryDocumentCategories.Load();
            var documentLibraryDocumentCategories = HttpRequestStorage.DatabaseEntities.AllDocumentLibraryDocumentCategories.Local;

            viewModel.UpdateModel(documentLibrary, documentLibraryDocumentCategories);
            HttpRequestStorage.DatabaseEntities.AllDocumentLibraries.Add(documentLibrary);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"Document Library '{documentLibrary.DocumentLibraryName}' successfully created.");
            return new ModalDialogFormJsonResult(documentLibrary.GetDetailUrl());
        }

        [HttpGet]
        [DocumentLibraryManageFeature]
        public PartialViewResult Edit(DocumentLibraryPrimaryKey documentLibraryPrimaryKey)
        {
            var documentLibrary = documentLibraryPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(documentLibrary);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [DocumentLibraryManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(DocumentLibraryPrimaryKey documentLibraryPrimaryKey, EditViewModel viewModel)
        {
            var documentLibrary = documentLibraryPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }

            HttpRequestStorage.DatabaseEntities.DocumentLibraryDocumentCategories.Load();
            var documentLibraryDocumentCategories = HttpRequestStorage.DatabaseEntities.AllDocumentLibraryDocumentCategories.Local;

            viewModel.UpdateModel(documentLibrary, documentLibraryDocumentCategories);
            SetMessageForDisplay($"Document Library '{documentLibrary.DocumentLibraryName}' successfully updated.");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var allCustomPages = HttpRequestStorage.DatabaseEntities.CustomPages.Where(x => x.CustomPageDisplayTypeID != CustomPageDisplayType.Disabled.CustomPageDisplayTypeID).ToList();
            var viewData = new EditViewData(DocumentCategory.All, allCustomPages);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [DocumentLibraryManageFeature]
        public PartialViewResult DeleteDocumentLibrary(DocumentLibraryPrimaryKey documentLibraryPrimaryKey)
        {
            var documentLibrary = documentLibraryPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(documentLibrary.DocumentLibraryID);
            return ViewDeleteDocumentLibrary(documentLibrary, viewModel);
        }

        private PartialViewResult ViewDeleteDocumentLibrary(DocumentLibrary documentLibrary, ConfirmDialogFormViewModel viewModel)
        {
            var numberOfDocumentAssociated = documentLibrary.DocumentLibraryDocuments.Count;
            var confirmMessage = numberOfDocumentAssociated > 0 ?
                $"This Document Library has {numberOfDocumentAssociated} documents. Deleting the Document Library will delete all associated documents. Are you sure you wish to delete Document Library '{documentLibrary.DocumentLibraryName}'?" :
                $"Are you sure you wish to delete Document Library '{documentLibrary.DocumentLibraryName}'?";

            var viewData = new ConfirmDialogFormViewData(confirmMessage);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [DocumentLibraryManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteDocumentLibrary(DocumentLibraryPrimaryKey documentLibraryPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var documentLibrary = documentLibraryPrimaryKey.EntityObject;
            var name = documentLibrary.DocumentLibraryName;
            if (!ModelState.IsValid)
            {
                return ViewDeleteDocumentLibrary(documentLibrary, viewModel);
            }

            // unset document library from Custom Page
            foreach (var documentLibraryCustomPage in documentLibrary.CustomPages)
            {
                documentLibraryCustomPage.DocumentLibraryID = null;
            }
            documentLibrary.CustomPages = new List<CustomPage>();
            documentLibrary.DeleteFull(HttpRequestStorage.DatabaseEntities);

            SetMessageForDisplay($"Document Library '{name}' successfully deleted.");
            return new ModalDialogFormJsonResult();
        }

        [DocumentLibraryManageFeature]
        public GridJsonNetJObjectResult<DocumentLibraryDocument> DocumentLibraryDocumentGridJsonData(DocumentLibraryPrimaryKey documentLibraryPrimary)
        {
            var gridSpec = new DocumentLibraryDocumentGridSpec(new DocumentLibraryManageFeature().HasPermissionByFirmaSession(CurrentFirmaSession));
            var documentLibrary = documentLibraryPrimary.EntityObject;
            var documentLibraryDocuments =
                documentLibrary.DocumentLibraryDocuments.ToList().OrderBy(x => x.SortOrder).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<DocumentLibraryDocument>(documentLibraryDocuments, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [DocumentLibraryManageFeature]
        public PartialViewResult NewDocument(DocumentLibraryPrimaryKey documentLibraryPrimaryKey)
        {
            var documentLibrary = documentLibraryPrimaryKey.EntityObject;
            var viewModel = new NewDocumentViewModel(documentLibrary);
            return ViewNewDocument(documentLibrary, viewModel);
        }

        private PartialViewResult ViewNewDocument(DocumentLibrary documentLibrary, NewDocumentViewModel viewModel)
        {
            var documentCategories = documentLibrary.DocumentLibraryDocumentCategories.Select(x => x.DocumentCategory)
                .ToSelectListWithEmptyFirstRow(x => x.DocumentCategoryID.ToString(CultureInfo.InvariantCulture), x => x.DocumentCategoryDisplayName);
            var viewData = new NewDocumentViewData(documentCategories);
            return RazorPartialView<NewDocument, NewDocumentViewData, NewDocumentViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [DocumentLibraryManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewDocument(DocumentLibraryPrimaryKey documentLibraryPrimaryKey, NewDocumentViewModel viewModel)
        {
            var documentLibrary = documentLibraryPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewNewDocument(documentLibrary, viewModel);
            }
            var document = new DocumentLibraryDocument(default(int), default(int), null, default(int), DateTime.Now, CurrentPerson.PersonID);

            HttpRequestStorage.DatabaseEntities.DocumentLibraryDocumentRoles.Load();
            var documentLibraryDocumentRoles = HttpRequestStorage.DatabaseEntities.AllDocumentLibraryDocumentRoles.Local;

            viewModel.UpdateModel(document, CurrentFirmaSession, documentLibraryDocumentRoles);
            HttpRequestStorage.DatabaseEntities.AllDocumentLibraryDocuments.Add(document);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"Document '{document.DocumentTitle}' successfully uploaded.");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [DocumentLibraryManageFeature]
        public PartialViewResult EditDocument(DocumentLibraryDocumentPrimaryKey documentLibraryDocumentPrimaryKey)
        {
            var documentLibraryDocument = documentLibraryDocumentPrimaryKey.EntityObject;
            var viewModel = new EditDocumentViewModel(documentLibraryDocument);
            return ViewEditDocument(documentLibraryDocument, viewModel);
        }

        private PartialViewResult ViewEditDocument(DocumentLibraryDocument documentLibraryDocument, EditDocumentViewModel viewModel)
        {
            var documentCategories = documentLibraryDocument.DocumentLibrary.DocumentLibraryDocumentCategories.Select(x => x.DocumentCategory)
                .ToSelectListWithEmptyFirstRow(x => x.DocumentCategoryID.ToString(CultureInfo.InvariantCulture), x => x.DocumentCategoryDisplayName);
            var viewData = new EditDocumentViewData(documentCategories);
            return RazorPartialView<EditDocument, EditDocumentViewData, EditDocumentViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [DocumentLibraryManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditDocument(DocumentLibraryDocumentPrimaryKey documentLibraryDocumentPrimaryKey, EditDocumentViewModel viewModel)
        {
            var documentLibraryDocument = documentLibraryDocumentPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditDocument(documentLibraryDocument, viewModel);
            }

            HttpRequestStorage.DatabaseEntities.DocumentLibraryDocumentRoles.Load();
            var documentLibraryDocumentRoles = HttpRequestStorage.DatabaseEntities.AllDocumentLibraryDocumentRoles.Local;

            viewModel.UpdateModel(documentLibraryDocument, CurrentFirmaSession, documentLibraryDocumentRoles);
            SetMessageForDisplay($"Document '{documentLibraryDocument.DocumentTitle}' successfully updated.");
            return new ModalDialogFormJsonResult();
        }


        [DocumentLibraryManageFeature]
        public PartialViewResult EditDocumentSortOrder(DocumentLibraryPrimaryKey documentLibraryPrimaryKey)
        {
            var classificationSystem = documentLibraryPrimaryKey.EntityObject;
            EditSortOrderViewModel viewModel = new EditSortOrderViewModel();
            return ViewEditDocumentSortOrder(classificationSystem, viewModel);
        }

        private PartialViewResult ViewEditDocumentSortOrder(DocumentLibrary documentLibrary, EditSortOrderViewModel viewModel)
        {
            EditSortOrderViewData viewData = new EditSortOrderViewData(new List<IHaveASortOrder>(documentLibrary.DocumentLibraryDocuments), "Documents");
            return RazorPartialView<EditSortOrder, EditSortOrderViewData, EditSortOrderViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [DocumentLibraryManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditDocumentSortOrder(DocumentLibraryPrimaryKey documentLibraryPrimaryKey, EditSortOrderViewModel viewModel)
        {

            var documentLibrary = documentLibraryPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditDocumentSortOrder(documentLibrary, viewModel);
            }

            viewModel.UpdateModel(new List<IHaveASortOrder>(documentLibrary.DocumentLibraryDocuments));
            SetMessageForDisplay("Successfully Updated Document Sort Order");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [DocumentLibraryManageFeature]
        public PartialViewResult DeleteDocument(DocumentLibraryDocumentPrimaryKey documentLibraryDocumentPrimaryKey)
        {
            var documentLibraryDocument = documentLibraryDocumentPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(documentLibraryDocument.DocumentLibraryDocumentID);
            return ViewDeleteDocument(documentLibraryDocument, viewModel);
        }

        private PartialViewResult ViewDeleteDocument(DocumentLibraryDocument documentLibraryDocument, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage = $"Are you sure you wish to delete Document '{documentLibraryDocument.DocumentTitle}'?";

            var viewData = new ConfirmDialogFormViewData(confirmMessage);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [DocumentLibraryManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteDocument(DocumentLibraryDocumentPrimaryKey documentLibraryDocumentPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var documentLibraryDocument = documentLibraryDocumentPrimaryKey.EntityObject;
            var name = documentLibraryDocument.DocumentTitle;
            if (!ModelState.IsValid)
            {
                return ViewDeleteDocument(documentLibraryDocument, viewModel);
            }

            documentLibraryDocument.DeleteFull(HttpRequestStorage.DatabaseEntities);

            SetMessageForDisplay($"Document '{name}' successfully deleted.");
            return new ModalDialogFormJsonResult();
        }
    }
}