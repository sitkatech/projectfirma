using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Areas.EIP.Views.Project;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.Tag
{
    public class SummaryViewData : EIPViewData
    {
        public readonly Models.Tag Tag;
        public readonly string EditTagUrl;
        public readonly string ManageTagsUrl;
        public readonly bool UserHasTagManagePermissions;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string FiveYearListProjectGridName;
        public readonly string FiveYearListProjectGridDataUrl;

        public SummaryViewData(Person currentPerson, Models.Tag tag) : base(currentPerson)
        {
            Tag = tag;            
            PageTitle = tag.TagName;
            EntityName = "Tag";
            
            EditTagUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.Edit(tag));
            ManageTagsUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.Index());
            UserHasTagManagePermissions = new TagManageFeature().HasPermissionByPerson(currentPerson);

            FiveYearListProjectGridName = "tagProjectListGrid";

            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                ObjectNameSingular = "Project with this Tag",
                ObjectNamePlural = "Projects with this Tag",
                SaveFiltersInCookie = true
            };
            
            FiveYearListProjectGridDataUrl = SitkaRoute<TagController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(tag));
        }
    }
}