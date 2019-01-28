using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectCustomAttributeTypeModelExtensions
    {
        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.DeleteProjectCustomAttributeType(UrlTemplate.Parameter1Int)));

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Edit(UrlTemplate.Parameter1Int)));

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Detail(UrlTemplate.Parameter1Int)));

        public static readonly UrlTemplate<int> DescriptionUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Description(UrlTemplate.Parameter1Int)));

        public static string GetDeleteUrl(this ProjectCustomAttributeType projectCustomAttributeType) => DeleteUrlTemplate.ParameterReplace(projectCustomAttributeType.ProjectCustomAttributeTypeID);
        public static string GetEditUrl(this ProjectCustomAttributeType projectCustomAttributeType) => EditUrlTemplate.ParameterReplace(projectCustomAttributeType.ProjectCustomAttributeTypeID);
        public static string GetDetailUrl(this ProjectCustomAttributeType projectCustomAttributeType) => DetailUrlTemplate.ParameterReplace(projectCustomAttributeType.ProjectCustomAttributeTypeID);
        public static string GetDescriptionUrl(this ProjectCustomAttributeType projectCustomAttributeType) => DescriptionUrlTemplate.ParameterReplace(projectCustomAttributeType.ProjectCustomAttributeTypeID);
    }
}