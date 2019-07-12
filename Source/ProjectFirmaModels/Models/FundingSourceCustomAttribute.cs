using System.Collections.Generic;

namespace ProjectFirmaModels.Models
{
    public partial class FundingSourceCustomAttribute : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"Custom Attribute (type: {FundingSourceCustomAttributeTypeID}, Funding Source: {FundingSourceID})";
        }

        public void SetCustomAttributeValues(IEnumerable<FundingSourceCustomAttributeValue> value) => FundingSourceCustomAttributeValues = (ICollection<FundingSourceCustomAttributeValue>)value;

        public IEnumerable<FundingSourceCustomAttributeValue> GetCustomAttributeValues() => FundingSourceCustomAttributeValues;
    }
}