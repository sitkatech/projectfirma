using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ProjectAttachment
{
    public class NewProjectAgnosticAttachmentViewModel : IValidatableObject
    {
        [Required]
        [DisplayName("Display Name")]
        [StringLength(ProjectFirmaModels.Models.ProjectAttachment.FieldLengths.DisplayName, ErrorMessage = "200 character maximum")]
        public string DisplayName { get; set; }
        
        [DisplayName("Description")]
        [StringLength(ProjectFirmaModels.Models.ProjectAttachment.FieldLengths.Description, ErrorMessage = "1000 character maximum.")]
        public string Description { get; set; }

        // can be the ID of a Project or a ProjectUpdateBatch depending on whether this ViewModel or its child type is invoked.
        public int? ParentID { get; set; }

        // can be the ID of a ProjectAttachment or a ProjectAttachmentUpdate depending on whether this ViewModel or its child type is invoked.
        public int? AttachmentID { get; set; }

        public NewProjectAgnosticAttachmentViewModel()
        {

        }
        

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (HttpRequestStorage.DatabaseEntities.ProjectAttachments.Where(x => x.ProjectID == ParentID && x.ProjectAttachmentID != AttachmentID)
                .Any(x => x.DisplayName.ToLower() == DisplayName.ToLower()))
            {
                validationResults.Add(new SitkaValidationResult<NewProjectAgnosticAttachmentViewModel, string>("The Display Name must be unique for each Attachment attached to a Project", m => m.DisplayName));
            }

            return validationResults;
        }
    }
}
