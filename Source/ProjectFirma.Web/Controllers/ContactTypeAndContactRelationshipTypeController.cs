/*-----------------------------------------------------------------------
<copyright file="ContactTypeAndContactRelationshipTypeController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Views.ContactTypeAndContactRelationshipType;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Controllers
{
    public class ContactTypeAndContactRelationshipTypeController : FirmaBaseController
    {
        [ContactAndContactRelationshipTypeViewFeature]
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
            var viewData = new IndexViewData(CurrentPerson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [ContactAndContactRelationshipTypeViewFeature]
        public GridJsonNetJObjectResult<ContactType> ContactTypeGridJsonData()
        {
            var hasManagePermissions = new ContactAndContactRelationshipTypeManageFeature().HasPermissionByPerson(CurrentPerson);
            var gridSpec = new ContactTypeGridSpec(hasManagePermissions);
            var contactTypes = HttpRequestStorage.DatabaseEntities.ContactTypes.ToList().OrderBy(x => x.ContactTypeName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ContactType>(contactTypes, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [ContactAndContactRelationshipTypeViewFeature]
        public GridJsonNetJObjectResult<ContactRelationshipType> ContactRelationshipTypeGridJsonData()
        {
            var hasManagePermissions = new ContactAndContactRelationshipTypeManageFeature().HasPermissionByPerson(CurrentPerson);
            var gridSpec = new ContactRelationshipTypeGridSpec(hasManagePermissions, HttpRequestStorage.DatabaseEntities.ContactTypes.ToList());
            var contactRelationshipTypes = HttpRequestStorage.DatabaseEntities.ContactRelationshipTypes.ToList().OrderBy(x => x.ContactRelationshipTypeName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ContactRelationshipType>(contactRelationshipTypes, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [ContactAndContactRelationshipTypeManageFeature]
        public PartialViewResult NewContactType()
        {
            var viewModel = new EditContactTypeViewModel();
            return ViewNewContactType(viewModel);
        }

        [HttpPost]
        [ContactAndContactRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewContactType(EditContactTypeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNewContactType(viewModel);
            }
            var contactType = new ContactType(viewModel.ContactTypeName, viewModel.ContactTypeAbbreviation, viewModel.IsDefaultContactType ?? false);
            viewModel.UpdateModel(contactType, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllContactTypes.Add(contactType);

            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay(
                $"New {FieldDefinitionEnum.ContactType.ToType().GetFieldDefinitionLabel()} {contactType.ContactTypeName} successfully created!");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ContactAndContactRelationshipTypeManageFeature]
        public PartialViewResult EditContactType(ContactTypePrimaryKey contactTypePrimaryKey)
        {
            var contactType = contactTypePrimaryKey.EntityObject;
            var viewModel = new EditContactTypeViewModel(contactType);
            return ViewEditContactType(viewModel);
        }

        [HttpPost]
        [ContactAndContactRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditContactType(ContactTypePrimaryKey contactTypePrimaryKey, EditContactTypeViewModel viewModel)
        {
            var contactType = contactTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditContactType(viewModel);
            }
            viewModel.UpdateModel(contactType, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNewContactType(EditContactTypeViewModel viewModel)
        {
            return ViewEditContactType(viewModel);
        }

        private PartialViewResult ViewEditContactType(EditContactTypeViewModel viewModel)
        {            
            var viewData = new EditContactTypeViewData();
            return RazorPartialView<EditContactType, EditContactTypeViewData, EditContactTypeViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ContactAndContactRelationshipTypeManageFeature]
        public PartialViewResult DeleteContactType(ContactTypePrimaryKey contactTypePrimaryKey)
        {
            var contactType = contactTypePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(contactType.ContactTypeID);
            return ViewDeleteContactType(contactType, viewModel);
        }

        private PartialViewResult ViewDeleteContactType(ContactType contactType, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !contactType.HasDependentObjects();
            var fieldDefinitionLabel = FieldDefinitionEnum.ContactType.ToType().GetFieldDefinitionLabel();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this {fieldDefinitionLabel} '{contactType.ContactTypeName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(fieldDefinitionLabel, SitkaRoute<ContactTypeAndContactRelationshipTypeController>.BuildLinkFromExpression(x => x.Index(), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ContactAndContactRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteContactType(ContactTypePrimaryKey contactTypePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var contactType = contactTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteContactType(contactType, viewModel);
            }
            contactType.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ContactAndContactRelationshipTypeManageFeature]
        public PartialViewResult NewContactRelationshipType()
        {
            var viewModel = new EditContactRelationshipTypeViewModel();
            return ViewNewContactRelationshipType(viewModel);
        }

        [HttpPost]
        [ContactAndContactRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewContactRelationshipType(EditContactRelationshipTypeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNewContactRelationshipType(viewModel);
            }
            var relationshipType = new ContactRelationshipType(viewModel.ContactRelationshipTypeName, false);
            HttpRequestStorage.DatabaseEntities.AllContactRelationshipTypes.Add(relationshipType);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            HttpRequestStorage.DatabaseEntities.ContactTypeContactRelationshipTypes.Load();
            var contactTypeRelationshipTypes = HttpRequestStorage.DatabaseEntities.AllContactTypeContactRelationshipTypes.Local;

            viewModel.UpdateModel(relationshipType, contactTypeRelationshipTypes);
            
            SetMessageForDisplay(
                $"New {FieldDefinitionEnum.ProjectRelationshipType.ToType().GetFieldDefinitionLabel()} {relationshipType.ContactRelationshipTypeName} successfully created!");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ContactAndContactRelationshipTypeManageFeature]
        public PartialViewResult EditContactRelationshipType(ContactRelationshipTypePrimaryKey contactRelationshipTypePrimaryKey)
        {
            var contactRelationshipType = contactRelationshipTypePrimaryKey.EntityObject;
            var viewModel = new EditContactRelationshipTypeViewModel(contactRelationshipType);
            return ViewEditContactRelationshipType(viewModel);
        }

        [HttpPost]
        [ContactAndContactRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditContactRelationshipType(ContactRelationshipTypePrimaryKey contactRelationshipTypePrimaryKey, EditContactRelationshipTypeViewModel viewModel)
        {
            var relationshipType = contactRelationshipTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditContactRelationshipType(viewModel);
            }

            HttpRequestStorage.DatabaseEntities.ContactTypeContactRelationshipTypes.Load();
            var contactTypeRelationshipTypes = HttpRequestStorage.DatabaseEntities.AllContactTypeContactRelationshipTypes.Local;

            viewModel.UpdateModel(relationshipType, contactTypeRelationshipTypes);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNewContactRelationshipType(EditContactRelationshipTypeViewModel viewModel)
        {
            return ViewEditContactRelationshipType(viewModel);
        }

        private PartialViewResult ViewEditContactRelationshipType(EditContactRelationshipTypeViewModel viewModel)
        {
            var allContactTypes = HttpRequestStorage.DatabaseEntities.ContactTypes.ToList();
            var viewData = new EditContactRelationshipTypeViewData(allContactTypes);
            return RazorPartialView<EditContactRelationshipType, EditContactRelationshipTypeViewData, EditContactRelationshipTypeViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ContactAndContactRelationshipTypeManageFeature]
        public PartialViewResult DeleteContactRelationshipType(ContactRelationshipTypePrimaryKey contactRelationshipTypePrimaryKey)
        {
            var contactRelationshipType = contactRelationshipTypePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(contactRelationshipType.ContactRelationshipTypeID);
            return ViewDeleteRelationshipType(contactRelationshipType, viewModel);
        }

        private PartialViewResult ViewDeleteRelationshipType(ContactRelationshipType contactRelationshipType, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = contactRelationshipType.CanDelete();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this {FieldDefinitionEnum.ProjectRelationshipType.ToType().GetFieldDefinitionLabel()} '{contactRelationshipType.ContactRelationshipTypeName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(FieldDefinitionEnum.ProjectRelationshipType.ToType().GetFieldDefinitionLabel(), SitkaRoute<ContactTypeAndContactRelationshipTypeController>.BuildLinkFromExpression(x => x.Index(), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ContactAndContactRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteContactRelationshipType(ContactRelationshipTypePrimaryKey contactRelationshipTypePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var contactRelationshipType = contactRelationshipTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteRelationshipType(contactRelationshipType, viewModel);
            }
            contactRelationshipType.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }
    }
}
