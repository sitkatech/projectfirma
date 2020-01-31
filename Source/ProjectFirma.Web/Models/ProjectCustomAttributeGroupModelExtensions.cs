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

        public static string GetProjectTypeDisplayNamesAsCommaDelimitedList(this ProjectCustomAttributeGroup projectCustomAttributeGroup)
        {
            return string.Join(", ", projectCustomAttributeGroup.ProjectCustomAttributeGroupProjectTypes.Select(x => x.ProjectType.ProjectTypeDisplayName).ToList());
        }

    }
}