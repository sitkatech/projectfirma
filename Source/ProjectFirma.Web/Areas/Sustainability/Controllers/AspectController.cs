using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.Sustainability.Security;
using ProjectFirma.Web.Areas.Sustainability.Views.Aspect;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Areas.Sustainability.Controllers
{
    public class AspectController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult AllIndicators()
        {
            var viewData = new AllSustainabilityIndicatorsViewData(CurrentPerson, HomeController.GetSustainabilityCommonPageData());
            return RazorView<AllIndicators, AllSustainabilityIndicatorsViewData>(viewData);
        }

        [Route("{sustainabilityAspectName}", Order = 2)]
        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult Summary(string sustainabilityAspectName)
        {
            var sustainabilityAspect = HttpRequestStorage.DatabaseEntities.SustainabilityAspects.GetSustainabilityAspectByName(sustainabilityAspectName);
            var editUrl = SitkaRoute<AspectController>.BuildUrlFromExpression(x => x.Edit(sustainabilityAspect.SustainabilityAspectName));
            var isEditButtonVisible = new SustainabilityDashboardManageFeature().HasPermissionByPerson(CurrentPerson);
            var viewData = new SummaryViewData(CurrentPerson, sustainabilityAspect, HomeController.GetSustainabilityCommonPageData(), editUrl, isEditButtonVisible);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [Route("{sustainabilityAspectName}/Edit", Order = 3)]
        [HttpGet]
        [SustainabilityDashboardManageFeature]
        public ViewResult Edit(string sustainabilityAspectName)
        {
            var sustainabilityAspect = HttpRequestStorage.DatabaseEntities.SustainabilityAspects.GetSustainabilityAspectByName(sustainabilityAspectName);
            var viewModel = new EditViewModel(sustainabilityAspect);
            return ViewEditAspectSummaryContent(sustainabilityAspect, viewModel);
        }

        private ViewResult ViewEditAspectSummaryContent(SustainabilityAspect sustainabilityAspect, EditViewModel viewModel)
        {
            var cancelUrl = SitkaRoute<AspectController>.BuildUrlFromExpression(x => x.Summary(sustainabilityAspect.SustainabilityAspectName));
            var viewData = new EditViewData(CurrentPerson, sustainabilityAspect, HomeController.GetSustainabilityCommonPageData(), cancelUrl);
            return RazorView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [Route("{sustainabilityAspectName}/Edit/{viewModel}", Order = 3)]
        [HttpPost]
        [SustainabilityDashboardManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(string sustainabilityAspectName, EditViewModel viewModel)
        {
            var sustainabilityAspect = HttpRequestStorage.DatabaseEntities.SustainabilityAspects.GetSustainabilityAspectByName(sustainabilityAspectName);
            if (!ModelState.IsValid)
            {
                return ViewEditAspectSummaryContent(sustainabilityAspect, viewModel);
            }
            viewModel.UpdateModel(sustainabilityAspect, CurrentPerson);
            return RedirectToAction(new SitkaRoute<AspectController>(x => x.Summary(sustainabilityAspect.SustainabilityAspectName)));
        }

        [HttpGet]
        [CrossAreaRoute]
        [SustainabilityDashboardManageFeature]
        public ActionResult EditSustainabilityIndicatorReporteds(string indicatorName)
        {
            var sustainabilityIndicator = HttpRequestStorage.DatabaseEntities.SustainabilityIndicators.GetSustainabilityIndicatorByName(indicatorName);
            var viewModel = new EditIndicatorReportedsViewModel(sustainabilityIndicator);
            return ViewEditSustainabilityIndicatorReporteds(sustainabilityIndicator, viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [SustainabilityDashboardManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditSustainabilityIndicatorReporteds(string indicatorName, EditIndicatorReportedsViewModel viewModel)
        {
            var sustainabilityIndicator = HttpRequestStorage.DatabaseEntities.SustainabilityIndicators.GetSustainabilityIndicatorByName(indicatorName);
            if (!ModelState.IsValid)
            {
                return ViewEditSustainabilityIndicatorReporteds(sustainabilityIndicator, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.SustainabilityIndicatorReporteds.Load();
            HttpRequestStorage.DatabaseEntities.SustainabilityIndicatorReportedSubcategoryOptions.Load();
            HttpRequestStorage.DatabaseEntities.SustainabilityIndicatorReportingPeriods.Load();
            viewModel.UpdateModel(sustainabilityIndicator, HttpRequestStorage.DatabaseEntities.SustainabilityIndicatorReporteds.Local,
                HttpRequestStorage.DatabaseEntities.SustainabilityIndicatorReportedSubcategoryOptions.Local,
                HttpRequestStorage.DatabaseEntities.SustainabilityIndicatorReportingPeriods.Local);
            return new ModalDialogFormJsonResult();
        }

        private ActionResult ViewEditSustainabilityIndicatorReporteds(SustainabilityIndicator sustainabilityIndicator, EditIndicatorReportedsViewModel viewModel)
        {
            var indicatorTargetValueTypes = IndicatorTargetValueType.All.ToList();
            var defaultReportingPeriodYear = sustainabilityIndicator.SustainabilityIndicatorReportingPeriods.Any()
                ? sustainabilityIndicator.SustainabilityIndicatorReportingPeriods.Max(x => x.SustainabilityIndicatorReportingPeriodBeginDate.Year) + 1
                : DateTime.Now.Year;
            var indicator = sustainabilityIndicator.Indicator;
            var viewDataForAngular = new EditIndicatorReportedsViewDataForAngular(indicator,
                defaultReportingPeriodYear,
                indicatorTargetValueTypes.ToDictionary(x => x.IndicatorTargetValueTypeName, x => x.IndicatorTargetValueTypeID));
            var viewData = new EditIndicatorReportedsViewData(indicator, viewDataForAngular, indicatorTargetValueTypes);
            return RazorPartialView<EditIndicatorReporteds, EditIndicatorReportedsViewData, EditIndicatorReportedsViewModel>(viewData, viewModel);
        }
    }
}