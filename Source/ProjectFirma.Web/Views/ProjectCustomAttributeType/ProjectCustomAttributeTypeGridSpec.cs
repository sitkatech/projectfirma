using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
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

            Add("delete", x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, AgGridColumnFilterType.None);
            Add("edit", x => AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(x.GetEditUrl(), ModalDialogFormHelper.DefaultDialogWidth, "Edit Attribute")), 30, AgGridColumnFilterType.None);           
            Add(FieldDefinitionEnum.ProjectCustomAttribute.ToType().ToGridHeaderString(),a => new HtmlLinkObject(a.ProjectCustomAttributeTypeName,a.GetDetailUrl()).ToJsonObjectForAgGrid(), 200, AgGridColumnFilterType.HtmlLinkJson);      
            Add("Description", a => a.ProjectCustomAttributeTypeDescription, 300);
            Add(FieldDefinitionEnum.ProjectCustomAttributeGroup.ToType().ToGridHeaderString(), a => a.ProjectCustomAttributeGroup?.ProjectCustomAttributeGroupName ?? string.Empty, 150, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.ProjectCustomAttributeDataType.ToType().ToGridHeaderString(), a => a.ProjectCustomAttributeDataType.ProjectCustomAttributeDataTypeDisplayName, 100, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.MeasurementUnit.ToType().ToGridHeaderString(), a => a.GetMeasurementUnitDisplayName(), 100, AgGridColumnFilterType.SelectFilterStrict);
            Add("Required?", a => a.IsRequired.ToYesNo(), 100, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.ProjectCustomAttributeTypeEditableBy.ToType().ToGridHeaderString(), x => x.GetEditableRoles(), 150, AgGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectCustomAttributeTypeViewableBy.ToType().ToGridHeaderString(), a => a.GetViewableRoles(), 200, AgGridColumnFilterType.Html);
            Add("Viewable on fact sheet?", a => a.IsViewableOnFactSheet.ToYesNo(), 140, AgGridColumnFilterType.Html);
        }
    }
}
