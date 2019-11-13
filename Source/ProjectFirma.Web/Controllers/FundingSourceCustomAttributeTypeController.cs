using System;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.FundingSourceCustomAttributeType;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Controllers
{
    public class FundingSourceCustomAttributeTypeController : FirmaBaseController
    {
        [FirmaAdminFeature]
        public ViewResult Manage()
        {
            var firmaPage = FirmaPageTypeEnum.ManageFundingSourceCustomAttributeTypesList.GetFirmaPage();
            var viewData = new ManageViewData(CurrentFirmaSession, firmaPage);
            return RazorView<Manage, ManageViewData>(viewData);
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<FundingSourceCustomAttributeType> FundingSourceCustomAttributeTypeGridJsonData()
        {
            var fundingSourceCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeTypes.ToList().OrderBy(x => x.FundingSourceCustomAttributeTypeName).ToList();
            var gridSpec = new FundingSourceCustomAttributeTypeGridSpec();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<FundingSourceCustomAttributeType>(fundingSourceCustomAttributeTypes, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ContentResult Description(FundingSourceCustomAttributeTypePrimaryKey fundingSourceCustomAttributeTypePrimaryKey)
        {
            return Content(fundingSourceCustomAttributeTypePrimaryKey.EntityObject.FundingSourceCustomAttributeTypeDescription);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel, null);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, null);
            }

            var fundingSourceCustomAttributeType = new FundingSourceCustomAttributeType(String.Empty, FundingSourceCustomAttributeDataType.String, false, false);
            viewModel.UpdateModel(fundingSourceCustomAttributeType, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllFundingSourceCustomAttributeTypes.Add(fundingSourceCustomAttributeType);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"{FieldDefinitionEnum.FundingSourceCustomAttribute.ToType().GetFieldDefinitionLabel()} {fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeName} successfully created.");

            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult Edit(FundingSourceCustomAttributeTypePrimaryKey fundingSourceCustomAttributeTypePrimaryKey)
        {
            var fundingSourceCustomAttributeType = fundingSourceCustomAttributeTypePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(fundingSourceCustomAttributeType);
            return ViewEdit(viewModel, fundingSourceCustomAttributeType);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(FundingSourceCustomAttributeTypePrimaryKey fundingSourceCustomAttributeTypePrimaryKey, EditViewModel viewModel)
        {
            var fundingSourceCustomAttributeType = fundingSourceCustomAttributeTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, fundingSourceCustomAttributeType);
            }
            viewModel.UpdateModel(fundingSourceCustomAttributeType, CurrentFirmaSession);

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, FundingSourceCustomAttributeType fundingSourceCustomAttributeType)
        {
            var instructionsFirmaPage = FirmaPageTypeEnum.ManageFundingSourceCustomAttributeTypeInstructions.GetFirmaPage();
            var submitUrl = ModelObjectHelpers.IsRealPrimaryKeyValue(viewModel.FundingSourceCustomAttributeTypeID)
                ? SitkaRoute<FundingSourceCustomAttributeTypeController>.BuildUrlFromExpression(x => x.Edit(viewModel.FundingSourceCustomAttributeTypeID))
                : SitkaRoute<FundingSourceCustomAttributeTypeController>.BuildUrlFromExpression(x => x.New());
            var viewData = new EditViewData(CurrentFirmaSession, MeasurementUnitType.All, FundingSourceCustomAttributeDataType.All, Role.All,
                submitUrl, instructionsFirmaPage, fundingSourceCustomAttributeType);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [FirmaAdminFeature]
        public ViewResult Detail(FundingSourceCustomAttributeTypePrimaryKey fundingSourceCustomAttributeTypePrimaryKey)
        {
            var fundingSourceCustomAttributeType = fundingSourceCustomAttributeTypePrimaryKey.EntityObject;
            var viewData = new DetailViewData(CurrentFirmaSession, fundingSourceCustomAttributeType);
            return RazorView<Detail, DetailViewData>(viewData);
        }


        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult DeleteFundingSourceCustomAttributeType(FundingSourceCustomAttributeTypePrimaryKey fundingSourceCustomAttributeTypePrimaryKey)
        {
            var fundingSourceCustomAttributeType = fundingSourceCustomAttributeTypePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID);
            return ViewDeleteFundingSourceCustomAttributeType(fundingSourceCustomAttributeType, viewModel);
        }

        private PartialViewResult ViewDeleteFundingSourceCustomAttributeType(FundingSourceCustomAttributeType fundingSourceCustomAttributeType, ConfirmDialogFormViewModel viewModel)
        {
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to delete {FieldDefinitionEnum.FundingSourceCustomAttribute.ToType().GetFieldDefinitionLabel()} \"{fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeName}\"?", true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteFundingSourceCustomAttributeType(FundingSourceCustomAttributeTypePrimaryKey fundingSourceCustomAttributeTypePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var fundingSourceCustomAttributeType = fundingSourceCustomAttributeTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteFundingSourceCustomAttributeType(fundingSourceCustomAttributeType, viewModel);
            }

            var message = $"{FieldDefinitionEnum.FundingSourceCustomAttribute.ToType().GetFieldDefinitionLabel()} '{fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeName}' successfully deleted!";
            fundingSourceCustomAttributeType.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }
    }
}
