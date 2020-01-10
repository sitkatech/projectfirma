using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectFirmaModels.Models
{
    public static class AttachmentRelationshipTypeFileResourceMimeTypeModelExtensions
    {
        public static string GetFileResourceMimeTypeDisplayNamesAsCommaDelimitedList(this ICollection<AttachmentRelationshipTypeFileResourceMimeType> attachmentRelationshipTypeFileResourceMimeTypes)
        {
            List<string> displayNames = attachmentRelationshipTypeFileResourceMimeTypes.Select(x => x.FileResourceMimeType.FileResourceMimeTypeDisplayName).ToList();
            return string.Join(", ", displayNames);
        }
    }
}