/*-----------------------------------------------------------------------
<copyright file="FieldDefinitionController.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.FieldDefinition;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class FieldDefinitionController : FirmaBaseController
    {
        [FieldDefinitionViewListFeature]
        [CrossAreaRoute]
        public ViewResult Index()
        {
            var viewData = new IndexViewData(CurrentPerson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [FieldDefinitionViewListFeature]
        [CrossAreaRoute]
        public GridJsonNetJObjectResult<FieldDefinition> IndexGridJsonData()
        {
            FieldDefinitionGridSpec gridSpec;
            var actions = GetFieldDefinitionsAndGridSpec(out gridSpec, CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<FieldDefinition>(actions, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<FieldDefinition> GetFieldDefinitionsAndGridSpec(out FieldDefinitionGridSpec gridSpec, Person currentPerson)
        {
            gridSpec = new FieldDefinitionGridSpec(new FieldDefinitionViewListFeature().HasPermissionByPerson(currentPerson));
            return FieldDefinition.All.Where(x => new FieldDefinitionManageFeature().HasPermission(currentPerson, x).HasPermission).OrderBy(x => x.GetFieldDefinitionLabel()).ToList();
        }

        [HttpGet]
        [FieldDefinitionManageFeature]
        [CrossAreaRoute]
        public ViewResult Edit(FieldDefinitionPrimaryKey fieldDefinitionPrimaryKey)
        {
            var fieldDefinitionData = HttpRequestStorage.DatabaseEntities.FieldDefinitionDatas.GetFieldDefinitionDataByFieldDefinition(fieldDefinitionPrimaryKey);            
            var viewModel = new EditViewModel(fieldDefinitionData);
            return ViewEdit(fieldDefinitionPrimaryKey, viewModel);
        }

        [HttpPost]
        [FieldDefinitionManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [CrossAreaRoute]
        public ActionResult Edit(FieldDefinitionPrimaryKey fieldDefinitionPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(fieldDefinitionPrimaryKey, viewModel);
            }
            var fieldDefinitionData = HttpRequestStorage.DatabaseEntities.FieldDefinitionDatas.GetFieldDefinitionDataByFieldDefinition(fieldDefinitionPrimaryKey);
            if (fieldDefinitionData == null)
            {
                fieldDefinitionData = new FieldDefinitionData(fieldDefinitionPrimaryKey.EntityObject);
                HttpRequestStorage.DatabaseEntities.AllFieldDefinitionDatas.Add(fieldDefinitionData);
            }

            viewModel.UpdateModel(fieldDefinitionData);
            SetMessageForDisplay("Field Definition successfully saved.");
            return RedirectToAction(new SitkaRoute<FieldDefinitionController>(x => x.Edit(fieldDefinitionData.FieldDefinition)));
        }

        private ViewResult ViewEdit(FieldDefinitionPrimaryKey fieldDefinitionPrimaryKey, EditViewModel viewModel)
        {
            var viewData = new EditViewData(CurrentPerson, fieldDefinitionPrimaryKey.EntityObject);
            return RazorView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [FieldDefinitionViewFeature]
        [CrossAreaRoute]
        public PartialViewResult FieldDefinitionDetails(int fieldDefinitionID)
        {
            var fieldDefinition = FieldDefinition.AllLookupDictionary[fieldDefinitionID];
            var fieldDefinitionData = HttpRequestStorage.DatabaseEntities.FieldDefinitionDatas.SingleOrDefault(x => x.FieldDefinitionID == fieldDefinitionID);
            var showEditLink = new FieldDefinitionManageFeature().HasPermission(CurrentPerson, fieldDefinition).HasPermission; 
            var viewData = new FieldDefinitionDetailsViewData(fieldDefinition, fieldDefinitionData, showEditLink);
            return RazorPartialView<FieldDefinitionDetails, FieldDefinitionDetailsViewData>(viewData);
        }
    }
}
