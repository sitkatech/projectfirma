using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.ProjectCustomAttributeType
{
    public class ProjectCustomAttributeTypeGridSpec : GridSpec<Models.ProjectCustomAttributeType>
    {
        public ProjectCustomAttributeTypeGridSpec()
        {
            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, DhtmlxGridColumnFilterType.None);
            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(x.GetEditUrl(), ModalDialogFormHelper.DefaultDialogWidth, "Edit Attribute")), 30, DhtmlxGridColumnFilterType.None);
            Add(Models.FieldDefinition.ProjectCustomAttributeType.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.ProjectCustomAttributeTypeName), 300, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.ProjectCustomAttributeDataType.ToGridHeaderString(), a => a.ProjectCustomAttributeDataType.ProjectCustomAttributeDataTypeDisplayName, 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.MeasurementUnit.ToGridHeaderString(), a => a.GetMeasurementUnitDisplayName(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Required?", a => a.IsRequired.ToYesNo(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
        }
    }
}
