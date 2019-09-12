using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCustomAttributeType
{
    public class ProjectCustomAttributeTypeGridSpec : GridSpec<ProjectFirmaModels.Models.ProjectCustomAttributeType>
    {
        public ProjectCustomAttributeTypeGridSpec()
        {

            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, DhtmlxGridColumnFilterType.None);
            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(x.GetEditUrl(), ModalDialogFormHelper.DefaultDialogWidth, "Edit Attribute")), 30, DhtmlxGridColumnFilterType.None);           
            Add(FieldDefinitionEnum.ProjectCustomAttribute.ToType().ToGridHeaderString(),a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.ProjectCustomAttributeTypeName), 200, DhtmlxGridColumnFilterType.Html);
            Add("Description", a => a.ProjectCustomAttributeTypeDescription, 300);
            Add(FieldDefinitionEnum.ProjectCustomAttributeDataType.ToType().ToGridHeaderString(), a => a.ProjectCustomAttributeDataType.ProjectCustomAttributeDataTypeDisplayName, 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.MeasurementUnit.ToType().ToGridHeaderString(), a => a.GetMeasurementUnitDisplayName(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Required?", a => a.IsRequired.ToYesNo(), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.ProjectCustomAttributeTypeEditableBy.ToType().ToGridHeaderString(), x => x.GetEditableRoles(), 150, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectCustomAttributeTypeViewableBy.ToType().ToGridHeaderString(), a => a.GetViewableRoles(), 200, DhtmlxGridColumnFilterType.Html);
            Add("Viewable on fact sheet?", a => a.IsViewableOnFactSheet.ToYesNo(), 140, DhtmlxGridColumnFilterType.Html);
        }
    }
}
