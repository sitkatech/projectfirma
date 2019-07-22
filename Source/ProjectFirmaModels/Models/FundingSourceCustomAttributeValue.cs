namespace ProjectFirmaModels.Models
{
    public partial class FundingSourceCustomAttributeValue : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"Funding Source Custom Attribute Value (ID: {FundingSourceCustomAttributeID}, value = \"{AttributeValue}\")";
        }
    }
}