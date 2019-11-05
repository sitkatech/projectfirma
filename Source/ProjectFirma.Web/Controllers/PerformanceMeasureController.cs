/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.PerformanceMeasure;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.ExcelWorkbookUtilities;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using Newtonsoft.Json.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirma.Web.Views.Shared.TextControls;
using Detail = ProjectFirma.Web.Views.PerformanceMeasure.Detail;
using DetailViewData = ProjectFirma.Web.Views.PerformanceMeasure.DetailViewData;
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
            var firmaPage = FirmaPageTypeEnum.PerformanceMeasuresList.GetFirmaPage();
            var viewData = new IndexViewData(CurrentPerson, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [PerformanceMeasureViewFeature]
        public GridJsonNetJObjectResult<PerformanceMeasure> PerformanceMeasureGridJsonData()
        {
            var gridSpec = new PerformanceMeasureGridSpec(CurrentPerson);
            var performanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList().SortByOrderThenName().ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<PerformanceMeasure>(performanceMeasures, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [PerformanceMeasureViewFeature]
        public ViewResult Detail(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var canManagePerformanceMeasure = new PerformanceMeasureManageFeature().HasPermissionByPerson(CurrentPerson) && performanceMeasure.PerformanceMeasureDataSourceType != PerformanceMeasureDataSourceType.TechnicalAssistanceValue;
            var isAdmin = new FirmaAdminFeature().HasPermissionByPerson(CurrentPerson);
            
            var performanceMeasureChartViewData = new PerformanceMeasureChartViewData(performanceMeasure, CurrentPerson, false, canManagePerformanceMeasure, performanceMeasure.GetAssociatedProjectsWithReportedValues(CurrentPerson));

            // Avoid scrolling the legend if it can be displayed on two lines
            performanceMeasureChartViewData.ViewGoogleChartViewData.GoogleChartJsons.ForEach(x =>
            {
                if (x.GoogleChartConfiguration.Legend != null && x.GoogleChartConfiguration.Legend.MaxLines == null)
                {
                    x.GoogleChartConfiguration.Legend.MaxLines = 2;
                }
            });

            var entityNotesViewData = new EntityNotesViewData(EntityNote.CreateFromEntityNote(performanceMeasure.PerformanceMeasureNotes),
                SitkaRoute<PerformanceMeasureNoteController>.BuildUrlFromExpression(c => c.New(performanceMeasure.PrimaryKey)),
                performanceMeasure.PerformanceMeasureDisplayName,
                canManagePerformanceMeasure);

            var viewData = new DetailViewData(CurrentPerson, performanceMeasure, performanceMeasureChartViewData, entityNotesViewData, canManagePerformanceMeasure, isAdmin);
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
            var measurementUnitTypesAsSelectListItems = MeasurementUnitType.All.OrderBy(x => x.MeasurementUnitTypeDisplayName).ToSelectListWithEmptyFirstRow(x => x.MeasurementUnitTypeID.ToString(CultureInfo.InvariantCulture), x => x.MeasurementUnitTypeDisplayName);
            var performanceMeasureTypesAsSelectListItems =
                PerformanceMeasureType.All.OrderBy(x => x.PerformanceMeasureTypeDisplayName)
                    .ToSelectListWithEmptyFirstRow(x => x.PerformanceMeasureTypeID.ToString(CultureInfo.InvariantCulture), x => x.PerformanceMeasureTypeDisplayName);
            var viewData = new EditViewData(measurementUnitTypesAsSelectListItems, performanceMeasureTypesAsSelectListItems);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
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
                    throw new ArgumentOutOfRangeException($"Invalid PerformanceMeasure Rich Text Content Type: '{performanceMeasureRichTextType}'");
            }
            var viewModel = new EditRtfContentViewModel(rtfContent);
            return ViewEditGuidance(viewModel, performanceMeasureRichTextType);
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPerformanceMeasureRichText(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey,
            EditRtfContent.PerformanceMeasureRichTextType performanceMeasureRichTextType,
            EditRtfContentViewModel viewModel)
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
                    throw new ArgumentOutOfRangeException($"Unknown GuidanceType: {performanceMeasureRichTextType}");
            }
            return RazorPartialView<EditRtfContent, EditRtfContentViewData, EditRtfContentViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public ContentResult SaveChartConfiguration(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, int performanceMeasureSubcategoryID)
        {
            return new ContentResult();
        }

        [HttpPost]
        [FirmaAdminFeature]
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

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult ResetChartConfiguration(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, int performanceMeasureSubcategoryID)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(performanceMeasure.PerformanceMeasureID);
            return ViewResetChartConfiguration(performanceMeasure, viewModel);
        }

        private PartialViewResult ViewResetChartConfiguration(PerformanceMeasure performanceMeasure, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage = $"Are you sure you want to reset the chart configuration to the default?";

            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ResetChartConfiguration(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, int performanceMeasureSubcategoryID, ConfirmDialogFormViewModel viewModel)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                SetErrorForDisplay("Error resetting chart configuration.");
                return ViewResetChartConfiguration(performanceMeasure, viewModel);
            }

            var performanceMeasureSubcategory = performanceMeasure.PerformanceMeasureSubcategories.Single(x => x.PerformanceMeasureSubcategoryID == performanceMeasureSubcategoryID);
            var defaultSubcategoryChartConfigurationJson = PerformanceMeasureModelExtensions.GetDefaultPerformanceMeasureChartConfigurationJson(performanceMeasure);
            performanceMeasureSubcategory.ChartConfigurationJson =
                JObject.FromObject(defaultSubcategoryChartConfigurationJson).ToString();
            performanceMeasureSubcategory.GoogleChartTypeID = GoogleChartType.ColumnChart.GoogleChartTypeID;

            return new ModalDialogFormJsonResult();
        }


        [PerformanceMeasureViewFeature]
        public PartialViewResult DefinitionAndGuidance(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var viewData = new DefinitionAndGuidanceViewData(performanceMeasure);
            return RazorPartialView<DefinitionAndGuidance, DefinitionAndGuidanceViewData>(viewData);
        }

        [PerformanceMeasureViewFeature]
        public GridJsonNetJObjectResult<PerformanceMeasureReportedValue> PerformanceMeasureReportedValuesGridJsonData(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasureActuals = GetPerformanceMeasureReportedValuesAndGridSpec(out var gridSpec, performanceMeasurePrimaryKey.EntityObject, CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<PerformanceMeasureReportedValue>(performanceMeasureActuals, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<PerformanceMeasureReportedValue> GetPerformanceMeasureReportedValuesAndGridSpec(out PerformanceMeasureReportedValuesGridSpec gridSpec, PerformanceMeasure performanceMeasure, Person currentPerson)
        {
            gridSpec = new PerformanceMeasureReportedValuesGridSpec(performanceMeasure);
            return performanceMeasure.GetReportedPerformanceMeasureValues(currentPerson);
        }

        [PerformanceMeasureViewFeature]
        public GridJsonNetJObjectResult<PerformanceMeasureExpected> PerformanceMeasureExpectedsGridJsonData(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasureExpecteds = GetPerformanceMeasureExpectedsAndGridSpec(out var gridSpec, performanceMeasurePrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<PerformanceMeasureExpected>(performanceMeasureExpecteds, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<PerformanceMeasureExpected> GetPerformanceMeasureExpectedsAndGridSpec(out PerformanceMeasureExpectedGridSpec gridSpec, PerformanceMeasure performanceMeasure)
        {
            gridSpec = new PerformanceMeasureExpectedGridSpec(performanceMeasure);
            return performanceMeasure.PerformanceMeasureExpecteds.ToList();
        }

        [HttpGet]
        [PerformanceMeasureManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel {IsSummable = true};
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
            var performanceMeasure = new PerformanceMeasure(default(string), default(int), default(int), false, false, PerformanceMeasureDataSourceType.Project.PerformanceMeasureDataSourceTypeID);
            viewModel.UpdateModel(performanceMeasure, CurrentPerson);

            var defaultSubcategory = new PerformanceMeasureSubcategory(performanceMeasure, "Default") { GoogleChartTypeID = GoogleChartType.ColumnChart.GoogleChartTypeID };
            var defaultSubcategoryChartConfigurationJson = PerformanceMeasureModelExtensions.GetDefaultPerformanceMeasureChartConfigurationJson(performanceMeasure);
            defaultSubcategory.ChartConfigurationJson = JObject.FromObject(defaultSubcategoryChartConfigurationJson).ToString();
            new PerformanceMeasureSubcategoryOption(defaultSubcategory, "Default", false);
            HttpRequestStorage.DatabaseEntities.AllPerformanceMeasures.Add(performanceMeasure);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"New {MultiTenantHelpers.GetPerformanceMeasureName()} '{performanceMeasure.GetDisplayNameAsUrl()}' successfully created!");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [PerformanceMeasureManageFeature]
        public PartialViewResult EditSubcategoriesAndOptions(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var viewModel = new EditSubcategoriesAndOptionsViewModel(performanceMeasure);
            return ViewEditSubcategoriesAndOptions(viewModel);
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditSubcategoriesAndOptions(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, EditSubcategoriesAndOptionsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditSubcategoriesAndOptions(viewModel);
            }
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            viewModel.UpdateModel(performanceMeasure);

            SetMessageForDisplay($"Successfully updated {MultiTenantHelpers.GetPerformanceMeasureName()} '{performanceMeasure.PerformanceMeasureDisplayName}'!");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditSubcategoriesAndOptions(EditSubcategoriesAndOptionsViewModel viewModel)
        {
            var viewData = new EditSubcategoriesAndOptionsViewData();
            return RazorPartialView<EditSubcategoriesAndOptions, EditSubcategoriesAndOptionsViewData, EditSubcategoriesAndOptionsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [PerformanceMeasureManageFeature]
        public PartialViewResult DeletePerformanceMeasure(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(performanceMeasure.PerformanceMeasureID);
            return ViewDeletePerformanceMeasure(performanceMeasure, viewModel);
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeletePerformanceMeasure(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeletePerformanceMeasure(performanceMeasure, viewModel);
            }
            performanceMeasure.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay($"Successfully deleted {MultiTenantHelpers.GetPerformanceMeasureName()} '{performanceMeasure.PerformanceMeasureDisplayName}'!");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewDeletePerformanceMeasure(PerformanceMeasure performanceMeasure, ConfirmDialogFormViewModel viewModel)
        {
            var hasNoAssociations = !performanceMeasure.PerformanceMeasureSubcategories.SelectMany(x => x.PerformanceMeasureSubcategoryOptions).Any(x => x.HasDependentObjects());
            var confirmMessage = hasNoAssociations
                ? $"<p>Are you sure you want to delete {MultiTenantHelpers.GetPerformanceMeasureName()} \"{performanceMeasure.PerformanceMeasureDisplayName}\"?</p>"
                : String.Format("<p>Are you sure you want to delete {0} \"{1}\"?</p><p>Deleting this {0} will <strong>delete all associated reported data</strong>, and this action cannot be undone. Click {2} to review.</p>",
                    MultiTenantHelpers.GetPerformanceMeasureName(),
                    performanceMeasure.PerformanceMeasureDisplayName,
                    SitkaRoute<PerformanceMeasureController>.BuildLinkFromExpression(x => x.Detail(performanceMeasure), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [PerformanceMeasureViewFeature]
        public ExcelResult IndexExcelDownload()
        {
            var performanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList().SortByOrderThenName().ToList();
            var excelWorkbook = new XLWorkbook();
            var sheetName = ExcelWorkbookSheetDescriptorFactory.TruncateWorksheetName($"{FieldDefinitionEnum.PerformanceMeasure.ToType().GetFieldDefinitionLabelPluralized()}");
            var ws = excelWorkbook.Worksheets.Add(sheetName);

            var row = 1;
            var fieldDefinitionLabel = FieldDefinitionEnum.PerformanceMeasure.ToType().GetFieldDefinitionLabel();
            foreach (var performanceMeasure in performanceMeasures)
            {
                var performanceMeasureHeaderCell = ws.Cell(row, 1);
                performanceMeasureHeaderCell.SetValue(fieldDefinitionLabel);
                performanceMeasureHeaderCell.SetDataType(XLCellValues.Text);
                performanceMeasureHeaderCell.Style.Font.SetBold();
                var unitsHeaderCell = ws.Cell(row, 2);
                unitsHeaderCell.SetValue("Units");
                unitsHeaderCell.SetDataType(XLCellValues.Text);
                unitsHeaderCell.Style.Font.SetBold();
                var subcategoryHeaderCell = ws.Cell(row, 3);
                subcategoryHeaderCell.SetValue(FieldDefinitionEnum.PerformanceMeasureSubcategory.ToType().GetFieldDefinitionLabel());
                subcategoryHeaderCell.SetDataType(XLCellValues.Text);
                subcategoryHeaderCell.Style.Font.SetBold();
                var numberOfOptionsHeaderCell = ws.Cell(row, 4);
                numberOfOptionsHeaderCell.SetValue("Number of Options");
                numberOfOptionsHeaderCell.SetDataType(XLCellValues.Text);
                numberOfOptionsHeaderCell.Style.Font.SetBold();
                var optionsHeaderCell = ws.Cell(row, 5);
                optionsHeaderCell.SetValue("Options");
                optionsHeaderCell.SetDataType(XLCellValues.Text);
                optionsHeaderCell.Style.Font.SetBold();
                row++;

                var performanceMeasureNameCell = ws.Cell(row, 1);
                performanceMeasureNameCell.SetValue(performanceMeasure.PerformanceMeasureDisplayName);
                performanceMeasureNameCell.SetDataType(XLCellValues.Text);
                var unitsNameCell = ws.Cell(row, 2);
                unitsNameCell.SetValue(performanceMeasure.MeasurementUnitType.MeasurementUnitTypeDisplayName);
                unitsNameCell.SetDataType(XLCellValues.Text);

                foreach (var performanceMeasureSubcategory in performanceMeasure.PerformanceMeasureSubcategories)
                {
                    var subcategoryNameCell = ws.Cell(row, 3);
                    subcategoryNameCell.SetValue(performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName);
                    subcategoryNameCell.SetDataType(XLCellValues.Text);
                    var numberOfOptionsCell = ws.Cell(row, 4);
                    numberOfOptionsCell.SetValue(performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions.Count);
                    numberOfOptionsCell.SetDataType(XLCellValues.Number);
                    var optionColNumberStart = 5;
                    foreach (var performanceMeasureSubcategoryOption in performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions)
                    {
                        var optionNameCell = ws.Cell(row, optionColNumberStart);
                        optionNameCell.SetValue(performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName);
                        optionNameCell.SetDataType(XLCellValues.Text);
                        optionColNumberStart++;
                    }
                    row++;
                }
                row++;
            }
            ws.Columns().AdjustToContents();
            return new ExcelResult(excelWorkbook,
                string.Format("{1} as of {0}", DateTime.Now.ToStringDateTime(),
                    fieldDefinitionLabel));
        }

        [FirmaAdminFeature]
        public PartialViewResult EditSortOrder()
        {
            var performanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures;
            EditSortOrderViewModel viewModel = new EditSortOrderViewModel();
            return ViewEditSortOrder(performanceMeasures, viewModel);
        }

        private PartialViewResult ViewEditSortOrder(IQueryable<PerformanceMeasure> performanceMeasures, EditSortOrderViewModel viewModel)
        {
            EditSortOrderViewData viewData = new EditSortOrderViewData(new List<IHaveASortOrder>(performanceMeasures), FieldDefinitionEnum.PerformanceMeasure.ToType().GetFieldDefinitionLabelPluralized());
            return RazorPartialView<EditSortOrder, EditSortOrderViewData, EditSortOrderViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditSortOrder(EditSortOrderViewModel viewModel)
        {
            var performanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures;


            if (!ModelState.IsValid)
            {
                return ViewEditSortOrder(performanceMeasures, viewModel);
            }

            viewModel.UpdateModel(new List<IHaveASortOrder>(performanceMeasures));
            SetMessageForDisplay($"Successfully Updated {FieldDefinitionEnum.PerformanceMeasure.ToType().GetFieldDefinitionLabel()} Sort Order");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult TechnicalAssistanceParameters()
        {
            Check.Assert(MultiTenantHelpers.UsesTechnicalAssistanceParameters(), "This feature is not available.");
            var technicalAssistanceParameterSimples = HttpRequestStorage.DatabaseEntities.TechnicalAssistanceParameters.ToList()
                .Select(x => new TechnicalAssistanceParameterSimple(x)).ToList();
            // add blank TAPSes for the years that don't already have stuff in the DB
            var reportingYearsForUserInputAsIntegers = FirmaDateUtilities.ReportingYearsForUserInputAsIntegers();
            var nextTwoYears = new List<int>() { reportingYearsForUserInputAsIntegers.Max() + 1, reportingYearsForUserInputAsIntegers.Max() + 2 };
            reportingYearsForUserInputAsIntegers.AddRange(nextTwoYears);
            technicalAssistanceParameterSimples.AddRange(reportingYearsForUserInputAsIntegers
                .Where(year => !technicalAssistanceParameterSimples.Select(x => x.Year).ToList().Contains(year))
                .Select(year => new TechnicalAssistanceParameterSimple(year)));

            var viewModel = new TechnicalAssistanceParametersViewModel(technicalAssistanceParameterSimples);
            return ViewTechnicalAssistanceParameters(viewModel);
        }

        private PartialViewResult ViewTechnicalAssistanceParameters(TechnicalAssistanceParametersViewModel viewModel)
        {
            var viewData = new TechnicalAssistanceParametersViewData();
            return RazorPartialView<TechnicalAssistanceParameters, TechnicalAssistanceParametersViewData,
                TechnicalAssistanceParametersViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult TechnicalAssistanceParameters(TechnicalAssistanceParametersViewModel viewModel)
        {
            Check.Assert(MultiTenantHelpers.UsesTechnicalAssistanceParameters(), "This feature is not available.");
            if (!ModelState.IsValid)
            {
                return ViewTechnicalAssistanceParameters(viewModel);
            }

            HttpRequestStorage.DatabaseEntities.TechnicalAssistanceParameters.Load();


            var currentTechnicalAssistanceParameters = HttpRequestStorage.DatabaseEntities.TechnicalAssistanceParameters.ToList();
            var allTechnicalAssistanceParameters = HttpRequestStorage.DatabaseEntities.AllTechnicalAssistanceParameters.Local;

            viewModel.UpdateModel(currentTechnicalAssistanceParameters, allTechnicalAssistanceParameters);
            return new ModalDialogFormJsonResult();
        }
    }
}