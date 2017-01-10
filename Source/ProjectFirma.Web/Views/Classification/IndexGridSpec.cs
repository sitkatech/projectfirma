using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Classification
{
    public class IndexGridSpec : GridSpec<Models.Classification>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {
            if (hasDeletePermissions)
            {
                Add(string.Empty,
                    x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, !x.HasDependentObjects()),
                    30);
            }

            Add(Models.FieldDefinition.Classification.ToGridHeaderString(MultiTenantHelpers.GetClassificationDisplayName()), a => a.GetDisplayNameAsUrl(), 250);
            Add(Models.FieldDefinition.ClassificationDescription.ToGridHeaderString("Description"), a => a.ClassificationDescription, 250);
            Add(Models.FieldDefinition.ClassificationDescription.ToGridHeaderString("Goal Statement"), a => a.GoalStatement, 250);
            Add("# of Projects", a => a.ProjectClassifications.Count, 90);
        }
    }
}