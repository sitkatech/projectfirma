using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.FundingSource;
using ProjectFirma.Web.Areas.EIP.Views.Project;
using ProjectFirma.Web.Areas.EIP.Views.Results;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using Edit = ProjectFirma.Web.Areas.EIP.Views.FundingSource.Edit;
using EditViewData = ProjectFirma.Web.Areas.EIP.Views.FundingSource.EditViewData;
using EditViewModel = ProjectFirma.Web.Areas.EIP.Views.FundingSource.EditViewModel;
using Index = ProjectFirma.Web.Areas.EIP.Views.FundingSource.Index;
using IndexGridSpec = ProjectFirma.Web.Areas.EIP.Views.FundingSource.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Areas.EIP.Views.FundingSource.IndexViewData;
using Summary = ProjectFirma.Web.Areas.EIP.Views.FundingSource.Summary;
using SummaryViewData = ProjectFirma.Web.Areas.EIP.Views.FundingSource.SummaryViewData;

namespace ProjectFirma.Web.Areas.EIP.Controllers
{
    public class FundingSourceController : LakeTahoeInfoBaseController
    {
        [FundingSourceViewFeature]
        public ViewResult Index()
        {
            return IndexImpl();
        }

        [AdminReadOnlyViewEverythingFeature]
        public ViewResult Manage()
        {
            return IndexImpl();
        }

        private ViewResult IndexImpl()
        {
            var projectFirmaPage = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.FundingSourcesList);
            var viewData = new IndexViewData(CurrentPerson, projectFirmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [FundingSourceViewFeature]
        public GridJsonNetJObjectResult<FundingSource> IndexGridJsonData()
        {
            IndexGridSpec gridSpec;
            var fundingSources = GetFundingSourcesAndGridSpec(out gridSpec, CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<FundingSource>(fundingSources, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<FundingSource> GetFundingSourcesAndGridSpec(out IndexGridSpec gridSpec, Person currentPerson)
        {
            var hasDeleteFundingSourcePermission = new FundingSourceManageFeature().HasPermissionByPerson(currentPerson);
            gridSpec = new IndexGridSpec(hasDeleteFundingSourcePermission);
            return FundingSources.List();
        }

        [HttpGet]
        [FundingSourceManageFeature]
        public PartialViewResult New()
        {
            const int organizationID = 0;
            var fundingSource = new FundingSource(organizationID, string.Empty, true, false);
            var viewModel = new EditViewModel(fundingSource);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FundingSourceManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var fundingSource = new FundingSource(viewModel.OrganizationID, string.Empty, true, false);
            viewModel.UpdateModel(fundingSource, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.FundingSources.Add(fundingSource);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [FundingSourceManageFeature]
        public PartialViewResult Edit(FundingSourcePrimaryKey fundingSourcePrimaryKey)
        {
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(fundingSource);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FundingSourceManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(FundingSourcePrimaryKey fundingSourcePrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            viewModel.UpdateModel(fundingSource, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var organizationsAsSelectListItems =
                HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations()
                    .ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture), x => x.OrganizationName);
            var viewData = new EditViewData(organizationsAsSelectListItems);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [FundingSourceViewFeature]
        public ViewResult Summary(FundingSourcePrimaryKey fundingSourcePrimaryKey)
        {
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            var focusAreas = HttpRequestStorage.DatabaseEntities.FocusAreas.OrderBy(x => x.FocusAreaNumber).ToList();

            var yearRange = ProjectFirmaDateUtilities.GetRangeOfYearsForReporting();
            var chartPopupUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(x => x.GoogleChartPopup(fundingSourcePrimaryKey));
            var googleChart = fundingSource.ProjectFundingSourceExpenditures
                .ToGoogleChart(x => x.Project.ActionPriority.Program.FocusArea.DisplayName,
                    focusAreas.Select(x => x.DisplayName).ToList(),
                    x => x.Project.ActionPriority.Program.FocusArea.DisplayName,
                    yearRange,
                    "ReportedExpendituresChart",
                    fundingSource.DisplayName, chartPopupUrl);

            var chartColorRange = focusAreas.Select(x => x.FocusAreaColor).ToList();
            var calendarYearExpendituresLineChartViewData = new CalendarYearExpendituresLineChartViewData(googleChart,
                chartColorRange);
            var viewData = new SummaryViewData(CurrentPerson, fundingSource, calendarYearExpendituresLineChartViewData);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [HttpGet]
        [FundingSourceManageFeature]
        public PartialViewResult DeleteFundingSource(FundingSourcePrimaryKey fundingSourcePrimaryKey)
        {
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(fundingSource.FundingSourceID);
            return ViewDeleteFundingSource(fundingSource, viewModel);
        }

        private PartialViewResult ViewDeleteFundingSource(FundingSource fundingSource, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !fundingSource.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this Funding Source '{0}'?", fundingSource.FundingSourceName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Funding Source", SitkaRoute<FundingSourceController>.BuildLinkFromExpression(x => x.Summary(fundingSource), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FundingSourceManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteFundingSource(FundingSourcePrimaryKey fundingSourcePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteFundingSource(fundingSource, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.FundingSources.Remove(fundingSource);
            return new ModalDialogFormJsonResult();
        }

        [FundingSourceViewFeature]
        public GridJsonNetJObjectResult<ProjectCalendarYearExpenditure> ProjectCalendarYearExpendituresGridJsonData(FundingSourcePrimaryKey fundingSourcePrimaryKey)
        {
            ProjectCalendarYearExpendituresGridSpec gridSpec;
            var projectFundingSources = GetProjectCalendarYearExpendituresAndGridSpec(out gridSpec, fundingSourcePrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectCalendarYearExpenditure>(projectFundingSources, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<ProjectCalendarYearExpenditure> GetProjectCalendarYearExpendituresAndGridSpec(out ProjectCalendarYearExpendituresGridSpec gridSpec,
            FundingSource fundingSource)
        {
            var projectFundingSourceExpenditures = fundingSource.ProjectFundingSourceExpenditures.ToList();
            var calendarYearRangeForExpenditures = projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(fundingSource);
            gridSpec = new ProjectCalendarYearExpendituresGridSpec(calendarYearRangeForExpenditures);
            return ProjectCalendarYearExpenditure.CreateFromProjectsAndCalendarYears(projectFundingSourceExpenditures, calendarYearRangeForExpenditures);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public PartialViewResult GoogleChartPopup(FundingSourcePrimaryKey fundingSourcePrimaryKey)
        {
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            var focusAreas = HttpRequestStorage.DatabaseEntities.FocusAreas.OrderBy(x => x.FocusAreaNumber).ToList();

            var yearRange = ProjectFirmaDateUtilities.GetRangeOfYearsForReporting();
            var googleChart = fundingSource.ProjectFundingSourceExpenditures
                .ToGoogleChart(x => x.Project.ActionPriority.Program.FocusArea.DisplayName,
                    focusAreas.Select(x => x.DisplayName).ToList(),
                    x => x.Project.ActionPriority.Program.FocusArea.DisplayName,
                    yearRange,
                    "ReportedExpendituresChart",
                    fundingSource.DisplayName, string.Empty);

            var viewData = new GoogleChartPopupViewData(googleChart);
            return RazorPartialView<GoogleChartPopup, GoogleChartPopupViewData>(viewData);
        }

    }
}