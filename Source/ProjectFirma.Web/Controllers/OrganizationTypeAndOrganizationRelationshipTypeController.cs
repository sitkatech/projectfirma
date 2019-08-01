/*-----------------------------------------------------------------------
<copyright file="TaxonomyBranchController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Views.OrganizationTypeAndOrganizationRelationshipType;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Controllers
{
    public class OrganizationTypeAndOrganizationRelationshipTypeController : FirmaBaseController
    {
        [OrganizationAndRelationshipTypeViewFeature]
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

        [OrganizationAndRelationshipTypeViewFeature]
        public GridJsonNetJObjectResult<OrganizationType> OrganizationTypeGridJsonData()
        {
            var hasManagePermissions = new OrganizationAndRelationshipTypeManageFeature().HasPermissionByPerson(CurrentPerson);
            var gridSpec = new OrganizationTypeGridSpec(hasManagePermissions);
            var organizationTypes = HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList().OrderBy(x => x.OrganizationTypeName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<OrganizationType>(organizationTypes, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [OrganizationAndRelationshipTypeViewFeature]
        public GridJsonNetJObjectResult<OrganizationRelationshipType> OrganizationRelationshipTypeGridJsonData()
        {
            var hasManagePermissions = new OrganizationAndRelationshipTypeManageFeature().HasPermissionByPerson(CurrentPerson);
            var gridSpec = new OrganizationRelationshipTypeGridSpec(hasManagePermissions, HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList());
            var organizationRelationshipTypes = HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes.ToList().OrderBy(x => x.OrganizationRelationshipTypeName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<OrganizationRelationshipType>(organizationRelationshipTypes, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [OrganizationAndRelationshipTypeManageFeature]
        public PartialViewResult NewOrganizationType()
        {
            var viewModel = new EditOrganizationTypeViewModel();
            return ViewNewOrganizationType(viewModel);
        }

        [HttpPost]
        [OrganizationAndRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewOrganizationType(EditOrganizationTypeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNewOrganizationType(viewModel);
            }
            var organizationType = new OrganizationType(viewModel.OrganizationTypeName, viewModel.OrganizationTypeAbbreviation, viewModel.LegendColor, viewModel.ShowOnProjectMaps ?? false, viewModel.IsDefaultOrganizationType ?? false, viewModel.IsFundingType ?? false);
            viewModel.UpdateModel(organizationType, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllOrganizationTypes.Add(organizationType);

            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay(
                $"New {FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabel()} {organizationType.OrganizationTypeName} successfully created!");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [OrganizationAndRelationshipTypeManageFeature]
        public PartialViewResult EditOrganizationType(OrganizationTypePrimaryKey organizationTypePrimaryKey)
        {
            var organizationType = organizationTypePrimaryKey.EntityObject;
            var viewModel = new EditOrganizationTypeViewModel(organizationType);
            return ViewEditOrganizationType(viewModel);
        }

        [HttpPost]
        [OrganizationAndRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditOrganizationType(OrganizationTypePrimaryKey organizationTypePrimaryKey, EditOrganizationTypeViewModel viewModel)
        {
            var organizationType = organizationTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditOrganizationType(viewModel);
            }
            viewModel.UpdateModel(organizationType, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNewOrganizationType(EditOrganizationTypeViewModel viewModel)
        {
            return ViewEditOrganizationType(viewModel);
        }

        private PartialViewResult ViewEditOrganizationType(EditOrganizationTypeViewModel viewModel)
        {            
            var viewData = new EditOrganizationTypeViewData();
            return RazorPartialView<EditOrganizationType, EditOrganizationTypeViewData, EditOrganizationTypeViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [OrganizationAndRelationshipTypeManageFeature]
        public PartialViewResult DeleteOrganizationType(OrganizationTypePrimaryKey organizationTypePrimaryKey)
        {
            var organizationType = organizationTypePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(organizationType.OrganizationTypeID);
            return ViewDeleteOrganizationType(organizationType, viewModel);
        }

        private PartialViewResult ViewDeleteOrganizationType(OrganizationType organizationType, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !organizationType.HasDependentObjects();
            var fieldDefinitionLabel = FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabel();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this {fieldDefinitionLabel} '{organizationType.OrganizationTypeName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(fieldDefinitionLabel, SitkaRoute<OrganizationTypeAndOrganizationRelationshipTypeController>.BuildLinkFromExpression(x => x.Index(), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [OrganizationAndRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteOrganizationType(OrganizationTypePrimaryKey organizationTypePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var organizationType = organizationTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteOrganizationType(organizationType, viewModel);
            }
            organizationType.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [OrganizationAndRelationshipTypeManageFeature]
        public PartialViewResult NewOrganizationRelationshipType()
        {
            var viewModel = new EditOrganizationRelationshipTypeViewModel();
            return ViewNewOrganizationRelationshipType(viewModel);
        }

        [HttpPost]
        [OrganizationAndRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewOrganizationRelationshipType(EditOrganizationRelationshipTypeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNewOrganizationRelationshipType(viewModel);
            }
            var relationshipType = new OrganizationRelationshipType(viewModel.OrganizationRelationshipTypeName, false, false, false, false, false);
            HttpRequestStorage.DatabaseEntities.AllOrganizationRelationshipTypes.Add(relationshipType);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            HttpRequestStorage.DatabaseEntities.OrganizationTypeOrganizationRelationshipTypes.Load();
            var organizationTypeRelationshipTypes = HttpRequestStorage.DatabaseEntities.AllOrganizationTypeOrganizationRelationshipTypes.Local;

            viewModel.UpdateModel(relationshipType, organizationTypeRelationshipTypes);
            
            SetMessageForDisplay(
                $"New {FieldDefinitionEnum.ProjectOrganizationRelationshipType.ToType().GetFieldDefinitionLabel()} {relationshipType.OrganizationRelationshipTypeName} successfully created!");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [OrganizationAndRelationshipTypeManageFeature]
        public PartialViewResult EditOrganizationRelationshipType(OrganizationRelationshipTypePrimaryKey organizationRelationshipTypePrimaryKey)
        {
            var organizationRelationshipType = organizationRelationshipTypePrimaryKey.EntityObject;
            var viewModel = new EditOrganizationRelationshipTypeViewModel(organizationRelationshipType);
            return ViewEditOrganizationRelationshipType(viewModel);
        }

        [HttpPost]
        [OrganizationAndRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditOrganizationRelationshipType(OrganizationRelationshipTypePrimaryKey organizationRelationshipTypePrimaryKey, EditOrganizationRelationshipTypeViewModel viewModel)
        {
            var relationshipType = organizationRelationshipTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditOrganizationRelationshipType(viewModel);
            }

            HttpRequestStorage.DatabaseEntities.OrganizationTypeOrganizationRelationshipTypes.Load();
            var organizationTypeRelationshipTypes = HttpRequestStorage.DatabaseEntities.AllOrganizationTypeOrganizationRelationshipTypes.Local;

            viewModel.UpdateModel(relationshipType, organizationTypeRelationshipTypes);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNewOrganizationRelationshipType(EditOrganizationRelationshipTypeViewModel viewModel)
        {
            return ViewEditOrganizationRelationshipType(viewModel);
        }

        private PartialViewResult ViewEditOrganizationRelationshipType(EditOrganizationRelationshipTypeViewModel viewModel)
        {
            var allOrganizationTypes = HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList();
            var viewData = new EditOrganizationRelationshipTypeViewData(allOrganizationTypes);
            return RazorPartialView<EditOrganizationRelationshipType, EditOrganizationRelationshipTypeViewData, EditOrganizationRelationshipTypeViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [OrganizationAndRelationshipTypeManageFeature]
        public PartialViewResult DeleteOrganizationRelationshipType(OrganizationRelationshipTypePrimaryKey organizationRelationshipTypePrimaryKey)
        {
            var organizationRelationshipType = organizationRelationshipTypePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(organizationRelationshipType.OrganizationRelationshipTypeID);
            return ViewDeleteRelationshipType(organizationRelationshipType, viewModel);
        }

        private PartialViewResult ViewDeleteRelationshipType(OrganizationRelationshipType organizationRelationshipType, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = organizationRelationshipType.CanDelete();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this {FieldDefinitionEnum.ProjectOrganizationRelationshipType.ToType().GetFieldDefinitionLabel()} '{organizationRelationshipType.OrganizationRelationshipTypeName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(FieldDefinitionEnum.ProjectOrganizationRelationshipType.ToType().GetFieldDefinitionLabel(), SitkaRoute<OrganizationTypeAndOrganizationRelationshipTypeController>.BuildLinkFromExpression(x => x.Index(), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [OrganizationAndRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteOrganizationRelationshipType(OrganizationRelationshipTypePrimaryKey organizationRelationshipTypePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var organizationRelationshipType = organizationRelationshipTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteRelationshipType(organizationRelationshipType, viewModel);
            }
            organizationRelationshipType.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }
    }
}
