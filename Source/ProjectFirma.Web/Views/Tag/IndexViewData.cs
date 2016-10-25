using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Views.Tag
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = "Tags";

            var hasTagManagePermissions = new TagManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(hasTagManagePermissions) {ObjectNameSingular = "Tag", ObjectNamePlural = "Tags", SaveFiltersInCookie = true};

            if (hasTagManagePermissions)
            {
                var contentUrl = SitkaRoute<TagController>.BuildUrlFromExpression(t => t.New());
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(contentUrl, "Create a new Tag");
            }

            GridName = "TagsGrid";
            GridDataUrl = SitkaRoute<TagController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}