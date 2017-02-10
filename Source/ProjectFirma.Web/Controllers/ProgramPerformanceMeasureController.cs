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