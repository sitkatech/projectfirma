/*-----------------------------------------------------------------------
<copyright file="TaxonomyTierPerformanceMeasureController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.TaxonomyTierPerformanceMeasure;

namespace ProjectFirma.Web.Controllers
{
    public class TaxonomyTierPerformanceMeasureController : FirmaBaseController
    {
        [HttpGet]
        [TaxonomyBranchPerformanceMeasureManageFeature]
        public PartialViewResult Edit(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var taxonomyBranchPerformanceMeasureSimples = performanceMeasure.TaxonomyLeafPerformanceMeasures.GroupBy(x => x.TaxonomyLeaf.TaxonomyBranchID).Select(x => new TaxonomyBranchPerformanceMeasureSimple(x.Key, x.First().PerformanceMeasureID, x.First().IsPrimaryTaxonomyLeaf)).ToList();
            var primaryTaxonomyBranchID = performanceMeasure.GetPrimaryTaxonomyTier()?.TaxonomyTierID;
            var viewModel = new EditViewModel(taxonomyBranchPerformanceMeasureSimples, primaryTaxonomyBranchID);
            return ViewEdit(viewModel, performanceMeasure);
        }

        [HttpPost]
        [TaxonomyBranchPerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, EditViewModel viewModel)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, performanceMeasure);
            }
            HttpRequestStorage.DatabaseEntities.AllTaxonomyLeafPerformanceMeasures.Load();
            viewModel.UpdateModel(performanceMeasure.TaxonomyLeafPerformanceMeasures.ToList(), HttpRequestStorage.DatabaseEntities.AllTaxonomyLeafPerformanceMeasures.Local);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, PerformanceMeasure performanceMeasure)
        {
            var taxonomyBranchSimples = HttpRequestStorage.DatabaseEntities.TaxonomyBranches.ToList().OrderBy(p => p.DisplayName).ToList().Select(x => new TaxonomyBranchSimple(x)).ToList();
            var viewData = new EditViewData(new PerformanceMeasureSimple(performanceMeasure), taxonomyBranchSimples);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }
    }
}
