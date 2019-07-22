using LtInfo.Common;
using LtInfo.Common.Mvc;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.FundingSourceCustomAttributeType
{
    public class EditViewData : FirmaViewData
    {
        public string FundingSourceCustomAttributeTypeIndexUrl { get; }
        public string SubmitUrl { get; }
        public ViewPageContentViewData ViewInstructionsFirmaPage { get; }
        public IEnumerable<SelectListItem> FundingSourceCustomAttributeDataTypes { get; }
        public IEnumerable<SelectListItem> MeasurementUnitTypes { get; }
        public IEnumerable<SelectListItem> YesNos { get; }
        public EditViewDataForAngular ViewDataForAngular { get; }

        public bool IncludeInNtaGrids { get; }

        public EditViewData(Person currentPerson,
            IEnumerable<MeasurementUnitType> measurementUnitTypes,
            List<FundingSourceCustomAttributeDataType> fundingSourceCustomAttributeDataTypes,
            List<ProjectFirmaModels.Models.Role> roles,
            string submitUrl,
            ProjectFirmaModels.Models.FirmaPage instructionsFirmaPage,
            ProjectFirmaModels.Models.FundingSourceCustomAttributeType fundingSourceCustomAttributeType)
            : base(currentPerson)
        {
            EntityName = "Attribute Type";
            PageTitle =
                $"{(fundingSourceCustomAttributeType != null ? "Edit" : "New")} Attribute Type";
            YesNos = BooleanFormats.GetYesNoSelectList();
            FundingSourceCustomAttributeDataTypes = fundingSourceCustomAttributeDataTypes.ToSelectListWithEmptyFirstRow(
                x => x.FundingSourceCustomAttributeDataTypeID.ToString(), x => x.FundingSourceCustomAttributeDataTypeDisplayName);
            MeasurementUnitTypes = measurementUnitTypes.OrderBy(x => x.MeasurementUnitTypeDisplayName)
                .ToSelectListWithEmptyFirstRow(
                    x => x.MeasurementUnitTypeID.ToString(), x => x.MeasurementUnitTypeDisplayName,
                    ViewUtilities.NoneString);
            FundingSourceCustomAttributeTypeIndexUrl =
                SitkaRoute<FundingSourceCustomAttributeTypeController>.BuildUrlFromExpression(x => x.Manage());
            SubmitUrl = submitUrl;

            ViewInstructionsFirmaPage = new ViewPageContentViewData(instructionsFirmaPage, currentPerson);

            ViewDataForAngular = new EditViewDataForAngular(fundingSourceCustomAttributeDataTypes);
        }

        public class EditViewDataForAngular
        {
            public IEnumerable<FundingSourceCustomAttributeDataTypeSimple> FundingSourceCustomAttributeDataTypes { get; }

            public EditViewDataForAngular(IEnumerable<FundingSourceCustomAttributeDataType> fundingSourceCustomAttributeDataTypes)
            {
                FundingSourceCustomAttributeDataTypes = fundingSourceCustomAttributeDataTypes.Select(x => new FundingSourceCustomAttributeDataTypeSimple(x)).ToList();
            }
        }

        public class FundingSourceCustomAttributeDataTypeSimple
        {
            public int ID { get; }
            public string DisplayName { get; }
            public bool HasOptions { get; }
            public bool HasMeasurementUnit { get; }

            public FundingSourceCustomAttributeDataTypeSimple(FundingSourceCustomAttributeDataType fundingSourceCustomAttributeDataType)
            {
                ID = fundingSourceCustomAttributeDataType.FundingSourceCustomAttributeDataTypeID;
                DisplayName = fundingSourceCustomAttributeDataType.FundingSourceCustomAttributeDataTypeDisplayName;
                HasOptions = fundingSourceCustomAttributeDataType.HasOptions();
                HasMeasurementUnit = fundingSourceCustomAttributeDataType.HasMeasurementUnit();
            }
        }
    }
}
