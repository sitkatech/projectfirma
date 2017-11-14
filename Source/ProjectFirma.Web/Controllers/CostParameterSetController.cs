/*-----------------------------------------------------------------------
<copyright file="CostParameterSetController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.CostParameterSet;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class CostParameterSetController : FirmaBaseController
    {
        [FirmaAdminFeature]
        public ViewResult Detail()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.CostParameterSet);
            var costParameterSet = HttpRequestStorage.DatabaseEntities.CostParameterSets.Latest();
            var viewData = new DetailViewData(CurrentPerson, firmaPage, costParameterSet);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult New()
        {
            var costParameterSet = HttpRequestStorage.DatabaseEntities.CostParameterSets.Latest();
            var viewModel = new NewViewModel(costParameterSet);
            return ViewNew(viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(NewViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var costParameterSet = new CostParameterSet(viewModel.InflationRate, viewModel.CurrentYearForPVCalculations, DateTime.Now);
            viewModel.UpdateModel(costParameterSet, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllCostParameterSets.Add(costParameterSet);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(NewViewModel viewModel)
        {
            var viewData = new NewViewData();
            return RazorPartialView<New, NewViewData, NewViewModel>(viewData, viewModel);
        }
    }
}
