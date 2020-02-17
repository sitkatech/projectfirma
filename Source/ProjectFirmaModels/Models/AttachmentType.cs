using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class AttachmentType : IAuditableEntity
    {
        public bool CanDelete()
        {
            return !ProjectAttachments.Any();
        }

        public string GetAuditDescriptionString() => AttachmentTypeName;

        public string MaxFileSizeForDisplay => $"{MaxFileSize / 1024 / 1000}MB";

    }
}