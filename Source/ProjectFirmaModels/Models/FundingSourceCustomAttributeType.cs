using System.Collections.Generic;
using LtInfo.Common.Views;
using Newtonsoft.Json;

namespace ProjectFirmaModels.Models
{
    public partial class FundingSourceCustomAttributeType : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"Custom Attribute Type: {FundingSourceCustomAttributeTypeName}";

        public string GetMeasurementUnitDisplayName()
        {
            return MeasurementUnitType == null ? ViewUtilities.NoneString : MeasurementUnitType.LegendDisplayName;
        }

        public List<string> GetOptionsSchemaAsListOfString()
        {
            return FundingSourceCustomAttributeTypeOptionsSchema != null ? JsonConvert.DeserializeObject<List<string>>(FundingSourceCustomAttributeTypeOptionsSchema) : new List<string>();
        }
    }
}