using System.Linq;
using System.Web;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirmaModels.Models
{
    public partial class AttachmentType : IAuditableEntity, IFieldDefinitionData
    {
        public bool CanDelete()
        {
            return !ProjectAttachments.Any();
        }

        public string GetAuditDescriptionString() => AttachmentTypeName;

        public string MaxFileSizeForDisplay => $"{MaxFileSize / 1024 / 1000}MB";

        public int FieldDefinitionDataID { get; }

        public string FieldDefinitionLabel => AttachmentTypeName;

        public HtmlString FieldDefinitionDataValueHtmlString => new HtmlString($"{AttachmentTypeDescription} <p class=\"smallExplanationText\"><strong>Maximum File Uploads:</strong> <span>{NumberOfAllowedAttachments} </span></p>");
    }
}