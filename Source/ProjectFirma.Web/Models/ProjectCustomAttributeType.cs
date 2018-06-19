using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Views;
using Newtonsoft.Json;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectCustomAttributeType : IAuditableEntity {
        public string AuditDescriptionString => $"Project Custom Attribute Type: {ProjectCustomAttributeTypeName}";

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.DeleteProjectCustomAttributeType(UrlTemplate.Parameter1Int)));
        public string GetDeleteUrl() => DeleteUrlTemplate.ParameterReplace(ProjectCustomAttributeTypeID);

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Edit(UrlTemplate.Parameter1Int)));
        public string GetEditUrl() => EditUrlTemplate.ParameterReplace(ProjectCustomAttributeTypeID);

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Detail(UrlTemplate.Parameter1Int)));
        public string GetDetailUrl() => DetailUrlTemplate.ParameterReplace(ProjectCustomAttributeTypeID);

        public HtmlString GetDisplayNameAsUrl() => UrlTemplate.MakeHrefString(GetDeleteUrl(), ProjectCustomAttributeTypeName);

        public string GetMeasurementUnitDisplayName()
        {
            return MeasurementUnitType == null ? ViewUtilities.NoneString : MeasurementUnitType.LegendDisplayName;
        }

        public List<string> GetOptionsSchemaAsListOfString()
        {
            return ProjectCustomAttributeTypeOptionsSchema != null ? JsonConvert.DeserializeObject<List<string>>(ProjectCustomAttributeTypeOptionsSchema) : new List<string>();
        }

        public string DisplayNameWithUnits()
        {
            return
                $"{ProjectCustomAttributeTypeName} {(MeasurementUnitType != null ? $"({MeasurementUnitType.MeasurementUnitTypeDisplayName})" : string.Empty)}";
        }

        public bool IsCompleteForProject(Project project)
        {
            return project.ProjectCustomAttributes.SingleOrDefault(x => x.ProjectCustomAttributeTypeID == ProjectCustomAttributeTypeID)
                       ?.ProjectCustomAttributeValues
                       ?.Any(x => !string.IsNullOrWhiteSpace(x.AttributeValue))
                   ?? false;
        }
    }
}
