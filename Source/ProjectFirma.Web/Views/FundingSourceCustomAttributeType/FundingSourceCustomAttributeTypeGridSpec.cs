using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.FundingSourceCustomAttributeType
{
    public class FundingSourceCustomAttributeTypeGridSpec : GridSpec<ProjectFirmaModels.Models.FundingSourceCustomAttributeType>
    {
        public FundingSourceCustomAttributeTypeGridSpec()
        {

            Add("delete", x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, AgGridColumnFilterType.None);
            Add("edit", x => AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(x.GetEditUrl(), ModalDialogFormHelper.DefaultDialogWidth, "Edit Attribute")), 30, AgGridColumnFilterType.None);           
            Add(FieldDefinitionEnum.FundingSourceCustomAttribute.ToType().ToGridHeaderString(),a => new HtmlLinkObject(a.FundingSourceCustomAttributeTypeName, a.GetDetailUrl()).ToJsonObjectForAgGrid(), 200, AgGridColumnFilterType.HtmlLinkJson);
            Add("Description", a => a.FundingSourceCustomAttributeTypeDescription, 300);
            Add(FieldDefinitionEnum.FundingSourceCustomAttributeDataType.ToType().ToGridHeaderString(), a => a.FundingSourceCustomAttributeDataType.FundingSourceCustomAttributeDataTypeDisplayName, 100, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.MeasurementUnit.ToType().ToGridHeaderString(), a => a.GetMeasurementUnitDisplayName(), 100, AgGridColumnFilterType.SelectFilterStrict);
            Add("Required?", a => a.IsRequired.ToYesNo(), 100, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.FundingSourceCustomAttributeTypeViewableBy.ToType().ToGridHeaderString(), a => a.GetViewableRoles(), 200, AgGridColumnFilterType.Html);
            Add($"Include In {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()} Grid?", a => a.IncludeInFundingSourceGrid.ToYesNo() ?? ViewUtilities.NoAnswerProvided, 100, AgGridColumnFilterType.SelectFilterStrict);
        }
    }
}
