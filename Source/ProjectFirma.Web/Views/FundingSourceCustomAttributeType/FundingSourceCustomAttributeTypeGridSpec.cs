using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
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

            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, DhtmlxGridColumnFilterType.None);
            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(x.GetEditUrl(), ModalDialogFormHelper.DefaultDialogWidth, "Edit Attribute")), 30, DhtmlxGridColumnFilterType.None);           
            Add(FieldDefinitionEnum.FundingSourceCustomAttribute.ToType().ToGridHeaderString(),a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.FundingSourceCustomAttributeTypeName), 200, DhtmlxGridColumnFilterType.Html);
            Add("Description", a => a.FundingSourceCustomAttributeTypeDescription, 300);
            Add(FieldDefinitionEnum.FundingSourceCustomAttributeDataType.ToType().ToGridHeaderString(), a => a.FundingSourceCustomAttributeDataType.FundingSourceCustomAttributeDataTypeDisplayName, 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.MeasurementUnit.ToType().ToGridHeaderString(), a => a.GetMeasurementUnitDisplayName(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Required?", a => a.IsRequired.ToYesNo(), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.FundingSourceCustomAttributeTypeEditableBy.ToType().ToGridHeaderString(), x => x.GetEditableRoles(), 150, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.FundingSourceCustomAttributeTypeViewableBy.ToType().ToGridHeaderString(), a => a.GetViewableRoles(), 200, DhtmlxGridColumnFilterType.Html);
            Add($"Include In {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()} Grid?", a => a.IncludeInFundingSourceGrid.ToYesNo() ?? ViewUtilities.NoAnswerProvided, 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
        }
    }
}
