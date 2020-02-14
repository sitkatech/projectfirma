namespace ProjectFirmaModels.Models
{
    public partial class AttachmentTypeTaxonomyTrunk : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        { 
            return $"AttachmentTypeTaxonomyTrunkID: {AttachmentTypeTaxonomyTrunkID}";
        }

    }
}