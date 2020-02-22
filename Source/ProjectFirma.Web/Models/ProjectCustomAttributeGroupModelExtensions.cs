using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectCustomAttributeGroupModelExtensions
    {
        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeGroupController>.BuildUrlFromExpression(c => c.DeleteProjectCustomAttributeGroup(UrlTemplate.Parameter1Int)));

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeGroupController>.BuildUrlFromExpression(c => c.Edit(UrlTemplate.Parameter1Int)));
        
        public static string GetDeleteUrl(this ProjectCustomAttributeGroup projectCustomAttributeGroup) => DeleteUrlTemplate.ParameterReplace(projectCustomAttributeGroup.ProjectCustomAttributeGroupID);
        public static string GetEditUrl(this ProjectCustomAttributeGroup projectCustomAttributeGroup) => EditUrlTemplate.ParameterReplace(projectCustomAttributeGroup.ProjectCustomAttributeGroupID);

        public static string GetProjectCategoryDisplayNamesAsCommaDelimitedList(this ProjectCustomAttributeGroup projectCustomAttributeGroup)
        {
            return string.Join(", ", projectCustomAttributeGroup.ProjectCustomAttributeGroupProjectCategories.Select(x => x.ProjectCategory.ProjectCategoryDisplayName).ToList());
        }

    }
}