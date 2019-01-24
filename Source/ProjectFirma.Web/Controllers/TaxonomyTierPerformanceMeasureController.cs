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
using ProjectFirmaModels.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.TaxonomyTierPerformanceMeasure;

namespace ProjectFirma.Web.Controllers
{
    public class TaxonomyTierPerformanceMeasureController : FirmaBaseController
    {
        [HttpGet]
        [TaxonomyTierPerformanceMeasureManageFeature]
        public PartialViewResult Edit(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var taxonomyTierPerformanceMeasureSimples = performanceMeasure.GetTaxonomyTiers().Select(x =>
                    new TaxonomyTierPerformanceMeasureSimple(x.Key.GetTaxonomyTierID(), x.First().PerformanceMeasureID,
                        x.First().IsPrimaryTaxonomyLeaf)).ToList();
            var primaryTaxonomyTierID = performanceMeasure.GetPrimaryTaxonomyTier().GetTaxonomyTierID();
            var viewModel = new EditViewModel(taxonomyTierPerformanceMeasureSimples, primaryTaxonomyTierID);
            return ViewEdit(viewModel, performanceMeasure);
        }

        [HttpPost]
        [TaxonomyTierPerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, EditViewModel viewModel)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, performanceMeasure);
            }
            HttpRequestStorage.DatabaseEntities.TaxonomyLeafPerformanceMeasures.Load();
            viewModel.UpdateModel(performanceMeasure.TaxonomyLeafPerformanceMeasures.ToList(), HttpRequestStorage.DatabaseEntities.AllTaxonomyLeafPerformanceMeasures.Local);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, PerformanceMeasure performanceMeasure)
        {
            var associatePerformanceMeasureTaxonomyLevel = MultiTenantHelpers.GetAssociatePerformanceMeasureTaxonomyLevel();
            var taxonomyBranchSimples = associatePerformanceMeasureTaxonomyLevel.GetTaxonomyTiers(HttpRequestStorage.DatabaseEntities).OrderBy(p => p.GetDisplayName()).ToList().Select(x => new TaxonomyTier(x)).ToList();
            var viewData = new EditViewData(new PerformanceMeasureSimple(performanceMeasure), taxonomyBranchSimples, associatePerformanceMeasureTaxonomyLevel);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }
    }
}
