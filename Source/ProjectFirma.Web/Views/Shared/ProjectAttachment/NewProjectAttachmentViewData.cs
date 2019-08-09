using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectAttachment
{
    public class NewProjectAttachmentViewData
    {
        public List<SelectListItem> AttachmentRelationshipTypes { get; }

        public NewProjectAttachmentViewData(IEnumerable<ProjectFirmaModels.Models.AttachmentRelationshipType> attachmentRelationshipTypes)
        {
            AttachmentRelationshipTypes = attachmentRelationshipTypes.ToSelectList(x => x.AttachmentRelationshipTypeID.ToString(CultureInfo.InvariantCulture), y => y.AttachmentRelationshipTypeName).ToList();
        }
    }
}
