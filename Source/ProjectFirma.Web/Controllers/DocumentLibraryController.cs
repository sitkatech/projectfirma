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
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.DocumentLibrary;
using ProjectFirma.Web.Views.Shared;
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
            var fundingSources = HttpRequestStorage.DatabaseEntities.DocumentLibraries
                .ToList()
                .OrderBy(x => x.DocumentLibraryName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<DocumentLibrary>(fundingSources, gridSpec);
            return gridJsonNetJObjectResult;
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
            var documentLibraryDocumentCategories = HttpRequestStorage.DatabaseEntities.DocumentLibraryDocumentCategories.ToList();

            viewModel.UpdateModel(documentLibrary, documentLibraryDocumentCategories);
            HttpRequestStorage.DatabaseEntities.AllDocumentLibraries.Add(documentLibrary);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"Document Library {documentLibrary.DocumentLibraryName} successfully created.");

            return new ModalDialogFormJsonResult();
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
            var documentLibraryDocumentCategories = HttpRequestStorage.DatabaseEntities.DocumentLibraryDocumentCategories.ToList();

            viewModel.UpdateModel(documentLibrary, documentLibraryDocumentCategories);
            SetMessageForDisplay($"Document Library {documentLibrary.DocumentLibraryName} successfully updated.");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var allCustomPages = HttpRequestStorage.DatabaseEntities.CustomPages.ToList();
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
            var numberOfDocumentAssociated = 0; // todo get count of FileResources for the DocumentLibrary
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

            documentLibrary.DeleteFull(HttpRequestStorage.DatabaseEntities);

            SetMessageForDisplay($"Document Library '{name}' successfully deleted.");
            return new ModalDialogFormJsonResult();
        }
    }
}