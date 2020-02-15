using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectAttachment
{
    public class EditProjectAttachmentsViewModel: IValidatableObject
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

        public EditProjectAttachmentsViewModel()
        {
        }

        public EditProjectAttachmentsViewModel(ProjectFirmaModels.Models.ProjectAttachment projectAttachment)
        {
            ParentID = projectAttachment.ProjectID;
            AttachmentID = projectAttachment.ProjectAttachmentID;
            DisplayName = projectAttachment.DisplayName;
            Description = projectAttachment.Description;
        }

        public EditProjectAttachmentsViewModel(ProjectFirmaModels.Models.ProjectAttachmentUpdate projectAttachmentUpdate)
        {
            DisplayName = projectAttachmentUpdate.DisplayName;
            Description = projectAttachmentUpdate.Description;
        }

        public void UpdateModel(ProjectFirmaModels.Models.ProjectAttachment projectAttachment)
        {
            projectAttachment.DisplayName = DisplayName;
            projectAttachment.Description = Description;
        }

        public void UpdateModel(ProjectFirmaModels.Models.ProjectAttachmentUpdate projectAttachmentUpdate)
        {
            projectAttachmentUpdate.DisplayName = DisplayName;
            projectAttachmentUpdate.Description = Description;
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            ProjectAttachmentPrimaryKey projectAttachmentPrimaryKey = AttachmentID;
            var projectAttachment = projectAttachmentPrimaryKey.EntityObject;

            // We want to validate that the DisplayName is unique per project & attachment type. A project can have duplicate display names as long as they are different attachment types
            if (HttpRequestStorage.DatabaseEntities.ProjectAttachments.Where(x => x.ProjectID == ParentID && x.ProjectAttachmentID != AttachmentID && x.AttachmentTypeID == projectAttachment.AttachmentTypeID)
                .Any(x => x.DisplayName.ToLower() == DisplayName.ToLower()))
            {
                AttachmentTypePrimaryKey attachmentTypePrimaryKey = projectAttachment.AttachmentTypeID;
                var attachmentType = attachmentTypePrimaryKey.EntityObject;

                validationResults.Add(new SitkaValidationResult<NewProjectAttachmentViewModel, string>($"There is already an attachment with the display name \"{DisplayName}\" under the {attachmentType.AttachmentTypeName} attachment type for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}.", m => m.DisplayName));
            }

            return validationResults;
        }
    }
}
