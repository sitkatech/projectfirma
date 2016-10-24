using System;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.TransportationCostParameterSet;
using ProjectFirma.Web.Security.Shared;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class TransportationCostParameterSetController : LakeTahoeInfoBaseController
    {
        [AnonymousUnclassifiedFeature]
        public ViewResult Summary()
        {
            return SummaryImpl();
        }

        [TransportationManageFeature]
        public ViewResult Manage()
        {
            return SummaryImpl();
        }

        private ViewResult SummaryImpl()
        {
            var projectFirmaPage = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.TransportationCostParameterSet);
            var transportationCostParameterSet = HttpRequestStorage.DatabaseEntities.TransportationCostParameterSets.Latest();
            var viewData = new SummaryViewData(CurrentPerson, projectFirmaPage, transportationCostParameterSet);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [HttpGet]
        [TransportationManageFeature]
        public PartialViewResult New()
        {
            var transportationCostParameterSet = HttpRequestStorage.DatabaseEntities.TransportationCostParameterSets.Latest();
            var viewModel = new NewViewModel(transportationCostParameterSet);
            return ViewNew(viewModel);
        }

        [HttpPost]
        [TransportationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(NewViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var transportationCostParameterSet = new TransportationCostParameterSet(viewModel.InflationRate, viewModel.CurrentRTPYearForPVCalculations, DateTime.Now);
            viewModel.UpdateModel(transportationCostParameterSet, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.TransportationCostParameterSets.Add(transportationCostParameterSet);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(NewViewModel viewModel)
        {
            var viewData = new NewViewData();
            return RazorPartialView<New, NewViewData, NewViewModel>(viewData, viewModel);
        }
    }
}