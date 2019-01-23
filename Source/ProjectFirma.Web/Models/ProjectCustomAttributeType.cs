using System.Collections.Generic;
using LtInfo.Common.Views;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectCustomAttributeType : IAuditableEntity {
        public string GetAuditDescriptionString() =>
            $"{FieldDefinition.ProjectCustomAttribute.GetFieldDefinitionLabel()}: {ProjectCustomAttributeTypeName}";

        public string GetMeasurementUnitDisplayName()
        {
            return MeasurementUnitType == null ? ViewUtilities.NoneString : MeasurementUnitType.LegendDisplayName;
        }

        public List<string> GetOptionsSchemaAsListOfString()
        {
            return ProjectCustomAttributeTypeOptionsSchema != null ? JsonConvert.DeserializeObject<List<string>>(ProjectCustomAttributeTypeOptionsSchema) : new List<string>();
        }
    }
}
