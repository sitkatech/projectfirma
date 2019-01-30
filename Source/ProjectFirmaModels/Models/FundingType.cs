namespace ProjectFirmaModels.Models
{
    public partial class FundingType : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"{FundingTypeDisplayName} updated";
        }
    }
}