using System.Collections.Generic;
using LtInfo.Common.Views;
using Newtonsoft.Json;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectCustomAttributeType : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"Custom Attribute Type: {ProjectCustomAttributeTypeName}";

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
