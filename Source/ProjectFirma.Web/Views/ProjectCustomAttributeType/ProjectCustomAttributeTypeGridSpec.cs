using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.ProjectCustomAttributeType
{
    public class ProjectCustomAttributeTypeGridSpec : GridSpec<ProjectFirmaModels.Models.ProjectCustomAttributeType>
    {
        public ProjectCustomAttributeTypeGridSpec()
        {
            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(ProjectFirmaModels.Models.ProjectCustomAttributeTypeModelExtensions.GetDeleteUrl(x), true), 30, DhtmlxGridColumnFilterType.None);
            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(ProjectFirmaModels.Models.ProjectCustomAttributeTypeModelExtensions.GetEditUrl(x), ModalDialogFormHelper.DefaultDialogWidth, "Edit Attribute")), 30, DhtmlxGridColumnFilterType.None);
            Add(FieldDefinitionEnum.ProjectCustomAttribute.ToType().ToGridHeaderString(), a => UrlTemplate.MakeHrefString(ProjectFirmaModels.Models.ProjectCustomAttributeTypeModelExtensions.GetDetailUrl(a), a.ProjectCustomAttributeTypeName), 200, DhtmlxGridColumnFilterType.Html);
            Add("Description", a => a.ProjectCustomAttributeTypeDescription, 300);
            Add(FieldDefinitionEnum.ProjectCustomAttributeDataType.ToType().ToGridHeaderString(), a => a.ProjectCustomAttributeDataType.ProjectCustomAttributeDataTypeDisplayName, 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.MeasurementUnit.ToType().ToGridHeaderString(), a => a.GetMeasurementUnitDisplayName(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Required?", a => a.IsRequired.ToYesNo(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
        }
    }
}
