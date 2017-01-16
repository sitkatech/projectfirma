using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.PerformanceMeasure;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using Index = ProjectFirma.Web.Views.PerformanceMeasure.Index;
using IndexViewData = ProjectFirma.Web.Views.PerformanceMeasure.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class PerformanceMeasureController : FirmaBaseController
    {
        [PerformanceMeasureManageFeature]
        public ViewResult Manage()
        {
            return IndexImpl();
        }


        [PerformanceMeasureViewFeature]
        public ViewResult Index()
        {
            return IndexImpl();
        }

        private ViewResult IndexImpl()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.WatershedsList);
            var viewData = new IndexViewData(CurrentPerson, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [PerformanceMeasureViewFeature]
        public GridJsonNetJObjectResult<PerformanceMeasure> PerformanceMeasureGridJsonData()
        {
            PerformanceMeasureGridSpec gridSpec;
            var performanceMeasures = GetPerformanceMeasuresAndGridSpec(out gridSpec);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<PerformanceMeasure>(performanceMeasures, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<PerformanceMeasure> GetPerformanceMeasuresAndGridSpec(out PerformanceMeasureGridSpec gridSpec)
        {
            gridSpec = new PerformanceMeasureGridSpec();
            return HttpRequestStorage.DatabaseEntities.PerformanceMeasures.OrderBy(x => x.PerformanceMeasureID).ToList();
        }

        [PerformanceMeasureViewFeature]
        public ViewResult Detail(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var userHasPerformanceMeasureManagePermissions = new PerformanceMeasureManageFeature().HasPermissionByPerson(CurrentPerson);
            var performanceMeasureChartViewData = new PerformanceMeasureChartViewData(performanceMeasure, false, userHasPerformanceMeasureManagePermissions ? ChartViewMode.ManagementMode : ChartViewMode.Small, null);
            var entityNotesViewData = new EntityNotesViewData(EntityNote.CreateFromEntityNote(new List<IEntityNote>(performanceMeasure.PerformanceMeasureNotes)),
                SitkaRoute<PerformanceMeasureNoteController>.BuildUrlFromExpression(c => c.New(performanceMeasure.PrimaryKey)),
                performanceMeasure.PerformanceMeasureDisplayName,
                userHasPerformanceMeasureManagePermissions);

            var viewData = new DetailViewData(CurrentPerson,
                performanceMeasure,
                performanceMeasureChartViewData,
                entityNotesViewData,
                userHasPerformanceMeasureManagePermissions);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [HttpGet]
        [PerformanceMeasureManageFeature]
        public PartialViewResult Edit(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(performanceMeasure);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, EditViewModel viewModel)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            viewModel.UpdateModel(performanceMeasure, CurrentPerson);
            return new ModalDialogFormJsonResult(performanceMeasure.GetSummaryUrl());
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var measurementUnitTypesAsSelectListItems = MeasurementUnitType.All.ToSelectList(x => x.MeasurementUnitTypeID.ToString(CultureInfo.InvariantCulture),
                x => x.MeasurementUnitTypeDisplayName);
            var performanceMeasureTypesAsSelectListItems = PerformanceMeasureType.All.OrderBy(x => x.PerformanceMeasureTypeDisplayName).ToSelectList(x => x.PerformanceMeasureTypeID.ToString(CultureInfo.InvariantCulture),
                x => x.PerformanceMeasureTypeDisplayName);
            var viewData = new EditViewData(measurementUnitTypesAsSelectListItems, performanceMeasureTypesAsSelectListItems);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [PerformanceMeasureManageFeature]
        public PartialViewResult EditAccomplishmentsMetadata(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var viewModel = new EditAccomplishmentsMetadataViewModel(performanceMeasure);
            return ViewEditAccomplishmentsMetadata(viewModel);
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditAccomplishmentsMetadata(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, EditAccomplishmentsMetadataViewModel viewModel)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;

            if (!ModelState.IsValid)
            {
                return ViewEditAccomplishmentsMetadata(viewModel);
            }
            viewModel.UpdateModel(performanceMeasure, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditAccomplishmentsMetadata(EditAccomplishmentsMetadataViewModel viewModel)
        {
            var viewData = new EditAccomplishmentsMetadataViewData();
            return RazorPartialView<EditAccomplishmentsMetadata, EditAccomplishmentsMetadataViewData, EditAccomplishmentsMetadataViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [PerformanceMeasureManageFeature]
        public PartialViewResult EditPerformanceMeasureRichText(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, EditRtfContent.PerformanceMeasureRichTextType performanceMeasureRichTextType)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            HtmlString rtfContent;
            switch (performanceMeasureRichTextType)
            {
                case EditRtfContent.PerformanceMeasureRichTextType.CriticalDefinitions:
                    rtfContent = performanceMeasure.CriticalDefinitionsHtmlString;
                    break;
                case EditRtfContent.PerformanceMeasureRichTextType.ProjectReporting:
                    rtfContent = performanceMeasure.ProjectReportingHtmlString;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Invalid PerformanceMeasure Rich Text Content Type: '{0}'", performanceMeasureRichTextType));
            }
            var viewModel = new EditRtfContentViewModel(rtfContent);
            return ViewEditGuidance(viewModel, performanceMeasureRichTextType);
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPerformanceMeasureRichText(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, EditRtfContent.PerformanceMeasureRichTextType performanceMeasureRichTextType, EditRtfContentViewModel viewModel)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditGuidance(viewModel, performanceMeasureRichTextType);
            }
            viewModel.UpdateModel(performanceMeasure, performanceMeasureRichTextType);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditGuidance(EditRtfContentViewModel viewModel, EditRtfContent.PerformanceMeasureRichTextType performanceMeasureRichTextType)
        {
            EditRtfContentViewData viewData;
            switch (performanceMeasureRichTextType)
            {
                case EditRtfContent.PerformanceMeasureRichTextType.SimpleDescription:
                case EditRtfContent.PerformanceMeasureRichTextType.CriticalDefinitions:
                case EditRtfContent.PerformanceMeasureRichTextType.AccountingPeriodAndScale:
                case EditRtfContent.PerformanceMeasureRichTextType.ProjectReporting:
                    viewData = new EditRtfContentViewData(CkEditorExtension.CkEditorToolbar.Minimal, null);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Unknown GuidanceType: {0}", performanceMeasureRichTextType));
            }
            return RazorPartialView<EditRtfContent, EditRtfContentViewData, EditRtfContentViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [PerformanceMeasureManageFeature]
        public ContentResult SaveChartConfiguration(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, int performanceMeasureSubcategoryID)
        {
            return new ContentResult();
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult SaveChartConfiguration(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, int performanceMeasureSubcategoryID, GoogleChartConfigurationViewModel viewModel)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;

            if (!ModelState.IsValid)
            {
                SetErrorForDisplay("Unable to save chart configuration: Unsupported options.");
            }
            else
            {
                viewModel.UpdateModel(performanceMeasure, performanceMeasureSubcategoryID);
            }
            return RedirectToAction(new SitkaRoute<PerformanceMeasureController>(x => x.Detail(performanceMeasure)));
        }


        [PerformanceMeasureViewFeature]
        public PartialViewResult DefinitionAndGuidance(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var viewData = new DefinitionAndGuidanceViewData(performanceMeasure);
            return RazorPartialView<DefinitionAndGuidance, DefinitionAndGuidanceViewData>(viewData);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public PartialViewResult PerformanceMeasureChartPopup(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var accomplishmentsChartViewData = new PerformanceMeasureChartViewData(performanceMeasure, 1080 + 20, 630 + 20, false, ChartViewMode.Large, null);
            return RazorPartialView<PerformanceMeasureChartPopup, PerformanceMeasureChartViewData>(accomplishmentsChartViewData);
        }


        [PerformanceMeasureViewFeature]
        public ViewResult InfoSheet(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var performanceMeasureChartViewData = new PerformanceMeasureChartViewData(performanceMeasure, 500, 400, false, ChartViewMode.InfoSheet, null);
            var viewData = new InfoSheetViewData(CurrentPerson, performanceMeasure, performanceMeasureChartViewData);
            return RazorView<InfoSheet, InfoSheetViewData>(viewData);
        }

        [PerformanceMeasureViewFeature]
        public GridJsonNetJObjectResult<PerformanceMeasureReportedValue> PerformanceMeasureReportedValuesGridJsonData(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            PerformanceMeasureReportedValuesGridSpec gridSpec;
            var performanceMeasureActuals = GetPerformanceMeasureReportedValuesAndGridSpec(out gridSpec, performanceMeasurePrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<PerformanceMeasureReportedValue>(performanceMeasureActuals, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<PerformanceMeasureReportedValue> GetPerformanceMeasureReportedValuesAndGridSpec(out PerformanceMeasureReportedValuesGridSpec gridSpec, PerformanceMeasure performanceMeasure)
        {
            gridSpec = new PerformanceMeasureReportedValuesGridSpec(performanceMeasure);
            return performanceMeasure.GetReportedPerformanceMeasureValues();
        }

        [PerformanceMeasureViewFeature]
        public GridJsonNetJObjectResult<PerformanceMeasureExpected> PerformanceMeasureExpectedsGridJsonData(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            PerformanceMeasureExpectedGridSpec gridSpec;
            var performanceMeasureExpecteds = GetPerformanceMeasureExpectedsAndGridSpec(out gridSpec, performanceMeasurePrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<PerformanceMeasureExpected>(performanceMeasureExpecteds, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<PerformanceMeasureExpected> GetPerformanceMeasureExpectedsAndGridSpec(out PerformanceMeasureExpectedGridSpec gridSpec,
            PerformanceMeasure performanceMeasure)
        {
            gridSpec = new PerformanceMeasureExpectedGridSpec(performanceMeasure);
            return performanceMeasure.PerformanceMeasureExpecteds.ToList();
        }

        [HttpGet]
        [PerformanceMeasureManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var performanceMeasure = new PerformanceMeasure(default(string), default(int), default(int), String.Empty);
            viewModel.UpdateModel(performanceMeasure, CurrentPerson);

            var defaultSubcategory = new PerformanceMeasureSubcategory(performanceMeasure, "Default");
            new PerformanceMeasureSubcategoryOption(defaultSubcategory, "Default");

            HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Add(performanceMeasure);

            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay(string.Format("New {0} {1} successfully created!", MultiTenantHelpers.GetPerformanceMeasureName(), performanceMeasure.GetDisplayNameAsUrl()));
            return new ModalDialogFormJsonResult();
        }
    }
}