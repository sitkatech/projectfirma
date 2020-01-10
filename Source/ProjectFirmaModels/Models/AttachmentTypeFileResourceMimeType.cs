using System;
using System.Linq;
using LtInfo.Common;

namespace ProjectFirmaModels.Models
{
    public partial class AttachmentRelationshipTypeFileResourceMimeType : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"AttachmentRelationshipTypeFileResourceMimeTypeID: {AttachmentRelationshipTypeFileResourceMimeTypeID}";
        }

    }
}