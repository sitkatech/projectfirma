using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCustomAttributeGroup
{
    public class ProjectCustomAttributeGroupGridSpec : GridSpec<ProjectFirmaModels.Models.ProjectCustomAttributeGroup>
    {
        public ProjectCustomAttributeGroupGridSpec()
        {
            var tenantAttribute = MultiTenantHelpers.GetTenantAttribute();

            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, DhtmlxGridColumnFilterType.None);
            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(x.GetEditUrl(), ModalDialogFormHelper.DefaultDialogWidth, $"Edit {FieldDefinitionEnum.ProjectCustomAttributeGroup.ToType().GetFieldDefinitionLabel()}")), 30, DhtmlxGridColumnFilterType.None);
            Add("Name", a => a.ProjectCustomAttributeGroupName, 300, DhtmlxGridColumnFilterType.Text);

            if (tenantAttribute.EnableProjectCategories)
            {
                Add(FieldDefinitionEnum.ProjectCategory.ToType().GetFieldDefinitionLabel(), a => a.GetProjectCategoryDisplayNamesAsCommaDelimitedList(), 150, DhtmlxGridColumnFilterType.SelectFilterStrict);
            }

            Add("Sort Order", a => a.SortOrder, 60, DhtmlxGridColumnFormatType.Integer);
        }
    }
}
