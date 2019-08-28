namespace ProjectFirmaModels.Models
{
    public partial class AttachmentRelationshipTypeTaxonomyTrunk : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        { 
            return $"AttachmentRelationshipTypeTaxonomyTrunkID: {AttachmentRelationshipTypeTaxonomyTrunkID}";
        }

    }
}