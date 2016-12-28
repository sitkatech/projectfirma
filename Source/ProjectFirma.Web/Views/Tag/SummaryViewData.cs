using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Project;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Tag
{
    public class SummaryViewData : FirmaViewData
    {
        public readonly Models.Tag Tag;
        public readonly string EditTagUrl;
        public readonly string ManageTagsUrl;
        public readonly bool UserHasTagManagePermissions;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoGridName;
        public readonly string BasicProjectInfoGridDataUrl;

        public SummaryViewData(Person currentPerson, Models.Tag tag) : base(currentPerson)
        {
            Tag = tag;            
            PageTitle = tag.TagName;
            EntityName = "Tag";
            
            EditTagUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.Edit(tag));
            ManageTagsUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.Index());
            UserHasTagManagePermissions = new TagManageFeature().HasPermissionByPerson(currentPerson);

            BasicProjectInfoGridName = "tagProjectListGrid";

            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                ObjectNameSingular = "Project with this Tag",
                ObjectNamePlural = "Projects with this Tag",
                SaveFiltersInCookie = true
            };
            
            BasicProjectInfoGridDataUrl = SitkaRoute<TagController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(tag));
        }
    }
}