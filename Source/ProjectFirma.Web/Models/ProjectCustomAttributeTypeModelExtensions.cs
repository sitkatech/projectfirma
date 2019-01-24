using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirmaModels.Models
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

        public static string GetDeleteUrl(ProjectCustomAttributeType projectCustomAttributeType) => DeleteUrlTemplate.ParameterReplace(projectCustomAttributeType.ProjectCustomAttributeTypeID);
        public static string GetEditUrl(ProjectCustomAttributeType projectCustomAttributeType) => EditUrlTemplate.ParameterReplace(projectCustomAttributeType.ProjectCustomAttributeTypeID);
        public static string GetDetailUrl(ProjectCustomAttributeType projectCustomAttributeType) => DetailUrlTemplate.ParameterReplace(projectCustomAttributeType.ProjectCustomAttributeTypeID);
        public static string GetDescriptionUrl(ProjectCustomAttributeType projectCustomAttributeType) => DescriptionUrlTemplate.ParameterReplace(projectCustomAttributeType.ProjectCustomAttributeTypeID);
    }
}