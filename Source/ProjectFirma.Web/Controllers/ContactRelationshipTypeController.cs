/*-----------------------------------------------------------------------
<copyright file="ContactRelationshipTypeController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ContactRelationshipType;

namespace ProjectFirma.Web.Controllers
{
    public class ContactRelationshipTypeController : FirmaBaseController
    {
        [ContactRelationshipTypeViewFeature]
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

        [ContactRelationshipTypeViewFeature]
        public GridJsonNetJObjectResult<ContactRelationshipType> ContactRelationshipTypeGridJsonData()
        {
            var hasManagePermissions = new ContactRelationshipTypeManageFeature().HasPermissionByPerson(CurrentPerson);
            var gridSpec = new ContactRelationshipTypeGridSpec(hasManagePermissions);
            var contactRelationshipTypes = HttpRequestStorage.DatabaseEntities.ContactRelationshipTypes.ToList().OrderBy(x => x.ContactRelationshipTypeName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ContactRelationshipType>(contactRelationshipTypes, gridSpec);
            return gridJsonNetJObjectResult;
        }


        [HttpGet]
        [ContactRelationshipTypeManageFeature]
        public PartialViewResult NewContactRelationshipType()
        {
            var viewModel = new EditContactRelationshipTypeViewModel();
            return ViewNewContactRelationshipType(viewModel);
        }

        [HttpPost]
        [ContactRelationshipTypeManageFeature]
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

            viewModel.UpdateModel(relationshipType);
            
            SetMessageForDisplay(
                $"New {FieldDefinitionEnum.ProjectContactRelationshipType.ToType().GetFieldDefinitionLabel()} {relationshipType.ContactRelationshipTypeName} successfully created!");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ContactRelationshipTypeManageFeature]
        public PartialViewResult EditContactRelationshipType(ContactRelationshipTypePrimaryKey contactRelationshipTypePrimaryKey)
        {
            var contactRelationshipType = contactRelationshipTypePrimaryKey.EntityObject;
            var viewModel = new EditContactRelationshipTypeViewModel(contactRelationshipType);
            return ViewEditContactRelationshipType(viewModel);
        }

        [HttpPost]
        [ContactRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditContactRelationshipType(ContactRelationshipTypePrimaryKey contactRelationshipTypePrimaryKey, EditContactRelationshipTypeViewModel viewModel)
        {
            var relationshipType = contactRelationshipTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditContactRelationshipType(viewModel);
            }

            viewModel.UpdateModel(relationshipType);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNewContactRelationshipType(EditContactRelationshipTypeViewModel viewModel)
        {
            return ViewEditContactRelationshipType(viewModel);
        }

        private PartialViewResult ViewEditContactRelationshipType(EditContactRelationshipTypeViewModel viewModel)
        {
            var viewData = new EditContactRelationshipTypeViewData();
            return RazorPartialView<EditContactRelationshipType, EditContactRelationshipTypeViewData, EditContactRelationshipTypeViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ContactRelationshipTypeManageFeature]
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
                ? $"Are you sure you want to delete this {FieldDefinitionEnum.ProjectContactRelationshipType.ToType().GetFieldDefinitionLabel()} '{contactRelationshipType.ContactRelationshipTypeName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(FieldDefinitionEnum.ProjectContactRelationshipType.ToType().GetFieldDefinitionLabel(), SitkaRoute<ContactRelationshipTypeController>.BuildLinkFromExpression(x => x.Index(), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ContactRelationshipTypeManageFeature]
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
