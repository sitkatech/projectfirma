using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectFirmaModels.Models
{
    public static class AttachmentTypeFileResourceMimeTypeModelExtensions
    {
        public static string GetFileResourceMimeTypeDisplayNamesAsCommaDelimitedList(this ICollection<AttachmentTypeFileResourceMimeType> attachmentTypeFileResourceMimeTypes)
        {
            List<string> displayNames = attachmentTypeFileResourceMimeTypes.Select(x => x.FileResourceMimeType.FileResourceMimeTypeDisplayName).ToList();
            return string.Join(", ", displayNames);
        }
    }
}