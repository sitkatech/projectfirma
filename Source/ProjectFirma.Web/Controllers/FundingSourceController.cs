using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.FundingSource;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Results;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using Detail = ProjectFirma.Web.Views.FundingSource.Detail;
using DetailViewData = ProjectFirma.Web.Views.FundingSource.DetailViewData;
using Edit = ProjectFirma.Web.Views.FundingSource.Edit;
using EditViewData = ProjectFirma.Web.Views.FundingSource.EditViewData;
using EditViewModel = ProjectFirma.Web.Views.FundingSource.EditViewModel;
using Index = ProjectFirma.Web.Views.FundingSource.Index;
using IndexGridSpec = ProjectFirma.Web.Views.FundingSource.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.FundingSource.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class FundingSourceController : FirmaBaseController
    {
        [FundingSourceViewFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.FundingSourcesList);
            var viewData = new IndexViewData(CurrentPerson, firmaPage);
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
            var fundingSource = new FundingSource(organizationID, string.Empty, true);
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
            var fundingSource = new FundingSource(viewModel.OrganizationID, string.Empty, true);
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
        public ViewResult Detail(FundingSourcePrimaryKey fundingSourcePrimaryKey)
        {
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            var taxonomyTierThrees = HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.OrderBy(x => x.TaxonomyTierThreeName).ToList();

            var yearRange = FirmaDateUtilities.GetRangeOfYearsForReporting();
            var chartPopupUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(x => x.GoogleChartPopup(fundingSourcePrimaryKey));
            var googleChart = fundingSource.ProjectFundingSourceExpenditures
                .ToGoogleChart(x => x.Project.TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThree.DisplayName,
                    taxonomyTierThrees.Select(x => x.DisplayName).ToList(),
                    x => x.Project.TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThree.DisplayName,
                    yearRange,
                    "ReportedExpendituresChart",
                    fundingSource.DisplayName, chartPopupUrl);

            var chartColorRange = taxonomyTierThrees.Select(x => x.ThemeColor).ToList();
            var calendarYearExpendituresLineChartViewData = new CalendarYearExpendituresLineChartViewData(googleChart,
                chartColorRange);
            var viewData = new DetailViewData(CurrentPerson, fundingSource, calendarYearExpendituresLineChartViewData);
            return RazorView<Detail, DetailViewData>(viewData);
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
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Funding Source", SitkaRoute<FundingSourceController>.BuildLinkFromExpression(x => x.Detail(fundingSource), "here"));

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
            var taxonomyTierThrees = HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.OrderBy(x => x.TaxonomyTierThreeName).ToList();

            var yearRange = FirmaDateUtilities.GetRangeOfYearsForReporting();
            var googleChart = fundingSource.ProjectFundingSourceExpenditures
                .ToGoogleChart(x => x.Project.TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThree.DisplayName,
                    taxonomyTierThrees.Select(x => x.DisplayName).ToList(),
                    x => x.Project.TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThree.DisplayName,
                    yearRange,
                    "ReportedExpendituresChart",
                    fundingSource.DisplayName, string.Empty);

            var viewData = new GoogleChartPopupViewData(googleChart);
            return RazorPartialView<GoogleChartPopup, GoogleChartPopupViewData>(viewData);
        }

    }
}