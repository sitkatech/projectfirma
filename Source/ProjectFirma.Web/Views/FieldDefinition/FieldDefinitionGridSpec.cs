using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.FieldDefinition
{
    public class FieldDefinitionGridSpec : GridSpec<Models.FieldDefinition>
    {
        public FieldDefinitionGridSpec(bool hasManagePermissions)
        {            
            if (hasManagePermissions)
            {
                Add(string.Empty,
                    a =>
                        DhtmlxGridHtmlHelpers.MakeLtInfoEditIconAsModalDialogLinkBootstrap(
                            new ModalDialogForm(
                                SitkaRoute<FieldDefinitionController>.BuildUrlFromExpression(t => t.Edit(a)),
                                string.Format("Edit Field Definition '{0}'", a.FieldDefinitionDisplayName))),
                    30);
            }
            Add("Field Name", a => a.FieldDefinitionDisplayName, 250);
            Add("Defined?", a => a.HasDefinition.ToYesNo(), 75, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("FieldDefinitionID", a => a.FieldDefinitionID, 0);
        }
    }
}