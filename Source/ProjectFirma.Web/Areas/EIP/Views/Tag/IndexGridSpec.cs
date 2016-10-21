using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.Tag
{
    public class IndexGridSpec : GridSpec<Models.Tag>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {            
            if (hasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.DeleteUrl, true), 30);
            }

            Add(Models.FieldDefinition.TagName.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.SummaryUrl, a.DisplayName), 200, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.TagDescription.ToGridHeaderString(), a => a.TagDescription, 600);
            Add("# of Projects", a => a.ProjectTags.Count, 65);
        }
    }
}