using System;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.CostParameterSet;
using ProjectFirma.Web.Security.Shared;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class CostParameterSetController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        public ViewResult Summary()
        {
            return SummaryImpl();
        }

        [ProjectBudgetManageFeature]
        public ViewResult Manage()
        {
            return SummaryImpl();
        }

        private ViewResult SummaryImpl()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.CostParameterSet);
            var costParameterSet = HttpRequestStorage.DatabaseEntities.CostParameterSets.Latest();
            var viewData = new SummaryViewData(CurrentPerson, firmaPage, costParameterSet);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [HttpGet]
        [ProjectBudgetManageFeature]
        public PartialViewResult New()
        {
            var costParameterSet = HttpRequestStorage.DatabaseEntities.CostParameterSets.Latest();
            var viewModel = new NewViewModel(costParameterSet);
            return ViewNew(viewModel);
        }

        [HttpPost]
        [ProjectBudgetManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(NewViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var costParameterSet = new CostParameterSet(viewModel.InflationRate, viewModel.CurrentYearForPVCalculations, DateTime.Now);
            viewModel.UpdateModel(costParameterSet, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.CostParameterSets.Add(costParameterSet);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(NewViewModel viewModel)
        {
            var viewData = new NewViewData();
            return RazorPartialView<New, NewViewData, NewViewModel>(viewData, viewModel);
        }
    }
}