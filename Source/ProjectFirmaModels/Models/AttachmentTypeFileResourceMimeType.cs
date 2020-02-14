using System;
using System.Linq;
using LtInfo.Common;

namespace ProjectFirmaModels.Models
{
    public partial class AttachmentTypeFileResourceMimeType : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"AttachmentTypeFileResourceMimeTypeID: {AttachmentTypeFileResourceMimeTypeID}";
        }

    }
}