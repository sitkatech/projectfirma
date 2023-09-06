using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
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
            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();

            Add("delete", x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, AgGridColumnFilterType.None);
            Add("edit", x => AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(x.GetEditUrl(), ModalDialogFormHelper.DefaultDialogWidth, $"Edit {FieldDefinitionEnum.ProjectCustomAttributeGroup.ToType().GetFieldDefinitionLabel()}")), 30, AgGridColumnFilterType.None);
            Add("Name", a => a.ProjectCustomAttributeGroupName, 300, AgGridColumnFilterType.Text);

            if (tenantAttribute.EnableProjectCategories)
            {
                Add(FieldDefinitionEnum.ProjectCategory.ToType().GetFieldDefinitionLabel(), a => a.GetProjectCategoryDisplayNamesAsCommaDelimitedList(), 150, AgGridColumnFilterType.SelectFilterStrict);
            }

            Add("Sort Order", a => a.SortOrder, 60, AgGridColumnFormatType.Integer);
        }
    }
}
