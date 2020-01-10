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

        public string MaxFileSizeForDisplay => $"{MaxFileSize / 1024 / 1000}MB";

    }
}