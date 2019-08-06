using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class AttachmentRelationshipType : IAuditableEntity
    {
        public bool CanDelete()
        {
            return !ProjectAttachments.Any();
        }

        public string GetAuditDescriptionString() => AttachmentRelationshipTypeName;

    }
}