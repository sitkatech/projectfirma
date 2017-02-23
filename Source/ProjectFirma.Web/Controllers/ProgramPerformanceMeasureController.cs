/*-----------------------------------------------------------------------
<copyright file="ProgramPerformanceMeasureController.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.TaxonomyTierTwoPerformanceMeasure;

namespace ProjectFirma.Web.Controllers
{
    public class TaxonomyTierTwoPerformanceMeasureController : FirmaBaseController
    {
        [HttpGet]
        [TaxonomyTierTwoPerformanceMeasureManageFeature]
        public PartialViewResult Edit(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var taxonomyTierTwoPerformanceMeasureSimples = performanceMeasure.TaxonomyTierTwoPerformanceMeasures.Select(x => new TaxonomyTierTwoPerformanceMeasureSimple(x)).ToList();
            var primaryTaxonomyTierTwoID = performanceMeasure.PrimaryTaxonomyTierTwo != null ? performanceMeasure.PrimaryTaxonomyTierTwo.TaxonomyTierTwoID : (int?) null;
            var viewModel = new EditViewModel(taxonomyTierTwoPerformanceMeasureSimples, primaryTaxonomyTierTwoID);
            return ViewEdit(viewModel, performanceMeasure);
        }

        [HttpPost]
        [TaxonomyTierTwoPerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, EditViewModel viewModel)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, performanceMeasure);
            }
            HttpRequestStorage.DatabaseEntities.TaxonomyTierTwoPerformanceMeasures.Load();
            viewModel.UpdateModel(performanceMeasure.TaxonomyTierTwoPerformanceMeasures.ToList(), HttpRequestStorage.DatabaseEntities.AllTaxonomyTierTwoPerformanceMeasures.Local);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, PerformanceMeasure performanceMeasure)
        {
            var taxonomyTierTwoSimples = HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.ToList().OrderBy(p => p.DisplayName).ToList().Select(x => new TaxonomyTierTwoSimple(x)).ToList();
            var viewData = new EditViewData(new PerformanceMeasureSimple(performanceMeasure), taxonomyTierTwoSimples);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }
    }
}
